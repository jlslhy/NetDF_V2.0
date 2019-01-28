using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Web;
using System.Web.UI;

namespace Common
{
    /// <summary>
    /// 提供类型转换、获取URL参数等的操作
    /// </summary>
    public class ToolsHelper
    {
        #region 类型转换
        /// <summary>
        /// 字符串形转换成Long，转换失败后的默认值"0"
        /// </summary>
        /// <param name="pStr">长整形定符串</param>
        public static long StrToLong(string pStr)
        {
            return StrToLong(pStr, 0);
        }
        /// <summary>
        /// 字符串形转换成Long
        /// </summary>
        /// <param name="pStr">长整形字符串</param>
        /// <param name="pDefaultValue">转换失败后的默认值</param>
        public static long StrToLong(string pStr, long pDefaultValue)
        {
            if (String.IsNullOrEmpty(pStr)) { return pDefaultValue; }
            else
            {
                try
                { return Convert.ToInt64(pStr); }
                catch
                {
                    return pDefaultValue;
                }
            }
        }

        /// <summary>
        /// 字符串形转换成Long，转换失败后的默认值"0"
        /// </summary>
        /// <param name="pStr">Int形定符串</param>
        public static int StrToInt(string pStr)
        {
            return StrToInt(pStr, 0);
        }

        /// <summary>
        /// 字符串转成Int形，转换失败后的默认值"0"
        /// </summary>
        /// <param name="pStr">整形字符串</param>
        /// <param name="pDefaultValue">转换失败后的默认值</param>
        /// <returns></returns>
        public static int StrToInt(string pStr, int pDefaultValue)
        {
            if (string.IsNullOrEmpty(pStr)) return pDefaultValue;
            try
            {
                return int.Parse(pStr);
            }
            catch
            {
                return pDefaultValue;
            }
        }
        /// <summary>
        /// 字符串形转换成double，转换失败后的默认值"0"
        /// </summary>
        /// <param name="pStr">double形定符串</param>
        public static double StrToDouble(string pStr)
        {
            return StrToDouble(pStr, 0);
        }
        /// <summary>
        /// 字符串转成double形
        /// </summary>
        /// <param name="pStr">double形字符串</param>
        /// <param name="pDefaultValue">转换失败后的默认值</param>
        /// <returns></returns>
        public static double StrToDouble(string pStr, double pDefaultValue)
        {
            if (string.IsNullOrEmpty(pStr)) return pDefaultValue;
            try
            {
                return double.Parse(pStr);
            }
            catch
            {
                return pDefaultValue;
            }
        }
        /// <summary>
        /// 字符串形转换成Decimal，转换失败后的默认值"0"
        /// </summary>
        /// <param name="pStr">Decimal形定符串</param>
        public static Decimal StrToDecimal(string pStr)
        {
            return StrToDecimal(pStr, 0);
        }
        /// <summary>
        /// Decimal字符串转成Decimal形
        /// </summary>
        /// <param name="pStr">Decimal形字符串</param>
        /// <param name="pDefaultValue">转换失败后的默认值</param>
        /// <returns></returns>
        public static Decimal StrToDecimal(string pStr, Decimal pDefaultValue)
        {
            if (String.IsNullOrEmpty(pStr))
                return pDefaultValue;
            try
            {
                return Convert.ToDecimal(pStr);
            }
            catch
            {
                return pDefaultValue;
            }
        }

        /// <summary>
        /// DateTime字符串转成DateTime形,转换失败可以返回null
        /// </summary>
        /// <param name="pStr">DateTime形字符串</param>
        /// <param name="pDefaultValue">转换失败后的默认值,可以为null</param>
        /// <returns></returns>
        public static DateTime? StrToDateTime(string pStr, DateTime? pDefaultValue)
        {
            if (String.IsNullOrEmpty(pStr))
                return pDefaultValue;
            try
            {
                return DateTime.Parse(pStr);
            }
            catch
            {
                return pDefaultValue;
            }
        }

        /// <summary>
        /// DateTime字符串转成DateTime形,转换失败反馈当前时间
        /// </summary>
        /// <param name="pStr">DateTime形字符串</param>
        public static DateTime StrToDateTime(string pStr)
        {
            if (String.IsNullOrEmpty(pStr))
                return DateTime.Now;
            try
            {
                return DateTime.Parse(pStr);
            }
            catch
            {
                return DateTime.Now;
            }
        }

