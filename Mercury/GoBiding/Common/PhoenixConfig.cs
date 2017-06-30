using System;
using System.Collections.Generic;
using System.Configuration;
using System.Runtime.Caching;

namespace Maticsoft.Common
{
    /// <summary>
    /// Summary description for AppConfig.
    /// </summary>
    public class PhoenixConfig
    {

        private PhoenixConfig()
        {
        }

        public static string ConnectionString
        {
            get { return ConfigurationManager.AppSettings["DBConn"]; }
        }

        public static CommonConfig Common
        {
            get
            {
                if (_cache[CacheKey] == null)
                    Init();

                var m = _cache[CacheKey] as ConfigBox;
                return m.Common;
            }
        }

        public static WebConfig Web
        {
            get
            {
                if (_cache[CacheKey] == null)
                    Init();

                var m = _cache[CacheKey] as ConfigBox;
                return m.Web;
            }
        }

        public static MailConfig Mail
        {
            get
            {
                if (_cache[CacheKey] == null)
                    Init();

                var m = _cache[CacheKey] as ConfigBox;
                return m.Mail;
            }
        }

        public static ArtworkConfig Artwork
        {
            get
            {
                if (_cache[CacheKey] == null)
                    Init();

                var m = _cache[CacheKey] as ConfigBox;
                return m.Artwork;
            }
        }

        public static IPAccessConfig IPAccess
        {
            get
            {
                if (_cache[CacheKey] == null)
                    Init();

                var m = _cache[CacheKey] as ConfigBox;
                return m.IPAccess;
            }
        }

        public static ImprintExcludeConfig ImprintExclude
        {
            get
            {
                if (_cache[CacheKey] == null)
                    Init();

                var m = _cache[CacheKey] as ConfigBox;
                return m.ImprintExclude;
            }
        }

        public static AnypromoFilePathConfig AnypromoFilePath
        {
            get
            {
                if (_cache[CacheKey] == null)
                    Init();

                var m = _cache[CacheKey] as ConfigBox;
                return m.AnypromoFilePath;
            }
        }

        private const string CacheKey = "PhoenixConfig";
        private static readonly object InitLock = new object();
        private static readonly ObjectCache _cache = MemoryCache.Default;

        private static void Init()
        {
            lock (InitLock)
            {
                if (_cache[CacheKey] == null)
                {
                    //初始化
                    string configFileName = Util.GetAbsoluteFilePath(ConfigurationManager.AppSettings["MyConfigFile"]);

                    var config = ConfigurationManager.OpenMappedMachineConfiguration(
                        new ConfigurationFileMap {MachineConfigFilename = configFileName}
                        );
                    var section1 = (TopSection) config.GetSection("top");


                    var newC = new ConfigBox(section1);

                    //配置依赖关系
                    var fileToBeMonitored = new List<string> {configFileName};
                    var policy = new CacheItemPolicy();
                    policy.ChangeMonitors.Add(new HostFileChangeMonitor(fileToBeMonitored));

                    _cache.Set(CacheKey, newC, policy);
                }
            }
        }

        public static string ToString(NameValueConfigurationCollection nvc, string name)
        {
            //如果属性值name在config文件中不存在（拼写大小写错误），会报错。
            var val = nvc[name].Value;
            if (val == "")
                throw new Exception(string.Format("{0} is empty but required, please check config file", name));
            if (val == "---")
            {
                val = "";
            }
            return val;
        }

        public static int ToInt32(NameValueConfigurationCollection nvc, string name)
        {
            var val = nvc[name].Value;
            if (val == "")
                throw new Exception(string.Format("{0} is empty but required, please check config file", name));

            int m;
            if (!Int32.TryParse(val, out m))
                throw new Exception(string.Format("{0} should be an interger, plase check config file", name));
            return m;
        }

        public static bool ToBool(NameValueConfigurationCollection nvc, string name)
        {
            var val = nvc[name].Value;
            if (val == "")
                throw new Exception(string.Format("{0} is empty but required, please check config file", name));

            if (val.ToLower() == "true" || val == "1")
                return true;
            else
            {
                return false;
            }
        }
    }


