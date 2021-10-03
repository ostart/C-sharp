using System;
using System.Linq;
using System.Collections.Generic;

namespace AlgorithmsDataStructures5
{
    public class DecisionTree
    {
        private Dictionary<string, List<string>> _choiceTable;

        private DecisionTreeNode _root;

        private List<string> _nonCountedCriterions;

        public DecisionTree()
        {
            _choiceTable = new Dictionary<string, List<string>>();
        }

        public DecisionTree(Dictionary<string, List<string>> choiceTable, string criterion)
        {
            _choiceTable = choiceTable;
            _root = MakeDecisionTreeAndGetRoot(criterion);
            _nonCountedCriterions = choiceTable.Keys.ToList();
        }

        public double CalculateEntropy(Dictionary<string, List<string>> choiceTable, string criterion)
        {
            var data = choiceTable[criterion];
            var values = data.Distinct();
            var result = 0.0;
            foreach (var item in values)
            {
                var proportion = data.Where(x => x == item).Count()/(double)data.Count;
                result += proportion * Math.Log2(proportion);
            }
            return -1 * result;
        }

        public double CalculateEntropy(Dictionary<string, List<string>> choiceTable, string parentCriterion, string criterion, string criterionValue)
        {
            var parentData = choiceTable[parentCriterion];
            var data = choiceTable[criterion];
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

        public double CalculateGain(Dictionary<string, List<string>> choiceTable, string parentCriterion, string criterion)
        {
            var parentEntropy = CalculateEntropy(choiceTable, parentCriterion);

            var choiceTableValue = choiceTable[criterion];
            var values = choiceTableValue.Distinct();
            var result = 0.0;
            foreach (var item in values)
            {
                var proportion = choiceTableValue.Where(x => x == item).Count()/(double)choiceTableValue.Count;
                result += proportion * CalculateEntropy(choiceTable, parentCriterion, criterion, item);
            }
            return parentEntropy - result;
        }

        public DecisionTreeNode MakeDecisionTreeAndGetRoot(string criterion = null)
        {
            if (criterion == null) return _root;
            if (_root != null && _root.Criterion == criterion) return _root;

            var root = new DecisionTreeNode(criterion);
            _nonCountedCriterions = _choiceTable.Keys.Where(x => x != criterion).ToList();
            var leafs = FormLeafs(criterion, _choiceTable[criterion]);
            FormChilds(_choiceTable, root, criterion, leafs);
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

        private void FormChilds(Dictionary<string, List<string>> choiceTable, DecisionTreeNode currentNode, string initialCriterion, Dictionary<string, DecisionTreeNode> leafs)
        {
            string maxGainCriterion = GetMaxGainCriterion(choiceTable, initialCriterion, _nonCountedCriterions);
            _nonCountedCriterions.Remove(maxGainCriterion);
            var values = choiceTable[maxGainCriterion].Distinct();
            foreach (var value in values)
            {
                var newChild = new DecisionTreeNode(maxGainCriterion, value);
                if (currentNode.Childs == null) currentNode.Childs = new List<DecisionTreeNode>();
                currentNode.Childs.Add(newChild);
                var filteredTable = FilterTable(choiceTable, maxGainCriterion, value);
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

        private Dictionary<string, List<string>> FilterTable(Dictionary<string, List<string>> choiceTable, string maxGainCriterion, string value)
        {
            var result = new Dictionary<string, List<string>>();
            var criterions = choiceTable.Keys.ToList();
            for (int i = 0; i < choiceTable[maxGainCriterion].Count; i++)
            {
                if (choiceTable[maxGainCriterion][i] == value)
                {
                    foreach (var criterion in criterions)
                    {
                        if (!result.ContainsKey(criterion)) result.Add(criterion, new List<string>());
                        if (result[criterion] == null) result[criterion] = new List<string>();
                        result[criterion].Add(choiceTable[criterion][i]);
                    }
                }
            }
            return result;
        }

        private string GetMaxGainCriterion(Dictionary<string, List<string>> choiceTable, string parentCriterion, List<string> otherCriterions)
        {
            if (otherCriterions.Count == 1) return otherCriterions[0];
            var maxGainCriterion = 0.0;
            string result = null;
            foreach (var criterion in otherCriterions)
            {
                var currentValueOfGain = CalculateGain(choiceTable, parentCriterion, criterion);
                if (currentValueOfGain > maxGainCriterion)
                {
                    maxGainCriterion = currentValueOfGain;
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