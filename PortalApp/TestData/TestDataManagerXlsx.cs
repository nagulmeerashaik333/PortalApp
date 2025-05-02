using ExcelDataReader;
using System.Data;


namespace UIAutomationPortal.TestData
{
    public class TestDataManagerXlsx
    {
        public static DataTable ReadSheet(string filePath, string sheetName)
        {
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

            using var stream = File.Open(filePath, FileMode.Open, FileAccess.Read);
            using var reader = ExcelReaderFactory.CreateReader(stream);
            var dataSet = reader.AsDataSet(new ExcelDataSetConfiguration
            {
                ConfigureDataTable = _ => new ExcelDataTableConfiguration
                {
                    UseHeaderRow = true
                }
            });

            return dataSet.Tables[sheetName];
        }
    }
}
