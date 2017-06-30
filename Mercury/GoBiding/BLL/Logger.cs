using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoBiding.BLL
{
    public static class Logger
    {
        public static void Info(string title, string msg)
        {
            Model.SystemLog log = new Model.SystemLog();
            log.CreateTime = DateTime.Now;
            log.AppName = "GoBiding";
            log.LogType = "Info";
            log.Message = msg;
            log.Platform = "PC";
            log.Remark = "";
            log.Title = title;

            new BLL.SystemLog().Add(log);
        }

        public static void Warn(string title, string msg)
        {
            Model.SystemLog log = new Model.SystemLog();
            log.CreateTime = DateTime.Now;
            log.AppName = "GoBiding";
            log.LogType = "Warn";
            log.Message = msg;
            log.Platform = "PC";
            log.Remark = "";
            log.Title = title;

            new BLL.SystemLog().Add(log);
        }

        public static void Error(string title, string msg)
        {
            Model.SystemLog log = new Model.SystemLog();
            log.CreateTime = DateTime.Now;
            log.AppName = "GoBiding";
            log.LogType = "Error";
            log.Message = msg;
            log.Platform = "PC";
            log.Remark = "";
            log.Title = title;

            new BLL.SystemLog().Add(log);
        }
    }
}
