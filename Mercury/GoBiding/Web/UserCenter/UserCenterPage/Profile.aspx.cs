using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GoBiding.Model;
using GoBiding.Web.BaseCode;
using Maticsoft.DBUtility;

namespace GoBiding.Web.UserCenter.UserCenterPage
{
    public partial class Profile : PhoenixBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Init();
            }

        }

        public void UploadUserProfile()
        {
            if (FileUploadControl.HasFile)
            {
                try
                {
                    int userId = int.Parse(Session["UserSessionId"].ToString());

                    string filename = Path.GetFileName(FileUploadControl.FileName);
                    string savefilename = userId + "_" + "Profile_" + filename;
                    FileUploadControl.SaveAs(Server.MapPath("~/imgs/users/") + savefilename);
                    this.imgProfile.ImageUrl = "~/imgs/users/" + savefilename;

                    var model = new BLL.Sys_Users().GetModel(userId);
                    model.UserProfile = savefilename;
                    new BLL.Sys_Users().Update(model);
                }
                catch (Exception ex)
                {
                }
            }
        }


        public void Init()
        {
            int userId = int.Parse(Session["UserSessionId"].ToString());

            var user = new BLL.Sys_Users().GetModel(userId);
            txtUserName.Value = user.UserName;
            txtCompanyName.Value = user.CompanyName;
            txtEmail.Value = user.Email;
            txtMobile.Value = user.MobilePhone;
            txtPosition.Value = user.Description;
            txtQQ.Value = user.QQ;
            txtAddress.Value = user.Address;
            txtUserNickName.Value = user.UserNickName;
            rdbMan.Checked = user.Gender == 1 ? true : false;
            rdbWoman.Checked = !rdbMan.Checked;
            ddlEmailNotice.SelectedValue = user.IsEmailNotice == 1 ? "1" : "0";
            ddlSmsNotice.SelectedValue = user.IsSmsNotice == 1 ? "1" : "0";
            ddlWeiXinNotice.SelectedValue = user.IsWeiXinNotice== 1 ? "1" : "0";
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
                else if (user.UserProfile.Contains("sinaimg"))
                {
                    imgProfile.ImageUrl = user.UserProfile;
                }
                else
                {
                    imgProfile.ImageUrl = "~/imgs/users/" + user.UserProfile;
                }
            }
            else
            {
                imgProfile.ImageUrl = "~/imgs/system/zwtp.png";
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            int userId = int.Parse(Session["UserSessionId"].ToString());

            var user = new BLL.Sys_Users().GetModel(userId);
            user.UserName = txtUserName.Value;
            user.CompanyName = txtCompanyName.Value;
            user.Email = txtEmail.Value;
            user.MobilePhone = txtMobile.Value;
            user.Description = txtPosition.Value;
            user.QQ = txtQQ.Value;
            user.Address = txtAddress.Value;
            user.Gender = rdbMan.Checked ? 1 : 2;
            user.UserNickName = txtUserNickName.Value;
            user.LastLoginTime = DateTime.Now;

            new BLL.Sys_Users().Update(user);
        }

        protected void btnSaveDingyue_Click(object sender, EventArgs e)
        {
            int userId = int.Parse(Session["UserSessionId"].ToString());

            var user = new BLL.Sys_Users().GetModel(userId);
            user.IsSmsNotice = int.Parse(ddlSmsNotice.SelectedValue);
            user.IsEmailNotice = int.Parse(ddlEmailNotice.SelectedValue);
            user.IsWeiXinNotice = int.Parse(ddlWeiXinNotice.SelectedValue);

            new BLL.Sys_Users().Update(user);
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            UploadUserProfile();
        }

        protected void btnSavePassword_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtPwd.Value) || string.IsNullOrEmpty(txtPwd2.Value))
            {
                Response.Write("<script>alert('请输入密码!');</script>"); 
            }

            if (txtPwd.Value != txtPwd2.Value)
            {
                Response.Write("<script>alert('两次密码不一致，请重新输入!');</script>");
            }

            int userId = int.Parse(Session["UserSessionId"].ToString());

            var user = new BLL.Sys_Users().GetModel(userId);
            user.Password = DESEncrypt.Encrypt(txtPwd.Value);
            new BLL.Sys_Users().Update(user);

            Response.Write("<script>alert('修改成功!');</script>"); 

        }

    }
}