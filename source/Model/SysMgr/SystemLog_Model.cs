/*
 * 框架版本：NetDF2.0  
 * 架构设计与开发、版权所有者：李青锦 
 * QQ：3425806176 
 * 技术网站：软艺软件(www.ruanyi.online) 
 * 技术交流群：826373349
 * */

using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
namespace Model.SysMgr
{
    public class SystemLog_Model:Model.Base.ModelBase
    {
	    public SystemLog_Model()
        {
            TableName = "SystemLog";
            PKey = "LogID";
            PKeyDataType = typeof(System.Int64);
        }

        public override object PKeyValue
        {
            get
            {
                return M_LogID;
            }
            set
            {
                M_LogID = (System.Int64)value;
            }
        }

        public override string AddSQL
        { get
            {
                return @"INSERT INTO [SystemLog]
           ( [LogClass],[LogTitle],[LogContent],[CreateTime],[Operator]) VALUES (@LogClass,@LogTitle,@LogContent,@CreateTime,@Operator)";}}

        public override string UpdateSQL
        { get
            {
                return @"UPDATE [SystemLog]
            SET [LogClass]=@LogClass,[LogTitle]=@LogTitle,[LogContent]=@LogContent,[CreateTime]=@CreateTime,[Operator]=@Operator WHERE  [LogID]=@LogID";}}

        public override SqlParameter[] ParamsForAdd
        { get
            {
                 List<SqlParameter> list = GetNotKeyParams();return list.ToArray();}}

        public override SqlParameter[] ParamsForUpdate
        { get
            {
                 List<SqlParameter> list = GetNotKeyParams();return list.ToArray();}}

        public List<SqlParameter> GetNotKeyParams()
        {
            
            List<SqlParameter> list = new List<SqlParameter>();
            list.Add(new SqlParameter("@LogClass",M_LogClass));
            list.Add(new SqlParameter("@LogTitle",M_LogTitle));
            list.Add(new SqlParameter("@LogContent",M_LogContent));
            list.Add(new SqlParameter("@CreateTime",M_CreateTime));
            list.Add(new SqlParameter("@Operator",M_Operator));
            foreach (SqlParameter par in list)
            {
                if (null == par.Value)
                {
                    par.Value = DBNull.Value;
                }
            }
            return list;
        }

	    

 // (主键)
 private long M_LogID;

 // 日志类别
 private string M_LogClass;

 // 日志标题
 private string M_LogTitle;

 // 日志内容
 private string M_LogContent;

 // 
 private DateTime? M_CreateTime;

 // 操作者
 private string M_Operator;

		/// <summary>
        /// (主键)
        /// </summary>
 public long LogID{

            get{
                return M_LogID;
                }
                 
            set{
                M_LogID=value;
                }
                 
}
/// <summary>
        /// 日志类别
        /// </summary>
 public string LogClass{

            get{
                return M_LogClass;
                }
                 
            set{
                M_LogClass=value;
                }
                 
}
/// <summary>
        /// 日志标题
        /// </summary>
 public string LogTitle{

            get{
                return M_LogTitle;
                }
                 
            set{
                M_LogTitle=value;
                }
                 
}
/// <summary>
        /// 日志内容
        /// </summary>
 public string LogContent{

            get{
                return M_LogContent;
                }
                 
            set{
                M_LogContent=value;
                }
                 
}
/// <summary>
        /// 
        /// </summary>
 public DateTime? CreateTime{

            get{
                return M_CreateTime;
                }
                 
            set{
                M_CreateTime=value;
                }
                 
}
/// <summary>
        /// 操作者
        /// </summary>
 public string Operator{

            get{
                return M_Operator;
                }
                 
            set{
                M_Operator=value;
                }
                 
}

    }
}