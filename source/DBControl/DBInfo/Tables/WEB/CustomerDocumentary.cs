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
    public class CustomerDocumentary : TableBase
    {
        
        public string TableDesc="客户跟单";
        
        public CustomerDocumentary() {
            TableName = "CustomerDocumentary";
            PKey = "ID";
            PKeyDataType = typeof(System.Int32);
            
            FieldInfoList.Add(new TableFieldInfo("ID",true,typeof(System.Int32),4,false,"",""));
            FieldInfoList.Add(new TableFieldInfo("CustomerCode",false,typeof(System.Int32),4,true,"","客户编码"));
            FieldInfoList.Add(new TableFieldInfo("DocumentaryPeople",false,typeof(System.String),50,true,"","跟单人"));
            FieldInfoList.Add(new TableFieldInfo("CustomerLevel",false,typeof(System.String),50,true,"","客户级别"));
            FieldInfoList.Add(new TableFieldInfo("SalesStage",false,typeof(System.String),100,true,"","销售阶段"));
            FieldInfoList.Add(new TableFieldInfo("DocumentaryContent",false,typeof(System.String),16,true,"","跟单内容"));
            FieldInfoList.Add(new TableFieldInfo("NextDocumentaryDate",false,typeof(System.DateTime),3,true,"","下次跟单日期"));
            FieldInfoList.Add(new TableFieldInfo("ReminderNote",false,typeof(System.String),1000,true,"","提醒备注"));
            FieldInfoList.Add(new TableFieldInfo("Attachment",false,typeof(System.String),50,true,"","附件"));
            FieldInfoList.Add(new TableFieldInfo("CreateTime",false,typeof(System.DateTime),8,true,"","创建时间"));
            FieldInfoList.Add(new TableFieldInfo("EditTime",false,typeof(System.DateTime),8,true,"","编辑时间"));
            FieldInfoList.Add(new TableFieldInfo("Creator",false,typeof(System.String),50,true,"","创建者"));
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
            /// 客户编码
            /// </summary>
             CustomerCode,
            /// <summary>
            /// 跟单人
            /// </summary>
             DocumentaryPeople,
            /// <summary>
            /// 客户级别
            /// </summary>
             CustomerLevel,
            /// <summary>
            /// 销售阶段
            /// </summary>
             SalesStage,
            /// <summary>
            /// 跟单内容
            /// </summary>
             DocumentaryContent,
            /// <summary>
            /// 下次跟单日期
            /// </summary>
             NextDocumentaryDate,
            /// <summary>
            /// 提醒备注
            /// </summary>
             ReminderNote,
            /// <summary>
            /// 附件
            /// </summary>
             Attachment,
            /// <summary>
            /// 创建时间
            /// </summary>
             CreateTime,
            /// <summary>
            /// 编辑时间
            /// </summary>
             EditTime,
            /// <summary>
            /// 创建者
            /// </summary>
             Creator
        }
    }
}
