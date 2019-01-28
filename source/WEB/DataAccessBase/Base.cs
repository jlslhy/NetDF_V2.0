using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NetServ.Net.Json;
using System.Data;
using SystemExtend;
using System.Text;
using Common;
using App.Web.UI;
using WEB.Module.LoginManage;
using WEB.Config;

namespace WEB.DataAccessBase
{
    public class Base : UserBasePage
    {
        /// <summary>
        /// 返回信息
        /// </summary>
        /// <param name="isSuccess"></param>
        /// <param name="msg"></param>
        protected virtual void ReturnMsg(HttpContext CurrentContext, bool isSuccess, enumReturnTitle title, string msg)
        {
            JsonObject returnVal = new JsonObject();
            returnVal = JsonResult(isSuccess, title, msg);
            JsonWriter jwriter = new JsonWriter();
            returnVal.Write(jwriter);
            CurrentContext.Response.Write(jwriter.ToString());
        }

        protected JsonObject JsonResult(bool IsSuccess, enumReturnTitle ReturnTitle, string ReturnMessage)
        {

            JsonObject jObj = new JsonObject();
            jObj.Add("IsSuccess", IsSuccess);
            jObj.Add("ReturnTitle", ReturnTitle.ToString());
            jObj.Add("ReturnMessage", ReturnMessage);
            return jObj;

        }


        protected JsonObject OneDataRecordToJson(IDataReader idr, params string[] fieldArr)
        {
            JsonObject jObj = new JsonObject();

            if (null != idr)
            {
                if (idr.Read())
                {
                    if (null == fieldArr || fieldArr.Length == 0)
                    {
                        for (int i = 0; i < idr.FieldCount; i++)
                        {
                            jObj.Add(idr.GetName(i), idr[i].ToString());
                        }
                    }
                    else
                    {
                        foreach (string field in fieldArr)
                        {
                            if (idr.HasField(field))
                            {
                                jObj.Add(field, idr[field].ToString());
                            }
                        }
                    }
                    idr.Close();
                }
                idr.Dispose();


            }


            return jObj;
        }

        protected JsonArray DataListToJson(IDataReader idr, string orderCol, bool descOrder, ref string minid, ref string maxid, params string[] fieldArr)
        {
            JsonArray jArray = new JsonArray();

            if (null != idr)
            {
                if (!idr.HasField(orderCol))
                {
                    throw new Exception("对不起，不存在排序字段：" + orderCol);
                }
                int index = 0;
                while (idr.Read())
                {
 
                    if (index.Equals(0))
                    {
                        maxid = idr[orderCol].ToString();
                        minid = idr[orderCol].ToString();
                    }
                    else
                    {
                        if (descOrder)
                        {
                            minid = idr[orderCol].ToString();
                        }
                        else
                        {
                            maxid = idr[orderCol].ToString();
                        }


                    }

                    JsonObject tempObj = new JsonObject();
                    if (null == fieldArr || fieldArr.Length == 0)
                    {

                        for (int i = 0; i < idr.FieldCount; i++)
                        {

                            tempObj.Add(idr.GetName(i), idr[i].ToString());
                        }

                    }
                    else
                    {

                        foreach (string field in fieldArr)
                        {
                            
                            if (idr.HasField(field))
                            {
                                tempObj.Add(field.Trim('[', ']'), idr[field.Trim('[', ']')].ToString());
                            }

                        }


                    }
                    jArray.Add(tempObj);
                    index++;
                }
                idr.Close();
                idr.Dispose();

            }

            return jArray;
        }


