// See https://aka.ms/new-console-template for more information
using ClosedXML.Excel;
using System.Data;

GenerateReport();

void GenerateReport()
{
    try
    {
        var data = ReadInputFile(AppDomain.CurrentDomain.BaseDirectory + "Files\\Report.txt");
        var workbook = new XLWorkbook();

        string[] columns =
        {
        "ORDER NUMBER",
        "TYPE ORDER",
        "STATUS",
        "COMMENTS"
        };

        DataTable pendingTransactionsTable = new DataTable();

        foreach (string column in columns)
        {
            pendingTransactionsTable.Columns.Add(column);
        }

        foreach (var recordProcesses in data)
        {
            pendingTransactionsTable.Rows.Add(
                recordProcesses[0],
                recordProcesses[1],
                recordProcesses[2],
                recordProcesses[3]
             );
        }
        workbook.AddWorksheet(pendingTransactionsTable, "Execution report");

        workbook.SaveAs(AppDomain.CurrentDomain.BaseDirectory + "Files\\Excel Reports\\" + "Execution report " + DateTime.Now.ToString("ddMMyyyy") + ".xlsx");
    }
    catch(Exception ex)
    {
        throw ex;
    }
}
static List<string[]> ReadInputFile(string pathInputFile)
{
    List<string[]> readData = new List<string[]>();

    using (StreamReader readFile = new StreamReader(pathInputFile))
    {
        string line;
        string[] row;
        int count = 0;
        while ((line = readFile.ReadLine()) != null)
        {
            if (count > 0)
            {
                row = line.Split('|');
                readData.Add(row);
            }
            count++;
        }
    }

    return readData;
}