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
    public class WF_NodeContent_Model:Model.Base.ModelBase
    {
	    public WF_NodeContent_Model()
        {
            TableName = "WF_NodeContent";
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
                return @"INSERT INTO [WF_NodeContent]
           ( [WorkFlowID],[NodeID],[ContentName],[ContentEditPageUrl],[ContentViewPageUrl],[Remark]) VALUES (@WorkFlowID,@NodeID,@ContentName,@ContentEditPageUrl,@ContentViewPageUrl,@Remark);select @@identity ";
            }
        }

        public override string UpdateSQL
        { 
            get
            {
                return @"UPDATE [WF_NodeContent]
            SET [WorkFlowID]=@WorkFlowID,[NodeID]=@NodeID,[ContentName]=@ContentName,[ContentEditPageUrl]=@ContentEditPageUrl,[ContentViewPageUrl]=@ContentViewPageUrl,[Remark]=@Remark WHERE  [ID]=@ID";
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
            list.Add(new SqlParameter("@ContentName",M_ContentName));
            list.Add(new SqlParameter("@ContentEditPageUrl",M_ContentEditPageUrl));
            list.Add(new SqlParameter("@ContentViewPageUrl",M_ContentViewPageUrl));
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

         // 节点ID
         private int? M_NodeID;

         // 内容名称
         private string M_ContentName;

         // 内容编辑页面地址
         private string M_ContentEditPageUrl;

         // 内容查看页面地址
         private string M_ContentViewPageUrl;

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
         /// 内容名称
         /// </summary>
         public string ContentName
         {
            get
              {
                    return M_ContentName;
              }
            set
              {
                    M_ContentName=value;
              }
          }

         /// <summary>
         /// 内容编辑页面地址
         /// </summary>
         public string ContentEditPageUrl
         {
            get
              {
                    return M_ContentEditPageUrl;
              }
            set
              {
                    M_ContentEditPageUrl=value;
              }
          }

         /// <summary>
         /// 内容查看页面地址
         /// </summary>
         public string ContentViewPageUrl
         {
            get
              {
                    return M_ContentViewPageUrl;
              }
            set
              {
                    M_ContentViewPageUrl=value;
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