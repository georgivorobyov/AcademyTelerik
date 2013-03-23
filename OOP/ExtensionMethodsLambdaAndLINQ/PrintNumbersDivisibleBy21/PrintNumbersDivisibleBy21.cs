using System;
using System.Collections.Generic;
using System.Linq;

/*
* Write a program that prints from given array of integers all numbers that
* are divisible by 7 and 3. Use the built-in extension methods and lambda
* expressions. Rewrite the same with LINQ.
*/

namespace PrintNumbersDivisibleBy21
{
    static class PrintNumbersDivisibleBy21
    {
        public static void Print<T>(this IEnumerable<T> elements, string title)
        {
            Console.Write(title);

            foreach (T element in elements)
            {
                Console.Write(" {0}", element);
            }

            Console.WriteLine();
        }

        static void Main()
        {
            int[] integers = new int[] { 1, 3, 21, 7, 42, 10, 20 };

            integers.Where(i => i % 21 == 0).Print("Lambda:");

            (from integer in integers where integer % 21 == 0 select integer).Print("Linq:");
        }
    }
}