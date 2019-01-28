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
    public class WF_Node : TableBase
    {
        
        public string TableDesc="流程节点，流程环节";
        
        public WF_Node() {
            TableName = "WF_Node";
            PKey = "ID";
            PKeyDataType = typeof(System.Int32);
            
            FieldInfoList.Add(new TableFieldInfo("ID",true,typeof(System.Int32),4,false,"",""));
            FieldInfoList.Add(new TableFieldInfo("NodeID",false,typeof(System.Int32),4,true,"","节点标识"));
            FieldInfoList.Add(new TableFieldInfo("NodeFlag",false,typeof(System.String),50,true,"","节点标记"));
            FieldInfoList.Add(new TableFieldInfo("NodeName",false,typeof(System.String),200,true,"","节点名称"));
            FieldInfoList.Add(new TableFieldInfo("WorkFlowID",false,typeof(System.Int32),4,true,"","所属工作流程标识"));
            FieldInfoList.Add(new TableFieldInfo("BranchFlowBeforehand",false,typeof(System.Boolean),1,true,"","支流先行"));
            FieldInfoList.Add(new TableFieldInfo("IsConcurrent",false,typeof(System.Boolean),1,true,"","是否并行"));
            FieldInfoList.Add(new TableFieldInfo("ConcurrentOnLine",false,typeof(System.String),100,true,"","并行的线路"));
            FieldInfoList.Add(new TableFieldInfo("AdmissionTickets",false,typeof(System.String),100,true,"","准入票"));
            FieldInfoList.Add(new TableFieldInfo("CanPassCountType",false,typeof(System.Int32),4,true,"","可通过计数类型 0为数量 1 为百分比"));
            FieldInfoList.Add(new TableFieldInfo("CanPassCount",false,typeof(System.Int32),4,true,"","可通过数量"));
            FieldInfoList.Add(new TableFieldInfo("CanPassPercent",false,typeof(System.Double),8,true,"","可通过百分比"));
            FieldInfoList.Add(new TableFieldInfo("ApprovalUrl",false,typeof(System.String),250,true,"","审批地址"));
            FieldInfoList.Add(new TableFieldInfo("ViewUrl",false,typeof(System.String),250,true,"","查阅地址"));
            FieldInfoList.Add(new TableFieldInfo("Remark",false,typeof(System.String),200,true,"","备注"));
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
            /// 节点标识
            /// </summary>
             NodeID,
            /// <summary>
            /// 节点标记
            /// </summary>
             NodeFlag,
            /// <summary>
            /// 节点名称
            /// </summary>
             NodeName,
            /// <summary>
            /// 所属工作流程标识
            /// </summary>
             WorkFlowID,
            /// <summary>
            /// 支流先行
            /// </summary>
             BranchFlowBeforehand,
            /// <summary>
            /// 是否并行
            /// </summary>
             IsConcurrent,
            /// <summary>
            /// 并行的线路
            /// </summary>
             ConcurrentOnLine,
            /// <summary>
            /// 准入票
            /// </summary>
             AdmissionTickets,
            /// <summary>
            /// 可通过计数类型 0为数量 1 为百分比
            /// </summary>
             CanPassCountType,
            /// <summary>
            /// 可通过数量
            /// </summary>
             CanPassCount,
            /// <summary>
            /// 可通过百分比
            /// </summary>
             CanPassPercent,
            /// <summary>
            /// 审批地址
            /// </summary>
             ApprovalUrl,
            /// <summary>
            /// 查阅地址
            /// </summary>
             ViewUrl,
            /// <summary>
            /// 备注
            /// </summary>
             Remark
        }
    }
}
