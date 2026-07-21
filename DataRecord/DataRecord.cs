namespace SpamEmailClassifier.Datarecord;

public class DataRecord : IDataRecords
{
    public string? Label { get; set; }

    public string? LabelName { get; set; }
    public string[] Headers { get; set; }
    public Dictionary<string, string> LineData { get; set; }

    public DataRecord(string[] headers, string[] line)
    {
        Headers = headers;
        LabelName = headers[^1];
        Label = line[^1];
        LineData = new Dictionary<string, string>();
        for (int i = 0; i < headers.Length - 1; i++)
        {
            LineData[headers[i]] = line[i];
        }
    }

    public DataRecord(string[] headers, List<string> line)
    {
        LineData = new Dictionary<string, string>();
        for (int i = 0; i < headers.Length; i++)
        {
            LineData[headers[i]] = line[i]; 
        }
    }
    public string[] GetHeaders()
    {
        return Headers;
    }
    public string? GetLabel()
    {
        return Label;
    }

    public string? GetLabelName()
    {
        return LabelName;
    }

    public Dictionary<string, string> GetFeatures()
    {
        return LineData;
    }

    public override string ToString()
    {
        return $"{string.Join(", ", LineData.Values)}";
    }
}