    public class ConfigBox
    {
        public ConfigBox(TopSection top)
        {
            Common = new CommonConfig(top.CommonNVC);
            Web = new WebConfig(top.WebNVC);
            Mail = new MailConfig(top.MailNVC);
            Artwork = new ArtworkConfig(top.ArtworkNVC, Common.BaseDir);
            IPAccess = new IPAccessConfig(top.IPAccessNVC);
            ImprintExclude = new ImprintExcludeConfig(top.ImprintExcludeNVC);
            AnypromoFilePath = new AnypromoFilePathConfig(top.AnypromoFilePathNVC);
        }

        public CommonConfig Common { get; set; }
        public WebConfig Web { get; set; }
        public MailConfig Mail { get; set; }
        public ArtworkConfig Artwork { get; set; }
        public IPAccessConfig IPAccess { get; set; }
        public ImprintExcludeConfig ImprintExclude { get; set; }
        public AnypromoFilePathConfig AnypromoFilePath { get; set; }
    }

    public class CommonConfig
    {
        private NameValueConfigurationCollection nvc;

        public CommonConfig(NameValueConfigurationCollection nvcc)
        {
            nvc = nvcc;
        }

        public string BaseDir
        {
            get { return PhoenixConfig.ToString(nvc, "baseDir"); }
        }

        public string ProductImagePhysicalPath
        {
            get { return BaseDir+PhoenixConfig.ToString(nvc, "productImagePhysicalPath"); }
        }

        public string ProductImageFtpPath
        {
            get { return BaseDir+PhoenixConfig.ToString(nvc, "productImageFtpPath"); }
        }

        public bool IsBackgroundJobRun
        {
            get { return PhoenixConfig.ToBool(nvc, "isBackgroundJobRun"); }
        }

        public string ProductImageUrlPath
        {
            get { return PhoenixConfig.ToString(nvc, "productImageUrlPath"); }
        }

        public string CategoryImageUrlPath
        {
            get { return PhoenixConfig.ToString(nvc, "categoryImageUrlPath"); }
        }

        public string EmlFolder
        {
            get { return BaseDir + PhoenixConfig.ToString(nvc, "emlFolder"); }
        }

        public string EmlUrl
        {
            get { return PhoenixConfig.ToString(nvc, "emlUrl"); }
        }

        public string SampleCAS
        {
            get { return PhoenixConfig.ToString(nvc, "sampleCAS"); }
        }

        public string BoxNetApikey
        {
            get { return PhoenixConfig.ToString(nvc, "boxNetApikey"); }
        }

        public string BoxNetAuthtoken
        {
            get { return PhoenixConfig.ToString(nvc, "boxNetAuthtoken"); }
        }

        public string ToPDFFolder
        {
            get { return PhoenixConfig.ToString(nvc, "toPDFFolder"); }
        }

        public string ToPDFExe
        {
            get { return PhoenixConfig.ToString(nvc, "toPDFExe"); }
        }

        public string ToPDFUrl
        {
            get { return PhoenixConfig.ToString(nvc, "toPDFUrl"); }
        }

        public string CeleDataCachePath
        {
            get { return PhoenixConfig.ToString(nvc, "celeDataCachePath"); }
        }

        public string CeleFeedUpdatePath
        {
            get { return PhoenixConfig.ToString(nvc, "celeFeedUpdatePath"); }
        }

        public string Seven7zPath
        {
            get { return PhoenixConfig.ToString(nvc, "seven7zPath"); }
        }

        public string FreeShipStartTime
        {
            get { return PhoenixConfig.ToString(nvc, "freeShipStartTime"); }
        }

        public int FreeShipAmount
        {
            get { return PhoenixConfig.ToInt32(nvc, "freeShipAmount"); }
        }

        public string XtraReportFolder
        {
            get { return PhoenixConfig.ToString(nvc, "xtraReportFolder"); }
        }

        public string XtraReportUrl
        {
            get { return PhoenixConfig.ToString(nvc, "xtraReportUrl"); }
        }

        public int IsAnyPromo
        {
            get { return PhoenixConfig.ToInt32(nvc, "isAnyPromo"); }
        }

        public string AuthorizeApiLogin
        {
            get { return PhoenixConfig.ToString(nvc, "authorizeApiLogin"); }
        }

