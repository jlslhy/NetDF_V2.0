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
    public class WF_AlreadyHandled_Model:Model.Base.ModelBase
    {
	    public WF_AlreadyHandled_Model()
        {
            TableName = "WF_AlreadyHandled";
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
                return @"INSERT INTO [WF_AlreadyHandled]
           ( [WorkFlowID],[InstanceID],[InstanceName],[ViewUrl],[Approver],[NodeID],[CreateTime],[HandleDuration],[HandleStatus],[Remark]) VALUES (@WorkFlowID,@InstanceID,@InstanceName,@ViewUrl,@Approver,@NodeID,@CreateTime,@HandleDuration,@HandleStatus,@Remark);select @@identity ";
            }
        }

        public override string UpdateSQL
        { 
            get
            {
                return @"UPDATE [WF_AlreadyHandled]
            SET [WorkFlowID]=@WorkFlowID,[InstanceID]=@InstanceID,[InstanceName]=@InstanceName,[ViewUrl]=@ViewUrl,[Approver]=@Approver,[NodeID]=@NodeID,[CreateTime]=@CreateTime,[HandleDuration]=@HandleDuration,[HandleStatus]=@HandleStatus,[Remark]=@Remark WHERE  [ID]=@ID";
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
            list.Add(new SqlParameter("@InstanceID",M_InstanceID));
            list.Add(new SqlParameter("@InstanceName",M_InstanceName));
            list.Add(new SqlParameter("@ViewUrl",M_ViewUrl));
            list.Add(new SqlParameter("@Approver",M_Approver));
            list.Add(new SqlParameter("@NodeID",M_NodeID));
            list.Add(new SqlParameter("@CreateTime",M_CreateTime));
            list.Add(new SqlParameter("@HandleDuration",M_HandleDuration));
            list.Add(new SqlParameter("@HandleStatus",M_HandleStatus));
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

         // 所属流程ID
         private int? M_WorkFlowID;

         // 所属实例ID
         private int? M_InstanceID;

         // 实例名称
         private string M_InstanceName;

         // 查看地址
         private string M_ViewUrl;

         // 审批人
         private string M_Approver;

         // 办理环节ID
         private int? M_NodeID;

         // 创建时间
         private DateTime? M_CreateTime;

         // 办理时长(百奈秒)
         private long? M_HandleDuration;

         // 办理状况，如及时、延时、异常等
         private string M_HandleStatus;

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
         /// 所属流程ID
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
         /// 查看地址
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
         /// 办理环节ID
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
         /// 办理时长(百奈秒)
         /// </summary>
         public long? HandleDuration
         {
            get
              {
                   return M_HandleDuration;
              }
            set
              {
                   M_HandleDuration=value;
              }
          }

         /// <summary>
         /// 办理状况，如及时、延时、异常等
         /// </summary>
         public string HandleStatus
         {
            get
              {
                   return M_HandleStatus;
              }
            set
              {
                   M_HandleStatus=value;
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