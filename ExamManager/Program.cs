using ExamManager.closure;
using System;

namespace ExamManager
{
    class Program
    {
        static void Main(string[] args)
        {
            //var dbSource = new DBDataSource();
            //var proc = new DataProcessor(dbSource);

            var path = @"C:\data\Studenti.csv";
            //var UI = new UserInterface(proc);
            var  UI = new UserInterface(new DataProcessor(new FileDataSource(path)));
            UI.MainMenu();

        }
    }
}
