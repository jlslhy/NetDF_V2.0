using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Reflection;


namespace SystemExtend
{
    public static  class TypeExt
    {
        /// <summary>
        /// 是否数值类型
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static bool IsDigitType(this Type type)
        {
            return (type.Equals(typeof(System.Byte))
               || type.Equals(typeof(System.SByte))
               || type.Equals(typeof(System.Char))
               || type.Equals(typeof(System.Decimal))
               || type.Equals(typeof(System.Double))
               || type.Equals(typeof(System.Single))
               || type.Equals(typeof(System.Int32))
               || type.Equals(typeof(System.UInt32))
               || type.Equals(typeof(System.Int64))
               || type.Equals(typeof(System.UInt64))
               || type.Equals(typeof(System.Int16))
               || type.Equals(typeof(System.UInt16))
               );
        }
        
        /// <summary>
        /// 是否字符串类型
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static bool IsStringType(this Type type)
        {
            return  type.Equals(typeof(System.String))  ;
        }

        /// <summary>
        /// 是否时间类型
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static bool IsDateTimeType(this Type type)
        {
            return  type.Equals(typeof(System.DateTime)) ;
        }



        /// <summary>
        /// 是否存在指定的字段名
        /// </summary>
        /// <param name="idr"></param>
        /// <param name="fieldName"></param>
        /// <returns></returns>
        public static bool HasField(this IDataReader idr,string fieldName)
        {
            bool has = false;

            int fieldCount = idr.FieldCount;
            for (int i = 0; i < fieldCount; i++)
            {
                if (idr.GetName(i).ToLower().Equals(fieldName.ToLower())
                    ||( "[" + idr.GetName(i).ToLower() + "]").Equals(fieldName.ToLower())
                    )
                {
                    has = true;
                    break;
                }
            }
            return has;
        }

        public static string ToString(this string[] strArr, string separator)
        {
            StringBuilder sb = new StringBuilder();
            
            if (null != strArr)
            {
                string s = string.Empty;
                foreach (string str in strArr)
                {
                    sb.Append(s);
                    sb.Append(str);
                    s = separator;
                }
            }
            return sb.ToString();
        }

        /// <summary>
        /// 将c# DateTime时间格式转换为Unix时间戳格式 13 位
        /// </summary>
        /// <param name="time">时间</param>
        /// <returns>long</returns>
        public static long ConvertDateTimeInt(this System.DateTime time)
        {
            //double intResult = 0;
            System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1, 0, 0, 0, 0));
            //intResult = (time- startTime).TotalMilliseconds;
            long t = (time.Ticks - startTime.Ticks) / 10000; //除10000调整为13位
            return t;
        }

        /// <summary>
        /// 利用反射来判断对象是否包含某个属性
        /// </summary>
        /// <param name="instance">object</param>
        /// <param name="propertyName">需要判断的属性</param>
        /// <returns>是否包含</returns>
        public static bool ContainProperty(this object instance, string propertyName)
        {
            if (instance != null && !string.IsNullOrEmpty(propertyName))
            {
                PropertyInfo _findedPropertyInfo = instance.GetType().GetProperty(propertyName);
                return (_findedPropertyInfo != null);
            }
            return false;
        }


    }
}
