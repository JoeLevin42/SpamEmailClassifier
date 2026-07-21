

using System.Reflection.Emit;
using static System.Runtime.InteropServices.JavaScript.JSType;
using SpamEmailClassifier.Datarecord;

namespace SpamEmailClassifier.Models
{
    public class Classifier
    {
        public string Predict(NaiveBayesModel model, DataRecord sample)
        {
            string bestLabel = "";
            double bestScore = double.MinValue;
            foreach (string label in model.Labels)
            {
                double score = model.Priors[label];
                foreach ((string feature, string value) in sample.LineData)
                {
                    string key = label + "_" + feature + "_" + value;
                    string unseenKey = label + "_" + feature;
                    if (model.ConditionalProbabilities.ContainsKey(key))
                    {
                        score = score * model.ConditionalProbabilities[key];
                    }
                    else
                    {
                        score = score * model.UnseenProbabilities[unseenKey];

                    }
                }
                   
                if(score > bestScore)
                {
                    bestScore = score;
                    bestLabel = label;
                }
            }
            return bestLabel;
        }
    }

}