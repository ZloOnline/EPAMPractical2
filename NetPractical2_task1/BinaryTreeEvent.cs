using System;

namespace NetPractical2_task1
{
    public delegate void BinaryTreeChange(object sender, BinaryTreeEventArgs args);
    public class BinaryTreeEventArgs : EventArgs
    {
        public object Value;
    }
}
