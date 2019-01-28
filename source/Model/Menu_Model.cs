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
    public class Menu_Model:Model.Base.ModelBase
    {
	    public Menu_Model()
        {
            TableName = "Menu";
            PKey = "MenuID";
            PKeyDataType = typeof(System.Int32);
        }

        public override object PKeyValue
        {
            get
            {
                return M_MenuID;
            }
            set
            {
                M_MenuID = (System.Int32)value;
            }
        }

        public override string AddSQL
        { get
            {
                return @"INSERT INTO [Menu]
           ( [Code],[MName],[MDesc],[IsFolder],[PCode],[MenuLevel],[Url],[Display],[OrderNum],[IsSystem]) VALUES (@Code,@MName,@MDesc,@IsFolder,@PCode,@MenuLevel,@Url,@Display,@OrderNum,@IsSystem);select @@identity ";}}

        public override string UpdateSQL
        { get
            {
                return @"UPDATE [Menu]
            SET [Code]=@Code,[MName]=@MName,[MDesc]=@MDesc,[IsFolder]=@IsFolder,[PCode]=@PCode,[MenuLevel]=@MenuLevel,[Url]=@Url,[Display]=@Display,[OrderNum]=@OrderNum,[IsSystem]=@IsSystem WHERE  [MenuID]=@MenuID";}}

        public override SqlParameter[] ParamsForAdd
        { get
            {
                 List<SqlParameter> list = GetNotKeyParams();return list.ToArray();}}

        public override SqlParameter[] ParamsForUpdate
        { get
            {
                 List<SqlParameter> list = GetNotKeyParams();
                list.Add(new SqlParameter("@MenuID", M_MenuID));
                return list.ToArray();}}

        public List<SqlParameter> GetNotKeyParams()
        {
            
            List<SqlParameter> list = new List<SqlParameter>();
            list.Add(new SqlParameter("@Code",M_Code));
            list.Add(new SqlParameter("@MName",M_MName));
            list.Add(new SqlParameter("@MDesc",M_MDesc));
            list.Add(new SqlParameter("@IsFolder",M_IsFolder));
            list.Add(new SqlParameter("@PCode",M_PCode));
            list.Add(new SqlParameter("@MenuLevel",M_MenuLevel));
            list.Add(new SqlParameter("@Url",M_Url));
            list.Add(new SqlParameter("@Display",M_Display));
            list.Add(new SqlParameter("@OrderNum",M_OrderNum));
            list.Add(new SqlParameter("@IsSystem",M_IsSystem));
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
 private int M_MenuID;

 // 
 private int? M_Code;

 // 
 private string M_MName;

 // 
 private string M_MDesc;

 // 
 private bool? M_IsFolder;

 // 
 private int? M_PCode;

 // 
 private int? M_MenuLevel;

 // 
 private string M_Url;

 // 
 private bool? M_Display;

 // 
 private int? M_OrderNum;

 // 
 private bool? M_IsSystem;

		/// <summary>
        /// (主键)
        /// </summary>
 public int MenuID{

            get{
                return M_MenuID;
                }
                 
            set{
                M_MenuID=value;
                }
                 
}
/// <summary>
        /// 
        /// </summary>
 public int? Code{

            get{
                return M_Code;
                }
                 
            set{
                M_Code=value;
                }
                 
}
/// <summary>
        /// 
        /// </summary>
 public string MName{

            get{
                return M_MName;
                }
                 
            set{
                M_MName=value;
                }
                 
}
/// <summary>
        /// 
        /// </summary>
 public string MDesc{

            get{
                return M_MDesc;
                }
                 
            set{
                M_MDesc=value;
                }
                 
}
/// <summary>
        /// 
        /// </summary>
 public bool? IsFolder{

            get{
                return M_IsFolder;
                }
                 
            set{
                M_IsFolder=value;
                }
                 
}
/// <summary>
        /// 
        /// </summary>
 public int? PCode{

            get{
                return M_PCode;
                }
                 
            set{
                M_PCode=value;
                }
                 
}
/// <summary>
        /// 
        /// </summary>
 public int? MenuLevel{

            get{
                return M_MenuLevel;
                }
                 
            set{
                M_MenuLevel=value;
                }
                 
}
/// <summary>
        /// 
        /// </summary>
 public string Url{

            get{
                return M_Url;
                }
                 
            set{
                M_Url=value;
                }
                 
}
/// <summary>
        /// 
        /// </summary>
 public bool? Display{

            get{
                return M_Display;
                }
                 
            set{
                M_Display=value;
                }
                 
}
/// <summary>
        /// 
        /// </summary>
 public int? OrderNum{

            get{
                return M_OrderNum;
                }
                 
            set{
                M_OrderNum=value;
                }
                 
}
/// <summary>
        /// 
        /// </summary>
 public bool? IsSystem{

            get{
                return M_IsSystem;
                }
                 
            set{
                M_IsSystem=value;
                }
                 
}

    }
}