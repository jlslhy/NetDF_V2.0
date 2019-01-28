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
namespace Model.WEB
{
    public class OfficeSupplies_Model:Model.Base.ModelBase
    {
	    public OfficeSupplies_Model()
        {
            TableName = "OfficeSupplies";
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
                return @"INSERT INTO [OfficeSupplies]
           ( [Code],[GoodsName],[GoodsCateogory],[Specification],[Unit],[IndicativePrice],[CreateTime],[EditTime],[Creator]) VALUES (@Code,@GoodsName,@GoodsCateogory,@Specification,@Unit,@IndicativePrice,@CreateTime,@EditTime,@Creator);select @@identity ";
            }
        }

        public override string UpdateSQL
        { 
            get
            {
                return @"UPDATE [OfficeSupplies]
            SET [Code]=@Code,[GoodsName]=@GoodsName,[GoodsCateogory]=@GoodsCateogory,[Specification]=@Specification,[Unit]=@Unit,[IndicativePrice]=@IndicativePrice,[CreateTime]=@CreateTime,[EditTime]=@EditTime,[Creator]=@Creator WHERE  [ID]=@ID";
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
            list.Add(new SqlParameter("@Code",M_Code));
            list.Add(new SqlParameter("@GoodsName",M_GoodsName));
            list.Add(new SqlParameter("@GoodsCateogory",M_GoodsCateogory));
            list.Add(new SqlParameter("@Specification",M_Specification));
            list.Add(new SqlParameter("@Unit",M_Unit));
            list.Add(new SqlParameter("@IndicativePrice",M_IndicativePrice));
            list.Add(new SqlParameter("@CreateTime",M_CreateTime));
            list.Add(new SqlParameter("@EditTime",M_EditTime));
            list.Add(new SqlParameter("@Creator",M_Creator));
            foreach (SqlParameter par in list)
            {
                if (null == par.Value)
                {
                    par.Value = DBNull.Value;
                }
            }
            return list;
        }

	    

         // 序号(主键)
         private int M_ID;

         // 物品编号
         private string M_Code;

         // 物品名称
         private string M_GoodsName;

         // 物品类别
         private string M_GoodsCateogory;

         // 规格
         private string M_Specification;

         // 单位
         private string M_Unit;

         // 参考价格
         private decimal? M_IndicativePrice;

         // 创建时间
         private DateTime? M_CreateTime;

         // 修改时间
         private DateTime? M_EditTime;

         // 创建者
         private string M_Creator;

		
         /// <summary>
         /// 序号(主键)
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
         /// 物品编号
         /// </summary>
         public string Code
         {
            get
              {
                   return M_Code;
              }
            set
              {
                   M_Code=value;
              }
          }

         /// <summary>
         /// 物品名称
         /// </summary>
         public string GoodsName
         {
            get
              {
                   return M_GoodsName;
              }
            set
              {
                   M_GoodsName=value;
              }
          }

         /// <summary>
         /// 物品类别
         /// </summary>
         public string GoodsCateogory
         {
            get
              {
                   return M_GoodsCateogory;
              }
            set
              {
                   M_GoodsCateogory=value;
              }
          }

         /// <summary>
         /// 规格
         /// </summary>
         public string Specification
         {
            get
              {
                   return M_Specification;
              }
            set
              {
                   M_Specification=value;
              }
          }

         /// <summary>
         /// 单位
         /// </summary>
         public string Unit
         {
            get
              {
                   return M_Unit;
              }
            set
              {
                   M_Unit=value;
              }
          }

         /// <summary>
         /// 参考价格
         /// </summary>
         public decimal? IndicativePrice
         {
            get
              {
                   return M_IndicativePrice;
              }
            set
              {
                   M_IndicativePrice=value;
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
         /// 修改时间
         /// </summary>
         public DateTime? EditTime
         {
            get
              {
                   return M_EditTime;
              }
            set
              {
                   M_EditTime=value;
              }
          }

         /// <summary>
         /// 创建者
         /// </summary>
         public string Creator
         {
            get
              {
                   return M_Creator;
              }
            set
              {
                   M_Creator=value;
              }
          }

    }
}