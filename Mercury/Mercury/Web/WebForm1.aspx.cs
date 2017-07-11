using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using Maticsoft.DBUtility;
using Mercury.BLL;

namespace Mercury.Web
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        private List<Mercury.Model.BidCategorys> categorys;

        public void test()
        {
            string html = @"
  <div style=""width: 100%; background-color: #fff; padding: 20px;""> 
   <div style=""width: 950px; margin: 0px auto; min-height: 300px; background-color: #fcfcfc;
            padding: 20px;""> 
    <img src=""http://www.gobiding.com/imgs/ad/ad_m_2.gif"" /> 
    <br /> 
    <div style=""font-size: 13px; color: #333; padding: 10px; line-height: 24px;  font-family: '微软雅黑';"">
      订阅说明：去投标网每日收集发布全国招标采购信息超过10000条，平台为您免费推送一次全国各行业招标信息，登录官方平台可以设置追踪器获取更多精准的招标采购信息商业市场竞争激烈，愿您抓住每一个机会，您的成功是我们为之努力的心愿！ 
     <br />
     <br /> 以下是为您推选的招标信息（您也可以免费注册登录去投标网设置订阅关键词，获取更精准匹配的招标信息）： 
    </div> 
";
            string htmlbody = @"
    <table id=""bidinfoitem"" cellspacing=""0"" style=""width: 100%; border: 1px solid #dcdcdc;
                        margin-bottom: 10px;""> 
     <tbody>
      <tr> 
       <td style=""width: 70px; height: 110px; padding-left: 10px; text-align: center; line-height: 30px;
                                vert-align: middle; font-size: 12px;""> 2017-07-05 </td> 
       <td style=""width: 500px; line-height: 24px; padding: 5px; vertical-align: top;""> <span style=""background: #FFBB66; font-size: 9px; padding: 2px 5px 2px 5px; color: #fff;"">正在招标</span> <a href=""/BidDetail/757171.html"" target=""_blank"" style=""font-size: 14px;
                                    font-family: microsoft yahei; text-decoration: none; color: #000;""> [招标]郑州铁路局2017年全局桥梁用油漆采购项目招标公告</a><br /> 
        <div style=""color: #666; font-size: 12px; line-height: 24px; padding-right: 100px;
                                    padding-bottom: 2px;"">
          郑州铁路局2017年全局桥梁用油漆采购项目招标公告时间：2017-07-0520:15:09发布：杜瑞table{margin:0pxauto;text-ali...
        </div> <span style=""background-color: #fff; font-size: 12px; padding: 5px;""> 招标公告</span> <span style=""background-color: #fff; font-size: 12px; padding: 5px;""> 建筑工程</span> <span style=""background-color: #fff;
                                        font-size: 12px; padding: 5px;""> 河南省</span> </td> 
      </tr> 
     </tbody>
    </table> 
";
            string htmltail = @"
 <div style=""line-height: 24px; font-family: '微软雅黑'; padding: 10px; font-size: 14px;""> 
     <table> 
      <tbody>
       <tr> 
        <td style=""width: 200px;""> <img src=""http://www.gobiding.com/imgs/system/wx300_300.png"" width=""170"" /> </td> 
        <td> 扫一扫关注微信公众号即可手机微信订阅，万千商机，尽在掌握！<br /> 如有任何疑问或者建议请及时联系我们！<br /> 官方网址：http://www.gobiding.com<br /> 联系地址：上海市长宁区金钟路968号<br /> 微信公众号：去投标网<br /> 企业邮箱：postmaster@gobiding.com<br /> qq客服：2968038259<br /> </td> 
       </tr> 
      </tbody>
     </table> 
    </div> 
   </div> 
  </div> 
";

            string totalhtml = html + htmlbody + htmltail;
            ltrcontent.Text = totalhtml;
        }
        
        protected void Page_Load(object sender, EventArgs e)
        {
            test();
            Init();
        }

        public string GetBidCategoryNameValue(string categoryId)
        {
            if (!string.IsNullOrEmpty(categoryId))
            {
                var c = categorys.Where(o => o.BidCategoryId == int.Parse(categoryId)).FirstOrDefault();
                if (c == null)
                    return "其他";

                return c.BidCategoryName;
            }
            else
            {
                return "其他";
            }

        }

        public string GetProvinceName(string provinceId)
        {
            var model = new BLL.Provinces().GetModel(int.Parse(provinceId));
            if (model != null)
                return model.ProvinceName;

            return "";
        }

        public void Init()
        {
            List<Model.Bids> bidList = new List<Model.Bids>();

            List<SqlParameter> _params = new List<SqlParameter>
                                             {
                                                 new SqlParameter("@pageindex", 1),
                                                 new SqlParameter("@pagesize", 10)
                                             };
            categorys = new BLL.BidCategorys().GetModelList("");

            using (SqlDataReader reader = DbHelperSQL.RunProcedure("GetUserBidsList", _params.ToArray()))
            {

                while (reader.Read())
                {
                    var bid = new Model.Bids();
                    bid.BidId = reader.GetInt64(1);
                    bid.BidTitle = reader.GetString(2);
                    bid.BidNumber = reader.GetValue(7) == null ? "" : reader.GetValue(7).ToString();
                    bid.ProvinceId = reader.GetInt32(6);
                    bid.BidPublishTime = DateTime.Parse(reader.GetDateTime(3).ToString());
                    bid.BidType = reader.GetString(22);
                    bid.BidContent = CommonUtility.GetChineseCh(reader.GetString(4));
                    bid.BidCompanyName = reader.GetValue(27).ToString();
                    bid.CreateTime = DateTime.Parse(reader.GetDateTime(20).ToString());
                    bid.BidCategoryId = reader["BidCategoryId"].ToString() != "" ? Convert.ToInt32(reader["BidCategoryId"].ToString()) : 0;

                    bidList.Add(bid);
                }

                rptBidList.DataSource = bidList;
                rptBidList.DataBind();
            }
        }
    }
}