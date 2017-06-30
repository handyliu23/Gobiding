using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GoBiding.Model;
using GoBiding.Web.BaseCode;

namespace GoBiding.Web.UserCenter.UserCenterPage
{
    public partial class PublishPurchaseOrder : PhoenixBase
    {
        public int poId = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Init();
            }
        }

        protected void ddlProvince_SelectedIndexChanged(object sender, EventArgs e)
        {
            int pId = int.Parse(this.ddlProvince.SelectedValue);
            initProvince(pId);
            initCity(pId, 0);
        }
        protected void ddlCity_SelectedIndexChanged(object sender, EventArgs e)
        {
            int cityId = int.Parse(this.ddlCity.SelectedValue);
            int pId = int.Parse(this.ddlProvince.SelectedValue);
            initCity(pId, cityId);
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

        public void Init()
        {
            int userId = int.Parse(Session["UserSessionId"].ToString());

            var user = new BLL.Sys_Users().GetModel(userId);
            IsCompanyAudited.Value = user.CompanyAuditStatus == 2 ? "true" : "false";

            if (Request.QueryString["poId"] != null)
            {
                poId = int.Parse(Request.QueryString["poId"].ToString());

                if (Request.QueryString["option"] != null && Request.QueryString["option"].ToString() == "edit")
                {
                    var model = new BLL.PurchaseOrder().GetModel(poId);
                    txtCompanyName.Value = model.CompanyName;
                    txtContacter.Value = model.ContacterName;
                    txtContacterMobile.Value = model.MobilePhone;
                    txtEmail.Value = model.Email;

                    if(model.ExpireTime != null)
                        txtExpiretime.Value = model.ExpireTime.Value.ToShortDateString();
                    txtBidTitle.Value = model.Title;
                    txtContacterTel.Value = model.TelePhone;
                    content.Text = model.Description;
                    selectIndustry.SelectedValue = model.ProductCategoryId.Value.ToString();
                    initProvince(model.RecvProvinceId ?? 0);
                    initCity(model.RecvProvinceId ?? 0, model.RecvCityId ?? 0);
                }
                if (Request.QueryString["option"] != null && Request.QueryString["option"].ToString() == "delete")
                {
                    new BLL.PurchaseOrder().Delete(poId);
                    Response.Redirect("/UserCenter/UserCenterPage/PurchaseOrderList.aspx");
                }
            }
            else
            {
                txtCompanyName.Value = user.CompanyName;
                txtContacter.Value = user.UserName;
                txtContacterMobile.Value = user.MobilePhone;
                txtEmail.Value = user.Email;

                initProvince(0);
                initCity(0, 0);
            }

        }
    }
}