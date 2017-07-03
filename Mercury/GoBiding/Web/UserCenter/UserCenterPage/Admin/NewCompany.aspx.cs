using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Maticsoft.DBUtility;
using System.Data.SqlClient;

namespace GoBiding.Web.UserCenter.UserCenterPage.Admin
{
    public partial class NewCompany : System.Web.UI.Page
    {
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
            int cId = 0;

            if (Request["cId"] != null)
                cId = int.Parse(Request["cId"].ToString());

            var ps = new BLL.Provinces().GetAllList();
            this.ddlProvince.DataSource = ps;
            ddlProvince.DataBind();

            Model.CatchCompany company = new BLL.CatchCompany().GetModel(cId);
            if (company != null)
            {
                txtCompanyName.Value = company.VendorName;
                ddlCompanyTypes.SelectedValue = company.CompanyType;
                txtEmail.Value = company.Email;
                txtMajorBusinesses.Value = company.MajorBusinesses;
                txtWebSite.Value = company.WebSite;
                txtMajorProduct.Value = company.MajorBusinesses;
                txtRegistFund.Value = company.RegisteredFund;
                txtAnnualSalesVolume.Value = company.AnnualSalesVolume;
                txtDesc.Value = company.Notes;

                initProvince(company.ProvinceId ?? 0);
                initCity(company.ProvinceId ?? 0, company.CityId ?? 0);
            }
            else
            {
                initProvince(0);
                initCity(0, 0);
            }

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCompanyName.Value))
            {
                Response.Write("<script>alert('企业名称不能为空')</script>");
            }
            Model.CatchCompany company = null;

            //如果用户输入的公司名已经在CatchCompany存在，直接默认关联。否则创建一个新公司关联
            if (!string.IsNullOrEmpty(txtCompanyName.Value))
            {
                var companyexists = new BLL.CatchCompany().GetModelList(" VendorName = '" + txtCompanyName.Value + "'");
                if (companyexists != null && companyexists.Count > 0)
                {
                    company = companyexists.FirstOrDefault();
                }
            }
            else
                company = new Model.CatchCompany();

            company.VendorName = txtCompanyName.Value;
            company.CompanyType = ddlCompanyTypes.SelectedValue;
            company.Email = txtEmail.Value;
            company.MajorBusinesses = txtMajorBusinesses.Value;
            company.RegisteredFund = txtRegistFund.Value;
            company.AnnualSalesVolume = txtAnnualSalesVolume.Value;
            company.WebSite = txtWebSite.Value;
            company.MajorProduct = txtMajorProduct.Value;
            company.ProvinceId = int.Parse(ddlProvince.SelectedValue);
            company.CityId = int.Parse(ddlCity.SelectedValue);
            company.Notes = txtDesc.Value;
            company.IsBidAgent = int.Parse(ddlUserType.SelectedValue);

            //company.CityId = 
            if (company.Id > 0)
            {
                company.OnCreated = DateTime.Now;
                new BLL.CatchCompany().Add(company);
            }
            else
                new BLL.CatchCompany().Update(company);
        }

        public void UploadCompnayProfile()
        {

        }
    }
}