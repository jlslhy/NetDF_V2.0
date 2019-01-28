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

namespace DBControl.DBInfo.Tables.WEB
{
    public class ADClass : TableBase
    {
        
        public string TableDesc="ADClass";
        
        public ADClass() {
            TableName = "ADClass";
            PKey = "ADClassID";
            PKeyDataType = typeof(System.Int32);
            
            FieldInfoList.Add(new TableFieldInfo("ADClassID",true,typeof(System.Int32),4,false,"",""));
            FieldInfoList.Add(new TableFieldInfo("ADClassName",false,typeof(System.String),100,true,"",""));
            FieldInfoList.Add(new TableFieldInfo("Description",false,typeof(System.String),100,true,"",""));
            FieldInfoList.Add(new TableFieldInfo("ParentId",false,typeof(System.Int32),4,true,"",""));
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
             ADClassID,
            /// <summary>
            /// 
            /// </summary>
             ADClassName,
            /// <summary>
            /// 
            /// </summary>
             Description,
            /// <summary>
            /// 
            /// </summary>
             ParentId
        }
    }
}
