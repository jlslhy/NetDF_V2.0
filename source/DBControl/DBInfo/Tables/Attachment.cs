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
    public class Attachment : TableBase
    {
        
        public string TableDesc="Attachment";
        
        public Attachment() {
            TableName = "Attachment";
            PKey = "AttachID";
            PKeyDataType = typeof(System.Int32);
            
            FieldInfoList.Add(new TableFieldInfo("AttachID",true,typeof(System.Int32),4,false,"",""));
            FieldInfoList.Add(new TableFieldInfo("AttachGUID",false,typeof(System.String),50,true,"",""));
            FieldInfoList.Add(new TableFieldInfo("BatchGUID",false,typeof(System.String),50,true,"","批次GUID"));
            FieldInfoList.Add(new TableFieldInfo("FileName",false,typeof(System.String),50,true,"",""));
            FieldInfoList.Add(new TableFieldInfo("Fix",false,typeof(System.String),50,true,"","后缀名"));
            FieldInfoList.Add(new TableFieldInfo("FileType",false,typeof(System.String),50,true,"","文件类型"));
            FieldInfoList.Add(new TableFieldInfo("HasThumbnail",false,typeof(System.Boolean),1,true,"",""));
            FieldInfoList.Add(new TableFieldInfo("URI",false,typeof(System.String),500,true,"","绝对资源地址"));
            FieldInfoList.Add(new TableFieldInfo("RelativeURL",false,typeof(System.String),500,true,"","相对网址"));
            FieldInfoList.Add(new TableFieldInfo("FileSize",false,typeof(System.Double),8,true,"","文件大小，单位为字节"));
            FieldInfoList.Add(new TableFieldInfo("OrderNum",false,typeof(System.Double),8,true,"",""));
            FieldInfoList.Add(new TableFieldInfo("Description",false,typeof(System.String),50,true,"",""));
            FieldInfoList.Add(new TableFieldInfo("MemberUpLoader",false,typeof(System.String),50,true,"","上传者 会员 "));
            FieldInfoList.Add(new TableFieldInfo("UserUploader",false,typeof(System.String),50,true,"","上传者 系统管理员 "));
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
             AttachID,
            /// <summary>
            /// 
            /// </summary>
             AttachGUID,
            /// <summary>
            /// 批次GUID
            /// </summary>
             BatchGUID,
            /// <summary>
            /// 
            /// </summary>
             FileName,
            /// <summary>
            /// 后缀名
            /// </summary>
             Fix,
            /// <summary>
            /// 文件类型
            /// </summary>
             FileType,
            /// <summary>
            /// 
            /// </summary>
             HasThumbnail,
            /// <summary>
            /// 绝对资源地址
            /// </summary>
             URI,
            /// <summary>
            /// 相对网址
            /// </summary>
             RelativeURL,
            /// <summary>
            /// 文件大小，单位为字节
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
            /// 上传者 会员 
            /// </summary>
             MemberUpLoader,
            /// <summary>
            /// 上传者 系统管理员 
            /// </summary>
             UserUploader,
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
