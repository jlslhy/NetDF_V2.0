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
    public class SystemRoleUsersRelation_Model:Model.Base.ModelBase
    {
	    public SystemRoleUsersRelation_Model()
        {
            TableName = "SystemRoleUsersRelation";
            PKey = "SystemRoleUsersRelationID";
            PKeyDataType = typeof(System.Int32);
        }

        public override object PKeyValue
        {
            get
            {
                return M_SystemRoleUsersRelationID;
            }
            set
            {
                M_SystemRoleUsersRelationID = (System.Int32)value;
            }
        }

        public override string AddSQL
        { get
            {
                return @"INSERT INTO [SystemRoleUsersRelation]
           ( [SystemRoleID],[SystemUserID]) VALUES (@SystemRoleID,@SystemUserID);select @@identity ";}}

        public override string UpdateSQL
        { get
            {
                return @"UPDATE [SystemRoleUsersRelation]
            SET [SystemRoleID]=@SystemRoleID,[SystemUserID]=@SystemUserID WHERE  [SystemRoleUsersRelationID]=@SystemRoleUsersRelationID";}}

        public override SqlParameter[] ParamsForAdd
        { get
            {
                 List<SqlParameter> list = GetNotKeyParams();return list.ToArray();}}

        public override SqlParameter[] ParamsForUpdate
        { get
            {
                 List<SqlParameter> list = GetNotKeyParams();
                list.Add(new SqlParameter("@SystemRoleUsersRelationID", M_SystemRoleUsersRelationID));
                return list.ToArray();}}

        public List<SqlParameter> GetNotKeyParams()
        {
            
            List<SqlParameter> list = new List<SqlParameter>();
            list.Add(new SqlParameter("@SystemRoleID",M_SystemRoleID));
            list.Add(new SqlParameter("@SystemUserID",M_SystemUserID));
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
 private int M_SystemRoleUsersRelationID;

 // 
 private int M_SystemRoleID;

 // 
 private int M_SystemUserID;

		/// <summary>
        /// (主键)
        /// </summary>
 public int SystemRoleUsersRelationID{

            get{
                return M_SystemRoleUsersRelationID;
                }
                 
            set{
                M_SystemRoleUsersRelationID=value;
                }
                 
}
/// <summary>
        /// 
        /// </summary>
 public int SystemRoleID{

            get{
                return M_SystemRoleID;
                }
                 
            set{
                M_SystemRoleID=value;
                }
                 
}
/// <summary>
        /// 
        /// </summary>
 public int SystemUserID{

            get{
                return M_SystemUserID;
                }
                 
            set{
                M_SystemUserID=value;
                }
                 
}

    }
}