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
    public partial class UserEdit : System.Web.UI.Page
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

                if (Request.QueryString["option"] != null)
                {
                    string option = Request.QueryString["option"].ToString();

                    if (option == "Delete")
                    {
                        if (Request.QueryString["userId"] != null)
                        {
                            int userId = int.Parse( Request.QueryString["userId"].ToString() );
                            Model.Sys_Users user = new BLL.Sys_Users().GetModel(userId);
                            if (user != null)
                            {
                                user.Deleted = true;
                                new BLL.Sys_Users().Update(user);

                                Response.Redirect("/UserCenter/UserCenterPage/Admin/UserList.aspx");
                            }
                        }
                    }

                    if (option == "DeleteData")
                    {
                        if (Request.QueryString["userId"] != null)
                        {
                            int userId = int.Parse( Request.QueryString["userId"].ToString() );
                            Model.Sys_Users user = new BLL.Sys_Users().GetModel(userId);
                            if (user != null)
                            {
                                new BLL.Sys_Users().Delete(user.Sys_UserId);

                                Response.Redirect("/UserCenter/UserCenterPage/Admin/UserList.aspx");
                            }
                        }
                    }
                    

                    if (option == "Auth")
                    {
                        if (Request.QueryString["userId"] != null)
                        {
                            int userId = int.Parse(Request.QueryString["userId"].ToString());
                            Model.Sys_Users user = new BLL.Sys_Users().GetModel(userId);
                            if (user != null)
                            {
                                user.CompanyAuditStatus = 2;
                                new BLL.Sys_Users().Update(user);

                                Response.Redirect("/UserCenter/UserCenterPage/Admin/UserList.aspx");
                            }
                        }
                    }
                }
            }
        }

    }
}