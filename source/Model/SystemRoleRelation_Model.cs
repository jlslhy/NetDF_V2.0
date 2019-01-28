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
    public class SystemRoleRelation_Model:Model.Base.ModelBase
    {
	    public SystemRoleRelation_Model()
        {
            TableName = "SystemRoleRelation";
            PKey = "SystemRoleRelationID";
            PKeyDataType = typeof(System.Int32);
        }

        public override object PKeyValue
        {
            get
            {
                return M_SystemRoleRelationID;
            }
            set
            {
                M_SystemRoleRelationID = (System.Int32)value;
            }
        }

        public override string AddSQL
        { get
            {
                return @"INSERT INTO [SystemRoleRelation]
           ( [SystemRoleID],[UserID]) VALUES (@SystemRoleID,@UserID);select @@identity ";}}

        public override string UpdateSQL
        { get
            {
                return @"UPDATE [SystemRoleRelation]
            SET [SystemRoleID]=@SystemRoleID,[UserID]=@UserID WHERE  [SystemRoleRelationID]=@SystemRoleRelationID";}}

        public override SqlParameter[] ParamsForAdd
        { get
            {
                 List<SqlParameter> list = GetNotKeyParams();return list.ToArray();}}

        public override SqlParameter[] ParamsForUpdate
        { get
            {
                 List<SqlParameter> list = GetNotKeyParams();
                list.Add(new SqlParameter("@SystemRoleRelationID", M_SystemRoleRelationID));
                return list.ToArray();}}

        public List<SqlParameter> GetNotKeyParams()
        {
            
            List<SqlParameter> list = new List<SqlParameter>();
            list.Add(new SqlParameter("@SystemRoleID",M_SystemRoleID));
            list.Add(new SqlParameter("@UserID",M_UserID));
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
 private int M_SystemRoleRelationID;

 // 
 private int? M_SystemRoleID;

 // 
 private int? M_UserID;

		/// <summary>
        /// (主键)
        /// </summary>
 public int SystemRoleRelationID{

            get{
                return M_SystemRoleRelationID;
                }
                 
            set{
                M_SystemRoleRelationID=value;
                }
                 
}
/// <summary>
        /// 
        /// </summary>
 public int? SystemRoleID{

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
 public int? UserID{

            get{
                return M_UserID;
                }
                 
            set{
                M_UserID=value;
                }
                 
}

    }
}