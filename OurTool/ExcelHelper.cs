using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using Excel = Microsoft.Office.Interop.Excel;
/*
 row,col -- They are used to tell Excel where in the cell we want the text 
•htext -- This variable will hold the text for the header 
•cell1,cell2 -- This will be used to specify what cells we will use, e.g. A1:B1 
•mergeColumns -- It holds the number of cells we want to merge in a cell 
•b -- It will hold the color of the background for the chosen cell 
•font -- True or False for the font of the text on the selected cell 
•size -- To specify the size of the cell 
•fcolor-- Specify the color font 
format -- It is used to tell Excel what time of format we want 
*/

namespace OurCRMTool
{
    public class ExcelHelper
    {
        private Excel.Application app = null;
        private Excel.Workbook workbook = null;
        private Excel.Worksheet worksheet = null;
        private Excel.Range workSheet_range = null;
        BL bl;
        public ExcelHelper()
        {
            bl = new BL();
        }

        public void createExcel(List<DataTable> tableList, string fileName, bool showExcel, string header = null, Dictionary<string, object> keyCharDic = null)
        {
            try
            {
                app = new Excel.Application();
                app.Visible = showExcel;

                workbook = app.Workbooks.Add(1);
                foreach (DataTable table in tableList)
                {
                    int sheetNr = tableList.IndexOf(table) + 1;

                    if (sheetNr != 1)
                    {
                        worksheet = workbook.Worksheets.Add();
                    }
                    else
                    {
                        worksheet = workbook.Sheets[sheetNr];
                    }
                    if (table.TableName != string.Empty)
                    {
                        string name = Regex.Replace(table.TableName, @"[\[/\?\]\*]", "");
                        if (name.Length > 31)
                        {
                            name = name.Substring(0, 31);
                        }
                        worksheet.Name = name;
                    }
                    else
                    {
                        worksheet.Name = "sheet_" + sheetNr.ToString();
                    }
                    //style excel
                    Excel.Range columns = worksheet.Columns;
                    columns.AutoFit();
                    Marshal.ReleaseComObject(columns);

                    int rowIndex = 1;
                    int colIndex = 0;

                    if (header != null)
                    {
                        string colFromString = String.Concat(GetColumnName(1), rowIndex);
                        string colToString = String.Concat(GetColumnName(table.Columns.Count), rowIndex);
                        createHeaders(1, table.Columns.Count, header, colFromString, colToString, 2, System.Drawing.Color.Silver, true, 10, "n");
                        rowIndex = rowIndex + 2;
                        colIndex = 0;
                    }
                    foreach (System.Data.DataColumn column in table.Columns)
                    {
                        colIndex++;
                        string colString = String.Concat(GetColumnName(colIndex), rowIndex);
                        createHeaders(rowIndex, colIndex, column.ColumnName, colString, colString, 2, System.Drawing.Color.Aqua, true, 10, "n");
                    }
                    foreach (System.Data.DataRow dsrow in table.Rows)
                    {
                        rowIndex++;
                        colIndex = 0;
                        object[] rowData = dsrow.ItemArray;
                        foreach (String d in rowData)
                        {
                            colIndex++;
                            string colString = String.Concat(GetColumnName(colIndex), rowIndex);
                            addData(rowIndex, colIndex, d, colString, colString, "@");
                        }
                    }

                    if (keyCharDic != null)
                    {
                        AddKeyChar(colIndex + 2, keyCharDic);

                    }

                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        static string GetColumnName(int index)
        {
            const string letters = "0ABCDEFGHIJKLMNOPQRSTUVWXYZ";

            var value = "";

            if (index >= letters.Length)
                value += letters[index / letters.Length - 1];

            value += letters[index % letters.Length];

            return value;
        }
        public void createHeaders(int row, int col, string htext, string cell1, string cell2, int mergeColumns, System.Drawing.Color backgroundColor, bool bold, int size, string fcolor)
        {
            worksheet.Cells[row, col] = htext;
            workSheet_range = worksheet.get_Range(cell1, cell2);
            workSheet_range.Merge(mergeColumns);
            Excel.Interior interior = workSheet_range.Interior;
            interior.Color = backgroundColor;

            Excel.Borders border = workSheet_range.Borders;
            border.Color = System.Drawing.Color.Black.ToArgb();

            workSheet_range.ColumnWidth = size;
            Excel.Range cells = workSheet_range.Cells;
            cells.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            Excel.Font font = workSheet_range.Font;
            font.Bold = bold;
            if (fcolor.Equals(""))
            {
                font.Color = System.Drawing.Color.White;
            }
            else
            {
                font.Color = System.Drawing.Color.Black;
            }
        }

        public void addData(int row, int col, string data, string cell1, string cell2, string format)
        {
            worksheet.Cells[row, col] = data;
            workSheet_range = worksheet.get_Range(cell1, cell2);
            workSheet_range.NumberFormat = format;
            //  workSheet_range.Columns.AutoFit();
            Excel.Borders border = workSheet_range.Borders;
            border.Color = System.Drawing.Color.Black.ToArgb();

        }

        public void saveExcel(string fullPath)
        {
            workbook.SaveAs(fullPath, Excel.XlFileFormat.xlOpenXMLWorkbook);
            workbook.Close(true);
            app.Quit();
        }
        public void openExcel(string fullPath)
        {
            Excel.Workbook wb = app.Workbooks.Open(fullPath);
        }

        public void ReleseExcel()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();

            if (app != null)
            {
                Marshal.ReleaseComObject(app);
            }
            if (workbook != null)
            {
                Marshal.ReleaseComObject(workbook);
            }
            if (worksheet != null)
            {
                Marshal.ReleaseComObject(worksheet);
            }
            if (workSheet_range != null)
            {
                Marshal.ReleaseComObject(workSheet_range);
            }
        }

        private void AddKeyToCell(int row, int col, string text, object obj)
        {
            //add text keyChart
            string colString = String.Concat(GetColumnName(col), row);
            addData(row, col, text, colString, colString, "@");

            //add color or image to keyChart
            col++;
            colString = String.Concat(GetColumnName(col), row);  //add borders and format to the cell
            addData(row, col, "", colString, colString, "@");
            
            if (obj is string)  //string is a path to get a image
            {
                Excel.Range oRange = worksheet.Cells[row, col];
                float Left = (float)((double)oRange.Left);
                float Top = (float)((double)oRange.Top);
                string imagPath = bl.ResourcesPath + "\\" + obj.ToString();
                Image im = bl.GetImage("Organization.gif");
                float width = im.Width;
                float height = im.Height;

                worksheet.Shapes.AddPicture(imagPath, Microsoft.Office.Core.MsoTriState.msoFalse, Microsoft.Office.Core.MsoTriState.msoCTrue, Left, Top, width, height);
            }
            else
            {  //is a color to paint the cell

                Excel.Font font = workSheet_range.Font;
                font.Color = (System.Drawing.Color)obj;
            }
        }

        private void AddKeyChar(int _colIndex, Dictionary<string, object> keyCharDic)
        {
            int rowIndex = 2;
            int colIndex = _colIndex;
           
            foreach (KeyValuePair<string, object> o in keyCharDic) {
                AddKeyToCell(rowIndex, colIndex, o.Key, o.Value);
                rowIndex++;
                colIndex = _colIndex;
            }

        }
       
    }

    public static class DataTableToExcel
    {
        public static DataTable TransforImageInDTToString(DataTable dt)
        {
            DataTable retDT = new DataTable();
            //set newDT columns names
            foreach (System.Data.DataColumn column in dt.Columns)
            {
                string columnName = GetColumnName(column.ColumnName);
                if (retDT.Columns.Contains(columnName))
                {
                    Random ran = new Random();
                    columnName += ran.Next(0, 100).ToString();
                }
                retDT.Columns.Add(columnName);
            }
            foreach (DataRow row in dt.Rows)
            {
                List<string> rowValues = new List<string>();
                foreach (DataColumn col in dt.Columns)
                {
                    if (row[col].GetType().Name.ToLower() == "bitmap")
                    {
                        rowValues.Add(GetStringForImage((Image)row[col]));
                    }
                    else
                    {
                        rowValues.Add(row[col].ToString());
                    }
                }
                retDT.Rows.Add(rowValues.ToArray());
            }
            retDT.TableName = dt.TableName;
            return retDT;
        }

        public static string GetStringForImage(Image img)
        {
            string retString = string.Empty;
            if (img.Tag != null)
            {
                switch (img.Tag.ToString())
                {
                    case "1":
                        retString = "User";
                        break;
                    case "2":
                        retString = "Business";
                        break;
                    case "4":
                        retString = "Parent";
                        break;
                    case "8":
                        retString = "Organization";
                        break;
                    default:
                        break;
                }
            }
            return retString;
        }

        public static string GetColumnName(string columnName)
        {
            string[] optionsNames = new string[] { "UserTeamsNames", "ObjectTypeCode", "LogicName", "Name", "Read", "Write", "Delete", "AppendTo", "Append", "Create", "Assign", "Share", };
            string newColumnName = columnName;
            foreach (string s in optionsNames)
            {
                if (columnName.Contains(s))
                {
                    newColumnName = s;
                    break;
                }
            }

            return newColumnName;
        }
    }

}