        public string MakeConditionString<T>(HttpContext CurrentContext, string ParamLeftFix) where T : DBControl.DBInfo.TableBase, new()
        {

            T tableInfo = new T();
            StringBuilder newConditionSB = new StringBuilder();


            if (!string.IsNullOrWhiteSpace(ParamLeftFix))
            {

                Dictionary<string, string> paramValueDic = UrlHelper.GetParamValueDic(CurrentContext, ParamLeftFix, true);
                if (null != paramValueDic && paramValueDic.Count > 0)
                {
                    int index = 0;

                    foreach (string Key in paramValueDic.Keys)
                    {
                        string tempKey = Key.Replace(ParamLeftFix, "");


                        if (index > 0) { newConditionSB.Append(" and "); }
                        if (Key.Contains("_Like"))
                        {
                            tempKey = tempKey.Replace("_Like", "");
                            newConditionSB.Append(string.Format("{0} like '%{1}%'", tempKey, paramValueDic[Key]));
                        }
                        else if (Key.Contains("_LeftLike"))
                        {
                            tempKey = tempKey.Replace("_LeftLike", "");
                            newConditionSB.Append(string.Format("{0} like '{1}%'", tempKey, paramValueDic[Key]));
                        }
                        else if (Key.Contains("_RightLike"))
                        {
                            tempKey = tempKey.Replace("_RightLike", "");
                            newConditionSB.Append(string.Format("{0} like '%{1}'", tempKey, paramValueDic[Key]));
                        }
                        else if (Key.Contains("_MoreThan"))
                        {
                            tempKey = tempKey.Replace("_MoreThan", "");
                            if (tableInfo.GetTabelFieldInfo(tempKey).DataType.IsDigitType())
                            {
                                newConditionSB.Append(string.Format("{0} > {1}", tempKey, paramValueDic[Key]));
                            }
                            else
                            {
                                newConditionSB.Append(string.Format("{0} > '{1}'", tempKey, paramValueDic[Key]));
                            }
                        }
                        else if (Key.Contains("_MoreEqualThan"))
                        {
                            tempKey = tempKey.Replace("_MoreEqualThan", "");
                            if (tableInfo.GetTabelFieldInfo(tempKey).DataType.IsDigitType())
                            {
                                newConditionSB.Append(string.Format("{0} >= {1}", tempKey, paramValueDic[Key]));
                            }
                            else
                            {
                                newConditionSB.Append(string.Format("{0} >= '{1}'", tempKey, paramValueDic[Key]));
                            }
                        }
                        else if (Key.Contains("_LessThan"))
                        {
                            tempKey = tempKey.Replace("_LessThan", "");
                            if (tableInfo.GetTabelFieldInfo(tempKey).DataType.IsDigitType())
                            {
                                newConditionSB.Append(string.Format("{0} < {1}", tempKey, paramValueDic[Key]));
                            }
                            else
                            {
                                newConditionSB.Append(string.Format("{0} < '{1}'", tempKey, paramValueDic[Key]));
                            }
                        }
                        else if (Key.Contains("_LessEqualThan"))
                        {
                            tempKey = tempKey.Replace("_LessEqualThan", "");
                            if (tableInfo.GetTabelFieldInfo(tempKey).DataType.IsDigitType())
                            {
                                newConditionSB.Append(string.Format("{0} <= {1}", tempKey, paramValueDic[Key]));
                            }
                            else
                            {
                                newConditionSB.Append(string.Format("{0} <= '{1}'", tempKey, paramValueDic[Key]));
                            }
                        }
                        else
                        {
                            if (tableInfo.GetTabelFieldInfo(tempKey).DataType.IsDigitType())
                            {
                                newConditionSB.Append(string.Format("{0} = {1}", tempKey, paramValueDic[Key]));
                            }
                            else
                            {
                                newConditionSB.Append(string.Format("{0} = '{1}'", tempKey, paramValueDic[Key]));
                            }
                        }

                        index++;
                    }
                }
            }

            return newConditionSB.ToString();
        }

        protected void PageBegin(HttpContext CurrentContext)
        {
            if (!CurrentUser.IsOnline())
            {
                #region 如果是开发测试模式,自动登录
                if (ConfigHelper.GetConfigBool("IsDebug"))
                {
                    string loginid = ConfigHelper.GetConfigString("DefaultLoginID");
                    string pass = ConfigHelper.GetConfigString("Pass");

                    LoginResult result;
                    UserBaseInfo uinfo = WEB.Module.LoginManage.LoginHelper.CheckLogin(loginid.Trim(), pass, out result);
                    if (result.Success)
                    {
                        IUser user = CurrentUser;
                        user.BaseInfo = uinfo;

                    }

                }
                #endregion
            }
            if (!CurrentUser.IsOnline())
            {
                //System.Web.HttpContext.Current.Response.Redirect("~/Manage/Layout/login.aspx?action=relogin");
                ReturnMsg(CurrentContext,false,enumReturnTitle.Login,"会话失败，请重新登录。");
                CurrentContext.Response.End();
            }
            else
            {
 
            }


        }

        /// <summary>
        /// 检查用户权限
        /// </summary>
        /// <param name="rightCode"></param>
        public void CheckUserRight(string rightCode, HttpContext CurrentContext)
        {
            bool hasRight = false;
            if (CurrentUser.IsOnline())
            {
                hasRight = DBControl.BLL.SystemRightBLL.IsExistRight(rightCode, CurrentUser.BaseInfo.UserID);
            }
            if (!hasRight)
            {
                ReturnMsg(CurrentContext, false, enumReturnTitle.Right, "没权限，无法操作。");
                CurrentContext.Response.End();

            }
        }



        /// <summary>
        /// 返回标题
        /// </summary>
        public enum enumReturnTitle { 
            /// <summary>
            /// 获取数据
            /// </summary>
            GetData,
            /// <summary>
            /// 操作数据
            /// </summary>
            OptData,
            /// <summary>
            /// 登录
            /// </summary>
            Login,
            /// <summary>
            /// 参数
            /// </summary>
            Param,
            /// <summary>
            /// 权限
            /// </summary>
            Right
        }
    }
}
