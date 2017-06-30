using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Maticsoft.DBUtility;

namespace GoBiding.Web
{
    public partial class BidNewsList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Bind();
            }
        }

        public void Bind()
        {
            int pageindex = 1;
            if (Request.QueryString["page"] != null)
            {
                pageindex = int.Parse(Request.QueryString["page"]);
            }

            string sql = string.Format(@"
select * from (
SELECT ROW_NUMBER() OVER (ORDER BY n.id desc)AS Row, n.*, t.TypeName  from 
DynamicNews n inner join DynamicNewsType t on n.DynamicNewsTypeId = t.Id  where 
 DynamicNewsTypeId <> 1
)temp where Row between ({0}-1)*{1}+1 and ({0}-1)*{1}+{1}
", pageindex, AspNetPager1.PageSize);
            var ds = DbHelperSQL.Query(sql);
            this.rptNewsList.DataSource = ds;
            this.rptNewsList.DataBind();

            string sql2 = @"
    select count(*) from DynamicNews n inner join DynamicNewsType t on n.DynamicNewsTypeId = t.Id where DynamicNewsTypeId <> 1
";
            var ds2 = DbHelperSQL.Query(sql2);

            AspNetPager1.RecordCount = int.Parse(ds2.Tables[0].Rows[0][0].ToString());

            sql = @"
    select top 10 * from DynamicNews n inner join DynamicNewsType t on n.DynamicNewsTypeId = t.Id where DynamicNewsTypeId = 1 order by 1 desc
";
            ds = DbHelperSQL.Query(sql);
            this.rptLawList.DataSource = ds;
            this.rptLawList.DataBind();


        }

        protected void AspNetPager1_PageChanged(object src, EventArgs e)
        {
            //Init();
        }
    }
}