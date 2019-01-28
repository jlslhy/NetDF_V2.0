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
    public class SystemSetup_Model:Model.Base.ModelBase
    {
	    public SystemSetup_Model()
        {
            TableName = "SystemSetup";
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
                return @"INSERT INTO [SystemSetup]
           ( [KeyCode],[SetupValue],[SetupType],[Remark]) VALUES (@KeyCode,@SetupValue,@SetupType,@Remark);select @@identity ";}}

        public override string UpdateSQL
        { get
            {
                return @"UPDATE [SystemSetup]
            SET [KeyCode]=@KeyCode,[SetupValue]=@SetupValue,[SetupType]=@SetupType,[Remark]=@Remark WHERE  [ID]=@ID";}}

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
            list.Add(new SqlParameter("@KeyCode",M_KeyCode));
            list.Add(new SqlParameter("@SetupValue",M_SetupValue));
            list.Add(new SqlParameter("@SetupType",M_SetupType));
            list.Add(new SqlParameter("@Remark",M_Remark));
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
 private string M_KeyCode;

 // 
 private string M_SetupValue;

 // 分类
 private string M_SetupType;

 // 
 private string M_Remark;

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
 public string KeyCode{

            get{
                return M_KeyCode;
                }
                 
            set{
                M_KeyCode=value;
                }
                 
}
/// <summary>
        /// 
        /// </summary>
 public string SetupValue{

            get{
                return M_SetupValue;
                }
                 
            set{
                M_SetupValue=value;
                }
                 
}
/// <summary>
        /// 分类
        /// </summary>
 public string SetupType{

            get{
                return M_SetupType;
                }
                 
            set{
                M_SetupType=value;
                }
                 
}
/// <summary>
        /// 
        /// </summary>
 public string Remark{

            get{
                return M_Remark;
                }
                 
            set{
                M_Remark=value;
                }
                 
}

    }
}