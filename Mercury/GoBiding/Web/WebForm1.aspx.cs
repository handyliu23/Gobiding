using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using Newtonsoft.Json;

namespace GoBiding.Web
{
    public partial class WebForm1 : System.Web.UI.Page
    {

        class wbtoken
        {
            public string access_token;
            public string expires_in;
            public string remind_in;
            public string uid;
        }

        //        {
        //      "access_token": "ACCESS_TOKEN",
        //      "expires_in": 1234,
        //      "remind_in":"798114",
        //      "uid":"12341234"
        //}
        public class wbUserInfo
        {
            public string openid;
            public string nickname;
            public string sex;
            public string province;
            public string city;
            public string country;
            public string headimgurl;
            public string unionid;

            public string access_token;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Request.Url.ToString().Contains("wb"))
            {
                GetUserInfoByAccessToken();
            }
        }

        public wbUserInfo GetUserInfoByAccessToken()
        {
            string appId = "1366921169";
            string secret = "b753d7e55fb8c65b16ba265d2f5a0fd2";
            //1.获取code
            if (Request.QueryString["Code"] == null)
            {
                Response.Redirect(string.Format("https://api.weibo.com/oauth2/authorize?client_id={0}&response_type=code&redirect_uri=http%3A%2F%2Fwww.gobiding.com/WebForm1.aspx", appId));
                return null;
            }

            var wc = new WebClient();

            //2.获取token
            string code = Request.QueryString["code"].ToString();
            string tokenUrl = string.Format("https://api.weibo.com/oauth2/access_token?client_id={0}&client_secret={2}&grant_type=authorization_code&code={1}&redirect_uri=http%3A%2F%2Fwww.gobiding.com/WebForm1.aspx", appId, code, secret);
            BLL.Logger.Info("tokenUrl", tokenUrl);
            var strReturn = wc.DownloadString(tokenUrl);
            wbtoken token = JsonConvert.DeserializeObject<wbtoken>(strReturn);
            BLL.Logger.Info("GetAccessToken", strReturn);

            //3.获取userInfo
            string getInfoUrl = string.Format("https://api.weibo.com/2/users/show.json?access_token={0}&lang=en", token.access_token);
            byte[] myDataBuffer = wc.DownloadData(getInfoUrl);
            string getInfoReturn = System.Text.Encoding.UTF8.GetString(myDataBuffer);
            BLL.Logger.Info("GetUserInfoReturn", getInfoReturn);

            wbUserInfo userInfo = JsonConvert.DeserializeObject<wbUserInfo>(getInfoReturn);
            userInfo.access_token = token.access_token;
            return userInfo;
        }
    }
}