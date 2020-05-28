using NUnit.Framework;
using AlgorithmsDataStructures5;
using System.Collections.Generic;

namespace Tests
{
    public class TestsDynamicConnectivityGraph
    {
        private DynamicConnectivityGraph<int> _dcg;
        private List<int> _list;

        [SetUp]
        public void Init()
        {
            _list = new List<int> {1,2,3,4,5,6,7,8};
            _dcg = new DynamicConnectivityGraph<int>(_list);
        }

        [Test]
        public void TestAddRemoveEdges()
        {
            _dcg.AddEdge(1,2);
            Assert.IsTrue(_dcg.IsConnected(1,2));
            _dcg.AddEdge(2,4);
            Assert.IsTrue(_dcg.IsConnected(2,4));
            _dcg.AddEdge(1,3);
            Assert.IsTrue(_dcg.IsConnected(1,3));
            _dcg.AddEdge(3,4);
            Assert.IsTrue(_dcg.IsConnected(3,4));
            _dcg.AddEdge(1,4);
            Assert.IsTrue(_dcg.IsConnected(1,4));

            _dcg.AddEdge(5,6);
            Assert.IsTrue(_dcg.IsConnected(5,6));
            _dcg.AddEdge(6,8);
            Assert.IsTrue(_dcg.IsConnected(6,8));
            _dcg.AddEdge(5,7);
            Assert.IsTrue(_dcg.IsConnected(5,7));
            _dcg.AddEdge(7,8);
            Assert.IsTrue(_dcg.IsConnected(7,8));
            _dcg.AddEdge(5,8);
            Assert.IsTrue(_dcg.IsConnected(5,8));

            Assert.IsFalse(_dcg.IsConnected(4,5));
            Assert.IsFalse(_dcg.IsConnected(1,8));

            _dcg.AddEdge(4,5);
            Assert.IsTrue(_dcg.IsConnected(4,5));
            Assert.IsTrue(_dcg.IsConnected(1,8));

            _dcg.RemoveEdge(4,5);
            Assert.IsFalse(_dcg.IsConnected(4,5));
            Assert.IsFalse(_dcg.IsConnected(1,8));
        }

        [Test]
        public void TestBridges()
        {
            _dcg.AddEdge(1,2);
            _dcg.AddEdge(2,4);
            _dcg.AddEdge(1,3);
            _dcg.AddEdge(3,4);
            _dcg.AddEdge(1,4);

            var bridges = _dcg.GetBridges();
            Assert.AreEqual(0, bridges.Count);
            Assert.IsTrue(_dcg.IsConnected(1,4));
            Assert.IsTrue(_dcg.IsSame2EdgeConnectivity(1,4));

            _dcg.AddEdge(5,6);
            _dcg.AddEdge(6,8);
            _dcg.AddEdge(5,7);
            _dcg.AddEdge(7,8);
            _dcg.AddEdge(5,8);

            bridges = _dcg.GetBridges();
            Assert.AreEqual(0, bridges.Count);
            Assert.IsTrue(_dcg.IsConnected(5,8));
            Assert.IsTrue(_dcg.IsSame2EdgeConnectivity(5,8));

            Assert.IsFalse(_dcg.IsConnected(4,5));
            Assert.IsFalse(_dcg.IsConnected(1,8));

            _dcg.AddEdge(4,5);

            bridges = _dcg.GetBridges();
            Assert.AreEqual(1, bridges.Count);
            Assert.IsTrue(_dcg.IsConnected(4,5));
            Assert.IsFalse(_dcg.IsSame2EdgeConnectivity(4,5));
            Assert.IsTrue(_dcg.IsSame2EdgeConnectivity(1,4));
            Assert.IsTrue(_dcg.IsConnected(1,8));
            Assert.IsFalse(_dcg.IsSame2EdgeConnectivity(1,8));
            Assert.IsTrue(_dcg.IsSame2EdgeConnectivity(5,8));

            _dcg.RemoveEdge(4,5);

            bridges = _dcg.GetBridges();
            Assert.AreEqual(0, bridges.Count);
            Assert.IsFalse(_dcg.IsConnected(4,5));
            Assert.IsFalse(_dcg.IsConnected(1,8));
            Assert.IsFalse(_dcg.IsSame2EdgeConnectivity(4,5));
            Assert.IsTrue(_dcg.IsSame2EdgeConnectivity(1,4));
            Assert.IsFalse(_dcg.IsSame2EdgeConnectivity(1,8));
            Assert.IsTrue(_dcg.IsSame2EdgeConnectivity(5,8));
        }
    }
}