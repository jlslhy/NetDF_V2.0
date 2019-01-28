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
    public class Comment : TableBase
    {
        public static string PKey = "CommentID";
        public static Type PKeyDataType = typeof(System.Int64);
        public string TableDesc="Comment";
        
        public Comment() {
            
            FieldInfoList.Add(new TableFieldInfo("CommentID",true,typeof(System.Int64),8,false,"",""));
            FieldInfoList.Add(new TableFieldInfo("CommentTitle",false,typeof(System.String),150,true,"","评论标题"));
            FieldInfoList.Add(new TableFieldInfo("CommentContent",false,typeof(System.String),16,true,"","评论内容"));
            FieldInfoList.Add(new TableFieldInfo("CreateTime",false,typeof(System.DateTime),8,true,"",""));
            FieldInfoList.Add(new TableFieldInfo("ModifyTime",false,typeof(System.DateTime),8,true,"",""));
            FieldInfoList.Add(new TableFieldInfo("Owner",false,typeof(System.String),50,true,"","所有者"));
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
             CommentID,
            /// <summary>
            /// 评论标题
            /// </summary>
             CommentTitle,
            /// <summary>
            /// 评论内容
            /// </summary>
             CommentContent,
            /// <summary>
            /// 
            /// </summary>
             CreateTime,
            /// <summary>
            /// 
            /// </summary>
             ModifyTime,
            /// <summary>
            /// 所有者
            /// </summary>
             Owner
        }
    }
}
