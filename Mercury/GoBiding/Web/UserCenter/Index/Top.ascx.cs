﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GoBiding.Web.UserCenter.Index
{
    public partial class Top : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserSessionId"] != null)
            {
                pubInfo.InnerText = "会员管理中心";
            }
        }
    }
}