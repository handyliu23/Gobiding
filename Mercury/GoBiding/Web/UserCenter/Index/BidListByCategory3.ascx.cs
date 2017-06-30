using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GoBiding.Web.UserCenter.Index
{
    public partial class BidListByCategory3 : System.Web.UI.UserControl
    {
        public string CategoryName = "";
        public string CategoryEnglishName = "";
        public int CategoryId = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                var ds = new BLL.Bids().GetList(8, " bidtype = 1", "BidPublishTime desc");
                rptBidList.DataSource = ds;
                rptBidList.DataBind();

                ds = new BLL.Bids().GetList(8, " bidtype = 3", "BidPublishTime desc");
                rptBidResultList.DataSource = ds;
                rptBidResultList.DataBind();
                
            }
        }

        public string GetProvinceName(string provinceId)
        {
            var model = new BLL.Provinces().GetModel(int.Parse(provinceId));
            if (model != null)
                return model.ProvinceName;

            return "";
        }

        public string GetBidTypeValue(string bidtype)
        {
            switch (bidtype)
            {
                case "1":
                    return "招标公告";
                case "2":
                    return "变更公告";
                case "3":
                    return "中标公告";
                case "4":
                    return "招标预告";
                case "5":
                    return "中止公告";
                case "6":
                    return "邀请招标";
                case "7":
                    return "竞争性谈判";
                case "11":
                    return "采购公告";
            }

            return "招标公告";

        }

    }
}