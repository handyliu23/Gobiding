using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GoBiding.Web.UserCenter.Index
{
    public partial class BidListBySchool : System.Web.UI.UserControl
    {
        public string CategoryName = "";
        public string CategoryEnglishName = "";
        public int CategoryId = 0;

        string huadongprovinces = "(9,10,11,12,13,14,15)";
        string huabeiprovinces = "(1,2,3,4,5)";
        string huananprovinces = "(19,20,21)";
        string huazhongprovinces = "(16,17,18)";
        string xinanprovinces = "(22,23,24,25,26)";
        string xibeiprovinces = "(27,28,29,30,31)";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string provinces = "";

                if (CategoryId == 1)
                {
                    provinces = huadongprovinces;
                }
                else if (CategoryId == 2)
                {
                    provinces = huabeiprovinces;
                }
                if (CategoryId == 3)
                {
                    provinces = huananprovinces;
                }
                else if (CategoryId == 4)
                {
                    provinces = huazhongprovinces;
                }
                if (CategoryId == 5)
                {
                    provinces = xinanprovinces;
                }
                else if (CategoryId == 6)
                {
                    provinces = xibeiprovinces;
                }
             
                var ds = new BLL.Bids().GetList(6, string.Format(" provinceId in {0} and bidCompanyName like '%大学'", provinces), "BidPublishTime desc");
                rptBidList.DataSource = ds;
                rptBidList.DataBind();

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