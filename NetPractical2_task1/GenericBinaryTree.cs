using System;
using System.Collections;
using System.Collections.Generic;


namespace NetPractical2_task1
{
    public class BinaryTree<T> : IEnumerable<T>
        where T : IComparable
    {
        private BinaryTreeNode<T> _root;
        public delegate void BinaryTreeChange(object addedValue);
        private int _count;
        public event BinaryTreeChange NodeAddedEvent;

        public BinaryTree()
        {
            _root = null;
            _count = 0;
        }

        public BinaryTree(T value)
        {
            _root = new BinaryTreeNode<T>(value);
            _count = 1;
        }

        public int Count
        {
            get
            {
                return _count;
            }
        }

        public void Add(T value)
        {
            if (_root == null)
            {
                _root = new BinaryTreeNode<T>(value);
            }
            else
            {
                Insert(_root, value);
            }
            _count++;
            if (NodeAddedEvent != null)
            {
                NodeAddedEvent.Invoke(value);
            }
        }

        public void Insert(BinaryTreeNode<T> node, T value)
        {
            if (value.CompareTo(node.Value) < 0)
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
            _count = 0;
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
    public class BinaryTreeNode<TNode>:IComparable<TNode>
        where TNode:IComparable
    {
        public TNode Value { get; private set; }
        public BinaryTreeNode<TNode> Left { get; set; }
        public BinaryTreeNode<TNode> Right { get; set; }
        public BinaryTreeNode(TNode value)
        {
            Value = value;
        }
        public int CompareTo(TNode other)
        {
            return Value.CompareTo(other);
        }
        
    }
}

public class Student:IComparable
{
    public string Name;
    public string Surname;
    public string TestName;
    private int mark;

    public int Mark
    {
        get
        {
            return mark;
        }
        set
        {
            if(mark < 0 && mark >100)
            {
                throw new ArgumentOutOfRangeException("Invalid Mark, should be 0-100");
            }
            mark = value;
        }
    }

    public int CompareTo(object other)
    { 
        Student _temp = other as Student;
        if (_temp == null)
        {
            throw new NullReferenceException("Compared object is not student or null");
        }
        if (_temp.TestName != TestName)
        {
            throw new ArgumentException("Students should pass same tests");
        }

        if(mark == _temp.mark )
        {
            return 0;
        }
        if(mark < _temp.mark)
        {
            return -1;
        } else 
        {
            return 1;
        }
    }

    public override string ToString()
    {
        return String.Format("{0} {1} passed test {2} with {3}", Name, Surname, TestName, Mark);
    }
}
static class EventHandler
{
    public static void PrintNodeAdded(Object addedValue)
    {
        Console.WriteLine(addedValue.ToString());
        Console.WriteLine("Sucessfuly added. Congratulations!");
    }
}
