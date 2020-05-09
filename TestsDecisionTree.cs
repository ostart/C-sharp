using NUnit.Framework;
using AlgorithmsDataStructures5;
using System.Collections.Generic;

namespace Tests
{
    public class TestsDecisionTree
    {
        private static Dictionary<string, List<string>> table;

        [SetUp]
        public static void Init()
        {
            table = new Dictionary<string, List<string>>();
            table.Add("Outlook", new List<string>{"Sunny","Sunny", "Overcast", "Rain", "Rain", "Rain", "Overcast", "Sunny", "Sunny", "Rain", "Sunny", "Overcast", "Overcast", "Rain"});
            table.Add("Temperature", new List<string>{"Hot","Hot", "Hot", "Mild", "Cool", "Cool", "Cool", "Mild", "Cool", "Mild", "Mild", "Mild", "Hot", "Mild"});
            table.Add("Humidity", new List<string>{"High","High", "High", "High", "Normal", "Normal", "Normal", "High", "Normal", "Normal", "Normal", "High", "Normal", "High"});
            table.Add("Wind", new List<string>{"Weak","Strong", "Weak", "Weak", "Weak", "Strong", "Strong", "Weak", "Weak", "Weak", "Strong", "Strong", "Weak", "Strong"});
            table.Add("Play Tennis", new List<string>{"No","No", "Yes", "Yes", "Yes", "No", "Yes", "No", "Yes", "Yes", "Yes", "Yes", "Yes", "No"});
        }

        [Test]
        public static void TestCalculateEntropy()
        {
            var decisionTree = new DecisionTree(table);
            double actualResult = decisionTree.CalculateEntropy("Play Tennis");
            Assert.AreEqual(0.94, actualResult, 0.001);
        }

        [Test]
        public static void TestCalculateCriterionEntropy()
        {
            var decisionTree = new DecisionTree(table);
            double actualResult = decisionTree.CalculateEntropy("Play Tennis", "Outlook", "Sunny");
            Assert.AreEqual(0.97, actualResult, 0.001);
        }

        [Test]
        public static void TestCalculateGain()
        {
            var decisionTree = new DecisionTree(table);

            double actualResult = decisionTree.CalculateGain("Play Tennis", "Outlook");
            Assert.AreEqual(0.246, actualResult, 0.001);

            actualResult = decisionTree.CalculateGain("Play Tennis", "Humidity");
            Assert.AreEqual(0.151, actualResult, 0.001);

            actualResult = decisionTree.CalculateGain("Play Tennis", "Wind");
            Assert.AreEqual(0.048, actualResult, 0.001);

            actualResult = decisionTree.CalculateGain("Play Tennis", "Temperature");
            Assert.AreEqual(0.029, actualResult, 0.001);
        }
    }
}