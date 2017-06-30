using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using System.Net;

namespace GoBiding.Web
{
    public partial class ThirdLogin : System.Web.UI.Page
    {
        string grant_type = "authorization_code"; //"client_credential";
        string appid = "wx81f6ea9d32b5e8ef";
        string secret = "d1dab694ed0abe145e3cf4fd2fca3ff7";

        class wxtoken
        {
            public string access_token;
            public string expires_in;
            public string openid;
        }

        public class wxUserInfo
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

        public wxUserInfo GetUserInfoByAccessToken()
        {
            //1.获取code
            if (Request.QueryString["Code"] == null)
            {
                Response.Redirect(string.Format("https://open.weixin.qq.com/connect/qrconnect?appid={0}&redirect_uri=http%3A%2F%2Fwww.gobiding.com/ThirdLogin.aspx?opt=wx&response_type=code&scope=snsapi_login&state=STATE", appid));
                return null;
            }
            var wc = new WebClient();

            //2.获取token
            string tokenUrl = string.Format("https://api.weixin.qq.com/sns/oauth2/access_token?grant_type={0}&appid={1}&secret={2}&code={3}", grant_type, appid, secret, Request.QueryString["Code"].ToString());
            BLL.Logger.Info("tokenUrl", tokenUrl);
            var strReturn = wc.DownloadString(tokenUrl);
            wxtoken token = JsonConvert.DeserializeObject<wxtoken>(strReturn);
            BLL.Logger.Info("GetAccessToken", strReturn);

            //3.获取userInfo

            string getInfoUrl = string.Format("https://api.weixin.qq.com/sns/userinfo?access_token={0}&openid={1}&lang=en", token.access_token, token.openid);
            byte[] myDataBuffer = wc.DownloadData(getInfoUrl);
            string getInfoReturn = System.Text.Encoding.UTF8.GetString(myDataBuffer);
            BLL.Logger.Info("GetUserInfoReturn", getInfoReturn);

            wxUserInfo userInfo = JsonConvert.DeserializeObject<wxUserInfo>(getInfoReturn);
            userInfo.access_token = token.access_token;
            return userInfo;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Request.Url.ToString().Contains("wx"))
                {
                    var userInfo = GetUserInfoByAccessToken();

                    if (userInfo != null)
                    {
                        hdnUserNickName.Value = userInfo.nickname;
                        hdnAccessToken.Value = userInfo.access_token;
                        hdnOpenId.Value = userInfo.openid;
                        hdnGender.Value = userInfo.sex;
                        hdnProfile.Value = userInfo.headimgurl;
                    }
                }
            }
            catch (Exception err)
            {
                BLL.Logger.Warn(err.Message, err.StackTrace);
            }


        }
    }
}