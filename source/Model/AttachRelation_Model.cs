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
    public class AttachRelation_Model:Model.Base.ModelBase
    {
	    public AttachRelation_Model()
        {
            TableName = "AttachRelation";
            PKey = "AttachRelationID";
            PKeyDataType = typeof(System.Int32);
        }

        public override object PKeyValue
        {
            get
            {
                return M_AttachRelationID;
            }
            set
            {
                M_AttachRelationID = (System.Int32)value;
            }
        }

        public override string AddSQL
        { get
            {
                return @"INSERT INTO [AttachRelation]
           ( [AttachID],[TableName],[TableID],[AttachType]) VALUES (@AttachID,@TableName,@TableID,@AttachType);select @@identity ";}}

        public override string UpdateSQL
        { get
            {
                return @"UPDATE [AttachRelation]
            SET [AttachID]=@AttachID,[TableName]=@TableName,[TableID]=@TableID,[AttachType]=@AttachType WHERE  [AttachRelationID]=@AttachRelationID";}}

        public override SqlParameter[] ParamsForAdd
        { get
            {
                 List<SqlParameter> list = GetNotKeyParams();return list.ToArray();}}

        public override SqlParameter[] ParamsForUpdate
        { get
            {
                 List<SqlParameter> list = GetNotKeyParams();
                list.Add(new SqlParameter("@AttachRelationID", M_AttachRelationID));
                return list.ToArray();}}

        public List<SqlParameter> GetNotKeyParams()
        {
            
            List<SqlParameter> list = new List<SqlParameter>();
            list.Add(new SqlParameter("@AttachID",M_AttachID));
            list.Add(new SqlParameter("@TableName",M_TableName));
            list.Add(new SqlParameter("@TableID",M_TableID));
            list.Add(new SqlParameter("@AttachType",M_AttachType));
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
 private int M_AttachRelationID;

 // 
 private int? M_AttachID;

 // 
 private string M_TableName;

 // 图片分类
 private int? M_TableID;

 // 
 private string M_AttachType;

		/// <summary>
        /// (主键)
        /// </summary>
 public int AttachRelationID{

            get{
                return M_AttachRelationID;
                }
                 
            set{
                M_AttachRelationID=value;
                }
                 
}
/// <summary>
        /// 
        /// </summary>
 public int? AttachID{

            get{
                return M_AttachID;
                }
                 
            set{
                M_AttachID=value;
                }
                 
}
/// <summary>
        /// 
        /// </summary>
 public string TableName{

            get{
                return M_TableName;
                }
                 
            set{
                M_TableName=value;
                }
                 
}
/// <summary>
        /// 图片分类
        /// </summary>
 public int? TableID{

            get{
                return M_TableID;
                }
                 
            set{
                M_TableID=value;
                }
                 
}
/// <summary>
        /// 
        /// </summary>
 public string AttachType{

            get{
                return M_AttachType;
                }
                 
            set{
                M_AttachType=value;
                }
                 
}

    }
}