using System;
using System.Linq;
using System.Collections.Generic;

namespace AlgorithmsDataStructures5
{
    public class DecisionTree
    {
        private Dictionary<string, List<string>> _table;

        private DecisionTreeNode _root;

        private List<string> _nonCountedCriterions;

        public DecisionTree()
        {
            _table = new Dictionary<string, List<string>>();
        }

        public DecisionTree(Dictionary<string, List<string>> table, string criterion)
        {
            _table = table;
            _root = MakeDecisionTreeAndGetRoot(criterion);
            _nonCountedCriterions = table.Keys.ToList();
        }

        public double CalculateEntropy(Dictionary<string, List<string>> table, string criterion)
        {
            var data = table[criterion];
            var values = data.Distinct();
            var result = 0.0;
            foreach (var item in values)
            {
                var proportion = data.Where(x => x == item).Count()/(double)data.Count;
                result += proportion * Math.Log2(proportion);
            }
            return -1 * result;
        }

        public double CalculateEntropy(Dictionary<string, List<string>> table, string parentCriterion, string criterion, string criterionValue)
        {
            var parentData = table[parentCriterion];
            var data = table[criterion];
            var resultData = new List<string>();
            for (int i = 0; i < data.Count; i += 1)
            {
                if (data[i] == criterionValue) resultData.Add(parentData[i]);
            }

            var values = resultData.Distinct();
            if (values.Count() == 1) return 0;
            var result = 0.0;
            foreach (var item in values)
            {
                var proportion = resultData.Where(x => x == item).Count()/(double)resultData.Count;
                result += proportion * Math.Log2(proportion);
            }

            return -1 * result;
        }

        public double CalculateGain(Dictionary<string, List<string>> table, string parentCriterion, string criterion)
        {
            var parentEntropy = CalculateEntropy(table, parentCriterion);

            var data = table[criterion];
            var values = data.Distinct();
            var result = 0.0;
            foreach (var item in values)
            {
                var proportion = data.Where(x => x == item).Count()/(double)data.Count;
                result += proportion * CalculateEntropy(table, parentCriterion, criterion, item);
            }
            return parentEntropy - result;
        }

        public DecisionTreeNode MakeDecisionTreeAndGetRoot(string criterion = null)
        {
            if (criterion == null) return _root;
            if (_root != null && _root.Criterion == criterion) return _root;

            var root = new DecisionTreeNode(criterion);
            _nonCountedCriterions = _table.Keys.Where(x => x != criterion).ToList();
            var leafs = FormLeafs(criterion, _table[criterion]);
            FormChilds(_table, root, criterion, leafs);
            _root = root;
            return root;
        }

        private Dictionary<string, DecisionTreeNode> FormLeafs(string criterion, List<string> lists)
        {
            var values = lists.Distinct();
            var result = new Dictionary<string, DecisionTreeNode>();
            foreach (var value in values)
            {
                result.Add(value, new DecisionTreeNode(criterion, value));
            }
            return result;
        }

        public string GetResultForCriterion(string criterion, Dictionary<string,string> findParams)
        {
            var root = MakeDecisionTreeAndGetRoot(criterion);
            return TraverseTree(root, findParams);
        }

        private void FormChilds(Dictionary<string, List<string>> table, DecisionTreeNode currentNode, string initialCriterion, Dictionary<string, DecisionTreeNode> leafs)
        {
            string maxGainCriterion = GetMaxGainCriterion(table, initialCriterion, _nonCountedCriterions);
            _nonCountedCriterions.Remove(maxGainCriterion);
            var values = table[maxGainCriterion].Distinct();
            foreach (var value in values)
            {
                var newChild = new DecisionTreeNode(maxGainCriterion, value);
                if (currentNode.Childs == null) currentNode.Childs = new List<DecisionTreeNode>();
                currentNode.Childs.Add(newChild);
                var filteredTable = FilterTable(table, maxGainCriterion, value);
                var resultValues = filteredTable[initialCriterion].Distinct().ToList();
                if (resultValues.Count == 1)
                {
                    if (newChild.Childs == null) newChild.Childs = new List<DecisionTreeNode>();
                    newChild.Childs.Add(leafs[resultValues[0]]);
                }
                else
                    FormChilds(filteredTable, newChild, initialCriterion, leafs);
            }
            
        }

        private Dictionary<string, List<string>> FilterTable(Dictionary<string, List<string>> table, string maxGainCriterion, string value)
        {
            var result = new Dictionary<string, List<string>>();
            var criterions = table.Keys.ToList();
            for (int i = 0; i < table[maxGainCriterion].Count; i++)
            {
                if (table[maxGainCriterion][i] == value)
                {
                    foreach (var criterion in criterions)
                    {
                        if (!result.ContainsKey(criterion)) result.Add(criterion, new List<string>());
                        if (result[criterion] == null) result[criterion] = new List<string>();
                        result[criterion].Add(table[criterion][i]);
                    }
                }
            }
            return result;
        }

        private string GetMaxGainCriterion(Dictionary<string, List<string>> table, string parentCriterion, List<string> otherCriterions)
        {
            if (otherCriterions.Count == 1) return otherCriterions[0];
            var max = 0.0;
            string result = null;
            foreach (var criterion in otherCriterions)
            {
                var cur = CalculateGain(table, parentCriterion, criterion);
                if (cur > max)
                {
                    max = cur;
                    result = criterion;
                }
            }
            return result;
        }

        private string TraverseTree(DecisionTreeNode node, Dictionary<string, string> findParams)
        {
            if (node.Childs == null) return node.Value;
            if (node.Childs.Count == 1) return TraverseTree(node.Childs[0], findParams);
            var criterion = node.Childs[0].Criterion;
            var value = findParams[criterion];
            var suitableNode = node.Childs.FirstOrDefault(x => x.Value == value);
            return TraverseTree(suitableNode, findParams);
        }
    }

    public class DecisionTreeNode
    {
        public string Criterion {get;set;}
        public string Value {get;set;}
        public List<DecisionTreeNode> Childs {get;set;}

        public DecisionTreeNode(string criterion, string value = null, List<DecisionTreeNode> childs = null)
        {
            Criterion = criterion;
            Value = value;
            Childs = childs;
        }
    }
}