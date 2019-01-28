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
    public class WF_WaitForHandling : TableBase
    {
        
        public string TableDesc="待办表";
        
        public WF_WaitForHandling() {
            TableName = "WF_WaitForHandling";
            PKey = "ID";
            PKeyDataType = typeof(System.Int32);
            
            FieldInfoList.Add(new TableFieldInfo("ID",true,typeof(System.Int32),4,false,"",""));
            FieldInfoList.Add(new TableFieldInfo("HandleCode",false,typeof(System.String),50,true,"","待办码 实例ID加顺序码"));
            FieldInfoList.Add(new TableFieldInfo("WorkFlowID",false,typeof(System.Int32),4,true,"","所属流程ID"));
            FieldInfoList.Add(new TableFieldInfo("InstanceID",false,typeof(System.Int32),4,true,"","所属实例ID"));
            FieldInfoList.Add(new TableFieldInfo("InstanceName",false,typeof(System.String),500,true,"","实例名称"));
            FieldInfoList.Add(new TableFieldInfo("HandleUrl",false,typeof(System.String),500,true,"","办理地址"));
            FieldInfoList.Add(new TableFieldInfo("Approver",false,typeof(System.String),50,true,"","审批人"));
            FieldInfoList.Add(new TableFieldInfo("NodeID",false,typeof(System.Int32),4,true,"","待办环节ID"));
            FieldInfoList.Add(new TableFieldInfo("CreateTime",false,typeof(System.DateTime),8,true,"","创建时间"));
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
            /// 待办码 实例ID加顺序码
            /// </summary>
             HandleCode,
            /// <summary>
            /// 所属流程ID
            /// </summary>
             WorkFlowID,
            /// <summary>
            /// 所属实例ID
            /// </summary>
             InstanceID,
            /// <summary>
            /// 实例名称
            /// </summary>
             InstanceName,
            /// <summary>
            /// 办理地址
            /// </summary>
             HandleUrl,
            /// <summary>
            /// 审批人
            /// </summary>
             Approver,
            /// <summary>
            /// 待办环节ID
            /// </summary>
             NodeID,
            /// <summary>
            /// 创建时间
            /// </summary>
             CreateTime
        }
    }
}
