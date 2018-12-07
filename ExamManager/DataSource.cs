using System;
using System.Collections.Generic;
using System.Text;

namespace ExamManager
{
    public interface DataSource
    {
        IEnumerable<Student> AllStudents();
    }
}
