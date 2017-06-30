﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GoBiding.Web;
using System.Data;
using Maticsoft.DBUtility;
using GoBiding.BLL;
using System.Net;
using Newtonsoft.Json;

namespace GoBiding
{
//{ 
//"openid":"OPENID",
//"nickname":"NICKNAME",
//"sex":1,
//"province":"PROVINCE",
//"city":"CITY",
//"country":"COUNTRY",
//"headimgurl": "http://wx.qlogo.cn/mmopen/g3MonUZtNHkdmzicIlibx6iaFqAc56vxLSUfpb6n5WKSYVY0ChQKkiaJSgQ1dZuTOgvLLrhJbERQQ4eMsv84eavHiaiceqxibJxCfHe/0",
//"privilege":[
//"PRIVILEGE1", 
//"PRIVILEGE2"
//],
//"unionid": " o6_bmasdasdsad6_2sgVt7hMZOPfL"
//}
     
      
    public partial class Default : System.Web.UI.Page
    {
      
        protected void Page_Load(object sender, EventArgs e)
        {
           
            if (Session["UserSessionId"] == null)
            {
                hdnislogin.Value = "False";
            }
            else {
                hdnislogin.Value = "True";
            }

            if (!IsPostBack)
            {
                Init();
            }
        }

        public string GetUserTypeName(int type)
        {
            switch (type)
            {
                case 1:
                    return "投标商";

                case 2:
                    return "招标商";

                case 3:
                    return "代理机构";
            }

            return "投标商";

        }

        public void Init()
        {
            try
            {
                if (Session["UserSessionId"] != null)
                {
                    hdnislogin.Value = "True";

                    int userId = int.Parse(Session["UserSessionId"].ToString());
                    var user = new BLL.Sys_Users().GetModel(userId);
                    if (user == null)
                        return;

                    lblCurrentUserLoginTime.Text = user.LastLoginTime.ToString();
                    lblCurrentUserPubBidCount.Text = new BLL.Bids().GetRecordCount(" SysUserId = " + user.Sys_UserId.ToString()).ToString();
                    lblCurrentUserPubPurchaseCount.Text = new BLL.Bids().GetRecordCount(" SysUserId = " + user.Sys_UserId.ToString()).ToString();
                    lblUnReadCount.Text = new BLL.Message().GetRecordCount(" IsRead = 0 AND ReceiverId = " + user.Sys_UserId.ToString()).ToString();
                    lblCurrentUserName.Text = user.UserNickName;
                    lblCurrentUserYear.Text = ((DateTime.Now.Year - user.OnCreate.Value.Year) + 1).ToString();
                    lblCurrentUserType.Text = GetUserTypeName(user.UserLoginType ?? 0);
                    if (!string.IsNullOrEmpty(user.UserProfile))
                    {
                        if (user.UserProfile.Contains("qzapp"))
                        {
                            imgProfile.ImageUrl = user.UserProfile + "/30";
                        }
                        else if (user.UserProfile.Contains("wx.qlogo"))
                        {
                            imgProfile.ImageUrl = user.UserProfile;
                        }
                        else
                        {
                            imgProfile.ImageUrl = "~/imgs/users/" + user.UserProfile;
                        }
                    }
                    else
                        imgProfile.ImageUrl = "~/imgs/users/zwtp.png";

                    if (user.CompanyAuditStatus == 0)
                    {
                        lblCurrentCompanyAuditStatus.Text = "未认证";
                    }
                    else if (user.CompanyAuditStatus == 1)
                    {
                        lblCurrentCompanyAuditStatus.Text = "待审核";
                    }
                    else if (user.CompanyAuditStatus == 2)
                    {
                        lblCurrentCompanyAuditStatus.Text = "已认证";
                    }
                    else if (user.CompanyAuditStatus == 3)
                    {
                        lblCurrentCompanyAuditStatus.Text = "未认证";
                    }
                    else
                    {
                        lblCurrentCompanyAuditStatus.Text = "未认证";
                    }
                }

                var starttime = DateTime.Today.AddDays(-7);
                ltrTotalCount.Text = new BLL.Bids().GetRecordCount(" BidPublishTime > '" + starttime.ToShortDateString() + "'").ToString();

                string sql = @"
select top 20 Id,Title,PublishTime,ExpireTime,Status,PurchaseType,IsEmergency,IsSetTop,CompanyName,p.ProvinceName, c.CityName
from PurchaseOrder po left join Provinces p on po.RecvProvinceId = p.ProvinceID 
left join Citys c on c.CityID = po.RecvCityId
order by 1 desc
                ";

                DataSet ds = DbHelperSQL.Query(sql);

                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    rptPurchaseOrderList.DataSource = ds;
                    rptPurchaseOrderList.DataBind();
                }

//                string sql2 =
//@"select top 8 Sys_UserId, CompanyId,OnCreate, DistrictId, CompanyName, c.CityName from Sys_Users u
//inner join Citys c on u.DistrictId = c.CityID
//where CompanyName <> '' order by 1 desc
//";

//                ds = DbHelperSQL.Query(sql2);

//                if (ds != null && ds.Tables[0].Rows.Count > 0)
//                {
//                    rptEmergencyPurchaseOrderList.DataSource = ds;
//                    rptEmergencyPurchaseOrderList.DataBind();
//                }
            }
            catch (Exception err)
            {
                Logger.Warn(err.Message, err.StackTrace);
                return;
            }
        }


    }
}