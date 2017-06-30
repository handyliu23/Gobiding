using System.Collections.Generic;

namespace GoBiding.Model
{
    public class SiteSessionInfo
    {
        public SiteSessionInfo()
        {
            Init();
        }

        public void Init()
        {
            sAdmin = null;
            sCustomer = null;
            sampleViewState = null;
            //Captcha = AppConst.StringNull;
        }

        //增加一个对象, 保存管理员信息
        public Model.Sys_Users sAdmin;

        public Model.Sys_Users sCustomer;
        public string sampleViewState;

        //public SOInfo sSOTemp=null;
        //public Dictionary<int, SOInfo> sSO = new Dictionary<int, SOInfo>();
        //public SQInfo sQO;
        //public SOInfo sFVP;

        //public ArrayList BrowseHistoryList; //value = productinfo
        //public string Captcha; //验证码
    }
}
