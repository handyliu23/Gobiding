using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading;
using Mercury.BLL;

namespace InitCatchCompanyUser
{
    class Program
    {
        static void Main(string[] args)
        {

            int startIndex = 1;
            int pageSize = 100;
            var userBLL = new Mercury.BLL.Sys_Users();
            var user = new Mercury.Model.Sys_Users();
            while(true)
            {
                DataSet ds = new Mercury.BLL.CatchCompany().GetListByPage(" qq <> '' or Email <> '' ", "Id", startIndex, startIndex + pageSize - 1);
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    string VendorName = ds.Tables[0].Rows[i]["VendorName"].ToString();
                    string Id = ds.Tables[0].Rows[i]["Id"].ToString();
                    string ContacterName = ds.Tables[0].Rows[i]["ContacterName"].ToString();
                    string ContacterPosition = ds.Tables[0].Rows[i]["ContacterPosition"].ToString();
                    string MobilePhone = ds.Tables[0].Rows[i]["MobilePhone"].ToString();
                    string TelephonePhone = ds.Tables[0].Rows[i]["ContacterTelephone"].ToString();
                    string Email = ds.Tables[0].Rows[i]["Email"].ToString();
                    string QQ = ds.Tables[0].Rows[i]["QQ"].ToString();
                    string CityId = ds.Tables[0].Rows[i]["CityId"].ToString();
                    string MajorBusinesses = ds.Tables[0].Rows[i]["MajorBusinesses"].ToString();
                    string ProvinceId = ds.Tables[0].Rows[i]["ProvinceId"].ToString();

                    var list = userBLL.GetModelList(" CompanyId = " + Id);
                    if (list != null && list.Count > 0)
                    {
                        continue;
                    }

                    user = new Mercury.Model.Sys_Users();
                    user.CompanyId = int.Parse(Id);
                    user.CompanyName = VendorName;
                    user.ContacterName = ContacterName;
                    user.MobilePhone = MobilePhone;
                    user.OnCreate = DateTime.Now;

                    if (!string.IsNullOrEmpty(MobilePhone))
                        user.UserNickName = MobilePhone;
                    else if (!string.IsNullOrEmpty(Email))
                        user.UserNickName = Email;
                    else if (!string.IsNullOrEmpty(QQ))
                        user.UserNickName = QQ;

                    user.UserName = ContacterName;
                    user.UserGUID = Guid.NewGuid();
                    user.UserLoginType = 1;
                    user.Password = "576672F92FB5DD33";
                    user.QQ = QQ;
                    if (string.IsNullOrEmpty(Email))
                        user.Email = QQ + "@QQ.COM";
                    else
                        user.Email = Email;
                    user.Scores = 0;
                    user.TelephonePhone = TelephonePhone;
                    //user.CompanyAuditStatus = 0;
                    user.Description = ContacterPosition;
                    user.DistrictId = int.Parse(CityId);

                    userBLL.Add(user);

                    Console.WriteLine(user.CompanyName);
                }

                if(ds.Tables[0].Rows.Count < 100)
                {
                    break;
                }

                startIndex = startIndex + pageSize; //1 + 100

                Thread.Sleep(100);
            }
        }
    }
}
