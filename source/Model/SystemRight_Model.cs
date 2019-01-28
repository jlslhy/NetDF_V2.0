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
    public class SystemRight_Model:Model.Base.ModelBase
    {
	    public SystemRight_Model()
        {
            TableName = "SystemRight";
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
                return @"INSERT INTO [SystemRight]
           ( [RightCode],[RightName],[RightDesc]) VALUES (@RightCode,@RightName,@RightDesc);select @@identity ";}}

        public override string UpdateSQL
        { get
            {
                return @"UPDATE [SystemRight]
            SET [RightCode]=@RightCode,[RightName]=@RightName,[RightDesc]=@RightDesc WHERE  [ID]=@ID";}}

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
            list.Add(new SqlParameter("@RightCode",M_RightCode));
            list.Add(new SqlParameter("@RightName",M_RightName));
            list.Add(new SqlParameter("@RightDesc",M_RightDesc));
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

 // 权限编号
 private string M_RightCode;

 // 权限名称
 private string M_RightName;

 // 说明
 private string M_RightDesc;

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
        /// 权限编号
        /// </summary>
 public string RightCode{

            get{
                return M_RightCode;
                }
                 
            set{
                M_RightCode=value;
                }
                 
}
/// <summary>
        /// 权限名称
        /// </summary>
 public string RightName{

            get{
                return M_RightName;
                }
                 
            set{
                M_RightName=value;
                }
                 
}
/// <summary>
        /// 说明
        /// </summary>
 public string RightDesc{

            get{
                return M_RightDesc;
                }
                 
            set{
                M_RightDesc=value;
                }
                 
}

    }
}