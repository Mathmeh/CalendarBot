using CalendarBot.Models;
using OfficeOpenXml;

namespace CalendarBot.Logic
{
    public class ExcelLogic
    {
        public static void CreateImplementationTable(List<Implementation> implementations, string path)
        {
            //var info = new ExcelInfo(2, "df", new DateTime(2015, 7, 20));
            using (ExcelPackage excel = new ExcelPackage())
            {
                excel.Workbook.Worksheets.Add("Worksheet1");
                

                var headerRow = new List<string[]>()
                  {
                    new string[] { "Дата", "Время \nначала", "Время \nокончания", "Группа", "Дисциплина", "Тема", "Тип\nзанятия", "Часы", "Ставка", "Примечания" }
                  };

                // Determine the header range 
                string headerRange = "A1:" + Char.ConvertFromUtf32(headerRow[0].Length + 64) + "1";

                // Target a worksheet
                var worksheet = excel.Workbook.Worksheets["Worksheet1"];

                // Loading headers
                worksheet.Cells[headerRange].LoadFromArrays(headerRow);

                var cellData = new List<object[]>();
               

                foreach (var impl in implementations)
                {
                    cellData.Add(new object[] 
                    {
                        impl.Date, 
                        impl.StartTime.ToString(),
                        impl.EndTime.ToString(), 
                        impl.Group,
                        impl.Discipline,
                        impl.Theme,
                        impl.LessonType,
                        impl.Hours,
                        impl.Ante,
                        impl.Note
                    });
                }
                worksheet.Cells[2, 1].LoadFromArrays(cellData);
                FileInfo excelFile = new FileInfo(path);
                excel.SaveAs(excelFile);
            }
        }
    }
}
