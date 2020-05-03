using NUnit.Framework;
using AlgorithmsDataStructures5;
using System.Collections.Generic;

namespace Tests
{
    public class TestsEulerGraph
    {
        private static EulerNode<string> Root;
        private static EulerNode<string> Root2;

        [SetUp]
        public static void Init()
        {
            var f = new EulerNode<string>("f");
            var b = new EulerNode<string>("b");
            var d = new EulerNode<string>("d", new List<EulerNode<string>> {f,b});
            f.Parent = d;
            b.Parent = d;
            var e = new EulerNode<string>("e");
            var c = new EulerNode<string>("c", new List<EulerNode<string>> {e,d});
            e.Parent = c;
            d.Parent = c;
            var a = new EulerNode<string>("a", new List<EulerNode<string>> {c});
            c.Parent = a;
            Root = a;

            var k = new EulerNode<string>("k");
            var i = new EulerNode<string>("i");
            var j = new EulerNode<string>("j", new List<EulerNode<string>> {k,i});
            k.Parent = j;
            i.Parent = j;
            var h = new EulerNode<string>("h");
            var g = new EulerNode<string>("g", new List<EulerNode<string>> {h,j});
            h.Parent = g;
            j.Parent = g;
            Root2 = g;
        }

        [Test]
        public static void TestMakeGraphFromTree()
        {
            var graph = EulerGraph<string>.MakeGraph(new List<EulerNode<string>> {Root});

            var expected = new Dictionary<string, List<string>> {
                {"a", new List<string> {"c"}},
                {"c", new List<string> {"e", "d", "a"}},
                {"e", new List<string> {"c"}},
                {"d", new List<string> {"f", "b", "c"}},
                {"f", new List<string> {"d"}},
                {"b", new List<string> {"d"}}
            };
            CollectionAssert.AreEquivalent(expected, graph.VertexChildNodes);
        }

        [Test]
        public static void TestMakeTourFromGraph()
        {
            var graph = EulerGraph<string>.MakeGraph(new List<EulerNode<string>> {Root});
            var tour = EulerGraph<string>.MakeTour(graph, graph.Roots[0]);
            graph.Tours.Add(tour);

            var expected = new List<string> {"a", "c", "e", "c", "d", "f", "d", "b", "d", "c", "a"};
            CollectionAssert.AreEquivalent(expected, tour);
        }

        [Test]
        public static void TestChangeGraphRoot()
        {
            var graph = EulerGraph<string>.MakeGraph(new List<EulerNode<string>> {Root});

            var tour = EulerGraph<string>.MakeTour(graph, "a");
            var expected = new List<string> {"a", "c", "e", "c", "d", "f", "d", "b", "d", "c", "a"};
            CollectionAssert.AreEquivalent(expected, tour);

            tour = EulerGraph<string>.MakeTour(graph, "d");
            expected = new List<string> {"d", "f", "d", "b", "d", "c", "e", "c", "a", "c", "d"};
            CollectionAssert.AreEquivalent(expected, tour);
        }

        [Test]
        public static void TestAddEdgeForTwoGraph()
        {
            var graph = EulerGraph<string>.MakeGraph(new List<EulerNode<string>> {Root});
            var tour = EulerGraph<string>.MakeTour(graph, "a");
            graph.Tours.Add(tour);
            var expected = new List<string> {"a", "c", "e", "c", "d", "f", "d", "b", "d", "c", "a"};
            CollectionAssert.AreEquivalent(expected, tour);

            var graph2 = EulerGraph<string>.MakeGraph(new List<EulerNode<string>> {Root2});
            var tour2 = EulerGraph<string>.MakeTour(graph2, "g");
            graph2.Tours.Add(tour2);
            var expected2 = new List<string> {"g", "h", "g", "j", "k", "j", "i", "j", "g"};
            CollectionAssert.AreEquivalent(expected2, tour2);

            var mergedGraph = EulerGraph<string>.Merge(graph, graph2);
            var expected3 = new List<string> {"a", "c", "e", "c", "d", "f", "d", "b", "d", "c", "a", "g", "h", "g", "j", "k", "j", "i", "j", "g", "a"};
            CollectionAssert.AreEquivalent(expected3, mergedGraph.Tours[0]);
        }

        [Test]
        public static void TestIsTheSameGraph()
        {
            var graph = EulerGraph<string>.MakeGraph(new List<EulerNode<string>> {Root});
            var tour = EulerGraph<string>.MakeTour(graph, "a");
            graph.Tours.Add(tour);
            var expected = new List<string> {"a", "c", "e", "c", "d", "f", "d", "b", "d", "c", "a"};
            CollectionAssert.AreEquivalent(expected, tour);

            var graph2 = EulerGraph<string>.MakeGraph(new List<EulerNode<string>> {Root2});
            var tour2 = EulerGraph<string>.MakeTour(graph2, "g");
            graph2.Tours.Add(tour2);
            var expected2 = new List<string> {"g", "h", "g", "j", "k", "j", "i", "j", "g"};
            CollectionAssert.AreEquivalent(expected2, tour2);

            Assert.IsTrue(graph.BothBelong("f", "e"));
            Assert.IsFalse(graph.BothBelong("f", "g"));
            Assert.IsTrue(graph2.BothBelong("j", "i"));
            Assert.IsFalse(graph2.BothBelong("f", "i"));
        }
    }
}