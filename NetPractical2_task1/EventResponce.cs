using System;

namespace NetPractical2_task1
{
    static class EventResponce
    {
        public static void PrintNodeAdded(Object sender, EventArgs args)
        {
            BinaryTreeEventArgs _temp = args as BinaryTreeEventArgs;
            if(_temp == null)
            {
                throw new ArgumentNullException("Cannot convert args to BinaryTreeArgs");
            }
            Console.WriteLine((_temp.Value).ToString());
            Console.WriteLine("Sucessfuly added. Congratulations!");
        }
    }
}