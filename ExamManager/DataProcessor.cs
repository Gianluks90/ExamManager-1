using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ExamManager
{
    class DataProcessor
    {
        private DataSource source;
        private Func<Student, bool> predicate;

        public DataProcessor(DataSource nonSonemmenoDiCheTipoSeiEnonMiInteressa)
        {
            source = nonSonemmenoDiCheTipoSeiEnonMiInteressa;
        }

        public IEnumerable<Student> AllStudents()
        {
            return source.AllStudents();
        }

        public Student FindById(int id)
        {
            return source.AllStudents().SingleOrDefault(s => s.Id == id);
        }
        private bool HasID(Student s)
        {
            return s.Id == 3;
        }
        public bool AreMaleSuperior()
        {
            //var m = source.AllStudents().Where(s => s.Gender == Sex.M)
            //    .OrderBy(s => s.Grade).First().Grade;
            //var f = source.AllStudents().Where(s => s.Gender == Sex.F)
            //    .OrderBy(s => s.Grade).Last().Grade;
            //return m > f;
            var minMaleGrade = source.AllStudents()
                .Where(s => s.Gender == Sex.m).Min(s => s.Grade);
            var maxFemaleGrade = source.AllStudents().Where(s => s.Gender == Sex.f).Max(s => s.Grade);
            return minMaleGrade > maxFemaleGrade;
        }

        public bool AreAdultsSuperior()
        {
            var modeTeenGrade = CalculateMode(source.AllStudents().Where(s => s.Age < 18));
            var modeAdultGrade = CalculateMode(source.AllStudents().Where(s => s.Age >= 18));
            return modeAdultGrade > modeTeenGrade;
        }
        public double GetMode()
        {
            return CalculateMode(source.AllStudents().ToList());
        }
        public double CalculateMode(IEnumerable<Student> inputList)
        {
            return inputList
                .GroupBy(s => s.Grade)
                .OrderByDescending(g => g.Count())
                .First()
                .Key;
        }

        public double GetMedian()
        {
            List<Student> r = source.AllStudents().OrderBy(s => s.Grade).ToList();
            double median;
            if ((r.Count & 1) == 0)
            {
                median = (r[r.Count / 2].Grade + r[r.Count / 2 - 1].Grade) / 2;
            }
            else
            {
                median = r[r.Count / 2].Grade;
            }
            return median;
        }

        public double GetAvg()
        {
            return source.AllStudents().Average(s => s.Grade);
        }


        public double MinGrade()
        {
            //return source.AllStudents()
            //    .Aggregate((s1, s2) => s1.Grade < s2.Grade ? s1 : s2).Grade; 

            //return source.AllStudents()
            //    .Select(s => s.Grade)
            //    .Aggregate((g1, g2) => g1 < g2 ? g1 : g2);

            var minGrade = int.MaxValue;
            return source.AllStudents()
                .Aggregate(minGrade, (min, s) => min < s.Grade ? min : s.Grade);
            
        }

        public double AverageWithAggregation()
        {
            var avg = 0;
            var count = source.AllStudents().Count();
            return source.AllStudents().
                Aggregate( avg, (sum, s) => sum + s.Grade, sum => sum/ count);
        }
    }
}
