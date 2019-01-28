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
    public class SystemRole : TableBase
    {
        
        public string TableDesc="SystemRole";
        
        public SystemRole() {
            TableName = "SystemRole";
            PKey = "SystemRoleID";
            PKeyDataType = typeof(System.Int32);
            
            FieldInfoList.Add(new TableFieldInfo("SystemRoleID",true,typeof(System.Int32),4,false,"",""));
            FieldInfoList.Add(new TableFieldInfo("SystemRoleName",false,typeof(System.String),50,true,"","角色名称"));
            FieldInfoList.Add(new TableFieldInfo("RoleDesc",false,typeof(System.String),300,true,"",""));
            FieldInfoList.Add(new TableFieldInfo("IsSystem",false,typeof(System.Boolean),1,true,"","是否系统角色"));
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
             SystemRoleID,
            /// <summary>
            /// 角色名称
            /// </summary>
             SystemRoleName,
            /// <summary>
            /// 
            /// </summary>
             RoleDesc,
            /// <summary>
            /// 是否系统角色
            /// </summary>
             IsSystem
        }
    }
}
