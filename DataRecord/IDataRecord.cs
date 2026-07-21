namespace SpamEmailClassifier.Datarecord;

public interface IDataRecords
{
    public string? GetLabel();

    public string? GetLabelName();
    public Dictionary<string, string> GetFeatures();
    public string[] GetHeaders();
    
}