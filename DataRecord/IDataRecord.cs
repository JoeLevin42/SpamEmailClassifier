namespace SpamEmailClassifier.Datarecord;

public interface IDataRecord
{
    string GetLabel();

    Dictionary<string, string> GetFeatures();
}