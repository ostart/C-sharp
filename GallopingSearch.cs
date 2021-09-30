using System;

namespace GallopingSearchSpace
{
    public class GallopingSearch
  {
      private int[] _sortedArray;
      private int _desiredValue;
      public GallopingSearch(int[] sortedArray, int desiredValue)
      {
          _sortedArray = sortedArray;
          _desiredValue = desiredValue;
      }

      public bool Search()
      {
          var binarySearch = new BinarySearch(_sortedArray);
          var i = 1;
          while(CalculateIndex(i) < _sortedArray.Length)
          {
            var index = CalculateIndex(i);
            if(_sortedArray[index] == _desiredValue)
                return true;
            if(_sortedArray[index] < _desiredValue)
                i += 1;
            else
                break;
          }
          if(CalculateIndex(i) >= _sortedArray.Length)
            binarySearch.Right = _sortedArray.Length - 1;
          else
            binarySearch.Right = CalculateIndex(i);

          binarySearch.Left = CalculateIndex(i - 1) + 1;

          do
          {
            binarySearch.Step(_desiredValue);
          } while (binarySearch.GetResult() == 0);
          
          return binarySearch.GetResult() == 1 ? true : false;
      }

      private int CalculateIndex(int i)
      {
          return (int)Math.Pow(2, i) - 2;
      }
  }

  public class BinarySearch
  {
      public int Left;
      public int Right;
      private int _result; //0-search; 1-found; -1-not found
      private int[] _sortedArray;

      public BinarySearch(int[] sortedArray)
      {
          Left = 0;
          Right = sortedArray.Length - 1;
          _result = 0;
          _sortedArray = sortedArray;
      }

      public void Step(int N)
      {
          if(_result == 0)
          {
              if(Right == Left)
              {
                  if(_sortedArray[Left] == N) _result = 1;
                  else _result = -1;
                  return;
              }

              var central = Left + ((Right - Left) / 2);
              if(_sortedArray[central] == N)
              {
                  Right = central;
                  Left = central;
                  _result = 1;
                  return;
              }
              if(_sortedArray[central] > N)
                  Right = central == 0 ? central : central - 1;
              if(_sortedArray[central] < N)
                  Left = (central == _sortedArray.Length - 1) ? central : central + 1;
          }
      }

      public int GetResult()
      {
          return _result;
      }
  }
}