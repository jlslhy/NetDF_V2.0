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
    public class CommentRelation : TableBase
    {
        public static string PKey = "CommentRelationID";
        public static Type PKeyDataType = typeof(System.Int64);
        public string TableDesc="CommentRelation";
        
        public CommentRelation() {
            
            FieldInfoList.Add(new TableFieldInfo("CommentRelationID",true,typeof(System.Int64),8,false,"",""));
            FieldInfoList.Add(new TableFieldInfo("CommentID",false,typeof(System.Int64),8,true,"",""));
            FieldInfoList.Add(new TableFieldInfo("TableName",false,typeof(System.String),50,true,"",""));
            FieldInfoList.Add(new TableFieldInfo("TableID",false,typeof(System.Int64),8,true,"",""));
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
             CommentRelationID,
            /// <summary>
            /// 
            /// </summary>
             CommentID,
            /// <summary>
            /// 
            /// </summary>
             TableName,
            /// <summary>
            /// 
            /// </summary>
             TableID
        }
    }
}
