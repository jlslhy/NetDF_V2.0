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
    public class Department : TableBase
    {
        
        public string TableDesc="Department";
        
        public Department() {
            TableName = "Department";
            PKey = "DepartmentID";
            PKeyDataType = typeof(System.Int32);
            
            FieldInfoList.Add(new TableFieldInfo("DepartmentID",true,typeof(System.Int32),4,false,"",""));
            FieldInfoList.Add(new TableFieldInfo("DeptName",false,typeof(System.String),50,true,"",""));
            FieldInfoList.Add(new TableFieldInfo("DeptFullID",false,typeof(System.String),50,true,"",""));
            FieldInfoList.Add(new TableFieldInfo("DeptFullName",false,typeof(System.String),150,true,"","全称"));
            FieldInfoList.Add(new TableFieldInfo("PDepartmentID",false,typeof(System.Int32),4,true,"",""));
            FieldInfoList.Add(new TableFieldInfo("DeptLevel",false,typeof(System.Int32),4,true,"","部门层级"));
            FieldInfoList.Add(new TableFieldInfo("DeptDesc",false,typeof(System.String),150,true,"",""));
            FieldInfoList.Add(new TableFieldInfo("IsEnabled",false,typeof(System.Boolean),1,true,"",""));
            FieldInfoList.Add(new TableFieldInfo("CreateTime",false,typeof(System.DateTime),8,true,"","创建时间"));
            FieldInfoList.Add(new TableFieldInfo("ModifyTime",false,typeof(System.DateTime),8,true,"","修改时间"));
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
             DepartmentID,
            /// <summary>
            /// 
            /// </summary>
             DeptName,
            /// <summary>
            /// 
            /// </summary>
             DeptFullID,
            /// <summary>
            /// 全称
            /// </summary>
             DeptFullName,
            /// <summary>
            /// 
            /// </summary>
             PDepartmentID,
            /// <summary>
            /// 部门层级
            /// </summary>
             DeptLevel,
            /// <summary>
            /// 
            /// </summary>
             DeptDesc,
            /// <summary>
            /// 
            /// </summary>
             IsEnabled,
            /// <summary>
            /// 创建时间
            /// </summary>
             CreateTime,
            /// <summary>
            /// 修改时间
            /// </summary>
             ModifyTime,
            /// <summary>
            /// 
            /// </summary>
             ordernum
        }
    }
}