        /// <summary>
        /// 字符串形转换成byte，转换失败后的默认值"0"
        /// </summary>
        /// <param name="pStr">byte形定符串</param>
        public static byte StrToByte(string pStr)
        {
            if (string.IsNullOrEmpty(pStr))
                return 0;
            try
            {
                return byte.Parse(pStr);
            }
            catch
            {
                return 0;
            }
        }
        /// <summary>
        /// 字符串形转换成Bool，转换失败后的默认值false
        /// </summary>
        /// <param name="pStr">Bool形字符串</param>
        public static bool StrToBool(string pStr)
        {
            if (string.IsNullOrEmpty(pStr))
                return false;
            try
            {
                if (pStr == "1" || pStr.ToLower() == "true")
                    return true;
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 取得byte[],数据为空时返回null
        /// </summary>
        /// <param name="pObj">object对象</param>
        /// <returns></returns>
        public static Byte[] ObjGetByte(object pObj)
        {
            if (pObj == null)
                return null;
            try
            {
                if (!string.IsNullOrEmpty(pObj.ToString()))
                {
                    return (Byte[])pObj;
                }
                else
                    return null;
            }
            catch
            {
                return null;
            }
        }

        #endregion

        #region 从URL中取得参数值 (总是不会有 null，所以叫做 'Safe')
        /// <summary>
        /// 从Url的QueryString集合中取得参数的值
        /// </summary>
        /// <param name="pPage"></param>
        /// <param name="pKey"></param>
        /// <returns></returns>
        public static string GetUrlQueryStr(Page pPage, string pKey)
        {
            string value = pPage.Request.QueryString[pKey];
            return (value == null) ? string.Empty : value;
        }

        /// <summary>
        /// 从Url的QueryString集合中安全的取得Int形值
        /// </summary>
        /// <param name="pPage">page对象</param>
        /// <param name="pKey">参数名称</param>
        /// <param name="pDefaultValue">默认值</param>
        /// <returns></returns>
        public static int GetUrlQueryInt(Page pPage, string pKey, int pDefaultValue)
        {
            string value = GetUrlQueryStr(pPage, pKey);
            int intValue = pDefaultValue;
            try
            {
                intValue = int.Parse(value);
                return intValue;
            }
            catch
            {
                return intValue;
            }
        }

        /// <summary>
        /// 从Url的QueryString集合中安全的取得Long形值
        /// </summary>
        /// <param name="pPage">page对象</param>
        /// <param name="pKey">参数名称</param>
        /// <param name="pDefaultValue">默认值</param>
        /// <returns></returns>
        public static long GetUrlQueryLong(Page pPage, string pKey, int pDefaultValue)
        {
            string value = GetUrlQueryStr(pPage, pKey);
            long longValue = pDefaultValue;
            try
            {
                longValue = long.Parse(value);
                return longValue;
            }
            catch
            {
                return longValue;
            }
        }

        /// <summary>
        /// 从Url的QueryString集合中安全的取得double形值
        /// </summary>
        /// <param name="pPage">page对象</param>
        /// <param name="pKey">参数名称</param>
        /// <param name="pDefaultValue">默认值</param>
        /// <returns></returns>
        public static double GetUrlQueryDouble(Page pPage, string pKey, double pDefaultValue)
        {
            string value = GetUrlQueryStr(pPage, pKey);
            double doubleValue = pDefaultValue;
            try
            {
                doubleValue = double.Parse(value);
                return doubleValue;
            }
            catch
            {
                return doubleValue;
            }
        }

        /// <summary>
        /// 从Url的QueryString集合中安全的取得decimal形值
        /// </summary>
        /// <param name="pPage">page对象</param>
        /// <param name="pKey">参数名称</param>
        /// <param name="pDefaultValue">默认值</param>
        /// <returns></returns>
        public static decimal GetUrlQueryDecimal(Page pPage, string pKey, decimal pDefaultValue)
        {
            string value = GetUrlQueryStr(pPage, pKey);
            decimal decValue = pDefaultValue;
            try
            {
                decValue = decimal.Parse(value);
                return decValue;
            }
            catch
            {
                return decValue;
            }
        }

        #endregion

        #region 防止Sql注入

        /// <summary>
        /// 防止Sql注入,过滤字符串中数据库脚本语法
        /// </summary>
        public static string CheckSqlStr(string pStr)
        {
            string strtemp = "";
            if (pStr != null)
            {
                strtemp = pStr.Replace("/*", "");
                strtemp = strtemp.Replace("--", "");
                strtemp = strtemp.Replace("'", "");
            }
            return strtemp;
        }
        #endregion

        #region 对象值拷贝
        ///// <summary>
        ///// 对象值拷贝
        ///// </summary>
        ///// <param name="origin">源对象</param>
        ///// <param name="target">目标对象</param>
        //public static void CopyValue(object origin, object target)
        //{
        //    System.Reflection.PropertyInfo[] properties = (target.GetType()).GetProperties();
        //    System.Reflection.FieldInfo[] fields = (origin.GetType()).GetFields();
        //    for (int i = 0; i < fields.Length; i++)
        //    {
        //        for (int j = 0; j < properties.Length; j++)
        //        {
        //            if (fields[i].Name == properties[j].Name && properties[j].CanWrite)
        //            {
        //                properties[j].SetValue(target, fields[i].GetValue(origin), null);
        //            }
        //        }
        //    }
        //}

        #region 对象值拷贝

        /// <summary>
        /// 对象值拷贝
        /// </summary>
        /// <param name="destination">目标对象</param>
        /// <param name="source">源对象</param>
        /// <returns>复制的属性字段个数</returns>
        public static int CopyValue(object destination, object source)
        {
            if (destination == null || source == null)
            {
                return 0;
            }

            int i = 0;
            Type desType = destination.GetType();
            Type type = source.GetType();

            foreach (FieldInfo mi in type.GetFields())
            {
                try
                {
                    FieldInfo des = desType.GetField(mi.Name);
                    if (des != null && des.FieldType == mi.FieldType)
                    {
                        des.SetValue(destination, mi.GetValue(source));
                        i++;
                    }
                }
                catch
                {
                }
            }

            foreach (PropertyInfo pi in type.GetProperties())
            {
                try
                {
                    PropertyInfo des = desType.GetProperty(pi.Name);
                    if (des != null && des.PropertyType == pi.PropertyType && des.CanWrite && pi.CanRead)
                    {
                        des.SetValue(destination, pi.GetValue(source, null), null);
                        i++;
                    }
                }
                catch
                {
                }
            }

            return i;
        }

        #endregion
        #endregion


        /// <summary>
        /// 截取字符串长度
        /// </summary>
        /// <param name="source"></param>
        /// <param name="iFrom"></param>
        /// <param name="MaxCount"></param>
        /// <returns></returns>
        public static string MySubString(string source, int iFrom, int MaxCount)
        {
            if (source == null) { return ""; }
            else
            {
                source = source.Trim();
                return source.Length > (iFrom + MaxCount) ? source.Substring(iFrom, MaxCount) : source.Substring(iFrom, source.Length);
            }
        }
    }
}
