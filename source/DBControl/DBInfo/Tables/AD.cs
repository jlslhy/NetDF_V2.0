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
    public class AD : TableBase
    {
        
        public string TableDesc="AD";
        
        public AD() {
            TableName = "AD";
            PKey = "ADID";
            PKeyDataType = typeof(System.Int32);
            
            FieldInfoList.Add(new TableFieldInfo("ADID",true,typeof(System.Int32),4,false,"",""));
            FieldInfoList.Add(new TableFieldInfo("ADName",false,typeof(System.String),300,true,"",""));
            FieldInfoList.Add(new TableFieldInfo("ADClassID",false,typeof(System.Int32),4,true,"",""));
            FieldInfoList.Add(new TableFieldInfo("DisplayPrickle",false,typeof(System.String),50,true,"",""));
            FieldInfoList.Add(new TableFieldInfo("DisplayWidth",false,typeof(System.Double),8,true,"",""));
            FieldInfoList.Add(new TableFieldInfo("DisplayHeight",false,typeof(System.Double),8,true,"",""));
            FieldInfoList.Add(new TableFieldInfo("ADType",false,typeof(System.Int32),4,true,"",""));
            FieldInfoList.Add(new TableFieldInfo("ADDisplayModeCode",false,typeof(System.String),50,true,"",""));
            FieldInfoList.Add(new TableFieldInfo("Description",false,typeof(System.String),300,true,"",""));
            FieldInfoList.Add(new TableFieldInfo("IsDisplay",false,typeof(System.Boolean),1,false,"",""));
            FieldInfoList.Add(new TableFieldInfo("CreateTime",false,typeof(System.DateTime),8,true,"",""));
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
             ADID,
            /// <summary>
            /// 
            /// </summary>
             ADName,
            /// <summary>
            /// 
            /// </summary>
             ADClassID,
            /// <summary>
            /// 
            /// </summary>
             DisplayPrickle,
            /// <summary>
            /// 
            /// </summary>
             DisplayWidth,
            /// <summary>
            /// 
            /// </summary>
             DisplayHeight,
            /// <summary>
            /// 
            /// </summary>
             ADType,
            /// <summary>
            /// 
            /// </summary>
             ADDisplayModeCode,
            /// <summary>
            /// 
            /// </summary>
             Description,
            /// <summary>
            /// 
            /// </summary>
             IsDisplay,
            /// <summary>
            /// 
            /// </summary>
             CreateTime
        }
    }
}
