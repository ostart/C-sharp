using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures5
{
    public class DynamicConnectivityGraph<T>
    {
        private readonly List<T> _vertices;
        private Dictionary<T, List<T>> _ajacencyList;

        private List<Edge<T>> _edges;

        private DSU<T> _dsuConnectivity;

        private List<Edge<T>> _bridges;

        private DSU<T> _dsu2EdgeConnectivity;


        public DynamicConnectivityGraph(List<T> vertices)
        {
            _vertices = vertices;
            _ajacencyList = new Dictionary<T, List<T>>();
            _edges = new List<Edge<T>>();
            _bridges = new List<Edge<T>>();
            _dsuConnectivity = new DSU<T>();
            _dsu2EdgeConnectivity = new DSU<T>();
            foreach (var vertex in vertices)
            {
                _ajacencyList.Add(vertex, new List<T>());
                _dsuConnectivity.MakeSet(vertex);
                _dsu2EdgeConnectivity.MakeSet(vertex);
            }
        }

        public void AddEdge(T vertex1, T vertex2)
        {
            _ajacencyList[vertex1].Add(vertex2);
            _ajacencyList[vertex2].Add(vertex1);
            var connectionNode1ToNode2 = new Edge<T>(vertex1, vertex2);
            var connectionNode2ToNode1 = new Edge<T>(vertex2, vertex1);

            if (!IsConnected(vertex1,vertex2))
            {
                _bridges.Add(connectionNode1ToNode2);
            }
            else
            {
                if (!IsSame2EdgeConnectivity(vertex1, vertex2))
                {
                    if (_bridges.Contains(connectionNode1ToNode2))
                        _bridges.Remove(connectionNode1ToNode2);
                    else if (_bridges.Contains(connectionNode2ToNode1))
                        _bridges.Remove(connectionNode2ToNode1);
                    _dsu2EdgeConnectivity.Unite(vertex1, vertex2);
                    var bridges = _bridges.ConvertAll(x => new Edge<T>(x.Vertex1, x.Vertex2));
                    foreach (var bridge in bridges)
                    {
                        if (IsConnected(bridge.Vertex1, bridge.Vertex2))
                        {
                            _bridges.Remove(bridge);
                            _dsu2EdgeConnectivity.Unite(bridge.Vertex1, bridge.Vertex2);
                        }
                    }
                }
            }
            if (!_edges.Contains(connectionNode1ToNode2) || !_edges.Contains(connectionNode2ToNode1))
            {
                _edges.Add(connectionNode1ToNode2);
                _dsuConnectivity.Unite(vertex1, vertex2);
            }
        }

        public void RemoveEdge(T vertex1, T vertex2)
        {
            _ajacencyList[vertex1].Remove(vertex2);
            _ajacencyList[vertex2].Remove(vertex1);
            var connectionNode1ToNode2 = new Edge<T>(vertex1, vertex2);
            var connectionNode2ToNode1 = new Edge<T>(vertex2, vertex1);
            if (_edges.Contains(connectionNode1ToNode2))
                _edges.Remove(connectionNode1ToNode2);
            else if (_edges.Contains(connectionNode2ToNode1))
                _edges.Remove(connectionNode2ToNode1);
            var edges = _edges.ConvertAll(x => new Edge<T>(x.Vertex1, x.Vertex2));
            _ajacencyList = new Dictionary<T, List<T>>();
            _edges = new List<Edge<T>>();
            _dsuConnectivity = new DSU<T>();
            _bridges = new List<Edge<T>>();
            _dsu2EdgeConnectivity = new DSU<T>();
            foreach (var vertex in _vertices)
            {
                _ajacencyList.Add(vertex, new List<T>());
                _dsuConnectivity.MakeSet(vertex);
                _dsu2EdgeConnectivity.MakeSet(vertex);
            }
            foreach (var edge in edges)
            {
                AddEdge(edge.Vertex1, edge.Vertex2);
            }
        }

        public bool IsConnected(T vertex1, T vertex2)
        {
            return _dsuConnectivity.Find(vertex1).Equals(_dsuConnectivity.Find(vertex2));
        }

        public bool IsSame2EdgeConnectivity(T vertex1, T vertex2)
        {
            return _dsu2EdgeConnectivity.Find(vertex1).Equals(_dsu2EdgeConnectivity.Find(vertex2));
        }

        public List<Edge<T>> GetBridges()
        {
            return _bridges;
        }
    }

    public class Edge<T>: IEquatable<Edge<T>>
    {
        public T Vertex1 {get;set;}
        public T Vertex2 {get;set;}

        public Edge(T vertex1, T vertex2)
        {
            Vertex1 = vertex1;
            Vertex2 = vertex2;
        }

        public bool Equals(Edge<T> other)
        {
            return Vertex1.Equals(other.Vertex1) && Vertex2.Equals(other.Vertex2);
        }
    }

    public class DSU<T>
    {
        private readonly Dictionary<T, T> _parent;
        // Ранг дерева >= высоты дерева
        private readonly Dictionary<T, int> _rank;
        private readonly Random _rand;

        public DSU()
        {
            _parent = new Dictionary<T, T>();
            _rank = new Dictionary<T, int>();
            _rand = new Random();
        }

        public void MakeSet(T node)
        {
            _parent.Add(node, node);
            _rank.Add(node, 0);
        }

        public T Find(T value)
        {
            if (_parent[value].Equals(value))
            {
                return value;
            }

            var topParent = SearchTopParent(value);

            ChangeTreeParent(value, topParent);

            return topParent;
        }

        public void Unite(T first, T second, bool isRandom = true)
        {
            first = Find(first);
            second = Find(second);

            if (first.Equals(second)) return;

            if (isRandom)
            {
                if (_rand.Next() % 2 == 0)
                    _parent[first] = second;
                else
                    _parent[second] = first;
            }
            else
            {
                if (_rank[first] < _rank[second])
                    _parent[first] = second;
                else
                {
                    _parent[second] = first;
                    if (_rank[first] == _rank[second])
                        ++_rank[first];
                }
            }
        }

        private T SearchTopParent(T startIndex)
        {
            var topParent = _parent[startIndex];

            while (!_parent[topParent].Equals(topParent))
            {
                topParent = _parent[topParent];
            }

            return topParent;
        }

        private void ChangeTreeParent(T index, T maxParent)
        {
            while (!_parent[index].Equals(maxParent))
            {
                var nextIndex = _parent[index];
                _parent[index] = maxParent;
                index = nextIndex;
            }
        }
    }
}