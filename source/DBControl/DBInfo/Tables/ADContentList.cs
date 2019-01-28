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
    public class ADContentList : TableBase
    {
        
        public string TableDesc="ADContentList";
        
        public ADContentList() {
            TableName = "ADContentList";
            PKey = "ADContentListID";
            PKeyDataType = typeof(System.Int32);
            
            FieldInfoList.Add(new TableFieldInfo("ADContentListID",true,typeof(System.Int32),4,false,"",""));
            FieldInfoList.Add(new TableFieldInfo("ADID",false,typeof(System.Int32),4,true,"",""));
            FieldInfoList.Add(new TableFieldInfo("ADText",false,typeof(System.String),8000,true,"",""));
            FieldInfoList.Add(new TableFieldInfo("PicUrl",false,typeof(System.String),250,true,"",""));
            FieldInfoList.Add(new TableFieldInfo("FlashUrl",false,typeof(System.String),250,true,"",""));
            FieldInfoList.Add(new TableFieldInfo("ToolTip",false,typeof(System.String),250,true,"",""));
            FieldInfoList.Add(new TableFieldInfo("LinkUrl",false,typeof(System.String),500,true,"",""));
            FieldInfoList.Add(new TableFieldInfo("Description",false,typeof(System.String),500,true,"",""));
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
             ADContentListID,
            /// <summary>
            /// 
            /// </summary>
             ADID,
            /// <summary>
            /// 
            /// </summary>
             ADText,
            /// <summary>
            /// 
            /// </summary>
             PicUrl,
            /// <summary>
            /// 
            /// </summary>
             FlashUrl,
            /// <summary>
            /// 
            /// </summary>
             ToolTip,
            /// <summary>
            /// 
            /// </summary>
             LinkUrl,
            /// <summary>
            /// 
            /// </summary>
             Description
        }
    }
}
