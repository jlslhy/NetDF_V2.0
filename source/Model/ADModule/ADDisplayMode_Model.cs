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
namespace Model.ADModule
{
    public class ADDisplayMode_Model:Model.Base.ModelBase
    {
	    public ADDisplayMode_Model()
        {
            TableName = "ADDisplayMode";
            PKey = "ADDisplayModeCode";
            PKeyDataType = typeof(System.String);
        }

        public override object PKeyValue
        {
            get
            {
                return M_ADDisplayModeCode;
            }
            set
            {
                M_ADDisplayModeCode = (System.String)value;
            }
        }

        public override string AddSQL
        { get
            {
                return @"INSERT INTO [ADDisplayMode]
           ( [ADDisplayModeCode],[DisplayModeName],[IsSystem],[ADType],[JsCode],[CSSCode],[DisplayModeTemplateCode],[Description]) VALUES (@ADDisplayModeCode,@DisplayModeName,@IsSystem,@ADType,@JsCode,@CSSCode,@DisplayModeTemplateCode,@Description);select @@identity ";}}

        public override string UpdateSQL
        { get
            {
                return @"UPDATE [ADDisplayMode]
            SET [DisplayModeName]=@DisplayModeName,[IsSystem]=@IsSystem,[ADType]=@ADType,[JsCode]=@JsCode,[CSSCode]=@CSSCode,[DisplayModeTemplateCode]=@DisplayModeTemplateCode,[Description]=@Description WHERE  [ADDisplayModeCode]=@ADDisplayModeCode";}}

        public override SqlParameter[] ParamsForAdd
        { get
            {
                 List<SqlParameter> list = GetNotKeyParams();
                PKeyValue = Guid.NewGuid().ToString();
                   
                list.Add(new SqlParameter("@ADDisplayModeCode", PKeyValue));return list.ToArray();}}

        public override SqlParameter[] ParamsForUpdate
        { get
            {
                 List<SqlParameter> list = GetNotKeyParams();
                list.Add(new SqlParameter("@ADDisplayModeCode", M_ADDisplayModeCode));
                return list.ToArray();}}

        public List<SqlParameter> GetNotKeyParams()
        {
            
            List<SqlParameter> list = new List<SqlParameter>();
            list.Add(new SqlParameter("@DisplayModeName",M_DisplayModeName));
            list.Add(new SqlParameter("@IsSystem",M_IsSystem));
            list.Add(new SqlParameter("@ADType",M_ADType));
            list.Add(new SqlParameter("@JsCode",M_JsCode));
            list.Add(new SqlParameter("@CSSCode",M_CSSCode));
            list.Add(new SqlParameter("@DisplayModeTemplateCode",M_DisplayModeTemplateCode));
            list.Add(new SqlParameter("@Description",M_Description));
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
 private string M_ADDisplayModeCode;

 // 
 private string M_DisplayModeName;

 // 
 private bool? M_IsSystem;

 // 
 private int? M_ADType;

 // 
 private string M_JsCode;

 // 
 private string M_CSSCode;

 // 
 private string M_DisplayModeTemplateCode;

 // 
 private string M_Description;

		/// <summary>
        /// (主键)
        /// </summary>
 public string ADDisplayModeCode{

            get{
                return M_ADDisplayModeCode;
                }
                 
            set{
                M_ADDisplayModeCode=value;
                }
                 
}
/// <summary>
        /// 
        /// </summary>
 public string DisplayModeName{

            get{
                return M_DisplayModeName;
                }
                 
            set{
                M_DisplayModeName=value;
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
/// <summary>
        /// 
        /// </summary>
 public int? ADType{

            get{
                return M_ADType;
                }
                 
            set{
                M_ADType=value;
                }
                 
}
/// <summary>
        /// 
        /// </summary>
 public string JsCode{

            get{
                return M_JsCode;
                }
                 
            set{
                M_JsCode=value;
                }
                 
}
/// <summary>
        /// 
        /// </summary>
 public string CSSCode{

            get{
                return M_CSSCode;
                }
                 
            set{
                M_CSSCode=value;
                }
                 
}
/// <summary>
        /// 
        /// </summary>
 public string DisplayModeTemplateCode{

            get{
                return M_DisplayModeTemplateCode;
                }
                 
            set{
                M_DisplayModeTemplateCode=value;
                }
                 
}
/// <summary>
        /// 
        /// </summary>
 public string Description{

            get{
                return M_Description;
                }
                 
            set{
                M_Description=value;
                }
                 
}

    }
}