using System;
using System.Collections.Generic;
using System.Text;

namespace ExamManager
{
    class UserInterface
    {
        private DataProcessor processor;
        const string MENU_MESSAGE = "Inserici:\n'l' per lista studenti\n" +
            "'r' per ricerca per ID\n'v' per media\n'd' per mediana" +
            "'m' per la moda dei voti\n's' per verifiche sessiste";

        public UserInterface(DataProcessor processor)
        {
            this.processor = processor;
        }

        public void MainMenu()
        {
            Console.WriteLine(MENU_MESSAGE);
            string input = ReadAnswer();

            switch (input[0])
            {
                case 'l':
                    ShowStudents();
                    break;
                case 'r':
                    SearchStudents();
                    break;
                case 'v':
                    ShowAverage();
                    break;
                case 'd':
                    ShowMedian();
                    break;
                case 'm':
                    ShowMode();
                    break;
                case 's':
                    ShowSexistCheck();
                    break;
                case 'q':
                    return;
                default:
                    Console.WriteLine("la lettera non è valida, ritenta");
                    break;
            }
            MainMenu();
        }

        private void ShowSexistCheck()
        {
            bool maleSupremacy = processor.AreMaleSuperior();
            bool adultSupremacy = processor.AreAdultsSuperior();
            string m = maleSupremacy ? "sono" : "non sono";
            string a = adultSupremacy ? "sono" : "non sono";
            Console.WriteLine($"i maschi {m} superiori alle ragazze");
            Console.WriteLine($"gli adulti {a} superiori ai giovini");
        }

        private void ShowMode()
        {
            Console.WriteLine($"la moda è: {processor.GetMode()}");
        }

        private void ShowMedian()
        {
            Console.WriteLine($"la mediana è: {processor.GetMedian()}");
        }

        private void ShowAverage()
        {
            Console.WriteLine($"la media è: {processor.GetAvg()}");
        }

        private void SearchStudents()
        {

            int id;
            string input;
            do
            {
                input = ReadAnswer("Inserire l'ID: ");
            } while (int.TryParse(input, out id));


            Student found = processor.FindById(id);
            if (found!=null)
            {
                Console.WriteLine(found);
            }
            else
            {
                Console.WriteLine("no trovato");
            }
        }

        private void ShowStudents()
        {
            IEnumerable<Student> students = processor.AllStudents();
            foreach (var s in students)
            {
                Console.WriteLine(s);
            }
        }

        private string ReadAnswer(string prompt = "")
        {
            Console.Write(prompt);
            return Console.ReadLine().ToLower();
        }
    }
}
