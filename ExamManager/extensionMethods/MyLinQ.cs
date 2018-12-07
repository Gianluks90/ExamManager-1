using System;
using System.Collections.Generic;
using System.Text;

namespace ExamManager.extensionMethods
{
    static class MyLinQ
    {
        public static IEnumerable<T> 
            MyWhere<T>(this IEnumerable<T> source, Func<T,bool> predicate)
        {
            foreach (var x in source)
            {
                if (predicate(x))
                {
                    yield return x;
                }
            }
        }

    }
}
