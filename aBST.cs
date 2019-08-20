using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures2
{
  public class aBST
  {
    public int? [] Tree; // массив ключей
	
    public aBST(int depth)
    {
      // правильно рассчитайте размер массива для дерева глубины depth:
      var tree_size = 0;
      for (var i = 0; i <= depth; i++) tree_size += (int)Math.Pow(2, i);
      Tree = new int?[tree_size];
      for (var i = 0; i < tree_size; i++) Tree[i] = null;
    }
	
    public int? FindKeyIndex(int key)
    {
      // ищем в массиве индекс ключа
      return GetIndex(0, key);
    }

    private int? GetIndex(int currentIndex, int key)
    {
        if(currentIndex > Tree.Length) return null;
        var currentValue = Tree[currentIndex];
        if(currentValue == null) return -1 * currentIndex;
        if(currentValue < key)
            return GetIndex(2 * currentIndex + 2, key);
        else if (currentValue > key)
            return GetIndex(2 * currentIndex + 1, key);
        else
            return currentIndex;
    }

    public int AddKey(int key)
    {
      // добавляем ключ в массив
      var index = FindKeyIndex(key);
      if(index == null || index > 0) return -1;
      if(index == 0) 
      {
          var currentValue = Tree[0];
          if(currentValue != null) return -1;
      }
      // индекс добавленного/существующего ключа или -1 если не удалось
      var resultIndex = (int) (-1 * index);
      Tree[resultIndex] = key;
      return resultIndex;
    }	
  }
}