using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;
namespace ExamManager
{
    public class FileDataSource : DataSource
    {
        private string path;
        private List<Student> students;
        public FileDataSource(string path)
        {
            this.path = path;
        }

        public  IEnumerable<Student> AllStudents()
        {
            if(students == null)
            {
                students = File.ReadLines(path)
                .Select(line => new Student(line.Split(","))).ToList();
            }
            return students;
        }
    }
}
