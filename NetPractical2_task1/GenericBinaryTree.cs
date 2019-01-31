using System;
using System.Collections;
using System.Collections.Generic;


namespace NetPractical2_task1
{
    public class BinaryTree<T> : IEnumerable<T>
    {
        private BinaryTreeNode<T> _root;
        
        public event BinaryTreeChange NodeAddedEvent;
        public readonly IComparer<T> _customComparer;

        protected BinaryTree()
        {
            _root = null;
            Count = 0;
            _customComparer = null;
        }
        protected BinaryTree(IComparer<T> comparer)
        {
            _root = null;
            Count = 0;
            _customComparer = comparer;
        }

        public BinaryTree(T value):this()
        {
            Add(value);
        }
        
        public BinaryTree(T[] value):this()
        {            
            AddMultiple(value);
        }
        public BinaryTree(T value, IComparer<T> comparer) : this(comparer)
        {
            Add(value);
        }
        public BinaryTree(T[] value, IComparer<T> comparer):this(comparer)
        {            
            AddMultiple(value);
        }
        

        public int Count
        {
            get;
            private set;
        }
        public void AddMultiple(T[] value)
        {
            foreach (var node in value)
            {
                Add(node);
            }
        }
        public void Add(T value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("Cant add null to tree");
            }
            if (_root == null)
            {
                _root = new BinaryTreeNode<T>(value);
            }
            else
            {
                Insert(_root, value);
            }
            Count++;
            EventAddCore(value);
        }
       
        public void EventAddCore(object value)
        {
            if (NodeAddedEvent != null)
            {
                NodeAddedEvent.Invoke(this, new BinaryTreeEventArgs { Value = value});
            }
        }

        public void Insert(BinaryTreeNode<T> node, T value)
        {
            if (node.Compare(value, _customComparer) < 0)
            {
                if (node.Left == null)
                {
                    node.Left = new BinaryTreeNode<T>(value);
                }
                else
                {
                    Insert(node.Left, value);
                }
            }
            else
            {
                if(node.Right == null)
                {
                    node.Right = new BinaryTreeNode<T>(value);
                } else
                {
                    Insert(node.Right, value);
                }
            }
        }

        public void Reset()
        {
            _root = null;
            Count = 0;
        }
        protected IEnumerator<T> YieldInOrder()
        {
            if(_root != null)
            {
                Stack stack = new Stack();

                BinaryTreeNode<T> current = _root;
                bool moveLeft = true;

                stack.Push(current);

                while (stack.Count > 0)
                {
                    if (moveLeft == true)
                    {
                        while(current.Left != null)
                        {
                            stack.Push(current);
                            current = current.Left;
                        }
                    }
                    yield return current.Value;

                    if(current.Right != null)
                    {
                        current = current.Right;
                        moveLeft = true;
                    }
                    else
                    {
                        current = (BinaryTreeNode<T>)stack.Pop();
                        moveLeft = false;
                    }
                }
            }
        }

        public IEnumerable<T> Reverse
        {
            get
            {
                if (_root != null)
                {
                    Stack stack = new Stack();

                    BinaryTreeNode<T> current = _root;
                    bool moveRight = true;

                    stack.Push(current);

                    while (stack.Count > 0)
                    {
                        if (moveRight == true)
                        {
                            while (current.Right != null)
                            {
                                stack.Push(current);
                                current = current.Right;
                            }
                        }
                        yield return current.Value;

                        if (current.Left != null)
                        {
                            current = current.Left;
                            moveRight = true;
                        }
                        else
                        {
                            current = (BinaryTreeNode<T>)stack.Pop();
                            moveRight = false;
                        }
                    }
                }
            }
        }
        public IEnumerator<T> GetEnumerator()
        {
            return this.YieldInOrder();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.YieldInOrder();
        }
    }    
}
