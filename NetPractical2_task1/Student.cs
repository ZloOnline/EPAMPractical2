using System;
using System.Collections.Generic;

namespace NetPractical2_task1
{
    public class StudentComparer:IComparer<Student>
    {
        public int Compare(Student first, Student other)
        {
            Student _temp = other as Student;
            if (_temp == null)
            {
                throw new NullReferenceException("Compared object is not student or null");
            }
            if (_temp.TestName != first.TestName)
            {
                throw new ArgumentException("Students should pass same tests");
            }

            if (first.Mark == _temp.Mark)
            {
                return 0;
            }
            if (first.Mark > _temp.Mark)
            {
                return -1;
            }
            else
            {
                return 1;
            }
        }
    }
    public class Student
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
                if (mark < 0 && mark > 100)
                {
                    throw new ArgumentOutOfRangeException("Invalid Mark, should be 0-100");
                }
                mark = value;
            }
        }
        

        public override string ToString()
        {
            return String.Format("{0} {1} passed test {2} with {3}", Name, Surname, TestName, Mark);
        }
    }
}
