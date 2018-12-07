using System;
using System.Collections.Generic;
using System.Text;

namespace ExamManager
{
    public enum Sex { m, f, c}

    public class Student
    {
      

        public Student(string[] tokens)
        {
            Id = int.Parse(tokens[0]);
            Name = tokens[1];
            Surname = tokens[2];
            Age = int.Parse(tokens[3]);
            Gender = Enum.Parse<Sex>(tokens[4]);
            Grade = int.Parse(tokens[5]);


        }

        public Student(int id, string name, string surname, int age, Sex gender, int grade)
        {
            Id = id;
            Name = name;
            Surname = surname;
            Age = age;
            Gender = gender;
            Grade = grade;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public Sex Gender { get; set; }
        public int Grade { get; set; }

        public override string ToString()
        {
            return $"ID: {Id}, Name: {Name}, Surname: {Surname}, Age: {Age}, Gender: {Gender}, Mark: {Grade}";
        }
    }
}
