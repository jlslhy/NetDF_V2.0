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
    public class WF_NodeOnLine_Model:Model.Base.ModelBase
    {
	    public WF_NodeOnLine_Model()
        {
            TableName = "WF_NodeOnLine";
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
                return @"INSERT INTO [WF_NodeOnLine]
           ( [WorkFlowID],[LineID],[LineName],[StartNodeID],[EndNodeID],[PassTickets]) VALUES (@WorkFlowID,@LineID,@LineName,@StartNodeID,@EndNodeID,@PassTickets);select @@identity ";
            }
        }

        public override string UpdateSQL
        { 
            get
            {
                return @"UPDATE [WF_NodeOnLine]
            SET [WorkFlowID]=@WorkFlowID,[LineID]=@LineID,[LineName]=@LineName,[StartNodeID]=@StartNodeID,[EndNodeID]=@EndNodeID,[PassTickets]=@PassTickets WHERE  [ID]=@ID";
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
            list.Add(new SqlParameter("@LineID",M_LineID));
            list.Add(new SqlParameter("@LineName",M_LineName));
            list.Add(new SqlParameter("@StartNodeID",M_StartNodeID));
            list.Add(new SqlParameter("@EndNodeID",M_EndNodeID));
            list.Add(new SqlParameter("@PassTickets",M_PassTickets));
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

         // 流程标识
         private int? M_WorkFlowID;

         // 线条标识
         private int? M_LineID;

         // 线名称
         private string M_LineName;

         // 开始结点
         private int? M_StartNodeID;

         // 结束结点
         private int? M_EndNodeID;

         // 通行票，为字符串，多个由分号隔开
         private string M_PassTickets;

		
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
         /// 流程标识
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
         /// 线条标识
         /// </summary>
         public int? LineID
         {
            get
              {
                    return M_LineID;
              }
            set
              {
                    M_LineID=value;
              }
          }

         /// <summary>
         /// 线名称
         /// </summary>
         public string LineName
         {
            get
              {
                    return M_LineName;
              }
            set
              {
                    M_LineName=value;
              }
          }

         /// <summary>
         /// 开始结点
         /// </summary>
         public int? StartNodeID
         {
            get
              {
                    return M_StartNodeID;
              }
            set
              {
                    M_StartNodeID=value;
              }
          }

         /// <summary>
         /// 结束结点
         /// </summary>
         public int? EndNodeID
         {
            get
              {
                    return M_EndNodeID;
              }
            set
              {
                    M_EndNodeID=value;
              }
          }

         /// <summary>
         /// 通行票，为字符串，多个由分号隔开
         /// </summary>
         public string PassTickets
         {
            get
              {
                    return M_PassTickets;
              }
            set
              {
                    M_PassTickets=value;
              }
          }

    }
}