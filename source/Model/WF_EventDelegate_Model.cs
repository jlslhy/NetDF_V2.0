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
    public class WF_EventDelegate_Model:Model.Base.ModelBase
    {
	    public WF_EventDelegate_Model()
        {
            TableName = "WF_EventDelegate";
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
                return @"INSERT INTO [WF_EventDelegate]
           ( [WorkFlowID],[NodeID],[EventName],[DelegatePath],[Remark],[Enabled]) VALUES (@WorkFlowID,@NodeID,@EventName,@DelegatePath,@Remark,@Enabled);select @@identity ";
            }
        }

        public override string UpdateSQL
        { 
            get
            {
                return @"UPDATE [WF_EventDelegate]
            SET [WorkFlowID]=@WorkFlowID,[NodeID]=@NodeID,[EventName]=@EventName,[DelegatePath]=@DelegatePath,[Remark]=@Remark,[Enabled]=@Enabled WHERE  [ID]=@ID";
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
            list.Add(new SqlParameter("@NodeID",M_NodeID));
            list.Add(new SqlParameter("@EventName",M_EventName));
            list.Add(new SqlParameter("@DelegatePath",M_DelegatePath));
            list.Add(new SqlParameter("@Remark",M_Remark));
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

         // 所属流程ID
         private int? M_WorkFlowID;

         // 节点ID
         private int? M_NodeID;

         // 事件名称
         private string M_EventName;

         // 代理方法路径
         private string M_DelegatePath;

         // 备注说明
         private string M_Remark;

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
         /// 节点ID
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
         /// 事件名称
         /// </summary>
         public string EventName
         {
            get
              {
                    return M_EventName;
              }
            set
              {
                    M_EventName=value;
              }
          }

         /// <summary>
         /// 代理方法路径
         /// </summary>
         public string DelegatePath
         {
            get
              {
                    return M_DelegatePath;
              }
            set
              {
                    M_DelegatePath=value;
              }
          }

         /// <summary>
         /// 备注说明
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