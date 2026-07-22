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
        private List<IDataRecords> _dataTrain;
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
            _dataTrain = _reader.Readfile(trainPath);
            _naiveBayesModel = _trainer.Train(_dataTrain, _dataTrain[0].GetLabelName());
        }

        public void Run()
        {
            try
            {
                List<string> result = new List<string>();
                string[] headers = _dataTrain[0].GetHeaders();

                foreach (string header in headers.SkipLast(1))
                {
                    Console.Write($"Please enter value for {header}: ");
                    string line = Console.ReadLine();
                    if (line.Length == 0) Environment.Exit(1);
                    result.Add(line);
                }
                DataRecord drLine = new DataRecord(headers, result);

                string newLabel = _classifier.Predict(_naiveBayesModel, drLine);

                for (int i = 0; i < result.Count - 1; i++)
                {
                    Console.WriteLine($"{headers[i]} : {result[i]}");
                }
                Console.WriteLine($"Prediction : {newLabel}");

            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine($"Error : {ex.Message}");
               
            }
        }

        public void Run(string inputPath , string outPath)
        {
            try
            {
                List<string> result = new List<string>();
                List<IDataRecords> data = _reader.Readfile(inputPath);
                string[] headers = data[0].GetHeaders();
                string headerStr = string.Join(",", headers);
                result.Add(headerStr);
                foreach (DataRecord line in data)
                {
                    string newLabel = _classifier.Predict(_naiveBayesModel, line);

                    Console.WriteLine($"{line.ToString()},{newLabel}");

                    result.Add(line.ToString() + $",{newLabel}");
                }

                _writer.Write(outPath, result);
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine($"Error : {ex.Message}");
            }


        }

    }
}