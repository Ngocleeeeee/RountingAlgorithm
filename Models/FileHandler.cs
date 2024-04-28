
using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RoutingAIgorithm.Models
{
    public static class FileHandler
    {
        private static Application excel;
        private static Workbook workbook;
        private static Worksheet worksheet;
        public static void ExportToExcel(System.Windows.Forms.DataGridView dataGridView, string fileName, string title,string route, string cost)
        {
            try
            {
                //Tạo đối tượng COM.
                excel = new Application();
                excel.Visible = false;
                excel.DisplayAlerts = false;
                //tạo mới một Workbooks bằng phương thức add()
                workbook = excel.Workbooks.Add(Type.Missing);
                worksheet = (Worksheet)workbook.Sheets["Sheet1"];
                //đặt tên cho sheet
                worksheet.Name = title;
                // Định dạng dòng tiêu đề
                Range titleRange = worksheet.Range[worksheet.Cells[1, 1], worksheet.Cells[1, 6]];
                titleRange.Font.Bold = true;
                titleRange.Font.Size = 14;
                titleRange.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                titleRange.Merge(); // Kết hợp các ô thành một ô duy nhất
                titleRange.Value = title; // Đặt giá trị cho tiêu đề


                int headerRowIndex = 3;
                int contentRowIndex = 4;

                // export header trong DataGridView
                for (int i = 0; i < dataGridView.ColumnCount; i++)
                {
                    Range headerRange = (Range)worksheet.Cells[headerRowIndex, i + 1];
                    worksheet.Cells[headerRowIndex, i + 1] = dataGridView.Columns[i].HeaderText.ToUpper();
                    headerRange.Font.Bold = true;
                    headerRange.Borders.LineStyle = XlLineStyle.xlContinuous;
                    headerRange.Borders.Weight = XlBorderWeight.xlThin;
                }

                // export nội dung trong DataGridView
                for (int i = 0; i < dataGridView.RowCount; i++)
                {
                    for (int j = 0; j < dataGridView.ColumnCount; j++)
                    {
                        Range cellRange = (Range)worksheet.Cells[contentRowIndex + i, j + 1];
                        worksheet.Cells[contentRowIndex + i, j + 1] = dataGridView.Rows[i].Cells[j].Value.ToString();
                        cellRange.Borders.LineStyle = XlLineStyle.xlContinuous;
                        cellRange.Borders.Weight = XlBorderWeight.xlThin;
                    }
                }
                // Định dạng dòng route và cost
                Range routeRange = (Range)worksheet.Cells[contentRowIndex+dataGridView.RowCount, 1];
                routeRange.Font.Bold = true;
                routeRange.Value = "Route: " + route;

                Range costRange = (Range)worksheet.Cells[contentRowIndex+dataGridView.RowCount + 1, 1];
                costRange.Font.Bold = true;
                costRange.Value = "Cost: " + cost;

                // sử dụng phương thức SaveAs() để lưu workbook với filename
                workbook.SaveAs(fileName);
                //đóng workbook
                workbook.Close();
                excel.Quit();

            }
            catch (Exception ex)
            {

            }
            finally
            {
                workbook = null;
                worksheet = null;
            }
        }


    }
}
