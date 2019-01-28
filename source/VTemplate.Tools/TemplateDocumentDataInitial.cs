using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VTemplate.Engine;

namespace VTemplate.Tools
{
    public class TemplateDocumentDataInitial
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="document">模板文档</param>
        /// <param name="currentpageindex">当前页索引号</param>
        /// <param name="totalpage">总页面数量</param>
        /// <param name="diplayPageNumberCount">一页中显示的最大页面链接数量</param>
        public static void PageControlDataBind(TemplateDocument document, int currentpageindex, int totalpage, int diplayPageNumberCount)
        {
            int PageNumberCountTimes = ((totalpage - 1) / diplayPageNumberCount) + 1;
            int currentPageNumberCountTimes = (currentpageindex  / diplayPageNumberCount) + 1;

            //////////////////////////////////////
            currentpageindex = currentpageindex < 0 ? 0 : currentpageindex;
            currentpageindex = currentpageindex >= totalpage ? totalpage - 1 : currentpageindex;

            ///////////////////////////////////////
            string firstPage = "";
            string prevPage = "";
            string nextPage = "";
            string lastPage = "";
            string pageNumberList = "";


            //////////////////////////////////////////////////////
            prevPage = string.Format("{0}.html", currentpageindex.ToString());
            nextPage = string.Format("{0}.html", (currentpageindex + 2).ToString());

            if (currentpageindex < 0)
            {
                prevPage = "#";
                firstPage = firstPage = "1.html";
            }
            else if (currentpageindex == 0)
            {
                firstPage = prevPage = "#";
            }
            else
            {
                firstPage = "1.html";
            }

            if (currentpageindex > totalpage - 1)
            {
                nextPage = "#";
                lastPage = totalpage.ToString() + ".html";
            }
            else if (currentpageindex == totalpage - 1)
            {
                lastPage = nextPage = "#";
            }
            else
            {
                lastPage = totalpage.ToString() + ".html";
            }

            /////////////////////////////////////////////
            StringBuilder pageNumberListSB = new StringBuilder();
            if (currentPageNumberCountTimes > 1)
            {
                pageNumberListSB.Append(string.Format("<li><a href='{0}.html'>...</a></li>", diplayPageNumberCount * (currentPageNumberCountTimes - 1)));
            }

            for (int i = (currentPageNumberCountTimes - 1) * diplayPageNumberCount + 1; i <= currentPageNumberCountTimes * diplayPageNumberCount; i++)
            {
                if (i > totalpage) break;
                if (i == currentpageindex + 1)
                {
                    pageNumberListSB.Append(string.Format("\n<li ><b>{1}</b></li>", i, i));
                }
                else
                {
                    pageNumberListSB.Append(string.Format("\n<li ><a href='{0}.html' >{1}</a></li>", i, i));
                }
            }

            if (currentPageNumberCountTimes < PageNumberCountTimes)
            {
                pageNumberListSB.Append(string.Format("\n<li><a href='{0}.html'>...</a></li>", diplayPageNumberCount * currentPageNumberCountTimes + 1));
            }


            pageNumberList = pageNumberListSB.ToString();
            ////////////////////////////////////////////
            document.Variables.SetValue("firstPage", firstPage);
            document.Variables.SetValue("prevPage", prevPage);
            document.Variables.SetValue("nextPage", nextPage);
            document.Variables.SetValue("lastPage", lastPage);
            document.Variables.SetValue("pageNumberList", pageNumberList);
            document.Variables.SetValue("currentPage", (currentpageindex + 1).ToString());
        }
    }
}
