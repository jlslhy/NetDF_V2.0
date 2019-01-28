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
    public class WF_NodeOnLine : TableBase
    {
        
        public string TableDesc="节点连线";
        
        public WF_NodeOnLine() {
            TableName = "WF_NodeOnLine";
            PKey = "ID";
            PKeyDataType = typeof(System.Int32);
            
            FieldInfoList.Add(new TableFieldInfo("ID",true,typeof(System.Int32),4,false,"",""));
            FieldInfoList.Add(new TableFieldInfo("WorkFlowID",false,typeof(System.Int32),4,true,"","流程标识"));
            FieldInfoList.Add(new TableFieldInfo("LineID",false,typeof(System.Int32),4,true,"","线条标识"));
            FieldInfoList.Add(new TableFieldInfo("LineName",false,typeof(System.String),100,true,"","线名称"));
            FieldInfoList.Add(new TableFieldInfo("StartNodeID",false,typeof(System.Int32),4,true,"","开始结点"));
            FieldInfoList.Add(new TableFieldInfo("EndNodeID",false,typeof(System.Int32),4,true,"","结束结点"));
            FieldInfoList.Add(new TableFieldInfo("PassTickets",false,typeof(System.String),100,true,"","通行票，为字符串，多个由分号隔开"));
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
            /// 流程标识
            /// </summary>
             WorkFlowID,
            /// <summary>
            /// 线条标识
            /// </summary>
             LineID,
            /// <summary>
            /// 线名称
            /// </summary>
             LineName,
            /// <summary>
            /// 开始结点
            /// </summary>
             StartNodeID,
            /// <summary>
            /// 结束结点
            /// </summary>
             EndNodeID,
            /// <summary>
            /// 通行票，为字符串，多个由分号隔开
            /// </summary>
             PassTickets
        }
    }
}
