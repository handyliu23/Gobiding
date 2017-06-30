using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using Newtonsoft.Json;

namespace GoBiding.Web
{
    public class User_info
    {
        public string OpenID { get; set; }//用户唯一appid

        public string Name { get; set; }

        public string img_qq50 { get; set; } //QQ图像40*40

        public string img_qq100 { get; set; }

        public string city { get; set; }

        public int year { get; set; }
    }

    public class a
    {

        public string client_id { get; set; }

        public string openid { get; set; }
    }

    public class QQ_Login
    {

        public static string appkey = "3caf0ee3686b46b3def77c9499fa0de9"; //app key
        public static string appid = "100545710";

        string Return_url = "http://localhost:58434/oauth/Auth.aspx";
        public string Authorize()
        {
            string state = new Random(100000).Next(99, 99999).ToString();//随机数
            string url = string.Format("https://graph.qq.com/oauth2.0/authorize?response_type=code&client_id={0}&redirect_uri={1}&state={2}", appid, Return_url, state);
            string str = "<script> location.href='" + url + "'</script>";
            return str;

        }

        #region 请求ACCESS的Token
        /// <summary>  
        /// 请求ACCESS的Token  
        /// </summary>  
        /// <param name="oauth_token_secret">获得授权临时Token的时候获得的密钥</param>  
        /// <returns>返回ACCess Token</returns>  
        public static string GetAccessToken(string oauth_code)
        {
            string thisquestadd = "https://graph.qq.com/oauth2.0/token";
            string token_parameter = "grant_type=authorization_code&client_id=" + appid + "&client_secret=" + appkey + "&code=" + oauth_code + "&redirect_uri=http://www.1189.tv";
            string url = string.Format("{0}?{1}", thisquestadd, token_parameter);
            string QQreturnstr = RequestUrl(url);
            return QQreturnstr;
        }
        #endregion

        #region 请求ACCESS的OpenID
        /// <summary>  
        /// 请求ACCESS的OpenID  
        /// </summary>  
        /// <param name="Access Token">使用Access Token来获取用户的OpenID</param>  
        /// <returns>返回OpenID</returns>  
        public static string GetAccessOpenID(string AccessToken)
        {
            string thisquestadd = "https://graph.qq.com/oauth2.0/me";
            string token_parameter = "access_token=" + AccessToken;
            string url = string.Format("{0}?{1}", thisquestadd, token_parameter);
            string QQreturnstr = RequestUrl(url);
            return QQreturnstr;
        }
        #endregion

        #region 获得用户信息的API
        /// <summary>  
        /// 获得用户信息的API  
        /// </summary>  
        /// <param name="oauth_token">Access token 请求是返回的</param>  
        /// <param name="openid">Access token 请求是返回的 openid</param>  
        /// <returns>XML</returns>  
        public static string GetQQUserInfo(string oauth_token, string openid)
        {
            string QQreturnstr = RequestUrl("https://graph.qq.com/user/get_user_info?access_token=" + oauth_token + "&oauth_consumer_key=" + appid + "&openid=" + openid);
            return QQreturnstr;
        }
        #endregion  

        /// <summary>  
        /// 将认证获得的参数简单转化为哈希表  
        /// </summary>  
        /// <param name="varstr">获得参数的字符串</param>  
        /// <returns></returns>  
        public static Hashtable Str2Hash(string varstr)
        {
            Hashtable myhash = new Hashtable();
            if (varstr.Trim() != string.Empty)
            {
                string[] temparr = varstr.Split('&');
                foreach (string onevarstr in temparr)
                {
                    string[] onevararr = onevarstr.Split('=');
                    myhash.Add(onevararr[0], onevararr[1]);
                }
                return myhash;
            }
            else
            {
                return null;
            }
        }  

        /// <summary>  
        /// 请求指定url地址并返回结果  
        /// </summary>  
        /// <param name="url"></param>  
        /// <returns></returns>  
        public static string RequestUrl(string url)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.MaximumAutomaticRedirections = 3;
            request.Timeout = 0x2710;
            Stream responseStream = ((HttpWebResponse)request.GetResponse()).GetResponseStream();
            StreamReader reader = new StreamReader(responseStream);
            string str = reader.ReadToEnd();
            reader.Close();
            responseStream.Close();
            return str;
        }  

        public User_info Back_User(string code)
        {
            return null;

            //string state = new Random(100000).Next(99, 99999).ToString();//随机数
            //User_info ui = new User_info();
            //string url = string.Format("https://graph.qq.com/oauth2.0/token?grant_type=authorization_code&client_id={0}&client_secret={1}&code={2}&redirect_uri={3}&state={4}", client_id, appid, code, Return_url, state);
            //string uu = new HttpProc().HtmlFromUrlGet(url));//处理http请求帮助类
            //string code1 = uu.Split('&')[0].Split('=')[1].ToString();//获得access_token

            ////根基access_token获取用户唯一OpenID
            //string url_me = string.Format("https://graph.qq.com/oauth2.0/me?access_token={0}", code1);
            //string callback = HttpProc.HtmlFromUrlGet(url_me);//这里获取的
            //callback = callback.Substring(callback.IndexOf('(') + 1, (callback.IndexOf(')') - callback.IndexOf('(') - 1)).Trim();
            //// dynamic jsonP = JValue.FromObject(callback); //这里我用的是一个序列化类库 Newtonsoft.Json.dll 6.0.4版本无奈公司版本过低 只能用4.0的版本 建议使用6.0.4版本
            //a jsonP = JsonConvert.DeserializeObject<a>(callback);//Newtonsoft.Json.dll 4.0或4.5版本
            //string OpenID = jsonP.openid;//获取用户唯一的OpenID 


        }

    }
}