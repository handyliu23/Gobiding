using System;

namespace GoBiding.Model
{
    public class AuthenticationSessionInfo
    {
        public AuthenticationSessionInfo()
        {
            Init();
        }

        public void Init()
        {
            AuthenticationHoldTime = DateTime.MinValue;
            //Captcha = AppConst.StringNull;
        }

        public DateTime AuthenticationHoldTime;
        //public SOInfo sSO;

        //public ArrayList BrowseHistoryList; //value = productinfo
        //public string Captcha; //验证码
    }
}
