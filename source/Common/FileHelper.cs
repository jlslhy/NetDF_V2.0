using System;
using System.IO;
using System.Text;
using System.Web;
using System.Web.UI;

using System.Resources;
using System.Reflection;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using Microsoft.Win32;
using System.Collections;
using System.Linq;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Threading;

namespace Common
{
    /// <summary>
    /// 提供常用的文件处理操作
    /// </summary>
    public class FileHelper
    {
        /// <summary>
        /// 下载文件,文本文件也有效
        /// </summary>
        /// <param name="pObjPage">调用的网页</param>
        /// <param name="pFileName">文件全路径</param>
        /// <param name="pShowName">下载时显示的文件名称</param>
        /// <param name="pIsDelFile">下载完成后，是否删除文件</param>
        public static void DownloadFile(System.Web.UI.Page pObjPage, String pFileName, String pShowName, bool pIsDelFile)
        {
            String saveFileName = "";       //保存时，客户端显示的文件名
            int intStart = 0;
            if (pShowName == "")
            {
                intStart = pFileName.LastIndexOf("\\") + 1;
                saveFileName = pFileName.Substring(intStart, pFileName.Length - intStart);
            }
            else
            {
                saveFileName = pShowName;
            }

            String fileextname = "";        //扩展名，主要是为了获取保存类型，从服务器的注册表中获取这个信息
            intStart = pFileName.LastIndexOf(".");
            fileextname = pFileName.Substring(intStart, pFileName.Length - intStart);

            String DEFAULT_CONTENT_TYPE = "application/unknown";        //默认的下载文件类型Mime

            RegistryKey regkey, fileextkey;
            String filecontenttype;         //实际的Mime

            try
            {
                regkey = Registry.ClassesRoot;
                fileextkey = regkey.OpenSubKey(fileextname);
                filecontenttype = fileextkey.GetValue("Content Type", DEFAULT_CONTENT_TYPE).ToString();
            }
            catch
            {
                //很有可能没有权限而出错，网站一定要运行在“本地系统”权限下才可以。
                filecontenttype = DEFAULT_CONTENT_TYPE;
            }

            pObjPage.Response.Clear();
            pObjPage.Response.Charset = "utf-8";
            pObjPage.Response.Buffer = true;
            pObjPage.EnableViewState = false;
            pObjPage.Response.ContentEncoding = System.Text.Encoding.UTF8;
            pObjPage.Response.AppendHeader("Content-Disposition", "attachment;filename=" + HttpUtility.UrlPathEncode(saveFileName));
            pObjPage.Response.ContentType = filecontenttype;

            FileStream MyFileStream = new FileStream(pFileName, FileMode.Open, FileAccess.Read);
            long FileSize;
            FileSize = MyFileStream.Length;
            byte[] Buffer = new byte[(int)FileSize];
            MyFileStream.Read(Buffer, 0, (int)FileSize);
            MyFileStream.Close();

            if (pIsDelFile)
            {
                File.SetAttributes(pFileName, FileAttributes.Normal);
                File.Delete(pFileName);
            }

            pObjPage.Response.BinaryWrite(Buffer);
            pObjPage.Response.Flush();
            pObjPage.Response.Close();
            pObjPage.Response.End();
        }

        public static void ExportExcel(DataGrid dataGrid)
        {
            string str = DateTime.Now.ToFileTime() + ".xls";
            HttpResponse response = HttpContext.Current.Response;
            response.Charset = "GB2312";
            response.ContentEncoding = Encoding.GetEncoding("GB2312");
            response.ContentType = "application/ms-excel/msword";
            response.AppendHeader("Content-Disposition", "attachment;filename=" + HttpUtility.UrlEncode(str));
            StringWriter writer = new StringWriter();
            HtmlTextWriter writer2 = new HtmlTextWriter(writer);
            writer2.WriteLine("<meta http-equiv=\"Content-Type\" content=\"text/html;charset=GB2312\">");

            #region 采用了自定义生成页面的方式，则屏蔽该代码
            foreach (DataGridColumn column in dataGrid.Columns)
            {
                if (((column is ButtonColumn) || (column is EditCommandColumn)) ||
                    (column is HyperLinkColumn))
                {
                    column.Visible = false;
                }
            }
            if (dataGrid.Items.Count > 0)
            {
                TableCellCollection cells = dataGrid.Items[0].Cells;
                for (int i = 0; i < cells.Count; i++)
                {
                    foreach (Control control in cells[i].Controls)
                    {
                        if ((!(control is Label) && !(control is LiteralControl))
                            && !(control is DataBoundLiteralControl) && !(control is HyperLink))
                        {
                            dataGrid.Columns[i].Visible = false;
                            break;
                        }

                        HyperLink hyperLink = control as HyperLink;
                        if (hyperLink != null)
                        {
                            if (hyperLink.Text == "查看" || hyperLink.Text == "编辑")
                            {
                                dataGrid.Columns[i].Visible = false;
                            }
                        }
                    }
                }
            }
            #endregion

            writer2.WriteLine(RenderDataGrid(dataGrid));
            //dataGrid.RenderControl(writer2);
            response.Write(writer.ToString());
            response.End();
        }

