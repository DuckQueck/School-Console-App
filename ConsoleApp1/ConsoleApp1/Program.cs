using System;
using System.IO;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            menu();
        }

        static void addStudentToList(string path)
        {
            Console.WriteLine("...----------------==(Pridėti)==----------------...");
            Console.Write("Vardas: ");
            string studentName = Console.ReadLine();
            Console.Write("Pavarde: ");
            string studentLastName = Console.ReadLine();
            string student = studentName + " " + studentLastName;
            File.AppendAllText(path, student + "\n");
            Console.WriteLine("---------------------------------------------------");

            menu();
        }

        static void readFile(string path)
        {
            Console.WriteLine("...---------------==(Studentai)==--------------...");
            Console.WriteLine(File.ReadAllText(path));
            Console.WriteLine("--------------------------------------------------");
            menu();
        }


        static void searchStudent(string path)
        {
            Console.WriteLine("...----------------==(Paieška)==----------------...");
            Console.Write("Vardas: ");
            string studentName = Console.ReadLine();
            Console.Write("Pavarde: ");
            string studentLastName = Console.ReadLine();
            bool rastas = false;
            string searchStudent = studentName + " " + studentLastName;
            String[] studens = File.ReadAllLines(path);

            foreach (var student in studens)
            {
                if (searchStudent == student)
                {
                    Console.WriteLine(" ");
                    Console.WriteLine("» " + searchStudent + " buvo rastas.");
                    rastas = true;
                }
            }
            if (!rastas)
            {
                Console.WriteLine(" ");
                Console.WriteLine("» " + searchStudent + " buvo nerastas.");
            }

            Console.WriteLine("--------------------------------------------------");
            menu();
        }

        static void clearConsole()
        {
            Console.Clear();
            menu();
        }

        static void closeConsole()
        {
            Console.WriteLine(" ");
        }

        static void clearStudentsList(string path)
        {
            File.WriteAllText(path, "");
            menu();
        }

        static void menu()
        {
            Console.WriteLine("...-------------==(Pasirinkimai)==-------------...");
            Console.WriteLine("» Studentų sarašas: 1");
            Console.WriteLine("» Pridėti stdentą: 2");
            Console.WriteLine("» Rasti studenta: 3");
            Console.WriteLine("» Išvalyti console: 4");
            Console.WriteLine("» Uždaryti console: 5");
            Console.WriteLine("» Išvalyti studentu sarasa: 6");
            Console.WriteLine("--------------------------------------------------");
            try
            {
                string path = @"C:\Users\moksleivis\Desktop\text.txt";

                Console.Write("» Įveskite pasirinkimą: ");

                int option = int.Parse(Console.ReadLine());

                if (option == 1)
                {
                    readFile(path);
                } else if (option == 2)
                {
                    addStudentToList(path);
                } else if (option == 3)
                {
                    searchStudent(path);
                } else if (option == 4)
                {
                    clearConsole();
                } else if (option == 5)
                {
                    closeConsole();
                } else if (option == 6)
                {
                    clearStudentsList(path);
                }

            }
            catch(Exception e)
            {
                Console.WriteLine("Blogas pasirinkimas.");
            }
        }
    }
}
