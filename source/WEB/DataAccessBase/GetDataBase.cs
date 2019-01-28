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
    public class GetDataBase : Base
    {
        protected string _tableName = string.Empty;
        protected string _orderBy = string.Empty;
        protected string _idField = "ID";
        protected string _pidField = "PID";

        protected int _pageSize = 10;
        protected long _total = 0L;
        protected string _selectTypeName = "FirstPage";
        protected int _page = 1;
        protected string _minid = string.Empty;
        protected string _maxid = string.Empty;
        protected bool _descOrder = false;


        protected HttpContext CurrentContext;


        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="context"></param>
        public void Initial(HttpContext context)
        {
            CurrentContext = context;
            PageBegin(context);

        }
        #region 公共函数

        public void GetAllJsonData(HttpContext context, params string[] fieldArr)
        {
            IDataReader idr = DBControl.Base.DBAccess.GetAllDataIDR(fieldArr, _tableName, _orderBy);
            if (null != idr)
            {
                JsonArray Rows = new JsonArray();
                while (idr.Read())
                {
                    JsonObject row = new JsonObject();
                    foreach (string field in fieldArr)
                    {
                        row.Add(field, idr[field].ToString());
                    }
                    Rows.Add(row);
                }

                if (!idr.IsClosed)
                { idr.Close(); }
                idr.Dispose();
                idr = null;

                JsonWriter jwriter = new JsonWriter();
                Rows.Write(jwriter);
                context.Response.Write(jwriter.ToString());

            }
            else
            {
                context.Response.Write(string.Empty);
            }

        }



        #region TreeData
        public void GetAllJsonTreeData(HttpContext context, string idField, string pidField, params string[] fieldArr)
        {
            IDataReader idr0 = DBControl.Base.DBAccess.GetDataIDR(fieldArr, _tableName, string.Format(" {0}=0", pidField), _orderBy);
            if (null != idr0)
            {
                JsonArray JsonData = GetJsonArrayForTreeData(idr0, idField, pidField, fieldArr);
                JsonObject jsonObjDefault = new JsonObject();
                jsonObjDefault.Add("id", "");
                jsonObjDefault.Add("text", "---请选择---");
                JsonData.Insert(0, jsonObjDefault);
                JsonWriter jwriter = new JsonWriter();
                JsonData.Write(jwriter);
                context.Response.Write(jwriter.ToString());

            }
            else
            {
                context.Response.Write(string.Empty);
            }

        }




        public JsonArray GetJsonArrayForTreeData(IDataReader idr, string idField, string pidField, params string[] fieldArr)
        {
            JsonArray Rows = new JsonArray();
            while (idr.Read())
            {
                JsonObject jsonObj = new JsonObject();

                jsonObj.Add("id", idr[fieldArr[0]].ToString());
                jsonObj.Add("text", idr[fieldArr[1]].ToString());


                if (DBControl.Base.DBAccess.HasRecord(_tableName, string.Format("{0}={1}", pidField, idr[idField].ToString())))
                {
                    IDataReader idrChildren = DBControl.Base.DBAccess.GetDataIDR(fieldArr, _tableName, string.Format("{0}={1}", pidField, idr[idField].ToString()), _orderBy);
                    if (null != idrChildren)
                    {

                        jsonObj.Add("children", GetJsonArrayForTreeData(idrChildren, idField, pidField, fieldArr));

                    }
                }

                Rows.Add(jsonObj);
            }
            idr.Close();
            idr.Dispose();
            return Rows;
        }



        public JsonObject GetJsonObject(IDataReader idr, params string[] fieldArr)
        {
            JsonObject jsonObj = new JsonObject();
            foreach (string field in fieldArr)
            {
                if (idr.HasField(field))
                {
                    jsonObj.Add(field, idr[field].ToString());
                }
            }
            return jsonObj;
        }

        #endregion


        #endregion


        /// <summary>
        /// 返回信息
        /// </summary>
        /// <param name="isSuccess"></param>
        /// <param name="msg"></param>
        protected void ReturnMsg(bool isSuccess,enumReturnTitle title, string msg)
        {
            this.ReturnMsg(CurrentContext, isSuccess, title, msg);
        }

        public enum enumSelectType
        {
            PrevPage = 1,
            NextPage = 2,
            FirstPage = 3,
            LastPage = 4,
            GoToPage = 5

        }

    }
}