        public string AuthorizeTransactionKey
        {
            get { return PhoenixConfig.ToString(nvc, "authorizeTransactionKey"); }
        }

        public bool AuthorizeTestMode
        {
            get { return PhoenixConfig.ToBool(nvc, "authorizeTestMode"); }
        }

        public string GeoLitePath
        {
            get { return PhoenixConfig.ToString(nvc, "geoLitePath"); }
        }
    }

    public class IPAccessConfig
    {
        private NameValueConfigurationCollection nvc;

        public IPAccessConfig(NameValueConfigurationCollection nvcc)
        {
            nvc = nvcc;
        }

        public bool IsLog
        {
            get { return PhoenixConfig.ToBool(nvc, "isLog"); }
        }

        public bool IsQueueToSQL
        {
            get { return PhoenixConfig.ToBool(nvc, "isQueueToSQL"); }
        }

        public bool IsBanIP
        {
            get { return PhoenixConfig.ToBool(nvc, "isBanIP"); }
        }

        public int Level1Count
        {
            get { return PhoenixConfig.ToInt32(nvc, "level1Count"); }
        }

        public int Level1ExpireHours
        {
            get { return PhoenixConfig.ToInt32(nvc, "level1ExpireHours"); }
        }

        public int Level2Count
        {
            get { return PhoenixConfig.ToInt32(nvc, "level2Count"); }
        }

        public int Level2ExpireHours
        {
            get { return PhoenixConfig.ToInt32(nvc, "level2ExpireHours"); }
        }

        public int Level3Count
        {
            get { return PhoenixConfig.ToInt32(nvc, "level3Count"); }
        }

        public int IPWhiteListAutoClearIntervalPerMin
        {
            get { return PhoenixConfig.ToInt32(nvc, "ipWhiteListAutoClearIntervalPerMin"); }
        }
    }

    public class ArtworkConfig
    {
        private NameValueConfigurationCollection nvc;
        private string baseDir;

        public ArtworkConfig(NameValueConfigurationCollection nvcc, string _baseDir)
        {
            baseDir = _baseDir;
            nvc = nvcc;
        }

        public string ArtworkOriginFolder
        {
            get { return baseDir + PhoenixConfig.ToString(nvc, "artworkOriginFolder"); }
        }

        public string ArtworkWebPicFolder
        {
            get { return baseDir + PhoenixConfig.ToString(nvc, "artworkWebPicFolder"); }
        }

        public string ArtworkWebPicUrl
        {
            get { return PhoenixConfig.ToString(nvc, "artworkWebPicUrl"); }
        }

        public string ArtworkOriginUrl
        {
            get { return PhoenixConfig.ToString(nvc, "artworkOriginUrl"); }
        }

        public string SilverLightSSLVisitWay
        {
            get { return PhoenixConfig.ToString(nvc, "silverLightSSLVisitWay"); }
        }

        public string ArtworkConvertExe
        {
            get { return PhoenixConfig.ToString(nvc, "artworkConvertExe"); }
        }
    }

    public class WebConfig
    {
        private NameValueConfigurationCollection nvc;

        public WebConfig(NameValueConfigurationCollection nvcc)
        {
            nvc = nvcc;
        }

        public bool IsLiveServer
        {
            get { return PhoenixConfig.ToBool(nvc, "isLiveServer"); }
        }

        public string LiveServerName
        {
            get { return PhoenixConfig.ToString(nvc, "liveServerName"); }
        }

        public string LandingPagePath
        {
            get { return PhoenixConfig.ToString(nvc, "landingPagePath"); }
        }

        public string LogoPath
        {
            get { return PhoenixConfig.ToString(nvc, "logoPath"); }
        }

        public string MinLogoPath
        {
            get { return PhoenixConfig.ToString(nvc, "minLogoPath"); }
        }

        public string GoogleAnalyticsTrackingID
        {
            get { return PhoenixConfig.ToString(nvc, "googleAnalyticsTrackingID"); }
        }

        public string GoogleConversionSO
        {
            get { return PhoenixConfig.ToString(nvc, "googleConversionSO"); }
        }

        public string GoogleConversionSMO
        {
            get { return PhoenixConfig.ToString(nvc, "googleConversionSMO"); }
        }

