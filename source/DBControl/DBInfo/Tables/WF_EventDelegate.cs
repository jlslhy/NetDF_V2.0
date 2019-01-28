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
    public class WF_EventDelegate : TableBase
    {
        
        public string TableDesc="流程事件委托";
        
        public WF_EventDelegate() {
            TableName = "WF_EventDelegate";
            PKey = "ID";
            PKeyDataType = typeof(System.Int32);
            
            FieldInfoList.Add(new TableFieldInfo("ID",true,typeof(System.Int32),4,false,"",""));
            FieldInfoList.Add(new TableFieldInfo("WorkFlowID",false,typeof(System.Int32),4,true,"","所属流程ID"));
            FieldInfoList.Add(new TableFieldInfo("NodeID",false,typeof(System.Int32),4,true,"","节点ID"));
            FieldInfoList.Add(new TableFieldInfo("EventName",false,typeof(System.String),100,true,"","事件名称"));
            FieldInfoList.Add(new TableFieldInfo("DelegatePath",false,typeof(System.String),150,true,"","代理方法路径"));
            FieldInfoList.Add(new TableFieldInfo("Remark",false,typeof(System.String),16,true,"","备注说明"));
            FieldInfoList.Add(new TableFieldInfo("Enabled",false,typeof(System.Boolean),1,true,"","是否启用"));
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
            /// 所属流程ID
            /// </summary>
             WorkFlowID,
            /// <summary>
            /// 节点ID
            /// </summary>
             NodeID,
            /// <summary>
            /// 事件名称
            /// </summary>
             EventName,
            /// <summary>
            /// 代理方法路径
            /// </summary>
             DelegatePath,
            /// <summary>
            /// 备注说明
            /// </summary>
             Remark,
            /// <summary>
            /// 是否启用
            /// </summary>
             Enabled
        }
    }
}
