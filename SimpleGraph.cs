using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures2
{
  public class Vertex<T>
  {
    public bool Hit;
    public T Value;
    public Vertex(T val)
    {
      Value = val;
      Hit = false;
    }
  }
  
  public class SimpleGraph<T>
  {
    public Vertex<T> [] vertex;
    public int [,] m_adjacency;
    public int max_vertex;
	
    public SimpleGraph(int size)
    {
      max_vertex = size;
      m_adjacency = new int [size,size];
      vertex = new Vertex<T> [size];
    }
	
    public void AddVertex(T value)
    {
      // ваш код добавления новой вершины
      // с значением value
      var newVertex = new Vertex<T>(value);
      // в свободную позицию массива vertex
      for (int i = 0; i < max_vertex; i++)
      {
          if (vertex[i] == null)
          {
            vertex[i] = newVertex;
            break;
          }
      }
    }

    // здесь и далее, параметры v -- индекс вершины
    // в списке  vertex
    public void RemoveVertex(int v)
    {
      // ваш код удаления вершины со всеми её рёбрами
      vertex[v] = null;
      for (int i = 0; i < max_vertex; i++)
      {
          m_adjacency[v,i] = 0;
          m_adjacency[i,v] = 0;
      }
    }
	
    public bool IsEdge(int v1, int v2)
    {
      return m_adjacency[v1, v2] == 1;// true если есть ребро между вершинами v1 и v2
    }
	
    public void AddEdge(int v1, int v2)
    {
      // добавление ребра между вершинами v1 и v2
      m_adjacency[v1, v2] = 1;
      m_adjacency[v2, v1] = 1;
    }
	
    public void RemoveEdge(int v1, int v2)
    {
      // удаление ребра между вершинами v1 и v2
      m_adjacency[v1, v2] = 0;
      m_adjacency[v2, v1] = 0;
    }

    public List<Vertex<T>> DepthFirstSearch(int VFrom, int VTo)
    {
      // Узлы задаются позициями в списке vertex.
      if(vertex[VFrom] == null || vertex[VTo] == null || VFrom == VTo) return new List<Vertex<T>>();
      // Возвращается список узлов -- путь из VFrom в VTo.
      var stack = new Stack<Vertex<T>>();
      foreach (var item in vertex)
      {
        if(item != null)
          item.Hit = false;
      }
      BuildDFS(VFrom, VTo, stack);
      // Список пустой, если пути нету.
      var resultArray = stack.ToArray();
      Array.Reverse(resultArray);
      return new List<Vertex<T>>(resultArray);
    }

    private void BuildDFS(int currentIndex, int finishIndex, Stack<Vertex<T>> stack)
    {
      var current = vertex[currentIndex];
      current.Hit = true;
      stack.Push(current);
      int[] adjacencyIndexes = GetAdjacencyIndexes(currentIndex);
      if(Array.Exists(adjacencyIndexes, item => item == finishIndex))
      {
        stack.Push(vertex[finishIndex]);
        return;
      }
      var nextIndex = GetNotVisited(adjacencyIndexes);
      if(nextIndex == -1)
      {
        stack.Pop();
        if(stack.Count == 0) return;
        var next = stack.Pop();
        var index = Array.FindIndex(vertex, item => item == next);
        BuildDFS(index, finishIndex, stack);
      }
      else 
        BuildDFS(nextIndex, finishIndex, stack);
    }

    private int GetNotVisited(int[] adjacencyIndexes)
    {
        foreach (var index in adjacencyIndexes)
        {
            if(vertex[index].Hit == false)
              return index;
        }
        return -1;
    }

    private int[] GetAdjacencyIndexes(int currentIndex)
    {
        var result = new List<int>();
        for (int i = 0; i < max_vertex; i++)
        {
          if(IsEdge(currentIndex, i))
            result.Add(i);
        }
        return result.ToArray();
    }

    public List<Vertex<T>> BreadthFirstSearch(int VFrom, int VTo)
    {
      // узлы задаются позициями в списке vertex.
      // или пустой список, если пути нету
      if(vertex[VFrom] == null || vertex[VTo] == null || VFrom == VTo) return new List<Vertex<T>>();
      // возвращает список узлов -- путь из VFrom в VTo
      foreach (var item in vertex)
      {
        if(item != null)
          item.Hit = false;
      }
      vertex[VFrom].Hit = true;
      var stack = new Stack<int>(new[] {VFrom}); // тут храним путь
      var queue = new Queue<Stack<int>>(new[] {stack});
      Stack<int> resultStack = BuildBFS(VTo, queue);
      var resultArray = resultStack.ToArray();
      Array.Reverse(resultArray);
      var result = new List<Vertex<T>>();
      foreach (var item in resultArray)
      {
          result.Add(vertex[item]);
      }
      return result;
    }

    private Stack<int> BuildBFS(int finishIndex, Queue<Stack<int>> queue)
    {
        if(queue.Count == 0) return new Stack<int>();
        var currentStack = queue.Dequeue();
        var currentIndex = currentStack.Peek();
        int[] adjacencyIndexes = GetAdjacencyIndexes(currentIndex);
        var nextIndex = -1;
        do
        {
          nextIndex = GetNotVisited(adjacencyIndexes);
          if(nextIndex != -1)
          {
            vertex[nextIndex].Hit = true;
            var currentArray = currentStack.ToArray();
            Array.Reverse(currentArray);
            var newStack = new Stack<int>(currentArray);
            newStack.Push(nextIndex);
            if(nextIndex == finishIndex)
              return newStack;
            queue.Enqueue(newStack);
          }
        } while (nextIndex != -1);
        return BuildBFS(finishIndex, queue);
    }

    public List<Vertex<T>> WeakVertices()
    {
      // возвращает список узлов вне треугольников
      var result = new List<Vertex<T>>();
      for (int i = 0; i < max_vertex; i++)
      {
        if(vertex[i] == null) continue;
        if(IsWeakVertex(i))
          result.Add(vertex[i]);
      }
      return result;
    }

    private bool IsWeakVertex(int currentIndex)
    {
      var adjacencyIndexes = GetAdjacencyIndexes(currentIndex);
      if(adjacencyIndexes.Length < 2) return true;
      var queue = new Queue<int>(adjacencyIndexes);
      if(HasAtLeastOneRelated(queue)) return false;
      return true;
    }

    private bool HasAtLeastOneRelated(Queue<int> queue)
    {
      while(queue.Count > 1)
      {
        var current = queue.Dequeue();
        var array = queue.ToArray();
        foreach (var item in array)
        {
            if(IsEdge(current, item))
              return true;
        }
      }
      return false;
    }
  }
}