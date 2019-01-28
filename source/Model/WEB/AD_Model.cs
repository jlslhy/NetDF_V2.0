/*
 * 框架版本：NetDF2.0  
 * 架构设计开发、版权所有者：李青锦 
 * QQ：3425806176 
 * 技术网站：软艺软件(www.ruanyi.online) 
 * 技术交流群：826373349
 * */
using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
namespace Model.WEB
{
    public class AD_Model:Model.Base.ModelBase
    {
	    public AD_Model()
        {
            TableName = "AD";
            PKey = "ADID";
            PKeyDataType = typeof(System.Int32);
        }

        public override object PKeyValue
        {
            get
            {
                return M_ADID;
            }
            set
            {
                M_ADID = (System.Int32)value;
            }
        }

        public override string AddSQL
        { 
            get
            {
                return @"INSERT INTO [AD]
           ( [ADName],[ADClassID],[DisplayPrickle],[DisplayWidth],[DisplayHeight],[ADType],[ADDisplayModeCode],[Description],[IsDisplay],[CreateTime]) VALUES (@ADName,@ADClassID,@DisplayPrickle,@DisplayWidth,@DisplayHeight,@ADType,@ADDisplayModeCode,@Description,@IsDisplay,@CreateTime);select @@identity ";
            }
        }

        public override string UpdateSQL
        { 
            get
            {
                return @"UPDATE [AD]
            SET [ADName]=@ADName,[ADClassID]=@ADClassID,[DisplayPrickle]=@DisplayPrickle,[DisplayWidth]=@DisplayWidth,[DisplayHeight]=@DisplayHeight,[ADType]=@ADType,[ADDisplayModeCode]=@ADDisplayModeCode,[Description]=@Description,[IsDisplay]=@IsDisplay,[CreateTime]=@CreateTime WHERE  [ADID]=@ADID";
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
                list.Add(new SqlParameter("@ADID", M_ADID));
                return list.ToArray();
            }
        }

        public List<SqlParameter> GetNotKeyParams()
        {
            
            List<SqlParameter> list = new List<SqlParameter>();
            list.Add(new SqlParameter("@ADName",M_ADName));
            list.Add(new SqlParameter("@ADClassID",M_ADClassID));
            list.Add(new SqlParameter("@DisplayPrickle",M_DisplayPrickle));
            list.Add(new SqlParameter("@DisplayWidth",M_DisplayWidth));
            list.Add(new SqlParameter("@DisplayHeight",M_DisplayHeight));
            list.Add(new SqlParameter("@ADType",M_ADType));
            list.Add(new SqlParameter("@ADDisplayModeCode",M_ADDisplayModeCode));
            list.Add(new SqlParameter("@Description",M_Description));
            list.Add(new SqlParameter("@IsDisplay",M_IsDisplay));
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
         private int M_ADID;

         // 
         private string M_ADName;

         // 
         private int? M_ADClassID;

         // 
         private string M_DisplayPrickle;

         // 
         private Single? M_DisplayWidth;

         // 
         private Single? M_DisplayHeight;

         // 
         private int? M_ADType;

         // 
         private string M_ADDisplayModeCode;

         // 
         private string M_Description;

         // 
         private bool M_IsDisplay;

         // 
         private DateTime? M_CreateTime;

		
         /// <summary>
         /// (主键)
         /// </summary>
         public int ADID
         {
            get
              {
                   return M_ADID;
              }
            set
              {
                   M_ADID=value;
              }
          }

         /// <summary>
         /// 
         /// </summary>
         public string ADName
         {
            get
              {
                   return M_ADName;
              }
            set
              {
                   M_ADName=value;
              }
          }

         /// <summary>
         /// 
         /// </summary>
         public int? ADClassID
         {
            get
              {
                   return M_ADClassID;
              }
            set
              {
                   M_ADClassID=value;
              }
          }

         /// <summary>
         /// 
         /// </summary>
         public string DisplayPrickle
         {
            get
              {
                   return M_DisplayPrickle;
              }
            set
              {
                   M_DisplayPrickle=value;
              }
          }

         /// <summary>
         /// 
         /// </summary>
         public Single? DisplayWidth
         {
            get
              {
                   return M_DisplayWidth;
              }
            set
              {
                   M_DisplayWidth=value;
              }
          }

         /// <summary>
         /// 
         /// </summary>
         public Single? DisplayHeight
         {
            get
              {
                   return M_DisplayHeight;
              }
            set
              {
                   M_DisplayHeight=value;
              }
          }

         /// <summary>
         /// 
         /// </summary>
         public int? ADType
         {
            get
              {
                   return M_ADType;
              }
            set
              {
                   M_ADType=value;
              }
          }

         /// <summary>
         /// 
         /// </summary>
         public string ADDisplayModeCode
         {
            get
              {
                   return M_ADDisplayModeCode;
              }
            set
              {
                   M_ADDisplayModeCode=value;
              }
          }

         /// <summary>
         /// 
         /// </summary>
         public string Description
         {
            get
              {
                   return M_Description;
              }
            set
              {
                   M_Description=value;
              }
          }

         /// <summary>
         /// 
         /// </summary>
         public bool IsDisplay
         {
            get
              {
                   return M_IsDisplay;
              }
            set
              {
                   M_IsDisplay=value;
              }
          }

         /// <summary>
         /// 
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