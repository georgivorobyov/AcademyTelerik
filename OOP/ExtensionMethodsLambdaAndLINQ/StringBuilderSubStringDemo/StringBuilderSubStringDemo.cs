using System;
using System.Text;
using StringBuilderSubString;

/*
 * Implement an extension method Substring(int index, int length) for the class
 * StringBuilder that returns new StringBuilder and has the same functionality
 * as Substring in the class String.
 */

namespace StringBuilderSubStringDemo
{
    class StringBuilderSubStringDemo
    {
        static void Main()
        {
            StringBuilder strBuilder = new StringBuilder("Hohoho");
            StringBuilder result = strBuilder.SubString(3, 2);

            Console.WriteLine(result.ToString());
        }
    }
}
