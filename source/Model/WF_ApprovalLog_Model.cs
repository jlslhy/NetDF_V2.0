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
    public class WF_ApprovalLog_Model:Model.Base.ModelBase
    {
	    public WF_ApprovalLog_Model()
        {
            TableName = "WF_ApprovalLog";
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
                return @"INSERT INTO [WF_ApprovalLog]
           ( [InstanceID],[ApprovalNodeID],[Approver],[AppTime],[ApprovalOpinion],[TheNextStep]) VALUES (@InstanceID,@ApprovalNodeID,@Approver,@AppTime,@ApprovalOpinion,@TheNextStep);select @@identity ";
            }
        }

        public override string UpdateSQL
        { 
            get
            {
                return @"UPDATE [WF_ApprovalLog]
            SET [InstanceID]=@InstanceID,[ApprovalNodeID]=@ApprovalNodeID,[Approver]=@Approver,[AppTime]=@AppTime,[ApprovalOpinion]=@ApprovalOpinion,[TheNextStep]=@TheNextStep WHERE  [ID]=@ID";
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
            list.Add(new SqlParameter("@InstanceID",M_InstanceID));
            list.Add(new SqlParameter("@ApprovalNodeID",M_ApprovalNodeID));
            list.Add(new SqlParameter("@Approver",M_Approver));
            list.Add(new SqlParameter("@AppTime",M_AppTime));
            list.Add(new SqlParameter("@ApprovalOpinion",M_ApprovalOpinion));
            list.Add(new SqlParameter("@TheNextStep",M_TheNextStep));
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

         // 所属实例ID
         private int? M_InstanceID;

         // 审批环节ID
         private int? M_ApprovalNodeID;

         // 审批人
         private string M_Approver;

         // 审批时间
         private DateTime? M_AppTime;

         // 审批意见
         private string M_ApprovalOpinion;

         // 下一步，动作路线与节点
         private string M_TheNextStep;

		
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
         /// 所属实例ID
         /// </summary>
         public int? InstanceID
         {
            get
              {
                    return M_InstanceID;
              }
            set
              {
                    M_InstanceID=value;
              }
          }

         /// <summary>
         /// 审批环节ID
         /// </summary>
         public int? ApprovalNodeID
         {
            get
              {
                    return M_ApprovalNodeID;
              }
            set
              {
                    M_ApprovalNodeID=value;
              }
          }

         /// <summary>
         /// 审批人
         /// </summary>
         public string Approver
         {
            get
              {
                    return M_Approver;
              }
            set
              {
                    M_Approver=value;
              }
          }

         /// <summary>
         /// 审批时间
         /// </summary>
         public DateTime? AppTime
         {
            get
              {
                    return M_AppTime;
              }
            set
              {
                    M_AppTime=value;
              }
          }

         /// <summary>
         /// 审批意见
         /// </summary>
         public string ApprovalOpinion
         {
            get
              {
                    return M_ApprovalOpinion;
              }
            set
              {
                    M_ApprovalOpinion=value;
              }
          }

         /// <summary>
         /// 下一步，动作路线与节点
         /// </summary>
         public string TheNextStep
         {
            get
              {
                    return M_TheNextStep;
              }
            set
              {
                    M_TheNextStep=value;
              }
          }

    }
}