using System;
using System.Linq;
using System.Collections.Generic;

namespace AlgorithmsDataStructures5
{
    public class DecisionTree
    {
        private Dictionary<string, List<string>> tree;

        public DecisionTree(Dictionary<string, List<string>> table)
        {
            this.tree = table;
        }

        public double CalculateEntropy(string criterion)
        {
            var data = tree[criterion];
            var values = data.Distinct();
            var result = 0.0;
            foreach (var item in values)
            {
                var proportion = data.Where(x => x == item).Count()/(double)data.Count;
                result += proportion * Math.Log2(proportion);
            }
            return -1 * result;
        }

        public double CalculateEntropy(string parentCriterion, string criterion, string criterionValue)
        {
            var parentData = tree[parentCriterion];
            var data = tree[criterion];
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

        public double CalculateGain(string parentCriterion, string criterion)
        {
            var parentEntropy = CalculateEntropy(parentCriterion);

            var data = tree[criterion];
            var values = data.Distinct();
            var result = 0.0;
            foreach (var item in values)
            {
                var proportion = data.Where(x => x == item).Count()/(double)data.Count;
                result += proportion * CalculateEntropy(parentCriterion, criterion, item);
            }
            return parentEntropy - result;
        }
    }
}