using System;
using System.Text.RegularExpressions;

namespace SortSpace
{
    public class KSort
  {
      public string[] Items;

      public KSort()
      {
          Items = new string[800];
      }

      public KSort(string[] array)
      {
          Items = new string[800];
          foreach (var item in array)
          {
              add(item);
          }
      }

      public int GetIndexAndMakeReplace(string s)
      {
          var pattern = @"^[a-h]\d{2}$";
          if(Regex.IsMatch(s, pattern, RegexOptions.IgnoreCase))
          {
              var afterReplace = ReplaceAndReturnNew(s);
              return Convert.ToInt32(afterReplace);
          }
          else
            return -1;
      }

      public bool add(string s)
      {
          var indexInItems = GetIndexAndMakeReplace(s);
          if(indexInItems == -1) 
            return false;
          Items[indexInItems] = s;
          return true;
      }

      private string ReplaceAndReturnNew(string s)
      {
          string pattern_a = @"^a";
          Regex regex_a = new Regex(pattern_a, RegexOptions.IgnoreCase);
          if(regex_a.IsMatch(s))
            return regex_a.Replace(s, "0");

          string pattern_b = @"^b";
          Regex regex_b = new Regex(pattern_b, RegexOptions.IgnoreCase);
          if(regex_b.IsMatch(s))
            return regex_b.Replace(s, "1");

          string pattern_c = @"^c";
          Regex regex_c = new Regex(pattern_c, RegexOptions.IgnoreCase);
          if(regex_c.IsMatch(s))
            return regex_c.Replace(s, "2");

          string pattern_d = @"^d";
          Regex regex_d = new Regex(pattern_d, RegexOptions.IgnoreCase);
          if(regex_d.IsMatch(s))
            return regex_d.Replace(s, "3");

          string pattern_e = @"^e";
          Regex regex_e = new Regex(pattern_e, RegexOptions.IgnoreCase);
          if(regex_e.IsMatch(s))
            return regex_e.Replace(s, "4");

          string pattern_f = @"^f";
          Regex regex_f = new Regex(pattern_f, RegexOptions.IgnoreCase);
          if(regex_f.IsMatch(s))
            return regex_f.Replace(s, "5");

          string pattern_g = @"^g";
          Regex regex_g = new Regex(pattern_g, RegexOptions.IgnoreCase);
          if(regex_g.IsMatch(s))
            return regex_g.Replace(s, "6");

          string pattern_h = @"^h";
          Regex regex_h = new Regex(pattern_h, RegexOptions.IgnoreCase);
          if(regex_h.IsMatch(s))
            return regex_h.Replace(s, "7");

          return s;
      }
  }
}