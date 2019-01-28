/*
 * 框架版本：NetDF2.0  
 * 架构设计与开发者：李青锦 
 * QQ：3425806176 
 * 技术网站：软艺软件(www.ruanyi.online) 
 * 技术交流群：826373349
 * */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DBControl.DBInfo.Tables.WEB
{
    public class Users : TableBase
    {
        
        public string TableDesc="Users";
        
        public Users() {
            TableName = "Users";
            PKey = "UserID";
            PKeyDataType = typeof(System.Int32);
            
            FieldInfoList.Add(new TableFieldInfo("UserID",true,typeof(System.Int32),4,false,"",""));
            FieldInfoList.Add(new TableFieldInfo("LoginID",false,typeof(System.String),50,true,"",""));
            FieldInfoList.Add(new TableFieldInfo("UserPwd",false,typeof(System.String),50,true,"",""));
            FieldInfoList.Add(new TableFieldInfo("RealName",false,typeof(System.String),50,true,"",""));
            FieldInfoList.Add(new TableFieldInfo("DepartmentID",false,typeof(System.Int32),4,true,"",""));
            FieldInfoList.Add(new TableFieldInfo("Mobile",false,typeof(System.String),50,true,"",""));
            FieldInfoList.Add(new TableFieldInfo("Email",false,typeof(System.String),50,true,"",""));
            FieldInfoList.Add(new TableFieldInfo("QQ",false,typeof(System.String),50,true,"",""));
            FieldInfoList.Add(new TableFieldInfo("CreatTime",false,typeof(System.DateTime),8,true,"(getdate())",""));
            FieldInfoList.Add(new TableFieldInfo("ModifyTime",false,typeof(System.DateTime),8,true,"",""));
            FieldInfoList.Add(new TableFieldInfo("Creator",false,typeof(System.String),50,true,"",""));
            FieldInfoList.Add(new TableFieldInfo("Editor",false,typeof(System.String),50,true,"",""));
            FieldInfoList.Add(new TableFieldInfo("LastLoginIP",false,typeof(System.String),23,true,"",""));
            FieldInfoList.Add(new TableFieldInfo("LastLoginTime",false,typeof(System.DateTime),8,true,"",""));
            FieldInfoList.Add(new TableFieldInfo("IsEnabled",false,typeof(System.Boolean),1,true,"",""));
            FieldInfoList.Add(new TableFieldInfo("IsLocked",false,typeof(System.Boolean),1,true,"",""));
            FieldInfoList.Add(new TableFieldInfo("Remark",false,typeof(System.String),500,true,"","备注"));
            FieldInfoList.Add(new TableFieldInfo("ordernum",false,typeof(System.Double),8,true,"",""));
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
             UserID,
            /// <summary>
            /// 
            /// </summary>
             LoginID,
            /// <summary>
            /// 
            /// </summary>
             UserPwd,
            /// <summary>
            /// 
            /// </summary>
             RealName,
            /// <summary>
            /// 
            /// </summary>
             DepartmentID,
            /// <summary>
            /// 
            /// </summary>
             Mobile,
            /// <summary>
            /// 
            /// </summary>
             Email,
            /// <summary>
            /// 
            /// </summary>
             QQ,
            /// <summary>
            /// 
            /// </summary>
             CreatTime,
            /// <summary>
            /// 
            /// </summary>
             ModifyTime,
            /// <summary>
            /// 
            /// </summary>
             Creator,
            /// <summary>
            /// 
            /// </summary>
             Editor,
            /// <summary>
            /// 
            /// </summary>
             LastLoginIP,
            /// <summary>
            /// 
            /// </summary>
             LastLoginTime,
            /// <summary>
            /// 
            /// </summary>
             IsEnabled,
            /// <summary>
            /// 
            /// </summary>
             IsLocked,
            /// <summary>
            /// 备注
            /// </summary>
             Remark,
            /// <summary>
            /// 
            /// </summary>
             ordernum
        }
    }
}
