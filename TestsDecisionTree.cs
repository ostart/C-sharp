using NUnit.Framework;
using AlgorithmsDataStructures5;
using System.Collections.Generic;

namespace Tests
{
    public class TestsDecisionTree
    {
        private static Dictionary<string, List<string>> choiceTable;

        [SetUp]
        public static void Init()
        {
            choiceTable = new Dictionary<string, List<string>>();
            choiceTable.Add("Outlook", new List<string>{"Sunny","Sunny", "Overcast", "Rain", "Rain", "Rain", "Overcast", "Sunny", "Sunny", "Rain", "Sunny", "Overcast", "Overcast", "Rain"});
            choiceTable.Add("Temperature", new List<string>{"Hot","Hot", "Hot", "Mild", "Cool", "Cool", "Cool", "Mild", "Cool", "Mild", "Mild", "Mild", "Hot", "Mild"});
            choiceTable.Add("Humidity", new List<string>{"High","High", "High", "High", "Normal", "Normal", "Normal", "High", "Normal", "Normal", "Normal", "High", "Normal", "High"});
            choiceTable.Add("Wind", new List<string>{"Weak","Strong", "Weak", "Weak", "Weak", "Strong", "Strong", "Weak", "Weak", "Weak", "Strong", "Strong", "Weak", "Strong"});
            choiceTable.Add("Play Tennis", new List<string>{"No","No", "Yes", "Yes", "Yes", "No", "Yes", "No", "Yes", "Yes", "Yes", "Yes", "Yes", "No"});
        }

        [Test]
        public static void TestCalculateEntropy()
        {
            var decisionTree = new DecisionTree();
            double actualResult = decisionTree.CalculateEntropy(choiceTable, "Play Tennis");
            Assert.AreEqual(0.94, actualResult, 0.001);
        }

        [Test]
        public static void TestCalculateCriterionEntropy()
        {
            var decisionTree = new DecisionTree();
            double actualResult = decisionTree.CalculateEntropy(choiceTable, "Play Tennis", "Outlook", "Sunny");
            Assert.AreEqual(0.97, actualResult, 0.001);
        }

        [Test]
        public static void TestCalculateGain()
        {
            var decisionTree = new DecisionTree();

            double actualResult = decisionTree.CalculateGain(choiceTable, "Play Tennis", "Outlook");
            Assert.AreEqual(0.246, actualResult, 0.001);

            actualResult = decisionTree.CalculateGain(choiceTable, "Play Tennis", "Humidity");
            Assert.AreEqual(0.151, actualResult, 0.001);

            actualResult = decisionTree.CalculateGain(choiceTable, "Play Tennis", "Wind");
            Assert.AreEqual(0.048, actualResult, 0.001);

            actualResult = decisionTree.CalculateGain(choiceTable, "Play Tennis", "Temperature");
            Assert.AreEqual(0.029, actualResult, 0.001);
        }

        [Test]
        public static void TestMakeDecisionTree()
        {
            var decisionTree = new DecisionTree(choiceTable, "Play Tennis");

            var actual = decisionTree.GetResultForCriterion("Play Tennis", new Dictionary<string, string> {{ "Outlook", "Overcast"}});
            Assert.AreEqual("Yes", actual);

            actual = decisionTree.GetResultForCriterion("Play Tennis", new Dictionary<string, string> {{ "Outlook", "Sunny"}, {"Humidity", "High"}});
            Assert.AreEqual("No", actual);

            actual = decisionTree.GetResultForCriterion("Play Tennis", new Dictionary<string, string> {{ "Outlook", "Sunny"}, {"Humidity", "Normal"}});
            Assert.AreEqual("Yes", actual);

            actual = decisionTree.GetResultForCriterion("Play Tennis", new Dictionary<string, string> {{ "Outlook", "Rain"}, {"Wind", "Strong"}});
            Assert.AreEqual("No", actual);

            actual = decisionTree.GetResultForCriterion("Play Tennis", new Dictionary<string, string> {{ "Outlook", "Rain"}, {"Wind", "Weak"}});
            Assert.AreEqual("Yes", actual);
        }
    }
}