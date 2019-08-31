using NUnit.Framework;
using AlgorithmsDataStructures2;

namespace Tests
{
    class TestsSimpleGraph
    {
        
        private SimpleGraph _graph;

        [SetUp]
        public void TestsSetup()
        {
            _graph = new SimpleGraph(5);
            _graph.vertex = new Vertex[] { new Vertex(1), new Vertex(2), new Vertex(3), new Vertex(4), null };
            _graph.m_adjacency = new int[,] {
                {0,1,1,1,0},
                {1,0,0,1,0},
                {1,0,0,1,0},
                {1,1,1,1,0},
                {0,0,0,0,0}
            };
        }

        [TearDown]
        public void TestsTeardown()
        {
            _graph = null;
        }

        [Test]
        public void TestIsEdge()
        {
            Assert.IsFalse(_graph.IsEdge(0,0));
            Assert.IsTrue(_graph.IsEdge(0,1));
            Assert.IsFalse(_graph.IsEdge(1,1));
            Assert.IsFalse(_graph.IsEdge(2,2));
            Assert.IsTrue(_graph.IsEdge(3,3));
            Assert.IsTrue(_graph.IsEdge(3,1)); 
        }

        [Test]
        public void TestAddVertex()
        {
            Assert.IsNull(_graph.vertex[4]);
            _graph.AddVertex(5);
            Assert.IsNotNull(_graph.vertex[4]);
            for (int i = 0; i < _graph.max_vertex; i++)
            {
                Assert.AreEqual(0, _graph.m_adjacency[4,i]);
                Assert.AreEqual(0, _graph.m_adjacency[i,4]);
            }
        
        }

        [Test]
        public void TestAddEdge()
        {
            Assert.IsFalse(_graph.IsEdge(1,2));
            Assert.IsFalse(_graph.IsEdge(2,1));
            _graph.AddEdge(1,2);
            Assert.IsTrue(_graph.IsEdge(1,2));
            Assert.IsTrue(_graph.IsEdge(2,1));
        }

        [Test]
        public void TestRemoveEdge()
        {
            Assert.IsTrue(_graph.IsEdge(0,3));
            Assert.IsTrue(_graph.IsEdge(3,0));
            _graph.RemoveEdge(0,3);
            Assert.IsFalse(_graph.IsEdge(0,3));
            Assert.IsFalse(_graph.IsEdge(3,0));
        }

        [Test]
        public void TestRemoveVertex()
        {
            Assert.IsNotNull(_graph.vertex[3]);
            for (int i = 0; i < _graph.max_vertex - 1; i++)
            {
                Assert.IsTrue(_graph.IsEdge(i,3));
                Assert.IsTrue(_graph.IsEdge(3,i));
            }
            _graph.RemoveVertex(3);
            Assert.IsNull(_graph.vertex[3]);
            for (int i = 0; i < _graph.max_vertex; i++)
            {
                Assert.IsFalse(_graph.IsEdge(i,3));
                Assert.IsFalse(_graph.IsEdge(3,i));
            }
        }
    }
}
