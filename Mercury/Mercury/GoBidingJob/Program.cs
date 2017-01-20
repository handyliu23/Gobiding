using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Topshelf;
using log4net.Config;

namespace GoBidingJob
{
    class Program
    {
        static void Main(string[] args)
        {
            HostFactory.Run(x =>
            {
                //x.UseLog4Net();
                InitLog4Net();

                x.Service<ServiceRunner>();

                x.SetDescription("QuartzDemo服务描述");
                x.SetDisplayName("QuartzDemo服务显示名称");
                x.SetServiceName("QuartzDemo服务名称");

                x.EnablePauseAndContinue();
            });
        }

        private static void InitLog4Net()
        {
            var logCfg = new FileInfo(AppDomain.CurrentDomain.BaseDirectory + "log4net.config");
            XmlConfigurator.ConfigureAndWatch(logCfg);
        }
    }
}
