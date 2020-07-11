using NUnit.Framework;
using AlgorithmsDataStructures6;
using System.Diagnostics;

namespace Tests
{
    [TestFixture]
    public class TestsPerceptron
    {
        private Perceptron _neuron;

        [SetUp]
        public void SetUp()
        {
            var weigths = new decimal[10,10]
            {
                {1,1,1,1,1,1,1,1,1,1},
                {1,0,0,0,3,3,0,0,3,1},
                {1,0,0,3,0,0,3,3,0,1},
                {1,0,0,3,0,0,3,0,0,1},
                {1,0,3,0,0,3,0,3,0,1},
                {1,1,1,1,1,1,1,1,1,1},
                {1,3,0,3,0,0,0,0,3,1},
                {1,3,3,0,0,0,0,0,3,1},
                {1,3,0,0,0,0,0,0,0,1},
                {1,0,0,0,0,0,0,0,0,1}
            };

            _neuron = new Perceptron(weigths, 35);
        }


        [TestCase("../../../PerceptronInput/positiveA_v1.txt")]
        [TestCase("../../../PerceptronInput/positiveA_v2.txt")]
        [TestCase("../../../PerceptronInput/positiveA_v3.txt")]
        [TestCase("../../../PerceptronInput/negativeB_v2.txt")]
        [TestCase("../../../PerceptronInput/negativeИ.txt")]
        public void TestPerceptron_PositiveInput_TrueResult(string filePath)
        {
            Assert.AreEqual(1, _neuron.CalculateOutput(filePath));
        }

        [TestCase("../../../PerceptronInput/negative6.txt")]
        [TestCase("../../../PerceptronInput/negativeB_v1.txt")]
        [TestCase("../../../PerceptronInput/negativeC.txt")]
        [TestCase("../../../PerceptronInput/negativeE.txt")]
        [TestCase("../../../PerceptronInput/negativeF.txt")]
        [TestCase("../../../PerceptronInput/negativeH.txt")]
        [TestCase("../../../PerceptronInput/negativeS.txt")]
        public void TestPerceptron_NegativeInput_FalseResult(string filePath)
        {
            Assert.AreEqual(0, _neuron.CalculateOutput(filePath));
        }
    }
}