using System.Diagnostics;
using System.Net.Configuration;
using Maticsoft.Common;
using Mercury.BLL;
using log4net;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace GoBidingJob
{
    public sealed class SpiderJob : IJob
    {
        private readonly ILog _logger = LogManager.GetLogger(typeof(SpiderJob));
        private Mercury.BLL.Sys_Users userService = new Sys_Users();
        private Mercury.BLL.Bids bidService = new Bids();
        private Mercury.BLL.Sys_UserTrackers trackerService = new Sys_UserTrackers();
        private Mercury.BLL.Provinces provinceService = new Provinces();
        private Mercury.BLL.BidCategorys industryService = new BidCategorys();
        private Mercury.BLL.Spiders spidersService = new Spiders();
        private Mercury.BLL.Hearts heartsService = new Hearts();

        public void Execute(IJobExecutionContext context)
        {
            _logger.InfoFormat("SendSubscribeBids Job start.");

            var heart = heartsService.GetModel(1);
            if (DateTime.Now > heart.HeartTime.Value.AddMinutes(5))
            {
                //启动爬虫
                DataSet ds = spidersService.GetList(1, "", "LastRunTime desc");

                int spiderId = 1;
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    spiderId = int.Parse(ds.Tables[0].Rows[0]["SpiderId"].ToString());
                }

                string[] arg = new string[1];
                arg[0] = spiderId.ToString();
                StartProcess(@"C:/Mercury/Mercury/Mercury/MercurySpider/bin/Debug/MercurySpider.exe", arg);
            }

        }

        public bool StartProcess(string filename, string[] args)
        {
            try
            {
                string s = "";
                foreach (string arg in args)
                {
                    s = s + arg + " ";
                }
                s = s.Trim();
                Process myprocess = new Process();
                ProcessStartInfo startInfo = new ProcessStartInfo(filename, s);
                myprocess.StartInfo = startInfo;

                //通过以下参数可以控制exe的启动方式，具体参照 myprocess.StartInfo.下面的参数，如以无界面方式启动exe等
                myprocess.StartInfo.UseShellExecute = false;
                myprocess.Start();
                return true;
            }
            catch (Exception ex)
            {
            }
            return false;
        }

    }
}
