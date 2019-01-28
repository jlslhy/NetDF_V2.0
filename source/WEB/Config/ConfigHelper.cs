using System;
using System.Configuration;
using Common;

namespace WEB.Config
{
	/// <summary>
	/// web.config操作类
    /// Copyright (C) 
	/// </summary>
	public sealed class ConfigHelper
	{

 
        /// <summary>
        /// 后台首页地址
        /// </summary>
        public static string BackgroundFirstPage
        {
            get
            {
                return GetConfigString("BackgroundFirstPage");
            }
        }

        /// <summary>
        /// 是否在开发测试
        /// </summary>
        public static bool IsDebug
        {
            get
            {
                return GetConfigBool("IsDebug");
            }

        }


		/// <summary>
		/// 得到AppSettings中的配置字符串信息
		/// </summary>
		/// <param name="key"></param>
		/// <returns></returns>
		public static string GetConfigString(string key)
		{
            string CacheKey = "AppSettings-" + key;
            object objModel = DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = ConfigurationManager.AppSettings[key]; 
                    if (objModel != null)
                    {                        
                        DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(180), TimeSpan.Zero);
                    }
                }
                catch
                { }
            }
            return objModel.ToString();
		}


       


		/// <summary>
		/// 得到AppSettings中的配置Bool信息
		/// </summary>
		/// <param name="key"></param>
		/// <returns></returns>
		public static bool GetConfigBool(string key)
		{
			bool result = false;
			string cfgVal = GetConfigString(key);
			if(null != cfgVal && string.Empty != cfgVal)
			{
				try
				{
					result = bool.Parse(cfgVal);
				}
				catch(FormatException)
				{
					// Ignore format exceptions.
				}
			}
			return result;
		}
		/// <summary>
		/// 得到AppSettings中的配置Decimal信息
		/// </summary>
		/// <param name="key"></param>
		/// <returns></returns>
		public static decimal GetConfigDecimal(string key)
		{
			decimal result = 0;
			string cfgVal = GetConfigString(key);
			if(null != cfgVal && string.Empty != cfgVal)
			{
				try
				{
					result = decimal.Parse(cfgVal);
				}
				catch(FormatException)
				{
					// Ignore format exceptions.
				}
			}

			return result;
		}
		/// <summary>
		/// 得到AppSettings中的配置int信息
		/// </summary>
		/// <param name="key"></param>
		/// <returns></returns>
		public static int GetConfigInt(string key)
		{
			int result = 0;
			string cfgVal = GetConfigString(key);
			if(null != cfgVal && string.Empty != cfgVal)
			{
				try
				{
					result = int.Parse(cfgVal);
				}
				catch(FormatException)
				{
					// Ignore format exceptions.
				}
			}

			return result;
        }

        /// <summary>
        /// 日志记录到文件
        /// </summary>
        public static bool LogToFile {
            get {
                return GetConfigBool("LogToFile");
            }
        }

        /// <summary>
        /// 日志记录到数据库
        /// </summary>
        public static bool LogToDB {
            get {
                return GetConfigBool("LogToDB");
            }
        }
        


        #region XmlConfig 配置值

        public static string GetXmlSystemConfig(string KeyPath, string Key)
        {
            return XmlHelper.GetValue(System.Web.HttpContext.Current.Server.MapPath(GetConfigString("SystempConfigFile")),KeyPath,Key);
        }

        public static string GetXmlSystemConfig(string Key)
        {
            return GetXmlSystemConfig("Config/Item",Key);
        }

        public static int GetXmlSystemConfigInt(string Key)
        {
            try {
                return Int32.Parse(GetXmlSystemConfig(Key));
            }
            catch {
                return 0;
            }
        }


        



        #endregion


    }
}
