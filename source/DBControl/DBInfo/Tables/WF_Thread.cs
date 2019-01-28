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
    public class WF_Thread : TableBase
    {
        
        public string TableDesc="流程实例线程";
        
        public WF_Thread() {
            TableName = "WF_Thread";
            PKey = "ID";
            PKeyDataType = typeof(System.Int32);
            
            FieldInfoList.Add(new TableFieldInfo("ID",true,typeof(System.Int32),4,false,"",""));
            FieldInfoList.Add(new TableFieldInfo("ThreadName",false,typeof(System.String),50,true,"","线程名称"));
            FieldInfoList.Add(new TableFieldInfo("InstanceID",false,typeof(System.Int32),4,true,"","所属实例ID"));
            FieldInfoList.Add(new TableFieldInfo("CurrentNodeID",false,typeof(System.Int32),4,true,"","当前节点ID"));
            FieldInfoList.Add(new TableFieldInfo("CurrentNodeTime",false,typeof(System.DateTime),8,true,"","进入当前环节的时间"));
            FieldInfoList.Add(new TableFieldInfo("NodeVariableValueXML",false,typeof(System.String),16,true,"","结点局部变量值"));
            FieldInfoList.Add(new TableFieldInfo("AllApprovers",false,typeof(System.String),500,true,"","所有审批人"));
            FieldInfoList.Add(new TableFieldInfo("PassedApprovers",false,typeof(System.String),500,true,"","已经审批通过的人"));
            FieldInfoList.Add(new TableFieldInfo("PassedCount",false,typeof(System.Int32),4,true,"","已经通过审批的人数"));
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
            /// 线程名称
            /// </summary>
             ThreadName,
            /// <summary>
            /// 所属实例ID
            /// </summary>
             InstanceID,
            /// <summary>
            /// 当前节点ID
            /// </summary>
             CurrentNodeID,
            /// <summary>
            /// 进入当前环节的时间
            /// </summary>
             CurrentNodeTime,
            /// <summary>
            /// 结点局部变量值
            /// </summary>
             NodeVariableValueXML,
            /// <summary>
            /// 所有审批人
            /// </summary>
             AllApprovers,
            /// <summary>
            /// 已经审批通过的人
            /// </summary>
             PassedApprovers,
            /// <summary>
            /// 已经通过审批的人数
            /// </summary>
             PassedCount
        }
    }
}
