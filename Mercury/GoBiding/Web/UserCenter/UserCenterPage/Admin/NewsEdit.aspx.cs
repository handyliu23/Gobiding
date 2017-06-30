using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Maticsoft.DBUtility;
using System.Data.SqlClient;
using System.Data;
using System.IO;

namespace GoBiding.Web.UserCenter.UserCenterPage.Admin
{
    public partial class NewsEdit : System.Web.UI.Page
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
                //if (Session["UserSessionId"].ToString() != "7")
                //{
                //    mainContent.Visible = false;
                //    return;
                //}

                Bind();
            }
        }

        public void UploadUserProfile()
        {
            if (FileUploadControl.HasFile)
            {
                try
                {
                    string filename = Path.GetFileName(FileUploadControl.FileName);
                    string savefilename = "News_" + Guid.NewGuid() + "_" + filename;
                    FileUploadControl.SaveAs(Server.MapPath("~/imgs/news/") + savefilename);
                    this.imgProfile.ImageUrl = "~/imgs/news/" + savefilename;
                    hdnFileName.Value = savefilename;
                }
                catch (Exception ex)
                {
                    BLL.Logger.Warn(ex.Message, ex.StackTrace);
                }
            }
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            UploadUserProfile();
        }

        public void Bind()
        {
            DataSet ds = DbHelperSQL.Query("select * from DynamicNewsType");
            ddlType.DataSource = ds;
            ddlType.DataValueField = "Id";
            ddlType.DataTextField = "TypeName";
            ddlType.DataBind();

            if (Request.QueryString["option"] != null)
            {
                string opt = Request.QueryString["option"].ToString();

                if (opt.ToLower().Equals("delete"))
                {
                    if (Request.QueryString["Id"] != null)
                    {
                        int NewsId = int.Parse(Request.QueryString["Id"].ToString());
                        new BLL.DynamicNews().Delete(NewsId);

                        Response.Redirect("/UserCenter/UserCenterPage/Admin/NewsList.aspx");
                    }
                }
                else if (opt.ToLower().Equals("add"))
                {

                }
                else if (opt.ToLower().Equals("edit"))
                {
                    if (Request.QueryString["Id"] != null)
                    {
                        int NewsId = int.Parse(Request.QueryString["Id"].ToString());
                        var bidModel = new BLL.DynamicNews().GetModel(NewsId);

                        this.txtTitle.Text = bidModel.NewsTitle;
                        this.ddlType.SelectedValue = (bidModel.DynamicNewsTypeId ?? 0).ToString();
                        txtKeywords.Text = bidModel.Keywords;
                        txtBrowseCount.Text = (bidModel.BrowseCount ?? 0).ToString();
                        ckDetailContent.Text = bidModel.Content;

                        if (!string.IsNullOrEmpty(bidModel.ProfileImage))
                        {
                            this.imgProfile.ImageUrl = "~/imgs/news/" + bidModel.ProfileImage;
                            hdnFileName.Value = bidModel.ProfileImage;
                        }
                    }
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["option"] != null)
            {
                if (Request.QueryString["option"].ToString().ToLower() == "add")
                {
                    var bidModel = new Model.DynamicNews();

                    bidModel.NewsTitle = this.txtTitle.Text;
                    bidModel.Content = this.ckDetailContent.Text;
                    bidModel.DynamicNewsTypeId = int.Parse(this.ddlType.SelectedValue);
                    bidModel.ProfileImage = hdnFileName.Value;
                    bidModel.BrowseCount = int.Parse(txtBrowseCount.Text);
                    bidModel.OnCreate = DateTime.Now;
                    bidModel.Author = "Handy Liu";
                    bidModel.Keywords = txtKeywords.Text;

                    new BLL.DynamicNews().Add(bidModel);
                }
                else if (Request.QueryString["option"].ToString().ToLower() == "edit")
                {
                    int NewsId = int.Parse(Request.QueryString["Id"].ToString());
                    var bidModel = new BLL.DynamicNews().GetModel(NewsId);

                    bidModel.NewsTitle = this.txtTitle.Text;
                    bidModel.Content = this.ckDetailContent.Text;
                    bidModel.DynamicNewsTypeId = int.Parse(this.ddlType.SelectedValue);
                    bidModel.ProfileImage = hdnFileName.Value;
                    bidModel.BrowseCount = int.Parse(txtBrowseCount.Text);
                    bidModel.Keywords = txtKeywords.Text;
                    new BLL.DynamicNews().Update(bidModel);
                }

                Response.Redirect("/UserCenter/UserCenterPage/Admin/NewsList.aspx");

            }

        }

    }
}