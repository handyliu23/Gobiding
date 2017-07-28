using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Maticsoft.DBUtility;
using System.Web.UI.HtmlControls;

namespace GoBiding.Web
{
    public partial class BidNewsDetail : System.Web.UI.Page
    {
        string strTitle;
        string strSeoKey;
        string strSeoDescription;

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                Bind();
            }
        }

        public void Bind()
        {
            BLL.DynamicNews dnBLL = new BLL.DynamicNews();
            string sql = @"
    select top 10 * from DynamicNews n inner join DynamicNewsType t on n.DynamicNewsTypeId = t.Id where DynamicNewsTypeId <> 1 order by 1 desc
";
            var ds = DbHelperSQL.Query(sql);
            this.rptNewsList.DataSource = ds;
            this.rptNewsList.DataBind();

            if(Request.QueryString["NewsId"] != null)
            {
                int newId = int.Parse(Request.QueryString["NewsId"]);
                var newInfo = dnBLL.GetModel(newId);
                ltrContent.Text = newInfo.Content;
                ltrTitle.Text = newInfo.NewsTitle;
                ltrKeys.Text = newInfo.Keywords;
                ltrPublishTime.Text = newInfo.OnCreate.Value.ToShortDateString();
                ltrAuthor.Text = newInfo.Author;

                strTitle = "去投标网_招标资讯_" + newInfo.NewsTitle + "_免费招标采购信息发布平台_免费招标采购";
                strSeoKey = newInfo.Keywords + ",去投标网,免费招标采购";
                strSeoDescription = "去投标网_招标资讯_免费招标采购信息_免费招标_采购信息_公开招标_工程招标_上海商麓网络科技有限公司官网";
                Page.Title = strTitle;
                HtmlMeta desc = new HtmlMeta();
                desc.Name = "Description";
                desc.Content = strSeoDescription;
                Page.Header.Controls.Add(desc);

                HtmlMeta keywords = new HtmlMeta();
                keywords.Name = "keywords";
                keywords.Content = strSeoKey;
                Page.Header.Controls.Add(keywords);

                newInfo.BrowseCount++;
                dnBLL.Update(newInfo);

            }
        }
    }
}