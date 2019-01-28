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
    public class Images : TableBase
    {
        
        public string TableDesc="Images";
        
        public Images() {
            TableName = "Images";
            PKey = "ImagesID";
            PKeyDataType = typeof(System.Int32);
            
            FieldInfoList.Add(new TableFieldInfo("ImagesID",true,typeof(System.Int32),4,false,"",""));
            FieldInfoList.Add(new TableFieldInfo("ImageGUID",false,typeof(System.String),50,true,"",""));
            FieldInfoList.Add(new TableFieldInfo("FileName",false,typeof(System.String),50,true,"",""));
            FieldInfoList.Add(new TableFieldInfo("Fix",false,typeof(System.String),50,true,"",""));
            FieldInfoList.Add(new TableFieldInfo("FileType",false,typeof(System.String),50,true,"",""));
            FieldInfoList.Add(new TableFieldInfo("HasThumbnail",false,typeof(System.Boolean),1,true,"",""));
            FieldInfoList.Add(new TableFieldInfo("Url",false,typeof(System.String),500,true,"",""));
            FieldInfoList.Add(new TableFieldInfo("FileSize",false,typeof(System.Double),8,true,"",""));
            FieldInfoList.Add(new TableFieldInfo("OrderNum",false,typeof(System.Double),8,true,"",""));
            FieldInfoList.Add(new TableFieldInfo("Description",false,typeof(System.String),50,true,"",""));
            FieldInfoList.Add(new TableFieldInfo("CreateTime",false,typeof(System.DateTime),8,true,"",""));
            FieldInfoList.Add(new TableFieldInfo("ModifyTime",false,typeof(System.DateTime),8,true,"",""));
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
             ImagesID,
            /// <summary>
            /// 
            /// </summary>
             ImageGUID,
            /// <summary>
            /// 
            /// </summary>
             FileName,
            /// <summary>
            /// 
            /// </summary>
             Fix,
            /// <summary>
            /// 
            /// </summary>
             FileType,
            /// <summary>
            /// 
            /// </summary>
             HasThumbnail,
            /// <summary>
            /// 
            /// </summary>
             Url,
            /// <summary>
            /// 
            /// </summary>
             FileSize,
            /// <summary>
            /// 
            /// </summary>
             OrderNum,
            /// <summary>
            /// 
            /// </summary>
             Description,
            /// <summary>
            /// 
            /// </summary>
             CreateTime,
            /// <summary>
            /// 
            /// </summary>
             ModifyTime
        }
    }
}
