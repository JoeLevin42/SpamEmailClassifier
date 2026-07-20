using SpamEmailClassifier.Models;
using System.Data;
using System.Linq;


namespace SpamEmailClassifier.Models
{
    class ModelTrainer
    {
        public NaiveBayesModel Train(List<IDataRecord> rows, string targetColumn)
        {
            NaiveBayesModel model = new NaiveBayesModel();

            int n = rows.Count;

            // This is retunrs all the distinct label
            // (e.g "SPAM" , "EMAIL", "SPAM" -> return onlu "SPAM", EMAIL")
            List<string> labels = rows
              .Select(row => row.GetLabel())
              .Distinct()
              .ToList();

            //This is creating the `table` of priors
            Dictionary<string, double> priors = new Dictionary<string, double>();

            foreach (string label in labels)
            {
                int count = rows.Count(row => row.GetLabel() == label);

                double probability = (double)count / n;

                priors[label] = probability;
            }


            //This is creating the conditional probability table 
            Dictionary<string, double> cond = new Dictionary<string, double>();

            Dictionary<string, double> unseen = new Dictionary<string, double>();


            foreach (string label in labels)
            {
                List<IDataRecord> labelRows = rows
                    .Where(row => row.GetLabel() == label)
                    .ToList();


                foreach (string feature in rows[0].GetFeatures().Keys)
                {
                    // Get all different values of this feature
                    int distinct = rows
                        .Select(row => row.GetFeatures()[feature])
                        .Distinct()
                        .Count();


                    // Calculate conditional probabilities
                    foreach (string value in rows
                        .Select(row => row.GetFeatures()[feature])
                        .Distinct())
                    {
                        int match = labelRows.Count(row =>
                            row.GetFeatures()[feature] == value);


                        double probability =
                            (double)(match + 1) /
                            (labelRows.Count + distinct);


                        string key =
                            label + "_" + feature + "_" + value;


                        cond[key] = probability;
                    }


                    // Calculate probability for unseen values
                    string unseenKey =
                        label + "_" + feature;


                    double unseenProbability =
                        1.0 / (labelRows.Count + distinct);


                    unseen[unseenKey] = unseenProbability;
                }
            }


            // Save the trained data into the model
            model.Labels = labels;
            model.Priors = priors;
            model.ConditionalProbabilities = cond;
            model.UnseenProbabilities = unseen;


            return model;
        }
    }
}