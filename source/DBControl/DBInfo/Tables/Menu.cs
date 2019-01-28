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
    public class Menu : TableBase
    {
        
        public string TableDesc="Menu";
        
        public Menu() {
            TableName = "Menu";
            PKey = "MenuID";
            PKeyDataType = typeof(System.Int32);
            
            FieldInfoList.Add(new TableFieldInfo("MenuID",true,typeof(System.Int32),4,false,"",""));
            FieldInfoList.Add(new TableFieldInfo("Code",false,typeof(System.Int32),4,true,"",""));
            FieldInfoList.Add(new TableFieldInfo("MName",false,typeof(System.String),50,true,"",""));
            FieldInfoList.Add(new TableFieldInfo("MDesc",false,typeof(System.String),50,true,"",""));
            FieldInfoList.Add(new TableFieldInfo("IsFolder",false,typeof(System.Boolean),1,true,"",""));
            FieldInfoList.Add(new TableFieldInfo("PCode",false,typeof(System.Int32),4,true,"",""));
            FieldInfoList.Add(new TableFieldInfo("MenuLevel",false,typeof(System.Int32),4,true,"",""));
            FieldInfoList.Add(new TableFieldInfo("Url",false,typeof(System.String),255,true,"",""));
            FieldInfoList.Add(new TableFieldInfo("Display",false,typeof(System.Boolean),1,true,"",""));
            FieldInfoList.Add(new TableFieldInfo("OrderNum",false,typeof(System.Int32),4,true,"",""));
            FieldInfoList.Add(new TableFieldInfo("IsSystem",false,typeof(System.Boolean),1,true,"",""));
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
             MenuID,
            /// <summary>
            /// 
            /// </summary>
             Code,
            /// <summary>
            /// 
            /// </summary>
             MName,
            /// <summary>
            /// 
            /// </summary>
             MDesc,
            /// <summary>
            /// 
            /// </summary>
             IsFolder,
            /// <summary>
            /// 
            /// </summary>
             PCode,
            /// <summary>
            /// 
            /// </summary>
             MenuLevel,
            /// <summary>
            /// 
            /// </summary>
             Url,
            /// <summary>
            /// 
            /// </summary>
             Display,
            /// <summary>
            /// 
            /// </summary>
             OrderNum,
            /// <summary>
            /// 
            /// </summary>
             IsSystem
        }
    }
}
