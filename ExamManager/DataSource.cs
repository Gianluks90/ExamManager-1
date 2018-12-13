using System;
using System.Collections.Generic;
using System.Text;

namespace ExamManager
{
    public interface DataSource
    {
        IEnumerable<Student> AllStudents();
        void AddStudent(int id, string name, string surname, int age, Sex gender, int grade);
        void RemoveStudent(string name, string surname);
    }
}
