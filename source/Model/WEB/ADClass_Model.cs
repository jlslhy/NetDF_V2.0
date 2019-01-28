/*
 * 框架版本：NetDF2.0  
 * 架构设计开发、版权所有者：李青锦 
 * QQ：3425806176 
 * 技术网站：软艺软件(www.ruanyi.online) 
 * 技术交流群：826373349
 * */
using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
namespace Model.WEB
{
    public class ADClass_Model:Model.Base.ModelBase
    {
	    public ADClass_Model()
        {
            TableName = "ADClass";
            PKey = "ADClassID";
            PKeyDataType = typeof(System.Int32);
        }

        public override object PKeyValue
        {
            get
            {
                return M_ADClassID;
            }
            set
            {
                M_ADClassID = (System.Int32)value;
            }
        }

        public override string AddSQL
        { 
            get
            {
                return @"INSERT INTO [ADClass]
           ( [ADClassName],[Description],[ParentId]) VALUES (@ADClassName,@Description,@ParentId);select @@identity ";
            }
        }

        public override string UpdateSQL
        { 
            get
            {
                return @"UPDATE [ADClass]
            SET [ADClassName]=@ADClassName,[Description]=@Description,[ParentId]=@ParentId WHERE  [ADClassID]=@ADClassID";
            }
        }

        public override SqlParameter[] ParamsForAdd
        { 
            get
            {
                 List<SqlParameter> list = GetNotKeyParams();
                 return list.ToArray();
            }
        }

        public override SqlParameter[] ParamsForUpdate
        { 
            get
            {
                List<SqlParameter> list = GetNotKeyParams();
                list.Add(new SqlParameter("@ADClassID", M_ADClassID));
                return list.ToArray();
            }
        }

        public List<SqlParameter> GetNotKeyParams()
        {
            
            List<SqlParameter> list = new List<SqlParameter>();
            list.Add(new SqlParameter("@ADClassName",M_ADClassName));
            list.Add(new SqlParameter("@Description",M_Description));
            list.Add(new SqlParameter("@ParentId",M_ParentId));
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
         private int M_ADClassID;

         // 
         private string M_ADClassName;

         // 
         private string M_Description;

         // 
         private int? M_ParentId;

		
         /// <summary>
         /// (主键)
         /// </summary>
         public int ADClassID
         {
            get
              {
                   return M_ADClassID;
              }
            set
              {
                   M_ADClassID=value;
              }
          }

         /// <summary>
         /// 
         /// </summary>
         public string ADClassName
         {
            get
              {
                   return M_ADClassName;
              }
            set
              {
                   M_ADClassName=value;
              }
          }

         /// <summary>
         /// 
         /// </summary>
         public string Description
         {
            get
              {
                   return M_Description;
              }
            set
              {
                   M_Description=value;
              }
          }

         /// <summary>
         /// 
         /// </summary>
         public int? ParentId
         {
            get
              {
                   return M_ParentId;
              }
            set
              {
                   M_ParentId=value;
              }
          }

    }
}