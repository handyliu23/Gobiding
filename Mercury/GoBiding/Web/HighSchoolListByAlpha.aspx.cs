using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using GoBiding.BLL;
using System.Data.SqlClient;
using Maticsoft.DBUtility;

namespace GoBiding.Web
{
    public partial class HighSchoolListByAlpha : System.Web.UI.Page
    {
        public string biddescription = "";
        public string title = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Init();
            }
        }

        public void Init()
        {
            if (Request.QueryString["ch"] == null)
                return;

            string firstch = Request.QueryString["ch"].ToString();
            lblFirstCh.Text = firstch;
            if (string.IsNullOrEmpty(firstch))
            {
                return;
            }

            string sql = @"select SchoolName from Schools where FirstAlpha = '" + firstch.First() + "'";
            DataSet ds = DbHelperSQL.Query(sql);
            rptBidList.DataSource = ds;
            rptBidList.DataBind();
        }

    }
}