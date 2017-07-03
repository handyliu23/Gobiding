using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using System.Net;
using System.Text;
using System.IO;

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

        public wxUserInfo GetUserInfoByWXAccessToken()
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
                    var userInfo = GetUserInfoByWXAccessToken();

                    if (userInfo != null)
                    {
                        hdnUserNickName.Value = userInfo.nickname;
                        hdnAccessToken.Value = userInfo.access_token;
                        hdnOpenId.Value = userInfo.openid;
                        hdnGender.Value = userInfo.sex;
                        hdnProfile.Value = userInfo.headimgurl;
                    }
                }
                if (Request.Url.ToString().Contains("xl"))
                {
                    var userInfo = GetUserInfoByWLAccessToken();

                    if (userInfo != null)
                    {
                        hdnUserNickName.Value = userInfo.screen_name;
                        hdnAccessToken.Value = userInfo.access_token;
                        hdnOpenId.Value = userInfo.idstr;
                        hdnGender.Value = userInfo.gender == "m" ? "1":"2";
                        hdnProfile.Value = userInfo.profile_image_url;
                    }
                }
            }
            catch (Exception err)
            {
                BLL.Logger.Warn(err.Message, err.StackTrace);
            }


        }


        class wbtoken
        {
            public string access_token;
            public string expires_in;
            public string remind_in;
            public long uid;
        }

        //        {
        //      "access_token": "ACCESS_TOKEN",
        //      "expires_in": 1234,
        //      "remind_in":"798114",
        //      "uid":"12341234"
        //}
        public class wbUserInfo
        {
            public long id;
            public string idstr;
            public string screen_name;
            public string name;
            public string city;
            public string province;
            public string location;
            public string description;
            public string profile_image_url; //logo
            public string gender;   //m:男，f:女

            public string access_token;

        }

        public wbUserInfo GetUserInfoByWLAccessToken()
        {
            try
            {
                string appId = "1366921169";
                string secret = "b753d7e55fb8c65b16ba265d2f5a0fd2";
                //1.获取code
                if (Request.QueryString["Code"] == null)
                {
                    Response.Redirect(string.Format("https://api.weibo.com/oauth2/authorize?client_id={0}&response_type=code&redirect_uri=http%3A%2F%2Fwww.gobiding.com/ThirdLogin.aspx?opt=xl", appId));
                    return null;
                }

                var wc = new WebClient();

                //2.获取token
                string code = Request.QueryString["code"].ToString();
                string postdata = string.Format("client_id={0}&client_secret={2}&grant_type=authorization_code&code={1}&redirect_uri=http%3A%2F%2Fwww.gobiding.com/ThirdLogin.aspx?opt=xl", appId, code, secret);
                string url = "https://api.weibo.com/oauth2/access_token";
                var strReturn = HttpPost(url, postdata);

                wbtoken token = JsonConvert.DeserializeObject<wbtoken>(strReturn);
                BLL.Logger.Info("GetAccessToken", strReturn);

                //3.获取userInfo
                string getInfoUrl = string.Format("https://api.weibo.com/2/users/show.json?access_token={0}&uid={1}", token.access_token, token.uid);
                BLL.Logger.Info("GetUserInfo", getInfoUrl);

                byte[] myDataBuffer = wc.DownloadData(getInfoUrl);
                string getInfoReturn = System.Text.Encoding.UTF8.GetString(myDataBuffer);
                BLL.Logger.Info("GetUserInfoReturn", getInfoReturn);

                wbUserInfo userInfo = JsonConvert.DeserializeObject<wbUserInfo>(getInfoReturn);
                userInfo.access_token = token.access_token;
                return userInfo;
            }
            catch (Exception err)
            {
                BLL.Logger.Warn(err.Message, err.StackTrace);
                return null;
            }
        }

        /// <summary>
        /// 新浪获取token必须用post方法
        /// </summary>
        /// <param name="Url"></param>
        /// <param name="postDataStr"></param>
        /// <returns></returns>
        private string HttpPost(string Url, string postDataStr)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url);
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = Encoding.UTF8.GetByteCount(postDataStr);
            Stream myRequestStream = request.GetRequestStream();
            StreamWriter myStreamWriter = new StreamWriter(myRequestStream, Encoding.GetEncoding("gb2312"));
            myStreamWriter.Write(postDataStr);
            myStreamWriter.Close();

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            Stream myResponseStream = response.GetResponseStream();
            StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding("utf-8"));
            string retString = myStreamReader.ReadToEnd();
            myStreamReader.Close();
            myResponseStream.Close();

            return retString;
        }
    }
}