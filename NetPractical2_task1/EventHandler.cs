using System;

namespace NetPractical2_task1
{
    static class EventHandler
    {
        public static void PrintNodeAdded(Object sender, BinaryTreeEventArgs args)
        {            
            Console.WriteLine((args.Value).ToString());
            Console.WriteLine("Sucessfuly added. Congratulations!");
        }
    }
}