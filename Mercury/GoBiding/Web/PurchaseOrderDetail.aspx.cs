using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using GoBiding.BLL;
using System.Web.UI.HtmlControls;

namespace GoBiding.Web
{
    public partial class PurchaseOrderDetail : System.Web.UI.Page
    {
        string strTitle;
        string strSeoKey;
        string strSeoDescription;
        public string companyname;
        public int companyId;
        public string qqstring;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {

                    int bId = int.Parse(Request.QueryString["poId"].ToString());
                    var bid = new BLL.PurchaseOrder().GetModel(bId);

                    #region
                    strTitle = "免费采购信息_" + bid.Title + "_去投标网_免费招标采购信息发布平台_手机招标采购";
                    strSeoKey = bid.Title + "_小额采购信息_采购报价_快速下单_手机招标采购";
                    strSeoDescription = "去投标网_免费招标采购信息，最好的招标采购信息服务平台_免费招标_采购信息_公开招标_工程招标_上海商麓网络科技有限公司官网";
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


                    lblTitle.Text = bid.Title;
                    lblTitle2.Text = bid.Title;
                    ltrPublishTime.Text = bid.PublishTime.ToString();
                    ltrBidAmount.Text = (bid.Budget ?? 0) == 0 ? "未填写" : bid.Budget.ToString();

                    ltrBidCompany.Text = bid.CompanyName;

                    if (bid.CompanyName == "个人")
                    {
                        divPersonUser.Visible = true;
                        divCompanyUser.Visible = false;

                        ltrMobile.Text = bid.MobilePhone;
                        ltrContacter.Text = bid.ContacterName;
                        ltrProvince.Text = new BLL.Provinces().GetModel(bid.RecvProvinceId ?? 0).ProvinceName;
                        ltrcity.Text = new BLL.Citys().GetModel(bid.RecvCityId ?? 0).CityName;

                    }
                    else {
                        divPersonUser.Visible = false;
                        divCompanyUser.Visible = true;

                    }

                    companyname = ltrBidCompany.Text;
                    ltrCategoryId.Text = (bid.ProductCategoryId ?? 0) == 0 ? "其他" : CommonUtility.GetCategoryName(bid.ProductCategoryId ?? 0);
                    ltrExpireTime.Text = bid.ExpireTime == null ? "长期" : bid.ExpireTime.Value.ToShortDateString();
                    ltrProvinceName.Text = CommonUtility.GetProvinceName(bid.RecvProvinceId.ToString());
                    ltrPublishTime.Text = bid.PublishTime == null ? "" : bid.PublishTime.Value.ToShortDateString();

                    var publishUser = new BLL.Sys_Users().GetModel(bid.SysUserId ?? 0);
                    ltrCompanyName.Text = bid.CompanyName;
                    companyId = publishUser.CompanyId;
                    ltrYears.Text = ((DateTime.Now - publishUser.OnCreate.Value).Days / 365 + 1).ToString();
                    if (string.IsNullOrEmpty(publishUser.QQ))
                    {
                        qqstring = "715794512";
                    }else
                        qqstring = publishUser.QQ;

                    var company = new BLL.CatchCompany().GetModel(publishUser.CompanyId);
                    if (company != null)
                    {
                        ltrDomain.Text = company.MajorBusinesses;
                        ltrMajor.Text = company.MajorProduct;
                    }

                    var publishPurchaseOrderCount = new BLL.PurchaseOrder().GetRecordCount(" SysUserId = " + publishUser.Sys_UserId);
                    ltrPubCount.Text = publishPurchaseOrderCount.ToString();
                    ltrArea.Text = CommonUtility.GetProvinceName(bid.RecvProvinceId.ToString());

                    if (Session["UserSessionId"] != null)
                    {
                        int userId = int.Parse(Session["UserSessionId"].ToString());

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

                    //邮件
                    //EncodeValueByRegex(bid, _emailregex);

                    //手机
                    //EncodeValueByRegex(bid, _mobileregex);

                    //电话号码
                    //EncodeValueByRegex(bid, _phoneregex);

                    //网址
                    //EncodeValueByRegex(bid, _httpurl);

                    //地址
                    //EncodeValueByRegex(bid, addressRegex);

                    lblContent.Text = bid.Description;
                }
                catch (Exception er)
                {
                }
            }
        }

        public void EncodeValueByRegex(Model.Bids bid, string regex)
        {
            var mathes = Regex.Matches(bid.BidContent, regex);
            if (mathes.Count > 0)
            {
                for (int i = 0; i < mathes.Count; i++)
                {
                    bid.BidContent = bid.BidContent.Replace(mathes[i].Value, "********");
                }
            }
        }

        public string EncodeValueByRegex(Model.Bids bid, List<string> regexitems)
        {
            Regex regex = null;
            MatchCollection matchs = null;

            foreach (var regexitem in regexitems)
            {
                regex = new Regex(regexitem, RegexOptions.None);

                matchs = regex.Matches(bid.BidContent);
                if (matchs.Count > 0)
                {
                    for (int i = 0; i < matchs.Count; i++)
                    {
                        if (matchs[i].Groups["v"].Value.Length > 3)
                            bid.BidContent = bid.BidContent.Replace(matchs[i].Groups["v"].Value, "********");
                    }
                }
            }

            return "";
        }
    }
}