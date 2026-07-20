namespace SpamEmailClassifier.Datarecord;

public interface IDataRecords
{
    string GetLabel();

    Dictionary<string, string> GetFeatures();
}