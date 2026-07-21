namespace SpamEmailClassifier.DataIo;
using SpamEmailClassifier.Datarecord;
using System.Data;

public class CSVReader : IReadData
{
    public List<IDataRecords> Readfile(string path)
    {
        try
        {
            string[] lines = File.ReadAllLines(path);
            List<IDataRecords> parsedData = ParsedData(lines);
            return parsedData;
        }
        catch (FileNotFoundException ex)
        {
            Console.WriteLine($"Error : {ex.Message}");
            throw ex;
        }
        }
   

    public List<IDataRecords> ParsedData(string[] lines)
    {
        string[] headers = lines[0].Split(",");
        List<IDataRecords> data = new List<IDataRecords>();
        for(int i = 1; i < lines.Length; i++)
        {
            if (string.IsNullOrWhiteSpace(lines[i]))
                continue; //TODO need to check this thing with erorr?????

            string[] line = lines[i].Split(",");
            IDataRecords dr = new DataRecord(headers, line);
            data.Add(dr);
        }
        return data;
    }
}