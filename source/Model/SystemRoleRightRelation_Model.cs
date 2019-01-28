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
    public class SystemRoleRightRelation_Model:Model.Base.ModelBase
    {
	    public SystemRoleRightRelation_Model()
        {
            TableName = "SystemRoleRightRelation";
            PKey = "SystemRoleRightRelationID";
            PKeyDataType = typeof(System.Int32);
        }

        public override object PKeyValue
        {
            get
            {
                return M_SystemRoleRightRelationID;
            }
            set
            {
                M_SystemRoleRightRelationID = (System.Int32)value;
            }
        }

        public override string AddSQL
        { get
            {
                return @"INSERT INTO [SystemRoleRightRelation]
           ( [SystemRoleID],[SystemRightID]) VALUES (@SystemRoleID,@SystemRightID);select @@identity ";}}

        public override string UpdateSQL
        { get
            {
                return @"UPDATE [SystemRoleRightRelation]
            SET [SystemRoleID]=@SystemRoleID,[SystemRightID]=@SystemRightID WHERE  [SystemRoleRightRelationID]=@SystemRoleRightRelationID";}}

        public override SqlParameter[] ParamsForAdd
        { get
            {
                 List<SqlParameter> list = GetNotKeyParams();return list.ToArray();}}

        public override SqlParameter[] ParamsForUpdate
        { get
            {
                 List<SqlParameter> list = GetNotKeyParams();
                list.Add(new SqlParameter("@SystemRoleRightRelationID", M_SystemRoleRightRelationID));
                return list.ToArray();}}

        public List<SqlParameter> GetNotKeyParams()
        {
            
            List<SqlParameter> list = new List<SqlParameter>();
            list.Add(new SqlParameter("@SystemRoleID",M_SystemRoleID));
            list.Add(new SqlParameter("@SystemRightID",M_SystemRightID));
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
 private int M_SystemRoleRightRelationID;

 // 
 private int M_SystemRoleID;

 // 
 private int M_SystemRightID;

		/// <summary>
        /// (主键)
        /// </summary>
 public int SystemRoleRightRelationID{

            get{
                return M_SystemRoleRightRelationID;
                }
                 
            set{
                M_SystemRoleRightRelationID=value;
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
 public int SystemRightID{

            get{
                return M_SystemRightID;
                }
                 
            set{
                M_SystemRightID=value;
                }
                 
}

    }
}