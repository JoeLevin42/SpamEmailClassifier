namespace SpamEmailClassifier.DataIo;

using SpamEmailClassifier.Datarecord;

interface IDataWriter
{
    public List<IDataRecords> Write(string path , List<string> lines);
}