using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GoBiding.BLL;
using Maticsoft.Common;

namespace GoBiding.Web.wap
{
    public partial class BidDetail : System.Web.UI.Page
    {
        public string keywords = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserSessionId"] == null)
            {
                //return;
                //Response.Redirect("/wap/waplogin.aspx?redirecturl=" + "/wap/Subscribe.aspx");
            }


            if(!IsPostBack)
            {
                if (Request.QueryString["BId"] == null)
                    return;

                int bId = int.Parse(Request.QueryString["BId"].ToString());
                hdnBidId.Value = bId.ToString();

                keywords = Request.QueryString["keywords"];

                var bid = new BLL.Bids().GetModel(bId);
                if(bid == null)
                {
                    Response.Redirect("/wap/Error.aspx");
                }

                lblTitle.Text = bid.BidTitle;
                lblContent.Text = CommonUtility.RemoveStyle(bid.BidContent);
                if (!string.IsNullOrEmpty(keywords))
                {
                    lblContent.Text = lblContent.Text.Replace(keywords, "<font style='color:red;'>"+ keywords + "</font>");
                }
                lblProvinceName.Text = CommonUtility.GetProvinceName(bid.ProvinceId.ToString());
                lblCategoryName.Text = CommonUtility.GetCategoryName(bid.BidCategoryId ?? 0);
                if (string.IsNullOrEmpty(lblCategoryName.Text))
                    rowCategory.Visible = false;
                lblPublishTime.Text = bid.BidPublishTime.ToShortDateString();
                lblSpiderName.Text = bid.BidSpiderName;
                lnkSpiderURL.HRef = bid.BidSourceURL;
                lnkSpiderUrl2.HRef = bid.BidSourceURL;
                lblBidType.Text = CommonUtility.GetBidTypeValue(bid.BidType);

                int userId = 0;
                if (Session["UserSessionId"] != null)
                    userId = int.Parse(Session["UserSessionId"].ToString());

                if (userId > 0)
                {
                    var history = new Model.Sys_UsersBidHistorys();
                    var list = new BLL.Sys_UsersBidHistorys().GetModelList(" BidId =" + bId + " and UserId =" + userId);
                    if (list != null && list.Count > 0)
                    {
                        history = list.FirstOrDefault();
                        history.CreateTime = DateTime.Now;
                        new BLL.Sys_UsersBidHistorys().Update(history);
                    }
                    else
                    {
                        history.BidId = bId;
                        history.UserId = userId;
                        history.CreateTime = DateTime.Now;
                        new BLL.Sys_UsersBidHistorys().Add(history);
                    }
                }
            }
        }
    }
}