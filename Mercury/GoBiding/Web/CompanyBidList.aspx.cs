using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GoBiding.BLL;
using Maticsoft.DBUtility;
using System.Web.UI.HtmlControls;

namespace GoBiding.Web
{
    public partial class CompanyBidList : System.Web.UI.Page
    {
        string strTitle;
        string strSeoKey;
        string strSeoDescription;
        public string companyName = "";

        public void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    if (Request.QueryString["BidCompanyId"] == null)
                        return;

                    int companyId = int.Parse(Request.QueryString["BidCompanyId"].ToString());
                    var company = new BLL.CatchCompany().GetModel(companyId);

                    #region
                    strTitle = company.VendorName + "官网采购信息_去投标网_免费招标采购信息发布平台_手机招标采购信息";
                    strSeoKey = company.VendorName + "_小额采购信息_采购报价_快速下单_手机招标采购";
                    strSeoDescription = company.VendorName + "_去投标网_免费招标采购信息，最好的招标采购信息服务平台_免费招标_采购信息_公开招标_工程招标_上海商麓网络科技有限公司官网";
                    Page.Title = strTitle;
                    HtmlMeta desc = new HtmlMeta();
                    desc.Name = "Description";
                    desc.Content = strSeoDescription;
                    Page.Header.Controls.Add(desc);

                    HtmlMeta keywords = new HtmlMeta();
                    keywords.Name = "keywords";
                    keywords.Content = strSeoKey;
                    Page.Header.Controls.Add(keywords);
                    #endregion

                    if (string.IsNullOrEmpty(company.VendorName))
                    {
                        return;
                    }

                    ltrCompanyName.Text = company.VendorName;
                    companyName = company.VendorName;

                    var ds = new BLL.Bids().GetList(8, " BidType=1 AND BidCompanyName = '" + company.VendorName + "'", "BidId desc");
                    if (ds != null && ds.Tables[0].Rows.Count > 0)
                    {
                        divzbgg.Visible = false;
                        rptBidList.DataSource = ds;
                        rptBidList.DataBind();
                    }
                    else
                    {
                        divzbgg.Visible = true;
                    }

                    var ds2 = new BLL.Bids().GetList(8, " BidType=2 AND BidCompanyName = '" + company.VendorName + "'", "BidId desc");
                    if (ds2 != null && ds2.Tables[0].Rows.Count > 0)
                    {
                        rptZBGGBidList.DataSource = ds2;
                        rptZBGGBidList.DataBind();
                    }
                    else
                    {
                        divbggg.Visible = true;
                    }


                    var ds3 = new BLL.Bids().GetList(8, " BidType=3 AND BidCompanyName = '" + company.VendorName + "'", "BidId desc");
                    if (ds3 != null && ds3.Tables[0].Rows.Count > 0)
                    {
                        rptzbgg.DataSource = ds3;
                        rptzbgg.DataBind();
                    }
                    else
                    {
                        divzhbgg.Visible = true;
                    }

                    var ds4 = new BLL.Bids().GetList(8, " BidType=5 AND BidCompanyName = '" + company.VendorName + "'", "BidId desc");

                    rptfbgg.DataSource = ds4;
                    rptfbgg.DataBind();

                    var ds5 = new BLL.Bids().GetList(8, " BidType=7 AND BidCompanyName = '" + company.VendorName + "'", "BidId desc");

                    rptjzxtp.DataSource = ds5;
                    rptjzxtp.DataBind();

                    var sql = @"select count(*) from Bids where BidCompanyName = '" + company.VendorName + "'";
                    var bidcount = int.Parse(DbHelperSQL.GetSingle(sql).ToString());

                    ltrBidCount.Text = bidcount.ToString();

                    if (company != null)
                    {
                        ltrYears.Text = (DateTime.Now.Year - company.OnCreated.Value.Year + 1).ToString();
                        ltrDomain.Text = string.IsNullOrEmpty(company.MajorBusinesses) ? "暂无" : company.MajorBusinesses;
                        ltrMajor.Text = string.IsNullOrEmpty(company.MajorProduct) ? "暂无" : company.MajorProduct;
                        ltrArea.Text = CommonUtility.GetProvinceName(company.ProvinceId.ToString());
                        ltrContacter.Text = company.ContacterName;
                        ltrCompanyNotes.Text = company.Notes;

                        var companyUsers = new BLL.Sys_Users().GetModelList(" CompanyId = '" + company.Id + "'");
                        if (companyUsers != null && companyUsers.Count > 0)
                        {
                            var companyUser = companyUsers.FirstOrDefault();
                            btnUserCenter.Visible = false;
                            var publishPurchaseOrderCount = new BLL.PurchaseOrder().GetRecordCount(" SysUserId = " + companyUser.Sys_UserId);
                            ltrPubCount.Text = publishPurchaseOrderCount.ToString();
                            ltrContacter.Text = companyUser.UserName;

                            //imgYYZZ.ImageUrl = "~/imgs/users/" + companyUser.YYZZ;
                            //imgSWDJ.ImageUrl = "~/imgs/users/" + companyUser.SWDJZ;
                            //imgZZJG.ImageUrl = "~/imgs/users/" + companyUser.ZZDJZ;
                        }
                        else
                        {
                            tblAuthentication.Visible = false;
                            ltrPubCount.Text = "0";
                        }
                    }
                    else
                    {
                        ltrYears.Text = "1";
                        ltrDomain.Text = "暂无";
                        ltrMajor.Text = "暂无";
                    }
                }
                catch (Exception err)
                {
                    Logger.Warn(err.Message, err.StackTrace);
                }
            }
        }

        protected void btnUserCenter_Click(object sender, EventArgs e)
        {
            if (Session["UserSessionId"] == null)
            {
                Response.Redirect("/Login.html");
            }

            var user = new BLL.Sys_Users().GetModel(int.Parse(Session["UserSessionId"].ToString()));
            if (user.CompanyId != null)
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "onekey", "alert('您已经创建公司档案，不能再认领其他公司，如果确实是您的公司，请联系在线客服！')", true);
                return;
            }

            string companyname = Request.QueryString["CompanyName"];

            var companys = new BLL.CatchCompany().GetModelList(" VendorName = '" + companyname + "'");
            if (companys != null && companys.Count > 0)
            {
                var company = companys.FirstOrDefault();

                Response.Redirect("/UserCenter/UserCenterPage/CompanyProfile.aspx?companyId=" + company.Id);
            }

        }
    }
}