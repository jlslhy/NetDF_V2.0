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
    public class WF_WaitForHandling_Model:Model.Base.ModelBase
    {
	    public WF_WaitForHandling_Model()
        {
            TableName = "WF_WaitForHandling";
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
                return @"INSERT INTO [WF_WaitForHandling]
           ( [HandleCode],[WorkFlowID],[InstanceID],[InstanceName],[HandleUrl],[Approver],[NodeID],[CreateTime]) VALUES (@HandleCode,@WorkFlowID,@InstanceID,@InstanceName,@HandleUrl,@Approver,@NodeID,@CreateTime);select @@identity ";
            }
        }

        public override string UpdateSQL
        { 
            get
            {
                return @"UPDATE [WF_WaitForHandling]
            SET [HandleCode]=@HandleCode,[WorkFlowID]=@WorkFlowID,[InstanceID]=@InstanceID,[InstanceName]=@InstanceName,[HandleUrl]=@HandleUrl,[Approver]=@Approver,[NodeID]=@NodeID,[CreateTime]=@CreateTime WHERE  [ID]=@ID";
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
            list.Add(new SqlParameter("@HandleCode",M_HandleCode));
            list.Add(new SqlParameter("@WorkFlowID",M_WorkFlowID));
            list.Add(new SqlParameter("@InstanceID",M_InstanceID));
            list.Add(new SqlParameter("@InstanceName",M_InstanceName));
            list.Add(new SqlParameter("@HandleUrl",M_HandleUrl));
            list.Add(new SqlParameter("@Approver",M_Approver));
            list.Add(new SqlParameter("@NodeID",M_NodeID));
            list.Add(new SqlParameter("@CreateTime",M_CreateTime));
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

         // 待办码 实例ID加顺序码
         private string M_HandleCode;

         // 所属流程ID
         private int? M_WorkFlowID;

         // 所属实例ID
         private int? M_InstanceID;

         // 实例名称
         private string M_InstanceName;

         // 办理地址
         private string M_HandleUrl;

         // 审批人
         private string M_Approver;

         // 待办环节ID
         private int? M_NodeID;

         // 创建时间
         private DateTime? M_CreateTime;

		
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
         /// 待办码 实例ID加顺序码
         /// </summary>
         public string HandleCode
         {
            get
              {
                    return M_HandleCode;
              }
            set
              {
                    M_HandleCode=value;
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
         /// 办理地址
         /// </summary>
         public string HandleUrl
         {
            get
              {
                    return M_HandleUrl;
              }
            set
              {
                    M_HandleUrl=value;
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
         /// 待办环节ID
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

    }
}