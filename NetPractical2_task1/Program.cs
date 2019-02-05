using System;

namespace NetPractical2_task1
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Student _testStudent1 = new Student()
                {
                    Name = "Vasia",
                    Surname = "Shevchenko",
                    TestName = "Physics",
                    Mark = 63
                };
                Student _testStudent2 = new Student()
                {
                    Name = "Petia",
                    Surname = "Pupkin",
                    TestName = "Physics",
                    Mark = 82
                };
                Student _testStudent3 = new Student()
                {
                    Name = "Dima",
                    Surname = "Drenaz",
                    TestName = "Physics",
                    Mark = 31
                };
                Student _testStudent4 = new Student()
                {
                    Name = "Maria",
                    Surname = "Antonova",
                    TestName = "Physics",
                    Mark = 72
                };
                Student _testStudent5 = new Student()
                {
                    Name = "Vasia",
                    Surname = "Shevchenko",
                    TestName = "Physics",
                    Mark = 21
                };
                BinaryTree<Student> testTree = new BinaryTree<Student>(_testStudent1);
                testTree.NodeAddedEvent += EventHandler.PrintNodeAdded;                
                testTree.Add(_testStudent2);
                testTree.Add(_testStudent3);
                testTree.Add(_testStudent4);
                testTree.Add(_testStudent5);
                testTree.Add(_testStudent2);
                Console.WriteLine("Element Count: {0}", testTree.Count);
                foreach (var student in testTree)
                {
                    Console.WriteLine("Student\n Name:{0}; Surname:{1}; Test:{2}; Mark:{3}", student.Name, student.Surname, student.TestName, student.Mark);
                }
                Console.WriteLine("Reverse order");
                foreach (var student in testTree.Reverse)
                {
                    Console.WriteLine("Student\n Name:{0}; Surname:{1}; Test:{2}; Mark:{3}", student.Name, student.Surname, student.TestName, student.Mark);
                }
                
            } 
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadKey();
        }
    }
}
