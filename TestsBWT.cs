using NUnit.Framework;
using AlgorithmsDataStructures6;
using System.Diagnostics;

namespace Tests
{
    [TestFixture]
    public class TestsBWT
    {
        [Test]
        public void TestBWT_PositiveInput_TrueResult()
        {
            var bwt = new BWT(2, 3, false);
        }
    }
}