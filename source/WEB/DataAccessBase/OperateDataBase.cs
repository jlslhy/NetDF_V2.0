using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Text;

using DBControl;
using DBControl.DBInfo.Tables;
using Common;
using NetServ.Net.Json;
using SystemExtend;


namespace WEB.DataAccessBase
{
    public class OperateDataBase : Base
    {
        protected string _tableName = string.Empty;
        protected string _pKeyValue = string.Empty;
        protected string _idField = "ID";
        protected HttpContext CurrentContext;


        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="context"></param>
        protected void Initial(HttpContext context)
        {
            CurrentContext = context;
            PageBegin(context);
            _pKeyValue = UrlHelper.ReqStrByGetOrPost(context, "id");

        }

        protected bool IsAdd
        {
            get
            {
                return string.IsNullOrWhiteSpace(_pKeyValue);
            }
        }

        protected bool IsEdit
        {
            get
            {
                return !string.IsNullOrWhiteSpace(_pKeyValue);
            }
        }

        /// <summary>
        /// 返回信息
        /// </summary>
        /// <param name="isSuccess"></param>
        /// <param name="msg"></param>
        protected void ReturnMsg(bool isSuccess,enumReturnTitle title, string msg)
        {
            this.ReturnMsg(CurrentContext, isSuccess, title, msg);
        }
    }
}
