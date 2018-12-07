using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace ExamManager
{
    public class DBDataSource : DataSource
    {
        public const string ALL_STUDENTS_QUERY =
            @"select id, name, surname, age, gender, grade 
                    from studente";

        public IEnumerable<Student> AllStudents()
        {

            var connString =
                @"Data Source=(localdb)\MSSQLLocalDB;
                Initial Catalog=scuola;Integrated Security=True;";


            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                using (SqlCommand command = new SqlCommand(ALL_STUDENTS_QUERY, conn))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    var posId = reader.GetOrdinal("id");
                    var posName= reader.GetOrdinal("name");
                    var posSurname = reader.GetOrdinal("surname");
                    var posAge = reader.GetOrdinal("age");
                    var posGender = reader.GetOrdinal("gender");
                    var posGrade = reader.GetOrdinal("grade");
                    var students = new List<Student>();
                    while (reader.Read())
                    {
                        var st = new Student(
                              reader.GetInt32(posId),
                              reader.GetString(posName),
                              reader.GetString(posSurname),
                              reader.GetInt32(posAge),
                              (Sex)Enum.Parse(typeof(Sex),reader.GetString(posGender)),
                              reader.GetInt32(posGrade)
                            );
                        students.Add(st);
                    }
                    return students;
                }
            }
            
        }
    }
}
