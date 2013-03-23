using System;
using System.Text;

namespace StringBuilderSubString
{
    public static class StringBuilderSubString
    {
        public static StringBuilder SubString(this StringBuilder input,
            int startIndex, int length)
        {
            return new StringBuilder(input.ToString(startIndex, length));
        }

        public static StringBuilder SubString(this StringBuilder input,
            int startIndex)
        {
            return input.SubString(startIndex, input.Length - startIndex);
        }
    }
}