        public static string RenderDataGrid(DataGrid dataGrid)
        {
            string strFormat = "<td>{0}</td>";
            StringBuilder sb = new StringBuilder();
            string header = "";
            for (int i = 0; i < dataGrid.Columns.Count; i++)
            {
                if (dataGrid.Columns[i].Visible)
                {
                    header += string.Format(strFormat, dataGrid.Columns[i].HeaderText) + "\r\n";
                }
            }
            sb.Append(string.Format("<tr height=40 bgcolor='#C0C0C0'>{0}</tr> \r\n", header));

            for (int k = 0; k < dataGrid.Items.Count; k++)
            {
                TableCellCollection cells = dataGrid.Items[k].Cells;

                ITextControl txtControl = null;
                string txtContent = "";
                for (int i = 0; i < cells.Count; i++)
                {
                    if (dataGrid.Columns[i].Visible)
                    {
                        string txtStr = "";
                        foreach (Control control in cells[i].Controls)
                        {
                            txtControl = control as ITextControl;
                            if (txtControl != null)
                            {
                                txtStr += txtControl.Text + "  ";
                            }
                            else
                            {
                                HyperLink webCtrl = control as HyperLink;
                                if (webCtrl != null)
                                {
                                    txtStr += webCtrl.Text + "  ";
                                }
                            }
                        }
                        txtContent += string.Format(strFormat, txtStr) + "\r\n";
                    }
                }
                if (!string.IsNullOrEmpty(txtContent))
                {
                    sb.Append(string.Format("<tr>{0}</tr> \r\n", txtContent));
                }
            }

            return string.Format("<Table border=1>{0}</Table> \r\n", sb.ToString());
        }

        /// <summary>
        /// 列表控件转换为Excel：例如GridView
        /// </summary>
        /// <param name="aResponse"></param>
        /// <param name="pControl">控件对象</param>
        /// <param name="pFileName">文件名称</param>
        public static void GridViewToExcel(HttpResponse aResponse, GridView pControl, string pFileName)
        {
            if (string.IsNullOrEmpty(pFileName)) pFileName = "temp.xls";
            if (!pFileName.ToLower().Contains(".xls")) pFileName = pFileName + ".xls";

            aResponse.ClearContent();
            aResponse.AddHeader("content-disposition", string.Format("attachment; filename={0}", pFileName));
            aResponse.ContentType = "application/excel";
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);

            pControl.RenderControl(htw);
            aResponse.Write(sw.ToString());
            aResponse.End();
        }


        /// 将一组对象导出成EXCEL 
        /// </summary> 
        /// <typeparam name="T">要导出对象的类型</typeparam> 
        /// <param name="objList">一组对象</param> 
        /// <param name="FileName">导出后的文件名</param> 
        /// <param name="columnInfo">列名信息</param> 
        public static void ExExcel<T>(List<T> objList, string FileName, Dictionary<string, string> columnInfo)
        {

            if (columnInfo.Count == 0) { return; }
            if (objList.Count == 0) { return; }
            //生成EXCEL的HTML 
            StringBuilder excelStr = new StringBuilder(objList.Count * columnInfo.Count);

            string html = "<meta http-equiv='content-type' content='application/ms-excel; charset=GB2312'/><table border='1'>";

            Type myType = objList[0].GetType();
            //根据反射从传递进来的属性名信息得到要显示的属性 
            List<PropertyInfo> myPro = new List<PropertyInfo>();
            html += "<tr>";
            foreach (string cName in columnInfo.Keys)
            {
                PropertyInfo p = myType.GetProperty(cName);
                if (p != null)
                {
                    myPro.Add(p);
                    //excelStr.Append(columnInfo[cName]).Append("\t");
                    html += "<td bgcolor='#969696'>" + columnInfo[cName] + "</td>";
                }
            }
            html += "</tr>";
            //如果没有找到可用的属性则结束 
            if (myPro.Count == 0) { return; }
            excelStr.Append("\n");

            string temp = "";

            foreach (T obj in objList)
            {
                html += "<tr>";
                foreach (PropertyInfo p in myPro)
                {
                    //excelStr.Append(p.GetValue(obj, null)).Append("\t");
                    temp = Convert.ToString(p.GetValue(obj, null));
                    if (String.IsNullOrEmpty(temp))
                    {
                        temp = "&nbsp;";
                    }
                    temp = temp.Replace("<", "&lt;");
                    temp = temp.Replace(">", "&gt;");
                    html += "<td>" + temp + "</td>";
                }
                //excelStr.Append("\n");
                html += "</tr>";
            }
            html += "</table>";

            //输出EXCEL 
            HttpResponse rs = System.Web.HttpContext.Current.Response;
            //rs.ContentEncoding = System.Text.Encoding.GetEncoding("GB2312");
            rs.AppendHeader("Content-Disposition", "attachment;filename=" + FileName);
            rs.ContentType = "application/ms-excel";
            rs.Write(html);
            rs.End();
        }

        #region 资源文件帮助文件
        static Dictionary<string, ResourceManager> resourceManagerTable = new Dictionary<string, ResourceManager>();
        public static string GetRes(string fileName, string key)
        {
            ResourceManager mgr;
            if (resourceManagerTable.Keys.Any(p => p == fileName))
            {
                mgr = resourceManagerTable[fileName];
            }
            else
            {
                mgr = new ResourceManager("Resources." + fileName, System.Reflection.Assembly.Load("App_GlobalResources"));
                resourceManagerTable[fileName] = mgr;
            }
            return mgr.GetString(key);
        }
        #endregion


        /// <summary>
        /// 读取TXT文件内容
        /// </summary>
        /// <param name="filepath"></param>
        /// <returns></returns>
        public static string ReaderContentByTXTFile(string filepath)
        {
            if (!File.Exists(filepath))
            {
                return "";
            }
            StreamReader sr = new StreamReader(filepath, System.Text.Encoding.Default);
            String input = sr.ReadToEnd();
            sr.Close();

            return input;

        }
    
    }

}
