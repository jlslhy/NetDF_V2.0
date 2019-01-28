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
    public class Role_Model:Model.Base.ModelBase
    {
	    public Role_Model()
        {
            TableName = "Role";
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
                return @"INSERT INTO [Role]
           ( [RoleName],[RoleDesc]) VALUES (@RoleName,@RoleDesc)";}}

        public override string UpdateSQL
        { get
            {
                return @"UPDATE [Role]
            SET [RoleName]=@RoleName,[RoleDesc]=@RoleDesc WHERE  [ID]=@ID";}}

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
            list.Add(new SqlParameter("@RoleName",M_RoleName));
            list.Add(new SqlParameter("@RoleDesc",M_RoleDesc));
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
 private string M_RoleName;

 // 
 private string M_RoleDesc;

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
 public string RoleName{

            get{
                return M_RoleName;
                }
                 
            set{
                M_RoleName=value;
                }
                 
}
/// <summary>
        /// 
        /// </summary>
 public string RoleDesc{

            get{
                return M_RoleDesc;
                }
                 
            set{
                M_RoleDesc=value;
                }
                 
}

    }
}