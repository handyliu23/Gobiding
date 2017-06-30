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
    public partial class CompanyProfile : PhoenixBase
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
            int userId = int.Parse(Session["UserSessionId"].ToString());

            var user = new BLL.Sys_Users().GetModel(userId);

            var ps = new BLL.Provinces().GetAllList();
            this.ddlProvince.DataSource = ps;
            ddlProvince.DataBind();

            if (user.CompanyAuditStatus == 0)
            {
                btnAudit.Enabled = true;
                AuditStatusDiv.Visible = false;
            }
            else if (user.CompanyAuditStatus == 1)
            {
                    btnAudit.Enabled = false;
                    AuditStatusDiv.Visible = true;
                    AuditStatus.InnerText = "待审核";
            }
            else if (user.CompanyAuditStatus == 2)
            {
                btnAudit.Visible = false;
                AuditStatusDiv.Visible = true;
                AuditStatus.InnerText = "已认证";
            }
            else if (user.CompanyAuditStatus == 3)
            {
                btnAudit.Enabled = true;
                AuditStatusDiv.Visible = true;
                AuditStatus.InnerText = "认证失败，请重新上传";
            }

            Model.CatchCompany company = new BLL.CatchCompany().GetModel(user.CompanyId);
            if(company != null)
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
            int userId = int.Parse(Session["UserSessionId"].ToString());

            var user = new BLL.Sys_Users().GetModel(userId);
            Model.CatchCompany company = null;
            if (user.CompanyId == 0)
            {
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
            }
            else
            {
                company = new BLL.CatchCompany().GetModel(user.CompanyId);
            } 
            
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

            //company.CityId = 
            if (user.CompanyId == 0)
            {
                company.OnCreated = DateTime.Now;
                new BLL.CatchCompany().Add(company);
            }
            else
                new BLL.CatchCompany().Update(company);

            user.CompanyId = company.Id;
            user.CompanyName = company.VendorName;
            new BLL.Sys_Users().Update(user);
        }

        protected void btnAudit_Click(object sender, EventArgs e)
        {
            UploadCompnayProfile();

            AuditStatusDiv.Visible = true;
            AuditStatus.InnerText = "待审核";
        }

        public void UploadCompnayProfile()
        {
            if (flpyyzz.HasFile && flpzzjgz.HasFile && flpswdj.HasFile)
            {
                try
                {
                    int userId = int.Parse(Session["UserSessionId"].ToString());

                    string yyzzfilename = userId + "_" + "Company_yyzz" + flpyyzz.FileName;
                    string zzjgzfilename = userId + "_" + "Company_zzjgz"+ flpzzjgz.FileName;
                    string swdjzfilename = userId + "_" + "Company_swdjz"+ flpswdj.FileName;

                    flpyyzz.SaveAs(Server.MapPath("~/imgs/users/") + yyzzfilename);
                    flpzzjgz.SaveAs(Server.MapPath("~/imgs/users/") + zzjgzfilename); 
                    flpswdj.SaveAs(Server.MapPath("~/imgs/users/") + swdjzfilename);

                    var model = new BLL.Sys_Users().GetModel(userId);
                    model.YYZZ = yyzzfilename;
                    model.ZZDJZ = zzjgzfilename;
                    model.SWDJZ = swdjzfilename;
                    model.CompanyAuditStatus = 1;   //待审核
                    model.CompanyAuditApplyTime = DateTime.Now;
                    new BLL.Sys_Users().Update(model);

                    btnAudit.Enabled = false;
                    AuditStatusDiv.Visible = true;
                    AuditStatus.InnerText = "待审核";
                }
                catch (Exception ex)
                {
                }
            }
            else
            {
                Response.Write("<Script Language=JavaScript>alert('请上传完整的材料');</Script>"); 
            }
        }

    }
}