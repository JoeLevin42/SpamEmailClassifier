

namespace SpamEmailClassifier.DataIo
{
    class CSVWriter : IDataWriter
    {
        public void Write(string path , List<string> lines)
        {
            File.WriteAllLines(path, lines);
        }
    }
}