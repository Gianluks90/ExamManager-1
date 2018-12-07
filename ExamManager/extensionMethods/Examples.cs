using System;
using MyLinQ;
using System.Collections.Generic;
using System.Text;

namespace ExamManager.extensionMethods
{
    class Examples
    {
        public void StringExample()
        {
            string s = "Ciccio";
            Console.WriteLine(s);
            var sr = StringExtensions.Reverse(s);
            sr = s.Reverse();
            Console.WriteLine(sr);
        }
    }
}
