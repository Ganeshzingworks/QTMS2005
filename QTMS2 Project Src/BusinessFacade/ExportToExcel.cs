using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Excel = Microsoft.Office.Interop.Excel;
 
 
namespace BusinessFacade
{
    public class ExportToExcel
    {
        Excel.Application application = null;
        Excel.Workbook workbook = null;
        Excel.Worksheet worksheet = null;
        Excel.Range workSheet_range = null;
        public void GenerateExcelFile(DataTable dtUpTdb )
        {
            try
            {
                
                application = new Excel.ApplicationClass();
                workbook = application.Workbooks.Add(Type.Missing);
                

                if (dtUpTdb.Rows.Count > 0)
                {
                    worksheet = (Excel.Worksheet)workbook.Sheets[1];
                   
                    worksheet.Name = "Sheet1";
                   

                    for (int col = 0; col < dtUpTdb.Columns.Count; col++)
                    {
                         
                        //string str = dtUpTdb.Columns[0].Caption.ToString();
                       
           //..............create table headers - getting data tables header               
                       
                        worksheet.Cells[1, col + 1] = dtUpTdb.Columns[col].Caption.ToString();


                    }
                    workSheet_range = null;


                    for (int row = 0; row < dtUpTdb.Rows.Count; row++)
                    {
                        //start with first row of data table
                        for (int col = 0; col < dtUpTdb.Columns.Count; col++)
                        {

                         // ..................................generate excel coloumn by coloumn
   
                        worksheet.Cells[row + 2, col+1] = dtUpTdb.Rows[row][col].ToString();
                      

                        }

                    }
                    //..

  
                }
                 
                 
                application.Visible = true;

                releaseObject(worksheet);
                releaseObject(workbook);

                releaseObject(application);
                //application.Quit();
                //efolderPath = null;
            }
            catch (Exception ex)
            {
                //ex.Message="Exception occured" ;
            }
            finally
            {
                GC.Collect();

            }
        }

        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
               // ex.Message = "Exception occured";
                //MessageBox.Show("Unable to release the Object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }

        private void CreateHeaders(int row, int col, string hText, string cell1, string cell2, int mergeColumn, string b, bool font, int size)
        {
            try
            {
                worksheet.Cells[row, col] = hText;
                workSheet_range = worksheet.get_Range(cell1, cell2);
                workSheet_range.Merge(mergeColumn);
                workSheet_range.WrapText = true;


                switch (b)
                {
                    case "DARK YELLOW":
                        workSheet_range.Interior.ColorIndex = 36;
                        break;
                    case "YELLOW":
                        //workSheet_range.Interior.Color = System.Drawing.Color.Yellow.ToArgb();
                        workSheet_range.Interior.ColorIndex = 27; //Color index 45 means Yellow mix color
                        break;
                    case "GRAY":
                        workSheet_range.Interior.Color = System.Drawing.Color.Gray.ToArgb();
                        break;
                    case "GAINSBORO":
                        workSheet_range.Interior.Color = System.Drawing.Color.Gainsboro.ToArgb();
                        break;
                    case "Turquoise":
                        workSheet_range.Interior.Color = System.Drawing.Color.Turquoise.ToArgb();
                        workSheet_range.Interior.ColorIndex = 8;
                        break;
                    case "AQUA":
                        workSheet_range.Interior.ColorIndex = 42;
                        break;
                    case "PeachPuff":
                        workSheet_range.Interior.Color = System.Drawing.Color.PeachPuff.ToArgb();
                        break;
                    case "TEAL":
                        workSheet_range.Interior.ColorIndex = 14;
                        break;
                    case "GREEN":
                        workSheet_range.Interior.ColorIndex = 10;
                        break;
                    case "LIGHT GREEN":
                        workSheet_range.Interior.ColorIndex = 35;
                        break;
                    case "TAN":
                        workSheet_range.Interior.ColorIndex = 40;
                        break;
                    case "DARK BLUE":
                        workSheet_range.Interior.ColorIndex = 5;
                        break;
                    case "DARK RED":
                        workSheet_range.Interior.ColorIndex = 3;
                        break;
                    case "SKY BLUE":
                        workSheet_range.Interior.ColorIndex = 33;
                        break;
                    default:
                        //  workSheet_range.Interior.Color = System.Drawing.Color..ToArgb();
                        break;
                }
                workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
                workSheet_range.Font.Bold = font;
                workSheet_range.ColumnWidth = size;
                workSheet_range.HorizontalAlignment = Excel.Constants.xlCenter;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
         
    }
}
