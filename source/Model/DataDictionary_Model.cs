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
    public class DataDictionary_Model:Model.Base.ModelBase
    {
	    public DataDictionary_Model()
        {
            TableName = "DataDictionary";
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
                return @"INSERT INTO [DataDictionary]
           ( [CategoryCode],[DataKey],[DataValue],[OrderNumber]) VALUES (@CategoryCode,@DataKey,@DataValue,@OrderNumber);select @@identity ";}}

        public override string UpdateSQL
        { get
            {
                return @"UPDATE [DataDictionary]
            SET [CategoryCode]=@CategoryCode,[DataKey]=@DataKey,[DataValue]=@DataValue,[OrderNumber]=@OrderNumber WHERE  [ID]=@ID";}}

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
            list.Add(new SqlParameter("@DataKey",M_DataKey));
            list.Add(new SqlParameter("@DataValue",M_DataValue));
            list.Add(new SqlParameter("@OrderNumber",M_OrderNumber));
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

 // 分类ID
 private string M_CategoryCode;

 // 
 private string M_DataKey;

 // 
 private string M_DataValue;

 // 
 private int? M_OrderNumber;

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
        /// 分类ID
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
 public string DataKey{

            get{
                return M_DataKey;
                }
                 
            set{
                M_DataKey=value;
                }
                 
}
/// <summary>
        /// 
        /// </summary>
 public string DataValue{

            get{
                return M_DataValue;
                }
                 
            set{
                M_DataValue=value;
                }
                 
}
/// <summary>
        /// 
        /// </summary>
 public int? OrderNumber{

            get{
                return M_OrderNumber;
                }
                 
            set{
                M_OrderNumber=value;
                }
                 
}

    }
}