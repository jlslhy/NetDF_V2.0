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
    public class WF_NodeContent : TableBase
    {
        
        public string TableDesc="节点的内容相关表";
        
        public WF_NodeContent() {
            TableName = "WF_NodeContent";
            PKey = "ID";
            PKeyDataType = typeof(System.Int32);
            
            FieldInfoList.Add(new TableFieldInfo("ID",true,typeof(System.Int32),4,false,"",""));
            FieldInfoList.Add(new TableFieldInfo("WorkFlowID",false,typeof(System.Int32),4,true,"","所属流程ID"));
            FieldInfoList.Add(new TableFieldInfo("NodeID",false,typeof(System.Int32),4,true,"","节点ID"));
            FieldInfoList.Add(new TableFieldInfo("ContentName",false,typeof(System.String),300,true,"","内容名称"));
            FieldInfoList.Add(new TableFieldInfo("ContentEditPageUrl",false,typeof(System.String),250,true,"","内容编辑页面地址"));
            FieldInfoList.Add(new TableFieldInfo("ContentViewPageUrl",false,typeof(System.String),250,true,"","内容查看页面地址"));
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
            /// 内容名称
            /// </summary>
             ContentName,
            /// <summary>
            /// 内容编辑页面地址
            /// </summary>
             ContentEditPageUrl,
            /// <summary>
            /// 内容查看页面地址
            /// </summary>
             ContentViewPageUrl,
            /// <summary>
            /// 备注
            /// </summary>
             Remark
        }
    }
}
