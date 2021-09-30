using System.Linq;
using System.Collections.Generic;

namespace AlgorithmsDataStructures5
{
    public class HuffmanCode
    {
        public static Dictionary<char, string> Make(string input)
        {
            var dictionaryCharacterCount = new Dictionary<char, int>();
            foreach(var letter in input)
            {
                if (dictionaryCharacterCount.ContainsKey(letter)) dictionaryCharacterCount[letter] += 1;
                else dictionaryCharacterCount[letter] = 1;
            }

            var initials = CreateInitials(dictionaryCharacterCount.ToList());

            var root = CreateTree(initials);

            var result = new Dictionary<char, string>();
            FormResult(root, result, "");

            return result;
        }

        private static List<HuffmanCodeNode> CreateInitials(List<KeyValuePair<char, int>> list)
        {
            var result = new List<HuffmanCodeNode>();
            foreach (var item in list)
            {
                result.Add(new HuffmanCodeNode(item.Value, item.Key));
            }
            return result.OrderBy(item => item.Priority).ToList();
        }

        private static HuffmanCodeNode CreateTree(List<HuffmanCodeNode> orderedList)
        {
            if (orderedList.Count == 1) return orderedList[0];
            var newList = orderedList.Skip(2).ToList();
            var first = orderedList[0];
            var second = orderedList[1];
            var newNode = new HuffmanCodeNode(first.Priority + second.Priority, null, first, second);
            newList.Add(newNode);
            return CreateTree(newList.OrderBy(item => item.Priority).ToList());
        }
        
        private static void FormResult(HuffmanCodeNode node, Dictionary<char, string> result, string str)
        {
            if (node == null) return;
            if (node.Value != null) result.Add((char)node.Value, str);
            if (node.LeftChild != null) FormResult(node.LeftChild, result, str + "0");
            if (node.RightChild != null) FormResult(node.RightChild, result, str + "1");
        }
    }

    internal class HuffmanCodeNode
    {
        public char? Value {get;set;}

        public int Priority {get;set;}

        public HuffmanCodeNode LeftChild {get;set;}

        public HuffmanCodeNode RightChild {get;set;}

        public HuffmanCodeNode(int priority, char? value = null, HuffmanCodeNode left = null, HuffmanCodeNode right = null)
        {
            Priority = priority;
            Value = value;
            LeftChild = left;
            RightChild = right;   
        }
    }
}