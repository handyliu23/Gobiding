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
    public partial class HighSchoolBid : System.Web.UI.Page
    {
        public string biddescription = "";
        public string title = "";  

        protected void Page_Load(object sender, EventArgs e)
        {
            int SHJTDX = new BLL.Bids().GetRecordCount(" BidCompanyName like '%上海交通大学%' ");
            int BJDX = new BLL.Bids().GetRecordCount(" BidCompanyName like '%北京大学%' ");
            int XAJTDX = new BLL.Bids().GetRecordCount(" BidCompanyName like '%西安交通大学%' ");
            int HZKJDX = new BLL.Bids().GetRecordCount(" BidCompanyName like '%华中科技大学%' ");
            int SCDX = new BLL.Bids().GetRecordCount(" BidCompanyName like '%四川大学%' ");
            int ZSDX = new BLL.Bids().GetRecordCount(" BidCompanyName like '%中山大学%' ");


            if (!IsPostBack)
            {
                lblSHJTDX.Text = SHJTDX.ToString();
                lblBJDX.Text = BJDX.ToString();
                lblHZKJDX.Text = HZKJDX.ToString();
                lblSCDX.Text = SCDX.ToString();
                lblZSDX.Text = ZSDX.ToString();
                lblXAJTDX.Text = XAJTDX.ToString();
                
            }
        }

        public void EncodeValueByRegex(Model.Bids bid, string regex)
        {
            var mathes = Regex.Matches(bid.BidContent, regex);
            if (mathes.Count > 0)
            {
                for (int i = 0; i < mathes.Count; i++)
                {
                    bid.BidContent = bid.BidContent.Replace(mathes[i].Value, "********");
                }
            }
        }

        public string EncodeValueByRegex(Model.Bids bid, List<string> regexitems)
        {
            Regex regex = null;
            MatchCollection matchs = null;

            foreach (var regexitem in regexitems)
            {
                regex = new Regex(regexitem, RegexOptions.None);

                matchs = regex.Matches(bid.BidContent);
                if (matchs.Count > 0)
                {
                    for (int i = 0; i < matchs.Count; i++)
                    {
                        if (matchs[i].Groups["v"].Value.Length > 3)
                            bid.BidContent = bid.BidContent.Replace(matchs[i].Groups["v"].Value, "********");
                    }
                }
            }

            return "";
        }
    }
}