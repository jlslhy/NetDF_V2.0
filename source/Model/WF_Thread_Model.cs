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
    public class WF_Thread_Model:Model.Base.ModelBase
    {
	    public WF_Thread_Model()
        {
            TableName = "WF_Thread";
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
                return @"INSERT INTO [WF_Thread]
           ( [ThreadName],[InstanceID],[CurrentNodeID],[CurrentNodeTime],[NodeVariableValueXML],[AllApprovers],[PassedApprovers],[PassedCount]) VALUES (@ThreadName,@InstanceID,@CurrentNodeID,@CurrentNodeTime,@NodeVariableValueXML,@AllApprovers,@PassedApprovers,@PassedCount);select @@identity ";
            }
        }

        public override string UpdateSQL
        { 
            get
            {
                return @"UPDATE [WF_Thread]
            SET [ThreadName]=@ThreadName,[InstanceID]=@InstanceID,[CurrentNodeID]=@CurrentNodeID,[CurrentNodeTime]=@CurrentNodeTime,[NodeVariableValueXML]=@NodeVariableValueXML,[AllApprovers]=@AllApprovers,[PassedApprovers]=@PassedApprovers,[PassedCount]=@PassedCount WHERE  [ID]=@ID";
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
            list.Add(new SqlParameter("@ThreadName",M_ThreadName));
            list.Add(new SqlParameter("@InstanceID",M_InstanceID));
            list.Add(new SqlParameter("@CurrentNodeID",M_CurrentNodeID));
            list.Add(new SqlParameter("@CurrentNodeTime",M_CurrentNodeTime));
            list.Add(new SqlParameter("@NodeVariableValueXML",M_NodeVariableValueXML));
            list.Add(new SqlParameter("@AllApprovers",M_AllApprovers));
            list.Add(new SqlParameter("@PassedApprovers",M_PassedApprovers));
            list.Add(new SqlParameter("@PassedCount",M_PassedCount));
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

         // 线程名称
         private string M_ThreadName;

         // 所属实例ID
         private int? M_InstanceID;

         // 当前节点ID
         private int? M_CurrentNodeID;

         // 进入当前环节的时间
         private DateTime? M_CurrentNodeTime;

         // 结点局部变量值
         private string M_NodeVariableValueXML;

         // 所有审批人
         private string M_AllApprovers;

         // 已经审批通过的人
         private string M_PassedApprovers;

         // 已经通过审批的人数
         private int? M_PassedCount;

		
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
         /// 线程名称
         /// </summary>
         public string ThreadName
         {
            get
              {
                    return M_ThreadName;
              }
            set
              {
                    M_ThreadName=value;
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
         /// 当前节点ID
         /// </summary>
         public int? CurrentNodeID
         {
            get
              {
                    return M_CurrentNodeID;
              }
            set
              {
                    M_CurrentNodeID=value;
              }
          }

         /// <summary>
         /// 进入当前环节的时间
         /// </summary>
         public DateTime? CurrentNodeTime
         {
            get
              {
                    return M_CurrentNodeTime;
              }
            set
              {
                    M_CurrentNodeTime=value;
              }
          }

         /// <summary>
         /// 结点局部变量值
         /// </summary>
         public string NodeVariableValueXML
         {
            get
              {
                    return M_NodeVariableValueXML;
              }
            set
              {
                    M_NodeVariableValueXML=value;
              }
          }

         /// <summary>
         /// 所有审批人
         /// </summary>
         public string AllApprovers
         {
            get
              {
                    return M_AllApprovers;
              }
            set
              {
                    M_AllApprovers=value;
              }
          }

         /// <summary>
         /// 已经审批通过的人
         /// </summary>
         public string PassedApprovers
         {
            get
              {
                    return M_PassedApprovers;
              }
            set
              {
                    M_PassedApprovers=value;
              }
          }

         /// <summary>
         /// 已经通过审批的人数
         /// </summary>
         public int? PassedCount
         {
            get
              {
                    return M_PassedCount;
              }
            set
              {
                    M_PassedCount=value;
              }
          }

    }
}