using System;
using System.Collections.Generic;
using System.Linq;

namespace YieldReturn
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("GetNumbers method - Yield");
            foreach (var num in GetNumbers())
            {
                Console.WriteLine(num);
            }

            Console.WriteLine("\nGetNumbersOrdinary method");
            foreach (var num in GetNumOrdinary().Take(5))
            {
                Console.WriteLine(num);
            }

            Console.WriteLine("\nGetNumbersYield method - Yield");
            foreach (var num in GetNumbersYield().Take(3))
            {
                Console.WriteLine(num);
            }

            Console.WriteLine("\nGetEvenNumbersYield method - Passing in the list");
            List<int> list = new List<int> { 1, 2, 3, 4, 5 };
            foreach (var num in Totals(list))
            {
                Console.WriteLine(num);
            }
            Console.Read();
        }

        private static IEnumerable<int> Totals(List<int> list)
        {
            var total = 0;
            foreach (var num in list)
            {
                total += num;
                yield return total;
            }
        }

        private static IEnumerable<int> GetNumbersYield()
        {
            var i = 0;
            while (true)
            {
                yield return ++i;
            }
        }

        private static IEnumerable<int> GetNumOrdinary()
        {
            var i = 0;
            var result = new List<int>();

            while (i < 10)
            {
                result.Add(++i);
            }
            return result;
        }

        private static IEnumerable<int> GetNumbers()
        {
            yield return 1;
            yield return 2;
            yield return 3;
        }
    }
}
