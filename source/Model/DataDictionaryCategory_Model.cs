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
namespace Model
{
    public class DataDictionaryCategory_Model:Model.Base.ModelBase
    {
	    public DataDictionaryCategory_Model()
        {
            TableName = "DataDictionaryCategory";
            PKey = "ID";
            PKeyDataType = typeof(System.Int32);
        }

        public override object PKeyValue
        {
            get
            {
                return M_ID;
            }
            set
            {
                M_ID = (System.Int32)value;
            }
        }

        public override string AddSQL
        { get
            {
                return @"INSERT INTO [DataDictionaryCategory]
           ( [CategoryCode],[CategoryName]) VALUES (@CategoryCode,@CategoryName);select @@identity ";}}

        public override string UpdateSQL
        { get
            {
                return @"UPDATE [DataDictionaryCategory]
            SET [CategoryCode]=@CategoryCode,[CategoryName]=@CategoryName WHERE  [ID]=@ID";}}

        public override SqlParameter[] ParamsForAdd
        { get
            {
                 List<SqlParameter> list = GetNotKeyParams();return list.ToArray();}}

        public override SqlParameter[] ParamsForUpdate
        { get
            {
                 List<SqlParameter> list = GetNotKeyParams();
                list.Add(new SqlParameter("@ID", M_ID));
                return list.ToArray();}}

        public List<SqlParameter> GetNotKeyParams()
        {
            
            List<SqlParameter> list = new List<SqlParameter>();
            list.Add(new SqlParameter("@CategoryCode",M_CategoryCode));
            list.Add(new SqlParameter("@CategoryName",M_CategoryName));
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
 private int M_ID;

 // 
 private string M_CategoryCode;

 // 
 private string M_CategoryName;

		/// <summary>
        /// (主键)
        /// </summary>
 public int ID{

            get{
                return M_ID;
                }
                 
            set{
                M_ID=value;
                }
                 
}
/// <summary>
        /// 
        /// </summary>
 public string CategoryCode{

            get{
                return M_CategoryCode;
                }
                 
            set{
                M_CategoryCode=value;
                }
                 
}
/// <summary>
        /// 
        /// </summary>
 public string CategoryName{

            get{
                return M_CategoryName;
                }
                 
            set{
                M_CategoryName=value;
                }
                 
}

    }
}