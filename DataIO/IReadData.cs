namespace SpamEmailClassifier.DataIo;
using SpamEmailClassifier.Datarecord;

public interface IReadData
{
    public List<IDataRecords> Readfile(string path);
}