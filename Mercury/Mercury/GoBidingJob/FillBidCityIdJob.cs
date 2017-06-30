using Maticsoft.DBUtility;
using Mercury.BLL;
using log4net;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading;

namespace GoBidingJob
{
    public sealed class FillBidCityIdJob : IJob
    {
        private readonly ILog _logger = LogManager.GetLogger(typeof(FillBidCityIdJob));
        private Mercury.BLL.Sys_Users userService = new Sys_Users();
        private Mercury.BLL.Bids bidService = new Bids();
        private Mercury.BLL.Sys_UserTrackers trackerService = new Sys_UserTrackers();
        private Mercury.BLL.Provinces provinceService = new Provinces();
        private Mercury.BLL.Citys cityService = new Citys();
        private DataSet districts = new Mercury.BLL.Districts().GetAllList();
        private DataSet citys = new Mercury.BLL.Citys().GetAllList();
        private DataSet provinces = new Mercury.BLL.Provinces().GetAllList();

        public void Execute(IJobExecutionContext context)
        {
            _logger.InfoFormat("FillBidCityIdJob测试");
            StringBuilder result = new StringBuilder();
            result.Capacity = 8 * 10 * 1024;

            while (true)
            {
                try
                {
                    StringBuilder strSql = new StringBuilder();
                    strSql.Append("select top 500 BidId,BidTitle,ProvinceId From Bids where CityId = 0 order by 1 desc");


                    var ds = DbHelperSQL.Query(strSql.ToString());
                    int referCount = 0;

                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        int bidId = int.Parse(ds.Tables[0].Rows[i][0].ToString());
                        string bidTitle = ds.Tables[0].Rows[i][1].ToString();
                        int bidprovinceId = int.Parse(ds.Tables[0].Rows[i][2].ToString());

                        int districtId = -1;
                        int cityId = -1;
                        int provinceId = -1;
                        districtId = findInDistricts(bidTitle, out cityId, out provinceId);
                        if (districtId > 0)
                        {
                            if (bidprovinceId == 0 || bidprovinceId == provinceId)
                            {
                                //找到的ditrictid 与抓取时的provinceid 相匹配，更新数据
                                result.AppendLine(string.Format(
                                    " update Bids set CityId = {0}, ProvinceId = {1} where bidid = {2}", cityId, provinceId,
                                    bidId));
                                referCount++;
                            }
                            else
                            {
                                result.AppendLine(string.Format(" update Bids set CityId = {0} where bidid = {1}", -1, bidId));
                                referCount++;
                            }
                        }
                        else
                        {
                            //district没有匹配到，继续匹配city
                            cityId = findInCitys(bidTitle, out provinceId);
                            if (cityId > 0)
                            {
                                //找到的ditrictid 与抓取时的provinceid 相匹配，更新数据
                                result.AppendLine(string.Format(
                                    " update Bids set CityId = {0}, ProvinceId = {1} where bidid = {2}", cityId, provinceId,
                                    bidId));
                                referCount++;
                            }
                            else
                            {
                                //city未匹配到，继续匹配province
                                provinceId = findInProvinces(bidTitle);
                                if (bidprovinceId == 0 && provinceId > 0)
                                {
                                    result.AppendLine(string.Format(" update Bids set CityId = {0}, ProvinceId = {1} where bidid = {2}", -1, provinceId, bidId));
                                    referCount++;
                                }
                                else
                                {
                                    //什么都没匹配到
                                    result.AppendLine(string.Format(" update Bids set CityId = {0} where bidid = {1}", -1, bidId));
                                    referCount++;
                                }
                            }
                        }
                    }

                    //Console.WriteLine(referCount);

                    //using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\FillBidCityIdJob.txt", false))
                    //{
                    //    file.Write(result.ToString());
                    //}

                    if(!string.IsNullOrEmpty(result.ToString()))
                        DbHelperSQL.ExecuteSql(result.ToString());

                    result.Clear();
                    Thread.Sleep(5000);
                }
                catch (Exception err)
                {
                    Logger.Warn(err.Message, err.StackTrace, "GoBidingJob");
                }
            }
        }

        public int findInProvinces(string target)
        {
            for (int i = 0; i < provinces.Tables[0].Rows.Count; i++)
            {
                int provinceID = int.Parse(provinces.Tables[0].Rows[i]["ProvinceID"].ToString());
                string provinceName = provinces.Tables[0].Rows[i]["ProvinceName"].ToString();

                if (provinceName.Length > 2)
                    provinceName = provinceName.Replace("自治区", "").Replace("省", "").Replace("市", "")
                        .Replace("维吾尔", "").Replace("回族", "").Replace("壮族", "").Replace("特别行政区", "");

                if (target.Contains(provinceName))
                {
                    return provinceID;
                }
            }

            return -1;
        }

        /// <summary>
        /// 没有找到都为-1
        /// </summary>
        /// <param name="target"></param>
        /// <param name="cityId">找到districtid的cityid</param>
        /// <returns>找到的districtid</returns>
        public int findInDistricts(string target, out int cityId, out int provinceId)
        {
            for (int i = 0; i < districts.Tables[0].Rows.Count; i++)
            {
                int districtId = int.Parse(districts.Tables[0].Rows[i]["DistrictID"].ToString());
                string district = districts.Tables[0].Rows[i]["DistrictName"].ToString();

                if (district.Length > 2)
                    district = district.Replace("自治市", "").Replace("自治区", "").Replace("自治县", "");
                if (district.Length > 2)
                {
                    if (district.Substring(district.Length - 1, 1).Contains("市") ||
                        district.Substring(district.Length - 1, 1).Contains("区") ||
                        district.Substring(district.Length - 1, 1).Contains("县"))
                    {
                        district = district.Substring(0, district.Length - 1);
                    }
                }

                if (target.Contains(district))
                {
                    cityId = int.Parse(districts.Tables[0].Rows[i]["CityID"].ToString());
                    provinceId = GetProvinceIdByCityId(cityId);
                    return districtId;
                }
            }

            cityId = -1;
            provinceId = -1;
            return -1;
        }

        public int findInCitys(string target, out int provinceId)
        {
            for (int i = 0; i < citys.Tables[0].Rows.Count; i++)
            {
                int cityId = int.Parse(citys.Tables[0].Rows[i]["CityID"].ToString());
                string cityname = citys.Tables[0].Rows[i]["CityName"].ToString();
                int provinceID = int.Parse(citys.Tables[0].Rows[i]["ProvinceID"].ToString());

                if (cityname.Length > 2)
                    cityname = cityname.Replace("自治市", "").Replace("自治区", "").Replace("自治县", "");
                if (cityname.Length > 2)
                {
                    if (cityname.Substring(cityname.Length - 1, 1).Contains("市") ||
                       cityname.Substring(cityname.Length - 1, 1).Contains("区") ||
                       cityname.Substring(cityname.Length - 1, 1).Contains("县"))
                    {
                        cityname = cityname.Substring(0, cityname.Length - 1);
                    }
                }

                if (target.Contains(cityname))
                {
                    provinceId = provinceID;
                    return cityId;
                }
            }

            provinceId = -1;
            return -1;
        }

        public int GetProvinceIdByCityId(int cityId)
        {
            var model = cityService.GetModelList(" CityID = " + cityId);
            if (model != null)
                return (int)model.FirstOrDefault().ProvinceID.Value;

            return -1;
        }
    }
}
