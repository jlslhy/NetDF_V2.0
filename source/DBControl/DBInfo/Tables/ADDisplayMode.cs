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
    public class ADDisplayMode : TableBase
    {
        
        public string TableDesc="ADDisplayMode";
        
        public ADDisplayMode() {
            TableName = "ADDisplayMode";
            PKey = "ADDisplayModeCode";
            PKeyDataType = typeof(System.String);
            
            FieldInfoList.Add(new TableFieldInfo("ADDisplayModeCode",true,typeof(System.String),50,false,"",""));
            FieldInfoList.Add(new TableFieldInfo("DisplayModeName",false,typeof(System.String),50,true,"",""));
            FieldInfoList.Add(new TableFieldInfo("IsSystem",false,typeof(System.Boolean),1,true,"",""));
            FieldInfoList.Add(new TableFieldInfo("ADType",false,typeof(System.Int32),4,true,"",""));
            FieldInfoList.Add(new TableFieldInfo("JsCode",false,typeof(System.String),16,true,"",""));
            FieldInfoList.Add(new TableFieldInfo("CSSCode",false,typeof(System.String),16,true,"",""));
            FieldInfoList.Add(new TableFieldInfo("DisplayModeTemplateCode",false,typeof(System.String),16,true,"",""));
            FieldInfoList.Add(new TableFieldInfo("Description",false,typeof(System.String),1000,true,"",""));
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
             ADDisplayModeCode,
            /// <summary>
            /// 
            /// </summary>
             DisplayModeName,
            /// <summary>
            /// 
            /// </summary>
             IsSystem,
            /// <summary>
            /// 
            /// </summary>
             ADType,
            /// <summary>
            /// 
            /// </summary>
             JsCode,
            /// <summary>
            /// 
            /// </summary>
             CSSCode,
            /// <summary>
            /// 
            /// </summary>
             DisplayModeTemplateCode,
            /// <summary>
            /// 
            /// </summary>
             Description
        }
    }
}
