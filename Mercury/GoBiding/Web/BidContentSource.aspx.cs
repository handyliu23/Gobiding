using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GoBiding.BLL;
using Maticsoft.DBUtility;

namespace GoBiding.Web
{
    public partial class BidContentSource : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int bId = int.Parse(Request.QueryString["BId"].ToString());
                lblContent.Text = CommonUtility.RemoveStyle(GetBidContent(bId));
            }
        }

        public string GetBidContent(int BidId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 BidContent from Bids ");
            strSql.Append(" where BidId=@BidId");
            SqlParameter[] parameters = {
					new SqlParameter("@BidId", SqlDbType.BigInt)
			};
            parameters[0].Value = BidId;

            GoBiding.Model.Bids model = new GoBiding.Model.Bids();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return ds.Tables[0].Rows[0][0].ToString();
            }

            return "";
        }
    }
}