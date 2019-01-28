using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using Common;

namespace WEB.Config
{
    public class WebConfig
    {
        public static string GetConnStr {
            get {
                return ConfigurationManager.AppSettings["ConnStr"];
            }
        }
        /// <summary>
        /// 默认登录ID
        /// </summary>
        public static string DefaultLoginID {
            get {
                return ConfigHelper.GetConfigString("DefaultLoginID");
            }
        }

        public static string Pass {
            get {
                return ConfigHelper.GetConfigString("Pass");
            }
        }

        /// <summary>
        /// 附件文件目录
        /// </summary>
        public static string AttachmentFileFoler
        {
            get
            {
                return ConfigHelper.GetConfigString("AttachmentFileFoler");
            }
        }
    }
}