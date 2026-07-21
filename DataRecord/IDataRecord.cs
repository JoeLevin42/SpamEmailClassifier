namespace SpamEmailClassifier.Datarecord;

public interface IDataRecords
{
    public string? GetLabel();

    public string? GetLabelName();
    Dictionary<string, string> GetFeatures();
}