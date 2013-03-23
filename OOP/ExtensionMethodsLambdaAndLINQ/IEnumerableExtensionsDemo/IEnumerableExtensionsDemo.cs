using System;
using IEnumerableExtensions;

/*
 * Implement a set of extension methods for IEnumerable<T> that implement the
 * following group functions: sum, product, min, max, average.
 */

namespace IEnumerableExtensionsDemo
{
    class IEnumerableExtensionsDemo
    {
        static void Main()
        {
            var ints = new int[] { 1, 2, 3, 4, 5 };
            var strs = new string[] { "a", "b", "c" };
            
            Console.WriteLine("Average: {0}", ints.Average<int>());
            Console.WriteLine("Product: {0}", ints.Product<int>());
            Console.WriteLine("Sum: {0}", ints.Sum<int>());
            Console.WriteLine("Min: {0}", strs.Min<string>());
            Console.WriteLine("Max: {0}", strs.Max<string>());
        }
    }
}
