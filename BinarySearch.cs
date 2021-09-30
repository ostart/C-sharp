namespace SortSpace
{
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