        public string GoogleConversionQO
        {
            get { return PhoenixConfig.ToString(nvc, "googleConversionQO"); }
        }
    }

    public class MailConfig
    {
        private NameValueConfigurationCollection nvc;

        public MailConfig(NameValueConfigurationCollection nvcc)
        {
            nvc = nvcc;
        }

        public string SmtpServer
        {
            get { return PhoenixConfig.ToString(nvc, "smtpServer"); }
        }

        public int SmtpPort
        {
            get { return PhoenixConfig.ToInt32(nvc, "smtpPort"); }
        }

        public bool SmtpSSL
        {
            get { return PhoenixConfig.ToBool(nvc, "smtpSSL"); }
        }

        public bool IsSendEmail
        {
            get { return PhoenixConfig.ToBool(nvc, "isSendEmail"); }
        }
    }

    public class ImprintExcludeConfig
    {
        private NameValueConfigurationCollection nvc;

        public ImprintExcludeConfig(NameValueConfigurationCollection nvcc)
        {
            nvc = nvcc;
        }

        public string ASI
        {
            get { return PhoenixConfig.ToString(nvc, "asi"); }
        }

        public string Method
        {
            get { return PhoenixConfig.ToString(nvc, "method"); }
        }

        public string Message
        {
            get { return PhoenixConfig.ToString(nvc, "message"); }
        }

        public string MessageEmbroidery
        {
            get { return PhoenixConfig.ToString(nvc, "messageEmbroidery"); }
        }

        public string MessageSilkscreen
        {
            get { return PhoenixConfig.ToString(nvc, "messageSilkscreen"); }
        }
    }

    public class AnypromoFilePathConfig
    {
        public NameValueConfigurationCollection nvc;

        public AnypromoFilePathConfig(NameValueConfigurationCollection nvcc)
        {
            nvc = nvcc;
        }

        public string BaseRoot
        {
            get { return PhoenixConfig.ToString(nvc, "baseRoot"); }
        }
        public string OldBaseRoot
        {
            get { return PhoenixConfig.ToString(nvc, "oldBaseRoot"); }
        }
        public string CacheDuration
        {
            get { return PhoenixConfig.ToString(nvc, "cacheDuration"); }
        }
     
    }

    public class TopSection : ConfigurationSection
    {
        [ConfigurationProperty("common", IsDefaultCollection = false)]
        public NameValueConfigurationCollection CommonNVC
        {
            get { return (NameValueConfigurationCollection) base["common"]; }
            set { base["common"] = value; }
        }

        [ConfigurationProperty("web", IsDefaultCollection = false)]
        public NameValueConfigurationCollection WebNVC
        {
            get { return (NameValueConfigurationCollection) base["web"]; }
            set { base["web"] = value; }
        }

        [ConfigurationProperty("mail", IsDefaultCollection = false)]
        public NameValueConfigurationCollection MailNVC
        {
            get { return (NameValueConfigurationCollection) base["mail"]; }
            set { base["mail"] = value; }
        }

        [ConfigurationProperty("artwork", IsDefaultCollection = false)]
        public NameValueConfigurationCollection ArtworkNVC
        {
            get { return (NameValueConfigurationCollection) base["artwork"]; }
            set { base["artwork"] = value; }
        }

        [ConfigurationProperty("ipAccess", IsDefaultCollection = false)]
        public NameValueConfigurationCollection IPAccessNVC
        {
            get { return (NameValueConfigurationCollection) base["ipAccess"]; }
            set { base["ipAccess"] = value; }
        }

        [ConfigurationProperty("imprintExclude", IsDefaultCollection = false)]
        public NameValueConfigurationCollection ImprintExcludeNVC
        {
            get { return (NameValueConfigurationCollection) base["imprintExclude"]; }
            set { base["imprintExclude"] = value; }
        }

        [ConfigurationProperty("anypromoFilePath", IsDefaultCollection = false)]
        public NameValueConfigurationCollection AnypromoFilePathNVC
        {
            get { return (NameValueConfigurationCollection) base["anypromoFilePath"]; }
            set { base["anypromoFilePath"] = value; }
        }
    }
}
