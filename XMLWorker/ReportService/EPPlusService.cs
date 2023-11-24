using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLWorker.ReportService
{
    public class EPPlusService
    {
        public EPPlusService()
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
        }

        public async Task SaveToExcel<T>(IEnumerable<T> data, FileInfo file)
        {
            using (var package = new ExcelPackage(file))
            {
                if (package != null)
                {
                    var worksheet = package.Workbook.Worksheets[0];

                    var range = worksheet.Cells["A2"].LoadFromCollection(data, false);
                    range.AutoFitColumns();

                    await package.SaveAsync();
                }
            }

        }

        //public async Task SaveToExcel<T>(IEnumerable<T> collection)
        //{
        //    SaveFileDialog sfD = new SaveFileDialog();
        //    sfD.DefaultExt = ".xlsx";
        //    sfD.Filter = "Файл Excel (.xlsx)|*.xlsx";
        //    sfD.FileName = $"Книга приема посетителей (на {DateTime.Now.ToString("dd.MM.yy")})";

        //    if (sfD.ShowDialog() == true)
        //    {
        //        var file = new FileInfo(sfD.FileName);
        //        if (file.Exists)
        //            file.Delete();

        //        CreateComplaintsSpreadSheet(file, collection);
        //    }
        //}

        public async Task CreateSpreadSheet<T>(IEnumerable<T> collection, FileInfo file)
        {
            using (ExcelPackage package = new (file))
            {
                ExcelWorksheet ws = package.Workbook.Worksheets.Add("Devices");
                ws.Cells.Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;

                ws.Cells["A2"].Value = "№";
                ws.Cells["B2"].Value = "ФИО владельца";
                ws.Cells["C2"].Value = "Модель";
                ws.Cells["D2"].Value = "Идентификационный номер устройства";

                ws.Column(col: 1).Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                ws.Row(row: 1).Height = 30;
                ws.Row(row: 1).Height = 20;

                ExcelRangeBase range = ws.Cells["A3"].LoadFromCollection(collection);
                range.AutoFitColumns();
                //ws.Column(col: 5).Style.WrapText = true;
                //ws.Column(col: 6).Style.WrapText = true;

                ws.Column(col: 1).Width = 5;
                //ws.Column(col: 2).Style.Numberformat.Format = "dd.mm.yy hh:mm";
                //ws.Column(col: 2).Width = 13;
                //ws.Column(col: 3).Width = 30;
                //ws.Column(col: 4).Width = 13;
                //ws.Column(col: 5).Width = 60;
                //ws.Column(col: 6).Width = 40;
                //ws.Column(col: 7).Width = 15;
                //ws.Column(col: 8).Width = 12;
                //ws.Column(col: 9).Width = 14;

                #region Header style
                ws.Cells[Address: "A1"].Value = $"Учет накопителей на {DateTime.Now.ToString("dd.MM.yyyy")}";
                ws.Cells[Address: "A1:D1"].Merge = true;

               // ws.Row(row: 1).Style.Font.Name = "Times New Roman";
                ws.Row(row: 1).Style.Font.Size = 16;
               // ws.Row(row: 2).Style.Font.Name = "Times New Roman";
                ws.Row(row: 2).Style.Font.Size = 12;

                ws.Cells[Address: "A2:D2"].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                ws.Row(row: 1).Style.Font.Bold = true;
                ws.Row(row: 2).Style.Font.Bold = true;
                ws.Row(row: 1).Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                ws.Row(row: 2).Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                #endregion

                await package.SaveAsync();
            }
        }
    }
}
