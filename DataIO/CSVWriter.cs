using SpamEmailClassifier.DataIo;

namespace SpamEmailClassifier.DataIo
{
    public class CSVWriter : IDataWriter
    {
        public void Write(string path , List<string> lines)
        {
            File.WriteAllLines(path, lines);
        }
    }
}