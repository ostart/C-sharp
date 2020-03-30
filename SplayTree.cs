using System.Collections.Generic;

namespace AlgorithmsDataStructures4
{
    public class SplayTree
    {
        public SplayTree()
        {
            Root = null;
        }

        public SplayTree(int[] list)
        {
            foreach (var item in list)
            {
                var current = SearchCurrent(item, Root);
                if (current == null)
                {
                    var root = new SplayTreeNode(item);
                    Root = root;
                }
                else 
                {
                    var node = new SplayTreeNode(item, current);
                    if (current.Value < item) current.RightChild = node;
                    else current.LeftChild = node;
                }
            }
        }

        public SplayTreeNode Root {get;set;}

        public SplayTreeNode Find(int x)
        {
            var node = BinarySearch(Root, x);
            if (node != null) Splay(node);
            return node;
        }

        public static SplayTree Merge(SplayTree tree1, SplayTree tree2)
        {
            //all tree1 < tree2
            SplayTreeNode max = GetMax(tree1.Root);
            tree1.Splay(max); //splay max tree1
            //make tree2 is rigth child of splayed tree1
            tree1.Root.RightChild = tree2.Root;
            tree2.Root.Parent = tree1.Root;
            return tree1;
        }

        public void Remove(int x)
        {
            var node = Find(x); //splay of x
            //merge left and right childs
            if (node != null)
            {
                node.LeftChild.Parent = null;
                node.RightChild.Parent = null;
                var resultTree = Merge(new SplayTree {Root = node.LeftChild}, new SplayTree {Root = node.RightChild});
                Root = resultTree.Root;
            }
        }

        public void Add(int x)
        {
            var splitted = Split(x);
            //add two trees as left and right childs of x root
            var newRoot = new SplayTreeNode()
            {
                Parent = null,
                Value = x,
                LeftChild = splitted[0].Root,
                RightChild = splitted[1].Root
            };
            splitted[0].Root.Parent = newRoot;
            splitted[1].Root.Parent = newRoot;
            Root = newRoot;
        }

        private SplayTreeNode SearchCurrent(int item, SplayTreeNode node)
        {
            if (node == null) return null;
            if (node.Value == item) return node;
            if (node.Value < item) {
                if (node.RightChild == null) return node;
                return SearchCurrent(item, node.RightChild);
            }
            else
            {
                if (node.LeftChild == null) return node;
                return SearchCurrent(item, node.LeftChild);
            }
        }

        private void Splay(SplayTreeNode v)
        {
            while (v.Parent != null)
            {
                if (v.Value == v.Parent.LeftChild.Value)
                {
                    if (v.Parent.Parent == null) RotateRight(v.Parent);
                    else if (v.Parent.Value == v.Parent.Parent.LeftChild.Value)
                    {
                        RotateRight(v.Parent.Parent);
                        RotateRight(v.Parent);
                    }    
                    else
                    {
                        RotateRight(v.Parent);
                        RotateLeft(v.Parent);
                    }
                }   
                else
                {
                    if (v.Parent.Parent == null) RotateLeft(v.Parent);
                    else if (v.Parent.Value == v.Parent.Parent.RightChild.Value)
                    {
                        RotateLeft(v.Parent.Parent);
                        RotateLeft(v.Parent);
                    }
                    else
                    {
                        RotateLeft(v.Parent);
                        RotateRight(v.Parent);
                    }
                } 
            }
            Root = v;
        }

        private List<SplayTree> Split(int x)
        {
            var root = SearchCurrent(x, Root); 
            if (root != null) Splay(root); //splay of x
            //возвращаем два дерева, полученные отсечением правого или левого поддерева от корня,
            // в зависимости от того, содержит корень элемент больше или не больше, чем x
            if (root.Value > x)
            {
                var tree1 = new SplayTree();
                tree1.Root = root.LeftChild;
                tree1.Root.Parent = null;
                root.LeftChild = null;
                return new List<SplayTree> { tree1, this };
            }
            else
            {
                var tree2 = new SplayTree();
                tree2.Root = root.RightChild;
                tree2.Root.Parent = null;
                root.RightChild = null;
                return new List<SplayTree> { this, tree2 };
            }
        }

        private SplayTreeNode BinarySearch(SplayTreeNode node, int x)
        {
            if (node == null || node.Value == x) return node;
            else if (node.Value < x) return BinarySearch(node.RightChild, x);
            else return BinarySearch(node.LeftChild, x);
        }

        private static SplayTreeNode GetMax(SplayTreeNode node)
        {
            if (node.RightChild == null) return node;
            return GetMax(node.RightChild);
        }

        private void RotateLeft(SplayTreeNode v)
        {
            SplayTreeNode p = v.Parent;
            SplayTreeNode r = v.RightChild;
            if (p != null)
            {
                if (p.LeftChild.Value == v.Value) p.LeftChild = r;
                else p.RightChild = r;
            }

            SplayTreeNode tmp = r.LeftChild;
            r.LeftChild = v;
            v.RightChild = tmp;
            v.Parent = r;
            r.Parent = p;
            if (v.RightChild != null) v.RightChild.Parent = v;
        }

        private void RotateRight(SplayTreeNode v)
        {
            SplayTreeNode p = v.Parent;
            SplayTreeNode l = v.LeftChild;
            if (p != null)
            {
                if (p.RightChild.Value == v.Value) p.RightChild = l;
                else p.LeftChild = l;
            }

            SplayTreeNode tmp = l.RightChild;
            l.RightChild = v;
            v.LeftChild = tmp;
            v.Parent = l;
            l.Parent = p;
            if (v.LeftChild != null) v.LeftChild.Parent = v;
        }
    }

    public class SplayTreeNode
    {
        public SplayTreeNode Parent {get;set;}
        public int Value  {get;set;}
        public SplayTreeNode LeftChild {get;set;}
        public SplayTreeNode RightChild {get;set;}

        public SplayTreeNode()
        {

        }

        public SplayTreeNode(int val, SplayTreeNode parent = null, SplayTreeNode left = null, SplayTreeNode right = null)
        {
            Value = val;
            Parent = parent;
            LeftChild = left;
            RightChild = right;
        }
    }
}