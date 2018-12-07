using System;
using System.Collections.Generic;
using System.Text;

namespace MyLinQ
{ 
    static class StringExtensions
    {
        public static string Reverse(this string input)
        {
            var sb = new StringBuilder(input);
            for(int i=input.Length - 1;i >= 0;i--)
            {
                sb.Append(input[i]);
            }
            return sb.ToString();
        }
    }
}
