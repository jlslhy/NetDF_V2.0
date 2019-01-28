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
    public class WF_WorkFlow : TableBase
    {
        
        public string TableDesc="工作流";
        
        public WF_WorkFlow() {
            TableName = "WF_WorkFlow";
            PKey = "ID";
            PKeyDataType = typeof(System.Int32);
            
            FieldInfoList.Add(new TableFieldInfo("ID",true,typeof(System.Int32),4,false,"",""));
            FieldInfoList.Add(new TableFieldInfo("WorkFlowID",false,typeof(System.Int32),4,true,"","工作流标识"));
            FieldInfoList.Add(new TableFieldInfo("WorkFlowName",false,typeof(System.String),200,true,"","工作流名称"));
            FieldInfoList.Add(new TableFieldInfo("Remark",false,typeof(System.String),1000,true,"","备注"));
            FieldInfoList.Add(new TableFieldInfo("CreateTime",false,typeof(System.DateTime),8,true,"","创建时间"));
            FieldInfoList.Add(new TableFieldInfo("Creator",false,typeof(System.String),50,true,"","创建者"));
            FieldInfoList.Add(new TableFieldInfo("WFAdministrator",false,typeof(System.String),150,true,"","流程管理员"));
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
            /// 工作流标识
            /// </summary>
             WorkFlowID,
            /// <summary>
            /// 工作流名称
            /// </summary>
             WorkFlowName,
            /// <summary>
            /// 备注
            /// </summary>
             Remark,
            /// <summary>
            /// 创建时间
            /// </summary>
             CreateTime,
            /// <summary>
            /// 创建者
            /// </summary>
             Creator,
            /// <summary>
            /// 流程管理员
            /// </summary>
             WFAdministrator,
            /// <summary>
            /// 是否启用
            /// </summary>
             Enabled
        }
    }
}
