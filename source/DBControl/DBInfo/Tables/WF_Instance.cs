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
    public class WF_Instance : TableBase
    {
        
        public string TableDesc="流程实例表";
        
        public WF_Instance() {
            TableName = "WF_Instance";
            PKey = "InstanceID";
            PKeyDataType = typeof(System.Int32);
            
            FieldInfoList.Add(new TableFieldInfo("InstanceID",true,typeof(System.Int32),4,false,"",""));
            FieldInfoList.Add(new TableFieldInfo("InstanceName",false,typeof(System.String),500,true,"","实例名称"));
            FieldInfoList.Add(new TableFieldInfo("WorkFlowID",false,typeof(System.Int32),4,true,"","所属工作流程标识"));
            FieldInfoList.Add(new TableFieldInfo("Status",false,typeof(System.Int32),4,true,"","流程实例状态"));
            FieldInfoList.Add(new TableFieldInfo("Threads",false,typeof(System.String),100,true,"","实例线程集"));
            FieldInfoList.Add(new TableFieldInfo("ThreadCount",false,typeof(System.Int32),4,true,"","线程数量"));
            FieldInfoList.Add(new TableFieldInfo("VariableValueXML",false,typeof(System.String),16,true,"","实例全局变量值"));
            FieldInfoList.Add(new TableFieldInfo("CreateTime",false,typeof(System.DateTime),8,true,"","创建时间"));
            FieldInfoList.Add(new TableFieldInfo("FinishTime",false,typeof(System.DateTime),8,true,"","实例结束时间"));
            FieldInfoList.Add(new TableFieldInfo("MaxHandleCode",false,typeof(System.String),50,true,"","最大待办码"));
            FieldInfoList.Add(new TableFieldInfo("Remark",false,typeof(System.String),16,true,"","备注"));
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
             InstanceID,
            /// <summary>
            /// 实例名称
            /// </summary>
             InstanceName,
            /// <summary>
            /// 所属工作流程标识
            /// </summary>
             WorkFlowID,
            /// <summary>
            /// 流程实例状态
            /// </summary>
             Status,
            /// <summary>
            /// 实例线程集
            /// </summary>
             Threads,
            /// <summary>
            /// 线程数量
            /// </summary>
             ThreadCount,
            /// <summary>
            /// 实例全局变量值
            /// </summary>
             VariableValueXML,
            /// <summary>
            /// 创建时间
            /// </summary>
             CreateTime,
            /// <summary>
            /// 实例结束时间
            /// </summary>
             FinishTime,
            /// <summary>
            /// 最大待办码
            /// </summary>
             MaxHandleCode,
            /// <summary>
            /// 备注
            /// </summary>
             Remark
        }
    }
}
