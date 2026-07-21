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
        string fileNameTrain = args[0];
        string trainPath = Path.Combine(baseDirectory, fileNameTrain);

        //currect path to test
        string fileNameTest = args[1];
        string testPath = Path.Combine(baseDirectory, fileNameTest);

        string folderName = "output";
        string fileNameTestOut = "predictions.csv";
        string outPath = Path.Combine(baseDirectory, fileNameTest);

        Pipeline pip = new Pipeline(reader, writer, modeltrainer, classifier, trainPath);
        
        if (args.Length == 1)
        {
            pip.Run();
        }
        else if(args.Length == 2)
        {
            pip.Run(testPath, outPath);
        }

    }
}