using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Data.SqlClient;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Maticsoft.DBUtility;
using System.Collections.Generic;

namespace GoBiding.Web.UserCenter.UserCenterPage.SystemInfo
{
    public partial class SpiderList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["UserSessionId"] == null)
                {
                    mainContent.Visible = false;
                    Response.Redirect("/Login.aspx");
                    return;
                }

                Init();
                InitPage();
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSpiderName.Text.Trim()) ||
                string.IsNullOrEmpty(txtSpiderUrl.Text.Trim()))
            {
                lblMessage.Text = "请输入有效的地址";
                return;
            }
            Model.Spiders spider = new Model.Spiders();
            spider.CreateTime = DateTime.Now;
            spider.SpiderName = txtSpiderName.Text;
            spider.SpiderUrl = txtSpiderUrl.Text;
            spider.EncodeType = txtEncodeing.Text;
            spider.ListExpression = txtListExpression.Text;
            spider.DetailExpression = txtDetailExpression.Text;
            spider.SpiderUrlPrefix = txtSpiderUrlPrefix.Text;
            spider.ProvinceId = int.Parse(ddlProvince.SelectedValue);
            spider.CityId = int.Parse(ddlCity.SelectedValue);
            spider.DistrictId = int.Parse(ddlDistrinct.SelectedValue);
            spider.FilenameExpressoin = txtTitleExpression.Text.Trim();
            spider.TitleExpression = txtTitleExpression.Text.Trim();
            spider.ContentExpression = txtContentExpression.Text;
            spider.SourceExpression = txtSourceExpression.Text.Trim();
            spider.FilenameExpressoin = txtFilenameExpressoin.Text.Trim();
            spider.BidType = txtBidType.Text.Trim();
            spider.HttpMethod = txtHttpMethod.Text;
            spider.PageParameter = txtPageParameter.Text;
            spider.Status = int.Parse(ddlStatus.SelectedValue);
            spider.SpiderType = int.Parse(ddlSpiderType.SelectedValue);
            spider.PageCount = string.IsNullOrEmpty(txtPageCount.Text) ? 10 : int.Parse(txtPageCount.Text);
            spider.PublishExpression = txtPublishExpression.Text.Trim();
            spider.CountPerPage = int.Parse(txtCountPerPage.Text.Trim());
            spider.Cookies = txtCookies.Text.Trim();
            spider.IsActive = true;

            new BLL.Spiders().Add(spider);

            Init();
        }

        public void Init()
        {
            SqlParameter[] _params = new SqlParameter[] { 
                new SqlParameter("@pageIndex", AspNetPager1.CurrentPageIndex),
                new SqlParameter("@pageSize", AspNetPager1.PageSize)
            };

            var dt = DbHelperSQL.RunProcedure("GetSpidersList", _params); 
            //new BLL.Spiders().GetList(200, "", "SpiderId desc");
            dgSpiders.DataSource = dt;
            dgSpiders.DataBind();

            btnSave.Visible = false;
            btnSearch.Visible = true;

            ltrTotalCount.Text = new BLL.Bids().GetRecordCount("").ToString();
        }

        public void InitEdit()
        {
            int spiderId = int.Parse(hdnSaveSpiderId.Value);
            var spider = new BLL.Spiders().GetModel(spiderId);

            txtContentExpression.Text = spider.ContentExpression;
            txtDetailExpression.Text = spider.DetailExpression;
            txtEncodeing.Text = spider.EncodeType;
            txtFilenameExpressoin.Text = spider.FilenameExpressoin;
            txtListExpression.Text = spider.ListExpression;
            txtPublishExpression.Text = spider.PublishExpression;
            txtSourceExpression.Text = spider.SourceExpression;
            txtSpiderName.Text = spider.SpiderName;
            txtSpiderUrl.Text = spider.SpiderUrl;
            txtSpiderUrlPrefix.Text = spider.SpiderUrlPrefix;
            txtTitleExpression.Text = spider.TitleExpression;
            txtBidType.Text = spider.BidType;
            txtHttpMethod.Text = spider.HttpMethod;
            txtPageParameter.Text = spider.PageParameter;
            ddlStatus.SelectedValue = spider.Status.ToString();
            ddlSpiderType.SelectedValue = spider.SpiderType.ToString();
            txtPageCount.Text = spider.PageCount.ToString();
            txtCountPerPage.Text = spider.CountPerPage.ToString();
            txtCookies.Text = spider.Cookies.ToString();

            initProvince(spider.ProvinceId ?? 0);
            initCity(spider.ProvinceId ?? 0, spider.CityId ?? 0);
            initDistrict(spider.CityId ?? 0, spider.DistrictId ?? 0);
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Model.Spiders spider = new BLL.Spiders().GetModel(int.Parse(hdnSaveSpiderId.Value));
            spider.CreateTime = DateTime.Now;
            spider.SpiderName = txtSpiderName.Text;
            spider.SpiderUrl = txtSpiderUrl.Text;
            spider.EncodeType = txtEncodeing.Text;
            spider.ListExpression = txtListExpression.Text;
            spider.DetailExpression = txtDetailExpression.Text;
            spider.SpiderUrlPrefix = txtSpiderUrlPrefix.Text;
            spider.FilenameExpressoin = txtTitleExpression.Text.Trim();
            spider.TitleExpression = txtTitleExpression.Text.Trim();
            spider.ContentExpression = txtContentExpression.Text;
            spider.PublishExpression = txtPublishExpression.Text.Trim();
            spider.SourceExpression = txtSourceExpression.Text.Trim();
            spider.FilenameExpressoin = txtFilenameExpressoin.Text.Trim();
            spider.ProvinceId = int.Parse(ddlProvince.SelectedValue);
            spider.CityId = int.Parse(ddlCity.SelectedValue);
            spider.DistrictId = int.Parse(ddlDistrinct.SelectedValue);
            spider.BidType = txtBidType.Text.Trim();
            spider.HttpMethod = txtHttpMethod.Text;
            spider.PageParameter = txtPageParameter.Text;
            spider.Status = int.Parse(ddlStatus.SelectedValue);
            spider.SpiderType = int.Parse(ddlSpiderType.SelectedValue);
            spider.PageCount = string.IsNullOrEmpty(txtPageCount.Text) ? 10 : int.Parse(txtPageCount.Text);
            spider.CountPerPage = int.Parse(txtCountPerPage.Text);
            spider.Cookies = txtCookies.Text;

            new BLL.Spiders().Update(spider);

            Init();
        }

        public void InitPage()
        {
            int totalBidsCount = (int)DbHelperSQL.GetSingle("SELECT COUNT(*) FROM Spiders ");
            AspNetPager1.RecordCount = totalBidsCount;

            initProvince(0);
            initCity(0, 0);
            initDistrict(0, 0);
        }
        protected void ddlProvince_SelectedIndexChanged(object sender, EventArgs e)
        {
            int pId = int.Parse(this.ddlProvince.SelectedValue);
            initProvince(pId);
            initCity(pId, 0);
            initDistrict(0, 0);
        }
        protected void ddlCity_SelectedIndexChanged(object sender, EventArgs e)
        {
            int cityId = int.Parse(this.ddlCity.SelectedValue);
            int pId = int.Parse(this.ddlProvince.SelectedValue);
            initCity(pId, cityId);
            initDistrict(cityId, 0);
        }

        public void initProvince(int provinceId)
        {
            BLL.Provinces provinceService = new BLL.Provinces();
            this.ddlProvince.DataSource = provinceService.GetAllList();
            this.ddlProvince.DataTextField = "ProvinceName";
            this.ddlProvince.DataValueField = "ProvinceID";
            this.ddlProvince.DataBind();

            this.ddlProvince.Items.Insert(0, new ListItem("请选择", "0"));
            this.ddlProvince.SelectedValue = provinceId.ToString();
        }

        public void initCity(int provinceId, int cityId)
        {
            BLL.Citys cityService = new BLL.Citys();
            this.ddlCity.DataSource = cityService.GetList(" ProvinceID = " + provinceId);
            this.ddlCity.DataTextField = "CityName";
            this.ddlCity.DataValueField = "CityId";
            this.ddlCity.DataBind();
            this.ddlCity.Items.Insert(0, new ListItem("请选择", "0"));
            this.ddlCity.SelectedValue = cityId.ToString();
        }

        public void initDistrict(int cityId, int districtId)
        {
            BLL.Districts districtService = new BLL.Districts();
            this.ddlDistrinct.DataSource = districtService.GetList(" CityID = " + cityId);
            this.ddlDistrinct.DataTextField = "DistrictName";
            this.ddlDistrinct.DataValueField = "DistrictID";
            this.ddlDistrinct.DataBind();
            this.ddlDistrinct.Items.Insert(0, new ListItem("请选择", "0"));
            this.ddlDistrinct.SelectedValue = districtId.ToString();
        }

        protected void AspNetPager1_PageChanged(object src, EventArgs e)
        {
            Init();
        }

        protected void dgBidList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgSpiders.PageIndex = e.NewPageIndex;
            Init();
        }

        protected void dgSpiders_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            GridViewRow row = null;

            if (e.CommandName == "DeleteCommand")
            {
                new BLL.Spiders().Delete(long.Parse(e.CommandArgument.ToString()));
                Init();
            }
            else if (e.CommandName == "EditCommand")
            {
                hdnSaveSpiderId.Value = e.CommandArgument.ToString();

                InitEdit();

                btnSearch.Visible = false;
                btnSave.Visible = true;
            }
            else if (e.CommandName == "ActiveToggleCommand")
            {
                int spiderId = int.Parse(e.CommandArgument.ToString());
                var spider = new BLL.Spiders().GetModel(spiderId);
                spider.IsActive = !spider.IsActive;
                new BLL.Spiders().Update(spider);
                Init();
            }
        }

        public int GetCountBySpiderName(string spidername)
        {
            return new BLL.Bids().GetRecordCount("BidSpiderName = '" + spidername + "'");
        }

        public int GetCountForCurrentDayBySpiderName(string spidername)
        {
            return new BLL.Bids().GetRecordCount("BidSpiderName = '" + spidername + "' and CreateTime > CONVERT(varchar(100), GETDATE(), 23)");
        }

        public int GetCountForBidCurrentDayBySpiderName(string spidername)
        {
            return new BLL.Bids().GetRecordCount("BidSpiderName = '" + spidername + "' and BidPublishTime > CONVERT(varchar(100), GETDATE(), 23) and BidPublishTime < CONVERT(varchar(100), GETDATE() + 1, 23)");
        }

        protected void btnQuickSearch_Click(object sender, EventArgs e)
        {
            string where = "";
            if (!string.IsNullOrEmpty(txtspidernameforsearch.Text))
            {
                where += " SpiderName like '%" + txtspidernameforsearch.Text + "%'";
            }
            if (!string.IsNullOrEmpty(txtspiderurlforsearch.Text))
            {
                where += " SpiderUrl like '%" + txtspiderurlforsearch.Text + "%'";
            }

            List<Model.Spiders> spidersearchlist = new BLL.Spiders().GetModelList(where);
            if (spidersearchlist != null && spidersearchlist.Count > 0)
                ltrSpiderId.Text = spidersearchlist.Find(o => o.SpiderId > 0).SpiderId.ToString();
                        
        }
    }
}
