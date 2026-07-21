using SpamEmailClassifier.DataIo;
using SpamEmailClassifier.Models;
using SpamEmailClassifier.Datarecord;
using System.Data;

namespace SpamEmailClassifier.Pipelines
{
    public class Pipeline
    {
        private IReadData _reader;
        private IDataWriter _writer;
        private ModelTrainer _trainer;
        private Classifier _classifier;
        private NaiveBayesModel _naiveBayesModel;

        public Pipeline(
            IReadData reader,
            IDataWriter writer,
            ModelTrainer trainer,
            Classifier classifier ,
            string trainPath)
        {
            _reader = reader;
            _writer = writer;
            _trainer = trainer;
            _classifier = classifier;
            List<IDataRecords> a = _reader.Readfile(trainPath);
            _naiveBayesModel = _trainer.Train(a, a[0].GetLabelName());
        }

        public void Run(string line)
        {
            
        }

        public void Run(string inputPath , string outPath)
        {
            // - csv reader
            // - 
        }

    }
}