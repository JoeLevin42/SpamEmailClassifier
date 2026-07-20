

namespace SpamEmailClassifier.Models
{
    class NaiveBayesModel
    {
        public List<string> Labels { get; set; }
        public Dictionary<string, double> Priors { get; set; }
        public Dictionary<string, double> ConditionalProbabilities { get; set; }
        public Dictionary<string, double> UnseenProbabilities { get; set; }


        public NaiveBayesModel()
        {
            Labels = new List<string>();
            Priors = new Dictionary<string, double>();
            ConditionalProbabilities = new Dictionary<string, double>();

            UnseenProbabilities = new Dictionary<string, double>();
        }
    }

}