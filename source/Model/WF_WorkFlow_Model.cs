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
    public class WF_WorkFlow_Model:Model.Base.ModelBase
    {
	    public WF_WorkFlow_Model()
        {
            TableName = "WF_WorkFlow";
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
        { 
            get
            {
                return @"INSERT INTO [WF_WorkFlow]
           ( [WorkFlowID],[WorkFlowName],[Remark],[CreateTime],[Creator],[WFAdministrator],[Enabled]) VALUES (@WorkFlowID,@WorkFlowName,@Remark,@CreateTime,@Creator,@WFAdministrator,@Enabled);select @@identity ";
            }
        }

        public override string UpdateSQL
        { 
            get
            {
                return @"UPDATE [WF_WorkFlow]
            SET [WorkFlowID]=@WorkFlowID,[WorkFlowName]=@WorkFlowName,[Remark]=@Remark,[CreateTime]=@CreateTime,[Creator]=@Creator,[WFAdministrator]=@WFAdministrator,[Enabled]=@Enabled WHERE  [ID]=@ID";
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
                list.Add(new SqlParameter("@ID", M_ID));
                return list.ToArray();
            }
        }

        public List<SqlParameter> GetNotKeyParams()
        {
            
            List<SqlParameter> list = new List<SqlParameter>();
            list.Add(new SqlParameter("@WorkFlowID",M_WorkFlowID));
            list.Add(new SqlParameter("@WorkFlowName",M_WorkFlowName));
            list.Add(new SqlParameter("@Remark",M_Remark));
            list.Add(new SqlParameter("@CreateTime",M_CreateTime));
            list.Add(new SqlParameter("@Creator",M_Creator));
            list.Add(new SqlParameter("@WFAdministrator",M_WFAdministrator));
            list.Add(new SqlParameter("@Enabled",M_Enabled));
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

         // 工作流标识
         private int? M_WorkFlowID;

         // 工作流名称
         private string M_WorkFlowName;

         // 备注
         private string M_Remark;

         // 创建时间
         private DateTime? M_CreateTime;

         // 创建者
         private string M_Creator;

         // 流程管理员
         private string M_WFAdministrator;

         // 是否启用
         private bool? M_Enabled;

		
         /// <summary>
         /// (主键)
         /// </summary>
         public int ID
         {
            get
              {
                   return M_ID;
              }
            set
              {
                   M_ID=value;
              }
          }

         /// <summary>
         /// 工作流标识
         /// </summary>
         public int? WorkFlowID
         {
            get
              {
                   return M_WorkFlowID;
              }
            set
              {
                   M_WorkFlowID=value;
              }
          }

         /// <summary>
         /// 工作流名称
         /// </summary>
         public string WorkFlowName
         {
            get
              {
                   return M_WorkFlowName;
              }
            set
              {
                   M_WorkFlowName=value;
              }
          }

         /// <summary>
         /// 备注
         /// </summary>
         public string Remark
         {
            get
              {
                   return M_Remark;
              }
            set
              {
                   M_Remark=value;
              }
          }

         /// <summary>
         /// 创建时间
         /// </summary>
         public DateTime? CreateTime
         {
            get
              {
                   return M_CreateTime;
              }
            set
              {
                   M_CreateTime=value;
              }
          }

         /// <summary>
         /// 创建者
         /// </summary>
         public string Creator
         {
            get
              {
                   return M_Creator;
              }
            set
              {
                   M_Creator=value;
              }
          }

         /// <summary>
         /// 流程管理员
         /// </summary>
         public string WFAdministrator
         {
            get
              {
                   return M_WFAdministrator;
              }
            set
              {
                   M_WFAdministrator=value;
              }
          }

         /// <summary>
         /// 是否启用
         /// </summary>
         public bool? Enabled
         {
            get
              {
                   return M_Enabled;
              }
            set
              {
                   M_Enabled=value;
              }
          }

    }
}