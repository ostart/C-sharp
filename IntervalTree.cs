using System.Collections.Generic;
using System.Linq;

namespace AlgorithmsDataStructures4
{
    public class IntervalTree
    {
        private List<Interval> _intervals;

        public IntervalTreeNode Root = null;

        public IntervalTree(List<Interval> intervals)
        {
            _intervals = intervals;
            Root = CreateIntervalTreeNode(_intervals, null);
        }

        public List<Interval> GetIntervals(int value)
        {
            return FindIntervals(Root, value);
        }

        private IntervalTreeNode CreateIntervalTreeNode(List<Interval> intervals, IntervalTreeNode parent)
        {
            if (intervals == null || intervals.Count == 0) return null;

            var min = intervals.Select(x => x.Bottom).Min();
            var max = intervals.Select(x => x.Top).Max();
            var avg = (min + max)/2;
            var less = new List<Interval>();
            var more = new List<Interval>();
            var correct = new List<Interval>();

            SortIntervalsList(intervals, avg, correct, less, more);
            var node = new IntervalTreeNode(correct, parent);
            node.LeftChild = CreateIntervalTreeNode(less, node);
            node.RightChild = CreateIntervalTreeNode(more, node);
            return node;
        }

        private void SortIntervalsList(List<Interval> initial, int avg, List<Interval> correct, List<Interval> less, List<Interval> more)
        {
            foreach (var item in initial)
            {
                if (item.Top < avg) less.Add(item);
                else if (item.Bottom > avg) more.Add(item);
                else correct.Add(item);
            }
        }

        private List<Interval> FindIntervals(IntervalTreeNode node, int value)
        {
            if (node == null) return new List<Interval>();
            
            if (node.Intervals.Count == 0)
            {
                if (node.LeftChild != null && node.LeftChild.RightMaxValue >= value)
                    return FindIntervals(node.LeftChild, value);
                else if (node.RightChild != null && node.RightChild.LeftMinValue <= value)
                    return FindIntervals(node.RightChild, value);
                else return new List<Interval>();
            }
            var result = new List<Interval>();

            if (node.LeftMinValue <= value && node.RightMaxValue >= value)
            {
                foreach (var interval in node.Intervals)
                {
                    if (interval.Bottom <= value && interval.Top >= value)
                        result.Add(interval);
                }
            }
            
            if (node.LeftChild != null && node.LeftChild.RightMaxValue > value) 
                result.AddRange(FindIntervals(node.LeftChild, value));
            else if (node.RightChild != null && node.RightChild.LeftMinValue < value) 
                result.AddRange(FindIntervals(node.RightChild, value));
            
            return result;
        }
    }

    public class IntervalTreeNode
    {
        public List<Interval> Intervals = new List<Interval>();
        public int LeftMinValue;
        public int RightMaxValue;

        public IntervalTreeNode Parent;
        public IntervalTreeNode LeftChild;
        public IntervalTreeNode RightChild;

        public IntervalTreeNode(List<Interval> intervals, IntervalTreeNode parent)
        {
            Intervals = intervals;
            Parent = parent;
            LeftMinValue = intervals.Count == 0 ? 0 : intervals.Select(x => x.Bottom).Min();
            RightMaxValue = intervals.Count == 0 ? 0 : intervals.Select(x => x.Top).Max();
        }
    }

    public class Interval
    {
        public int Bottom { get; set; }
        public int Top { get; set; }

        public Interval(int bottom, int top)
        {
            Bottom = bottom;
            Top = top;
        }
    }
}