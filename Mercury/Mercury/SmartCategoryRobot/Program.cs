using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Mercury.Model;
using Mercury.BLL;
using System.Threading;

namespace SmartCategoryRobot
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var bizBid = new Mercury.BLL.Bids();
                List<Mercury.Model.SmartCategorys> smarts = new Mercury.BLL.SmartCategorys().GetModelList(" ParentCategoryId <> 0");
                int pageCount = 100;
                int pageNumber = 1;

                while (true)
                {
                    
                    //var bids = new Mercury.BLL.Bids().GetListByPage(" (BidCategoryId is null or bidcategoryid =0)", "BidId desc", 1 + (pageNumber - 1) * pageCount, pageNumber * pageCount);
                    var bids = new Mercury.BLL.Bids().GetListByPage(" BidAgent = ''", "BidId desc", 1 + (pageNumber - 1) * pageCount, pageNumber * pageCount);
                    pageNumber++;
                    if (bids != null && bids.Tables[0].Rows.Count > 0)
                    {
                        for (int i = 0; i < bids.Tables[0].Rows.Count; i++)
                        {
                            string title = bids.Tables[0].Rows[i]["BidTitle"].ToString();
                            int bidId = int.Parse(bids.Tables[0].Rows[i]["BidId"].ToString());

                            Console.WriteLine(title);

                            bool ismatch = false;
                            //更新行业分类
                            //foreach (Mercury.Model.SmartCategorys smart in smarts)
                            //{
                            //    if (!ismatch)
                            //    {
                            //        List<string> keywords = smart.Keywords.Split(' ').ToList();
                            //        foreach (var keyword in keywords)
                            //        {
                            //            if (!string.IsNullOrEmpty(keyword) && title.Contains(keyword))
                            //            {
                            //                var model = bizBid.GetModel(bidId);
                            //                model.BidCategoryId = smart.ParentCategoryId;
                            //                model.SubBidCategoryId = smart.BidCategoryId;
                            //                bizBid.Update(model);
                            //                ismatch = true;
                            //                break;
                            //                //model.BidCategoryName = smart.BidCategoryId;
                            //            }
                            //        }
                            //    }
                            //    else {
                            //        break;
                            //    }
                            //}

                            //更新招标编号
                            //if (bidId == 17724)
                            //{
                            string BidContent = bids.Tables[0].Rows[i]["BidContent"].ToString();


                            string BidNumber = FindSpecialSegmentByContent("采购编号：", BidContent);
                            if (BidNumber.Trim() == "")
                            {
                                BidNumber = FindSpecialSegmentByContent("项目编号：", BidContent);
                            }
                            if (BidNumber.Trim() == "")
                            {
                                BidNumber = FindSpecialSegmentByContent("招标编号", BidContent);
                            }
                            if (BidNumber.Trim() == "")
                            {
                                BidNumber = FindSpecialSegmentByContent("项目编号", BidContent);
                                //BidNumber = GetElement("采购编号(?<v>.*?)<tr>", BidContent);
                            }
                            if (BidNumber.Trim() == "")
                            {
                                BidNumber = FindSpecialSegmentByContent("编号：", BidContent);
                                if (BidNumber.Trim() == "")
                                    BidNumber = FindSpecialSegmentByContent("编号:", BidContent);

                            }
                            if (BidNumber != "" && BidNumber.Length < 4) //长交采</FONT>2016XJ004号</SPAN>
                            {
                                BidNumber += FindSpecialSegmentByContent(BidNumber, BidContent);
                            }

                            if (BidNumber != "" && BidNumber.Substring(BidNumber.Length - 1, 1) == "-") //YJCG（竞）2016-</span><span style="font-size: 12pt">202</span>
                            {
                                BidNumber += FindSpecialSegmentByContent(BidNumber, BidContent);
                            }

                            BidNumber = BidNumber.Replace("：", "");
                            BidNumber = ReplaceHtmlTag(BidNumber);

                            var bidModel = bizBid.GetModel(bidId);

                            if (BidNumber.Length < 25)
                            {
                                bidModel.BidNumber = BidNumber;
                                if (BidNumber == "")
                                    bidModel.BidNumber = "见正文";
                            }
                            //}

                            //更新截止时间
                            string BidExpireTime = FindSpecialSegmentByContent("截止时间：", BidContent);
                            if (BidExpireTime.Trim() == "")
                            {
                                BidExpireTime = FindSpecialSegmentByContent("截止日期：", BidContent);
                            }
                            if (BidExpireTime.Trim() == "")
                            {
                                BidExpireTime = FindSpecialSegmentByContent("截止时间", BidContent);
                            }
                            if (!string.IsNullOrEmpty(BidExpireTime))
                            {
                                DateTime ex = DateTime.MinValue;
                                DateTime.TryParse(BidExpireTime, out ex);
                                if (ex != DateTime.MinValue)
                                    bidModel.BidExpireTime = ex;
                            }

                            //开标时间
                            string BidOpenTime = FindSpecialSegmentByContent("开标时间：", BidContent);
                            if (BidOpenTime.Trim() == "")
                            {
                                BidOpenTime = FindSpecialSegmentByContent("开标日期：", BidContent);
                            }
                            if (BidOpenTime.Trim() == "")
                            {
                                BidOpenTime = FindSpecialSegmentByContent("开标时间", BidContent);
                            }
                            if (!string.IsNullOrEmpty(BidOpenTime))
                            {
                                DateTime ex = DateTime.MinValue;
                                DateTime.TryParse(BidOpenTime, out ex);
                                if (ex != DateTime.MinValue)
                                    bidModel.BidOpenTime = ex;
                            }

                            //招标代理机构
                            string AgentCompany = FindSpecialSegmentByContent("招标代理机构：", BidContent);
                            if (AgentCompany.Trim() == "")
                            {
                                AgentCompany = FindSpecialSegmentByContent("代理机构名称：", BidContent);
                            }
                            if (AgentCompany.Trim() == "")
                            {
                                AgentCompany = FindSpecialSegmentByContent("采购代理机构全称：", BidContent);
                            }
                            if (!string.IsNullOrEmpty(AgentCompany))
                            {
                                bidModel.BidAgent = AgentCompany;

                                //将catchcompany中的企业修改为招标代理企业
                                var agentcatchcompanys = new Mercury.BLL.CatchCompany().GetModelList(" vendorname = '" + AgentCompany + "'");
                                if (agentcatchcompanys == null || agentcatchcompanys.Count == 0)
                                {
                                    var agentcatchcompany = new Mercury.Model.CatchCompany();
                                    agentcatchcompany.VendorName = AgentCompany;
                                    agentcatchcompany.OnCreated = DateTime.Now;
                                    agentcatchcompany.IsBidAgent = 1;

                                    new Mercury.BLL.CatchCompany().Add(agentcatchcompany);
                                }
                                else
                                {
                                    var agentcatchcompany = agentcatchcompanys.FirstOrDefault();
                                    agentcatchcompany.IsBidAgent = 1;
                                    new Mercury.BLL.CatchCompany().Update(agentcatchcompany);
                                }
                            }
                            else {
                                bidModel.BidAgent = "-";
                            }

                            //开标时间
                            string budget = FindSpecialSegmentByContent("预算：", BidContent);
                            if (budget.Trim() == "")
                            {
                                BidOpenTime = FindSpecialSegmentByContent("总金额：", BidContent);
                            }
                            if (!string.IsNullOrEmpty(budget))
                            {
                                //bidModel.TotalAmount = decimal.Parse(budget);
                            }

                            bizBid.Update(bidModel);
                        }
                    }
                    else
                    {
                        pageNumber = 1;
                    }

                    Thread.Sleep(100);
                }
            }
            catch (Exception err)
            {
                Logger.Warn(err.Message, err.StackTrace, "GoBidingJob");
            }

        }

        public static string FindSpecialSegmentByContent(string key, string content)
        {
            int startindex = content.IndexOf(key);

            if (startindex <= 0)
                return "";

            int tagCount = 0;
            string result = "";
            int resultLength = 0;
            int resultStartIndex = 0;

            for (int i = startindex + key.Length; i < 100000; i++)
            {
                if (content.Substring(i, 1) == ":" || content.Substring(i, 1) == "：")
                    continue;

                if (content.Substring(i).Length < 2)
                    break;

                if (content.Substring(i, 2) == "</" && tagCount == 0)
                {
                    if (resultLength > 0)
                        break;

                    tagCount++;
                    i += 1;
                    continue;
                }

                if (content.Substring(i, 2).ToLower() == "<a" ||
                    content.Substring(i, 2).ToLower() == "<b" ||
                    content.Substring(i, 2).ToLower() == "<h" ||
                    content.Substring(i, 2).ToLower() == "<t" ||
                    content.Substring(i, 2).ToLower() == "<p" ||
                    content.Substring(i, 2).ToLower() == "<f" ||
                    content.Substring(i, 2).ToLower() == "<o" ||
                    content.Substring(i, 2).ToLower() == "<u" ||
                    content.Substring(i, 2).ToLower() == "<s"
                    )
                {
                    if (resultLength > 0) //已经匹配到后
                    {
                        break;
                    }

                    tagCount++;
                    i += 1;
                    continue;
                }

                if (content.Substring(i, 1) == ">")   //标签结束符
                {
                    tagCount--;
                }
                else
                {
                    if (tagCount <= 0)   //匹配到key
                    {
                        if (resultStartIndex == 0)
                            resultStartIndex = i;

                        resultLength++;
                        continue;
                    }
                    else
                    {
                        continue;  //匹配tag内容   
                    }
                }
            }

            if (resultLength > 0)
            {
                result = content.Substring(resultStartIndex, resultLength);
            }

            string str2 = result.Replace("）", "");
            int count = result.Length - str2.Length;
            if (result.Contains("（") && count >= 2)
                result = result.Substring(0, result.LastIndexOf("）"));
            str2 = result.Replace(")", "");
            count = result.Length - str2.Length;
            if (result.Contains("(") && count >= 2)
                result = result.Substring(0, result.LastIndexOf(")"));

            if (!result.Contains("(") && result.Contains(")"))
                result = result.Substring(0, result.IndexOf(")"));
            if (!result.Contains("（") && result.Contains("）"))
                result = result.Substring(0, result.IndexOf("）"));

            result = result.Replace("&nbsp;", "").Trim();
            result = result.IndexOf("，") > 0 ? result.Substring(0, result.IndexOf("，")).Trim() : result;
            return result;
        }

        public static string ReplaceHtmlTag(string html, int length = 0)
        {
            string strText = System.Text.RegularExpressions.Regex.Replace(html, "<[^>]+>", "");
            strText = System.Text.RegularExpressions.Regex.Replace(strText, "&[^;]+;", "");

            if (length > 0 && strText.Length > length)
                return strText.Substring(0, length);

            return strText;
        }

        public static string GetElement(string regexString, string html)
        {
            if (string.IsNullOrEmpty(regexString))
                return html;

            var regexitems = regexString.Split(',');
            Regex regex = null;
            MatchCollection matchs = null;

            foreach (var regexitem in regexitems)
            {
                regex = new Regex(regexitem, RegexOptions.None);

                matchs = regex.Matches(html);
                if (matchs.Count > 0)
                {
                    return matchs[0].Groups["v"].Value;
                }
            }

            return "";
        }
    }
}
