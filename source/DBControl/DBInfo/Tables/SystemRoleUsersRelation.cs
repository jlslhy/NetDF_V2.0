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
    public class SystemRoleUsersRelation : TableBase
    {
        
        public string TableDesc="SystemRoleUsersRelation";
        
        public SystemRoleUsersRelation() {
            TableName = "SystemRoleUsersRelation";
            PKey = "SystemRoleUsersRelationID";
            PKeyDataType = typeof(System.Int32);
            
            FieldInfoList.Add(new TableFieldInfo("SystemRoleUsersRelationID",true,typeof(System.Int32),4,false,"",""));
            FieldInfoList.Add(new TableFieldInfo("SystemRoleID",false,typeof(System.Int32),4,false,"",""));
            FieldInfoList.Add(new TableFieldInfo("SystemUserID",false,typeof(System.Int32),4,false,"",""));
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
             SystemRoleUsersRelationID,
            /// <summary>
            /// 
            /// </summary>
             SystemRoleID,
            /// <summary>
            /// 
            /// </summary>
             SystemUserID
        }
    }
}
