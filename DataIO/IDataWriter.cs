namespace SpamEmailClassifier.DataIo;

using SpamEmailClassifier.Datarecord;

public interface IDataWriter
{
    public void Write(string path , List<string> lines);
}