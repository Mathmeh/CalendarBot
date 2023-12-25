using CalendarBot.Models;
using OfficeOpenXml;
using System.Data;
using System.Reflection;

namespace CalendarBot.Excel
{
    public static class ExcelParser
    {
        public static List<StudyPlan> GetStudyPlans(string filePath, string sheetName, bool hasHeader = true)
        {

            var fi = new FileInfo(filePath);
            var AutumnPayload = new List<StudyPlan>();
            var SpringPayload = new List<StudyPlan>();

            // Check if the file exists
            if (!fi.Exists)
                throw new Exception("File " + filePath + " Does Not Exists");

            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            var xlPackage = new ExcelPackage(fi);


            // get the first worksheet in the workbook
            //var worksheet = xlPackage.Workbook.Worksheets["Лист 1"];
            //TrimLastEmptyRows(worksheet);

            ////var a = worksheet.Cells[51, 30].Value;
            ////var b = worksheet.Dimension.End.Column;
            ////var c = worksheet.Dimension.End.Row;
            //int i = 2;
            //var c = worksheet.Cells[i, 3].Value;

            //i++; // пропускаем строку с 
            //     //  var a =  worksheet.Cells.ExpxortDataTable()

            var payLoadPlan = ExcelPackageToDataTable(xlPackage);

            var studyPlanList = new List<StudyPlan>();

            foreach (DataRow r in payLoadPlan.Rows)
            {
                var plan = CustomRowResolver.RowToStudyPlan(r);
                studyPlanList.Add(plan);

            }

            #region
            var dr = studyPlanList[0];
            IEnumerable<FieldInfo> fields = dr.GetType().GetTypeInfo().DeclaredFields;

            foreach (var field in fields.Where(x => !x.IsStatic))
            {
                Console.WriteLine("{0}={1}", field.Name, field.GetValue(dr));
            }
            #endregion

            return studyPlanList;
        }


        public static DataTable ExcelPackageToDataTable(ExcelPackage excelPackage)
        {
            DataTable dt = new DataTable();
            ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets[0];

            //check if the worksheet is completely empty
            if (worksheet.Dimension == null)
            {
                return dt;
            }

            //create a list to hold the column names
            List<string> columnNames = new List<string>();

            //needed to keep track of empty column headers
            int currentColumn = 1;

            //loop all columns in the sheet and add them to the datatable
            foreach (var cell in worksheet.Cells[1, 1, 1, worksheet.Dimension.End.Column])
            {
                string columnName = cell.Text.Trim();

                //check if the previous header was empty and add it if it was
                if (cell.Start.Column != currentColumn)
                {
                    columnNames.Add("Header_" + currentColumn);
                    dt.Columns.Add("Header_" + currentColumn);
                    currentColumn++;
                }

                //add the column name to the list to count the duplicates
                columnNames.Add(columnName);

                //count the duplicate column names and make them unique to avoid the exception
                //A column named 'Name' already belongs to this DataTable
                int occurrences = columnNames.Count(x => x.Equals(columnName));
                if (occurrences > 1)
                {
                    columnName = columnName + "_" + occurrences;
                }

                //add the column to the datatable
                dt.Columns.Add(columnName);

                currentColumn++;
            }

            //start adding the contents of the excel file to the datatable
            for (int i = 2; i <= worksheet.Dimension.End.Row; i++)
            {
                var row = worksheet.Cells[i, 1, i, worksheet.Dimension.End.Column];
                DataRow newRow = dt.NewRow();

                //loop all cells in the row
                foreach (var cell in row)
                {
                    newRow[cell.Start.Column - 1] = cell.Text;
                }

                dt.Rows.Add(newRow);
            }

            return dt;
        }
       
    }

}
