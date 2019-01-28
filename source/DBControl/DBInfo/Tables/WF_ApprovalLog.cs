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
    public class WF_ApprovalLog : TableBase
    {
        
        public string TableDesc="审批日志表";
        
        public WF_ApprovalLog() {
            TableName = "WF_ApprovalLog";
            PKey = "ID";
            PKeyDataType = typeof(System.Int32);
            
            FieldInfoList.Add(new TableFieldInfo("ID",true,typeof(System.Int32),4,false,"",""));
            FieldInfoList.Add(new TableFieldInfo("InstanceID",false,typeof(System.Int32),4,true,"","所属实例ID"));
            FieldInfoList.Add(new TableFieldInfo("ApprovalNodeID",false,typeof(System.Int32),4,true,"","审批环节ID"));
            FieldInfoList.Add(new TableFieldInfo("Approver",false,typeof(System.String),50,true,"","审批人"));
            FieldInfoList.Add(new TableFieldInfo("AppTime",false,typeof(System.DateTime),8,true,"","审批时间"));
            FieldInfoList.Add(new TableFieldInfo("ApprovalOpinion",false,typeof(System.String),16,true,"","审批意见"));
            FieldInfoList.Add(new TableFieldInfo("TheNextStep",false,typeof(System.String),250,true,"","下一步，动作路线与节点"));
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
            /// 所属实例ID
            /// </summary>
             InstanceID,
            /// <summary>
            /// 审批环节ID
            /// </summary>
             ApprovalNodeID,
            /// <summary>
            /// 审批人
            /// </summary>
             Approver,
            /// <summary>
            /// 审批时间
            /// </summary>
             AppTime,
            /// <summary>
            /// 审批意见
            /// </summary>
             ApprovalOpinion,
            /// <summary>
            /// 下一步，动作路线与节点
            /// </summary>
             TheNextStep
        }
    }
}
