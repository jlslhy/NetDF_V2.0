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
    public class WF_Instance_Model:Model.Base.ModelBase
    {
	    public WF_Instance_Model()
        {
            TableName = "WF_Instance";
            PKey = "InstanceID";
            PKeyDataType = typeof(System.Int32);
        }

        public override object PKeyValue
        {
            get
            {
                return M_InstanceID;
            }
            set
            {
                M_InstanceID = (System.Int32)value;
            }
        }

        public override string AddSQL
        { 
            get
            {
                return @"INSERT INTO [WF_Instance]
           ( [InstanceName],[WorkFlowID],[Status],[Threads],[ThreadCount],[VariableValueXML],[CreateTime],[FinishTime],[MaxHandleCode],[Remark]) VALUES (@InstanceName,@WorkFlowID,@Status,@Threads,@ThreadCount,@VariableValueXML,@CreateTime,@FinishTime,@MaxHandleCode,@Remark);select @@identity ";
            }
        }

        public override string UpdateSQL
        { 
            get
            {
                return @"UPDATE [WF_Instance]
            SET [InstanceName]=@InstanceName,[WorkFlowID]=@WorkFlowID,[Status]=@Status,[Threads]=@Threads,[ThreadCount]=@ThreadCount,[VariableValueXML]=@VariableValueXML,[CreateTime]=@CreateTime,[FinishTime]=@FinishTime,[MaxHandleCode]=@MaxHandleCode,[Remark]=@Remark WHERE  [InstanceID]=@InstanceID";
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
                list.Add(new SqlParameter("@InstanceID", M_InstanceID));
                return list.ToArray();
            }
        }

        public List<SqlParameter> GetNotKeyParams()
        {
            
            List<SqlParameter> list = new List<SqlParameter>();
            list.Add(new SqlParameter("@InstanceName",M_InstanceName));
            list.Add(new SqlParameter("@WorkFlowID",M_WorkFlowID));
            list.Add(new SqlParameter("@Status",M_Status));
            list.Add(new SqlParameter("@Threads",M_Threads));
            list.Add(new SqlParameter("@ThreadCount",M_ThreadCount));
            list.Add(new SqlParameter("@VariableValueXML",M_VariableValueXML));
            list.Add(new SqlParameter("@CreateTime",M_CreateTime));
            list.Add(new SqlParameter("@FinishTime",M_FinishTime));
            list.Add(new SqlParameter("@MaxHandleCode",M_MaxHandleCode));
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
         private int M_InstanceID;

         // 实例名称
         private string M_InstanceName;

         // 所属工作流程标识
         private int? M_WorkFlowID;

         // 流程实例状态
         private int? M_Status;

         // 实例线程集
         private string M_Threads;

         // 线程数量
         private int? M_ThreadCount;

         // 实例全局变量值
         private string M_VariableValueXML;

         // 创建时间
         private DateTime? M_CreateTime;

         // 实例结束时间
         private DateTime? M_FinishTime;

         // 最大待办码
         private string M_MaxHandleCode;

         // 备注
         private string M_Remark;

		
         /// <summary>
         /// (主键)
         /// </summary>
         public int InstanceID
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
         /// 实例名称
         /// </summary>
         public string InstanceName
         {
            get
              {
                    return M_InstanceName;
              }
            set
              {
                    M_InstanceName=value;
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
         /// 流程实例状态
         /// </summary>
         public int? Status
         {
            get
              {
                    return M_Status;
              }
            set
              {
                    M_Status=value;
              }
          }

         /// <summary>
         /// 实例线程集
         /// </summary>
         public string Threads
         {
            get
              {
                    return M_Threads;
              }
            set
              {
                    M_Threads=value;
              }
          }

         /// <summary>
         /// 线程数量
         /// </summary>
         public int? ThreadCount
         {
            get
              {
                    return M_ThreadCount;
              }
            set
              {
                    M_ThreadCount=value;
              }
          }

         /// <summary>
         /// 实例全局变量值
         /// </summary>
         public string VariableValueXML
         {
            get
              {
                    return M_VariableValueXML;
              }
            set
              {
                    M_VariableValueXML=value;
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
         /// 实例结束时间
         /// </summary>
         public DateTime? FinishTime
         {
            get
              {
                    return M_FinishTime;
              }
            set
              {
                    M_FinishTime=value;
              }
          }

         /// <summary>
         /// 最大待办码
         /// </summary>
         public string MaxHandleCode
         {
            get
              {
                    return M_MaxHandleCode;
              }
            set
              {
                    M_MaxHandleCode=value;
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