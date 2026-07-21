using SpamEmailClassifier.DataIo;
using SpamEmailClassifier.Datarecord;
using SpamEmailClassifier.Models;
using SpamEmailClassifier.Pipelines;

class Program
{
    static void Main(string[] args)
    {
       
        IReadData reader = new CSVReader();
        IDataWriter writer = new CSVWriter();
        ModelTrainer modeltrainer = new ModelTrainer();
        Classifier classifier = new Classifier();

        string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;

        //currect path to train
        string outFolder = "DataFiles";
        string MiddleFolder = "InputFiles";
        string InnerFolder = "TrainInput";
        string fileNameTrain = args[0];
        string trainPath = Path.Combine(baseDirectory, outFolder, MiddleFolder, InnerFolder, fileNameTrain);

        //currect path to test

        Pipeline pip = new Pipeline(reader, writer, modeltrainer, classifier, trainPath);
        try { 
            if (args.Length == 1)
            {
                pip.Run();
            }
            else if (args.Length == 2)
            {
                string fileNameTest = args[1];
                string innerfolder = "TestInput";
                string testPath = Path.Combine(baseDirectory, outFolder, MiddleFolder, innerfolder, fileNameTest);

                string folderName = "output";
                string fileNameTestOut = "predictions.csv";
                string outPath = Path.Combine(baseDirectory, folderName, fileNameTestOut);

                pip.Run(testPath, outPath);
            }
        }
        catch (FileNotFoundException ex)
        {
            Console.WriteLine($"Error : {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error : {ex.Message}");
        }

    }
}