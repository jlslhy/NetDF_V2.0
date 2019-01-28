using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using DBControl;
using DBControl.DBInfo.Tables;
using Common;
using NetServ.Net.Json;
using SystemExtend;
using WEB.DataAccessBase;

namespace WEB.DataAccess.SystemSetupTBL
{
    /// <summary>
    /// GetData_Ext 的摘要说明
    /// </summary>
    public class GetData_Ext : GetDataBase, IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {


        DBControl.Base.BLLOpt<Model.SystemSetup_Model> Bll = new DBControl.Base.BLLOpt<Model.SystemSetup_Model>();
        DBControl.DBInfo.Tables.SystemSetup tableInfo = new DBControl.DBInfo.Tables.SystemSetup();

        public void ProcessRequest(HttpContext context)
        {
            /********  初始化 Start  ********/
            _tableName = "SystemSetup";
            _orderBy = "ID asc";
            _idField = "ID";


            /********  初始化 End  ********/
            context.Response.ContentType = "text/plain";
            Initial(context);
            if (UrlHelper.ReqStr("m").Equals("GetCode_NumberAutoAdd"))
            {
                GetCode_NumberAutoAdd();
            }
            else
            {
                ReturnMsg(false, enumReturnTitle.Param, "请传递一个有效的参数。");
            }
        }

        private void GetCode_NumberAutoAdd() {
            string rltValue = "";
            string KeyCode = UrlHelper.ReqStr("KeyCode");
            Model.SystemSetup_Model model = Bll.GetFirstModel(" SetupType='NumberAutoAdd'  and KeyCode='"+KeyCode+"'");
            if (null != model)
            {
                model.SetupValue = (int.Parse(model.SetupValue) + 1).ToString();
                Bll.UpdateModel(model);
                rltValue = model.SetupValue;
            }
            ReturnMsg(true, enumReturnTitle.GetData, rltValue);

            
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}