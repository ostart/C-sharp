using System;
using System.Linq;
using System.Collections.Generic;

namespace AlgorithmsDataStructures5
{
    public class EulerGraph<T>
    {
        public Dictionary<T, List<T>> VertexChildNodes {get;set;}
        public List<T> Roots {get;set;}
        public List<List<T>> Tours {get;set;}
        public EulerGraph()
        {
            VertexChildNodes = new Dictionary<T, List<T>>();
            Roots = new List<T>();
            Tours = new List<List<T>>();
        }
        
        public static EulerGraph<T> MakeGraph(List<EulerNode<T>> nodes, EulerGraph<T> result = null)
        {
            if (result == null) 
            {
                result = new EulerGraph<T>();
                if (nodes != null) result.Roots = nodes.Select(x => x.Value).ToList();
            }
            foreach (var node in nodes)
            {
                if (node.Children != null)
                {
                    var list = node.Children.Select(x => x.Value).ToList();
                    if (result.VertexChildNodes.ContainsKey(node.Value))
                        result.VertexChildNodes[node.Value].AddRange(list);
                    else
                        result.VertexChildNodes[node.Value] = list;
                    var _ = MakeGraph(node.Children, result);
                }
                if (node.Parent != null)
                {
                    if (result.VertexChildNodes.ContainsKey(node.Value))
                        result.VertexChildNodes[node.Value].Add(node.Parent.Value);
                    else
                        result.VertexChildNodes[node.Value] = new List<T> {node.Parent.Value};
                }
            }
            return result;
        }

        public static List<T> MakeTour(EulerGraph<T> graph, T start)
        {
            if (graph.Roots.Contains(start))
            {
                foreach (var tour in graph.Tours)
                {
                    if (tour[0].Equals(start)) return tour;
                }
            }
            else graph.Roots.Add(start);

            var clonedGraph = Clone(graph);
            var result = new List<T>();
            var current = start;
            while(clonedGraph.VertexChildNodes[current].Count != 0)
            {
                result.Add(current);
                var next = clonedGraph.VertexChildNodes[current][0];
                if (next.Equals(start) && clonedGraph.VertexChildNodes[current].Count > 1)
                {
                    next = clonedGraph.VertexChildNodes[current][1];
                    clonedGraph.VertexChildNodes[current].RemoveAt(1);
                }
                else clonedGraph.VertexChildNodes[current].RemoveAt(0);
                current = next;
            }
            result.Add(current);
            return result;
        }

        public static EulerGraph<T> Merge(EulerGraph<T> graph1, EulerGraph<T> graph2)
        {
            var result = Clone(graph1);
            var v1 = result.Roots[0];
            var v2 = graph2.Roots[0];
            foreach (var vertex in graph2.VertexChildNodes)
            {
                result.VertexChildNodes[vertex.Key] = vertex.Value;
            }
            result.VertexChildNodes[v1].Add(v2);
            result.VertexChildNodes[v2].Add(v1);
            result.Tours[0].AddRange(graph2.Tours[0]);
            result.Tours[0].Add(v1);
            return result;
        }

        public bool BothBelong(T v1, T v2)
        {
            var result = false;
            if (Tours.Count > 0)
            {
                foreach (var tour in Tours)
                {
                    if (tour.Contains(v1) && tour.Contains(v2)) result = true;
                }
            }
            return result;
        }

        private static EulerGraph<T> Clone(EulerGraph<T> graph)
        {
            var result = new EulerGraph<T>();
            result.Roots = graph.Roots.Select(x => x).ToList();
            result.Tours = graph.Tours.Select(x => x.Select(y => y).ToList()).ToList();
            foreach(KeyValuePair<T, List<T>> entry in graph.VertexChildNodes)
            {
                result.VertexChildNodes[entry.Key] = entry.Value.Select(x => x).ToList();
            }
            return result;
        }
    }

    public class EulerNode<T>
    {
        public T Value {get;set;}
        public EulerNode<T> Parent {get;set;}
        public List<EulerNode<T>> Children {get;set;}

        public EulerNode(T value, List<EulerNode<T>> children = null, EulerNode<T> parent = null)
        {
            Value = value;
            Parent = parent;
            Children = children;
        }
    }
}