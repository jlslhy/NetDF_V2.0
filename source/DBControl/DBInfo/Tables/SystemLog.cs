/*
 * 框架版本：NetDF2.0  
 * 架构设计与开发、版权所有者：李青锦 
 * QQ：3425806176 
 * 技术网站：软艺软件(www.ruanyi.online) 
 * 技术交流群：826373349
 * */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DBControl.DBInfo.Tables
{
    public class SystemLog : TableBase
    {
        
        public string TableDesc="SystemLog";
        
        public SystemLog() {
            TableName = "SystemLog";
            PKey = "LogID";
            PKeyDataType = typeof(System.Int64);
            
            FieldInfoList.Add(new TableFieldInfo("LogID",true,typeof(System.Int64),8,false,"",""));
            FieldInfoList.Add(new TableFieldInfo("LogClass",false,typeof(System.String),50,true,"","日志类别"));
            FieldInfoList.Add(new TableFieldInfo("LogTitle",false,typeof(System.String),150,true,"","日志标题"));
            FieldInfoList.Add(new TableFieldInfo("LogContent",false,typeof(System.String),16,true,"","日志内容"));
            FieldInfoList.Add(new TableFieldInfo("CreateTime",false,typeof(System.DateTime),8,true,"",""));
            FieldInfoList.Add(new TableFieldInfo("Operator",false,typeof(System.String),50,true,"","操作者"));
        }

        public TableFieldInfo GetTableFieldInfo(string fieldName)
        {
            
            TableFieldInfo tInfo = null;
            foreach (TableFieldInfo t in FieldInfoList)
            {
                if (t.FieldName.Equals(fieldName.Trim()))
                {
                    tInfo = t;
                    break;
                }
            }
            return tInfo;
        }

        public Type GetFieldType(string fieldName)
        {
            TableFieldInfo tInfo = GetTableFieldInfo(fieldName);
            if (null == tInfo)
            {
                throw new Exception(string.Format("表{0}中没有字段：{1}",TableName,fieldName));
            }
            
            return   tInfo.DataType ;

        }
        
        public enum Field { 
         
            /// <summary>
            /// 
            /// </summary>
             LogID,
            /// <summary>
            /// 日志类别
            /// </summary>
             LogClass,
            /// <summary>
            /// 日志标题
            /// </summary>
             LogTitle,
            /// <summary>
            /// 日志内容
            /// </summary>
             LogContent,
            /// <summary>
            /// 
            /// </summary>
             CreateTime,
            /// <summary>
            /// 操作者
            /// </summary>
             Operator
        }
    }
}
