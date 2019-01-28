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
    public class WF_Node_Model:Model.Base.ModelBase
    {
	    public WF_Node_Model()
        {
            TableName = "WF_Node";
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
                return @"INSERT INTO [WF_Node]
           ( [NodeID],[NodeFlag],[NodeName],[WorkFlowID],[BranchFlowBeforehand],[IsConcurrent],[ConcurrentOnLine],[AdmissionTickets],[CanPassCountType],[CanPassCount],[CanPassPercent],[ApprovalUrl],[ViewUrl],[Remark]) VALUES (@NodeID,@NodeFlag,@NodeName,@WorkFlowID,@BranchFlowBeforehand,@IsConcurrent,@ConcurrentOnLine,@AdmissionTickets,@CanPassCountType,@CanPassCount,@CanPassPercent,@ApprovalUrl,@ViewUrl,@Remark);select @@identity ";
            }
        }

        public override string UpdateSQL
        { 
            get
            {
                return @"UPDATE [WF_Node]
            SET [NodeID]=@NodeID,[NodeFlag]=@NodeFlag,[NodeName]=@NodeName,[WorkFlowID]=@WorkFlowID,[BranchFlowBeforehand]=@BranchFlowBeforehand,[IsConcurrent]=@IsConcurrent,[ConcurrentOnLine]=@ConcurrentOnLine,[AdmissionTickets]=@AdmissionTickets,[CanPassCountType]=@CanPassCountType,[CanPassCount]=@CanPassCount,[CanPassPercent]=@CanPassPercent,[ApprovalUrl]=@ApprovalUrl,[ViewUrl]=@ViewUrl,[Remark]=@Remark WHERE  [ID]=@ID";
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
            list.Add(new SqlParameter("@NodeID",M_NodeID));
            list.Add(new SqlParameter("@NodeFlag",M_NodeFlag));
            list.Add(new SqlParameter("@NodeName",M_NodeName));
            list.Add(new SqlParameter("@WorkFlowID",M_WorkFlowID));
            list.Add(new SqlParameter("@BranchFlowBeforehand",M_BranchFlowBeforehand));
            list.Add(new SqlParameter("@IsConcurrent",M_IsConcurrent));
            list.Add(new SqlParameter("@ConcurrentOnLine",M_ConcurrentOnLine));
            list.Add(new SqlParameter("@AdmissionTickets",M_AdmissionTickets));
            list.Add(new SqlParameter("@CanPassCountType",M_CanPassCountType));
            list.Add(new SqlParameter("@CanPassCount",M_CanPassCount));
            list.Add(new SqlParameter("@CanPassPercent",M_CanPassPercent));
            list.Add(new SqlParameter("@ApprovalUrl",M_ApprovalUrl));
            list.Add(new SqlParameter("@ViewUrl",M_ViewUrl));
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

         // 节点标识
         private int? M_NodeID;

         // 节点标记
         private string M_NodeFlag;

         // 节点名称
         private string M_NodeName;

         // 所属工作流程标识
         private int? M_WorkFlowID;

         // 支流先行
         private bool? M_BranchFlowBeforehand;

         // 是否并行
         private bool? M_IsConcurrent;

         // 并行的线路
         private string M_ConcurrentOnLine;

         // 准入票
         private string M_AdmissionTickets;

         // 可通过计数类型 0为数量 1 为百分比
         private int? M_CanPassCountType;

         // 可通过数量
         private int? M_CanPassCount;

         // 可通过百分比
         private double? M_CanPassPercent;

         // 审批地址
         private string M_ApprovalUrl;

         // 查阅地址
         private string M_ViewUrl;

         // 备注
         private string M_Remark;

		
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
         /// 节点标识
         /// </summary>
         public int? NodeID
         {
            get
              {
                   return M_NodeID;
              }
            set
              {
                   M_NodeID=value;
              }
          }

         /// <summary>
         /// 节点标记
         /// </summary>
         public string NodeFlag
         {
            get
              {
                   return M_NodeFlag;
              }
            set
              {
                   M_NodeFlag=value;
              }
          }

         /// <summary>
         /// 节点名称
         /// </summary>
         public string NodeName
         {
            get
              {
                   return M_NodeName;
              }
            set
              {
                   M_NodeName=value;
              }
          }

         /// <summary>
         /// 所属工作流程标识
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
         /// 支流先行
         /// </summary>
         public bool? BranchFlowBeforehand
         {
            get
              {
                   return M_BranchFlowBeforehand;
              }
            set
              {
                   M_BranchFlowBeforehand=value;
              }
          }

         /// <summary>
         /// 是否并行
         /// </summary>
         public bool? IsConcurrent
         {
            get
              {
                   return M_IsConcurrent;
              }
            set
              {
                   M_IsConcurrent=value;
              }
          }

         /// <summary>
         /// 并行的线路
         /// </summary>
         public string ConcurrentOnLine
         {
            get
              {
                   return M_ConcurrentOnLine;
              }
            set
              {
                   M_ConcurrentOnLine=value;
              }
          }

         /// <summary>
         /// 准入票
         /// </summary>
         public string AdmissionTickets
         {
            get
              {
                   return M_AdmissionTickets;
              }
            set
              {
                   M_AdmissionTickets=value;
              }
          }

         /// <summary>
         /// 可通过计数类型 0为数量 1 为百分比
         /// </summary>
         public int? CanPassCountType
         {
            get
              {
                   return M_CanPassCountType;
              }
            set
              {
                   M_CanPassCountType=value;
              }
          }

         /// <summary>
         /// 可通过数量
         /// </summary>
         public int? CanPassCount
         {
            get
              {
                   return M_CanPassCount;
              }
            set
              {
                   M_CanPassCount=value;
              }
          }

         /// <summary>
         /// 可通过百分比
         /// </summary>
         public double? CanPassPercent
         {
            get
              {
                   return M_CanPassPercent;
              }
            set
              {
                   M_CanPassPercent=value;
              }
          }

         /// <summary>
         /// 审批地址
         /// </summary>
         public string ApprovalUrl
         {
            get
              {
                   return M_ApprovalUrl;
              }
            set
              {
                   M_ApprovalUrl=value;
              }
          }

         /// <summary>
         /// 查阅地址
         /// </summary>
         public string ViewUrl
         {
            get
              {
                   return M_ViewUrl;
              }
            set
              {
                   M_ViewUrl=value;
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

    }
}