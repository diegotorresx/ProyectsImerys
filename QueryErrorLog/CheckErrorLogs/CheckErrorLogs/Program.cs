using Dapper;
using System.Data;
using System.Data.SqlClient;
using System.Text;

string textResult = string.Empty;
string pathInput = AppDomain.CurrentDomain.BaseDirectory + "Files\\Config.txt";
string pathList = AppDomain.CurrentDomain.BaseDirectory + "Files\\ListID.txt";
List<string[]> listID = ReadIDFile(pathList);
Dictionary<string, string> dictConfig = ReadInputFile(pathInput);
foreach (var ID in listID)
{
    List<CheckErrorLogs.Model.ModelData> dataResultById = QueryErrorLogs(dictConfig["connectionStringTest"], dictConfig["spQueryName"], ID[1]);
    string resultQueryLog = string.Empty;
    foreach (var dataId in dataResultById)
    {
        resultQueryLog = resultQueryLog + string.Format("{0} {1} {2} {3}", dataId.RPA_ID,dataId.dateTime.ToString(),dataId.Error_Description,dataId.Enviroment);
    }
    File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + "Files\\" + ID[1] + "ErrorLog.txt", textResult, Encoding.ASCII);
}
List<CheckErrorLogs.Model.ModelData> dataResult = QueryErrorLogs(dictConfig["connectionStringTest"], dictConfig["spQueryName"], "");
foreach (var register in dataResult)
{
    updateErrorLog(dictConfig["connectionStringTest"], dictConfig["spUpdateName"], register.ID);
}

File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + "Files\\RegistersErrorLog.txt", textResult, Encoding.ASCII);

static List<CheckErrorLogs.Model.ModelData> QueryErrorLogs(string connectionString, string spName, string RpaId)
{
    try
    {
        using (IDbConnection db = new SqlConnection(connectionString))
        {
            db.Open();
            var list = db.Query<CheckErrorLogs.Model.ModelData>(spName, new { RpaId = RpaId} , commandType: CommandType.StoredProcedure).ToList();
            return list.ToList();
        }
    }
    catch (Exception e)
    {
        throw e;
    }
}

 static void updateErrorLog(string connectionString, string storedProcedureName, int id)
{
    try
    {
        using (IDbConnection db = new SqlConnection(connectionString))
        {
            db.Open();
            db.Execute(storedProcedureName, new { ID = id }, commandType: CommandType.StoredProcedure, commandTimeout: 0);
            db.Close();
        }
    }
    catch(Exception e)
    {
        throw e;
    } 
}
static List<string[]> ReadIDFile(string pathInputFile)
{
    try
    {
        List<string[]> listID = new List<string[]>();
        int count = 0;
        using (StreamReader readFile = new StreamReader(pathInputFile))
        {
            string line;
            string[] row;

            while ((line = readFile.ReadLine()) != null)
            {
                if (count > 0)
                {
                    row = line.Split('|');
                    listID.Add(row);
                }
                count++;
            }
        }
        return listID;
    }
    catch (Exception e)
    {
        throw e;
    }

}

static Dictionary<string, string> ReadInputFile(string pathInputFile)
{
    try
    {
        Dictionary<string, string> config = new Dictionary<string, string>();
        int count = 0;
        using (StreamReader readFile = new StreamReader(pathInputFile))
        {
            string line;
            string[] row;

            while ((line = readFile.ReadLine()) != null)
            {
                if (count > 0)
                {
                    row = line.Split('|');
                    config.Add(row[0], row[1]);
                }
                count++;
            }
        }
        return config;
    }
    catch (Exception e)
    {
        throw e;
    }
    
}