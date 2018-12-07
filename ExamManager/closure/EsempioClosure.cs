using System;
using System.Collections.Generic;
using System.Text;

namespace ExamManager.closure
{
    public class EsempioClosure
    {
        public string name = "ciccio";
                // string
        public Func<string, bool> GenerateMyFunction()
        {
     
            return s => s == name;
        }




    }
}
