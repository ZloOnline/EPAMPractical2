using System;
using System.Collections.Generic;

namespace NetPractical2_task1
{
    public class BinaryTreeNode<TNode>       
    {
        public TNode Value { get; private set; }
        public BinaryTreeNode<TNode> Left { get; set; }
        public BinaryTreeNode<TNode> Right { get; set; }
        public BinaryTreeNode(TNode value)
        {
            Value = value;
        }
        public int Compare(TNode other, IComparer<TNode> comparer)
        {
            if (comparer != null)
            {
                return comparer.Compare(Value, other);
            }
            var c = other as IComparable;
            if (c != null)
            {
                return c.CompareTo(Value);
            } else
            {
                throw new ArgumentException("Value is not comparable and no comparer provided");
            }
        }
    }
}
