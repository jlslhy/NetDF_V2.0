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
    public class SystemSetup : TableBase
    {
        
        public string TableDesc="SystemSetup";
        
        public SystemSetup() {
            TableName = "SystemSetup";
            PKey = "ID";
            PKeyDataType = typeof(System.Int32);
            
            FieldInfoList.Add(new TableFieldInfo("ID",true,typeof(System.Int32),4,false,"",""));
            FieldInfoList.Add(new TableFieldInfo("KeyCode",false,typeof(System.String),100,false,"",""));
            FieldInfoList.Add(new TableFieldInfo("SetupValue",false,typeof(System.String),1000,true,"",""));
            FieldInfoList.Add(new TableFieldInfo("SetupType",false,typeof(System.String),100,true,"","分类"));
            FieldInfoList.Add(new TableFieldInfo("Remark",false,typeof(System.String),1000,true,"",""));
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
             ID,
            /// <summary>
            /// 
            /// </summary>
             KeyCode,
            /// <summary>
            /// 
            /// </summary>
             SetupValue,
            /// <summary>
            /// 分类
            /// </summary>
             SetupType,
            /// <summary>
            /// 
            /// </summary>
             Remark
        }
    }
}
