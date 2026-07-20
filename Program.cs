using SpamEmailClassifier.DataIo;
using SpamEmailClassifier.Datarecord;

class Program
{
    static void Main()
    {
        string path = @"C:\Users\Yonil\source\repos\SpamEmailClassifier\train.csv";
        List<DataRecord> dr = new CSVReader().Read(path);
        foreach(DataRecord d in dr)
            Console.WriteLine(d);
    }
}