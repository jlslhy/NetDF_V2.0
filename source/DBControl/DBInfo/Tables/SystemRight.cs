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
    public class SystemRight : TableBase
    {
        
        public string TableDesc="SystemRight";
        
        public SystemRight() {
            TableName = "SystemRight";
            PKey = "ID";
            PKeyDataType = typeof(System.Int32);
            
            FieldInfoList.Add(new TableFieldInfo("ID",true,typeof(System.Int32),4,false,"",""));
            FieldInfoList.Add(new TableFieldInfo("RightCode",false,typeof(System.String),50,true,"","权限编号"));
            FieldInfoList.Add(new TableFieldInfo("RightName",false,typeof(System.String),50,true,"","权限名称"));
            FieldInfoList.Add(new TableFieldInfo("RightDesc",false,typeof(System.String),50,true,"","说明"));
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
            /// 权限编号
            /// </summary>
             RightCode,
            /// <summary>
            /// 权限名称
            /// </summary>
             RightName,
            /// <summary>
            /// 说明
            /// </summary>
             RightDesc
        }
    }
}
