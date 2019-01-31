using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetPractical_2
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                ArrayWithOffset<double> testArray = new ArrayWithOffset<double>(-3, 5);
                Random a = new Random((int)DateTime.Now.Millisecond);
                for (int i = testArray.GetStartIndex; i <= testArray.GetEndIndex; i++)
                {                    
                    testArray[i] = a.NextDouble() * 100;
                }
                foreach (var x in testArray)
                {
                    Console.WriteLine(x);
                }
            } catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadKey();
        }
    }

}
