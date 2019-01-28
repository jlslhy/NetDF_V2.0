using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NPOI.HSSF.UserModel;
using System.Web;
using System.IO;
using System.Data;
using NPOI.SS.UserModel;
using NPOI.HSSF.Util;

namespace ZJ.GMCC.Framework.Common.Tools
{
    public class NPOIExcelHelper
    {
        public void CreateExcel(IDictionary<string, System.Data.DataTable> iDicDT, string FilePath, bool Visible)
        {
            HSSFWorkbook book = new HSSFWorkbook();

            foreach (KeyValuePair<string, System.Data.DataTable> val in iDicDT)
            {

                DataWrite2Sheet(val.Value, 0, val.Value.Rows.Count - 1, book,val.Key);
            }
            ExportToExcel(book, "数据导出.xls");
        }
        /// <summary>
        /// 把DataTable 转为Excel 内容
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="startRow"></param>
        /// <param name="endRow"></param>
        /// <param name="book"></param>
        /// <param name="sheetName"></param>
        private void DataWrite2Sheet(DataTable dt, int startRow, int endRow, HSSFWorkbook book, string sheetName)
        {
            //头部样式
            CellStyle headstyle = book.CreateCellStyle();
            headstyle.Alignment = HorizontalAlignment.CENTER;
            headstyle.VerticalAlignment = VerticalAlignment.CENTER;
            Font headfont = book.CreateFont();
            headfont.Boldweight = 700;
            headstyle.SetFont(headfont);
            headstyle.FillPattern = FillPatternType.SOLID_FOREGROUND;
            headstyle.FillForegroundColor = HSSFColor.GREY_25_PERCENT.index;
            headstyle.BorderBottom = CellBorderType.THIN;
            headstyle.BorderLeft = CellBorderType.THIN;
            headstyle.BorderRight = CellBorderType.THIN;
            headstyle.BorderTop = CellBorderType.THIN;
           
            NPOI.SS.UserModel.Sheet sheet = book.CreateSheet(sheetName);
            NPOI.SS.UserModel.Row header = sheet.CreateRow(0);
            header.Height = 20 * 20;
            
            //表格内容样
            CellStyle dataStyle = book.CreateCellStyle();
            dataStyle.BorderBottom = CellBorderType.THIN;
            dataStyle.FillPattern = FillPatternType.SOLID_FOREGROUND;
            dataStyle.BorderLeft = CellBorderType.THIN;
            dataStyle.BorderRight = CellBorderType.THIN;
            dataStyle.BorderTop = CellBorderType.THIN;
            


            for (int i = 0; i < dt.Columns.Count; i++)
            {
                NPOI.SS.UserModel.Cell cell = header.CreateCell(i);
                cell.CellStyle = headstyle;
                string val = dt.Columns[i].Caption ?? dt.Columns[i].ColumnName;
                cell.SetCellValue(val);
            }

            int rowIndex = 1;
            for (int i = startRow; i <= endRow; i++)
            {

                DataRow dtRow = dt.Rows[i];
                NPOI.SS.UserModel.Row excelRow = sheet.CreateRow(rowIndex++); 

                for (int j = 0; j < dtRow.ItemArray.Length; j++)
                {
                    excelRow.CreateCell(j).CellStyle = dataStyle;
                    excelRow.CreateCell(j).SetCellValue(dtRow[j].ToString());
                   
                }
            }

        }
        public void ExportToExcel(HSSFWorkbook hssfworkbook, string filePath)
        {
            HttpContext.Current.Response.ContentType = "application/vnd.ms-excel"; 
            HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment; filename=" + HttpUtility.UrlEncode(filePath, System.Text.Encoding.UTF8)); 
            HttpContext.Current.Response.Clear();
            MemoryStream ms = new MemoryStream();
            hssfworkbook.Write(ms); 

            HttpContext.Current.Response.BinaryWrite(ms.ToArray()); 
            HttpContext.Current.Response.Flush();   
        }
    }
}
