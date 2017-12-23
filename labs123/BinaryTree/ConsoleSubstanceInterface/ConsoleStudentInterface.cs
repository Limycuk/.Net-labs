using System;
using Comparer;
using Provider;
using Substance;

namespace ConsoleSubstanceInterface
{
    public class ConsoleStudentInterface
    {
        public ConsoleStudentInterface(String filePath)
        {
            StudentComparer comparer = new StudentComparer();
            FilePath = filePath;
            Provider = new SubstanceProvider<Student>(comparer);
        }

        SubstanceProvider<Student> Provider { get; set; }
        String FilePath { get; set; }

        public void StartMenu()
        {
            while (true)
            {
                Console.WriteLine("Enter 'add' for add new student");
                Console.WriteLine("Enter 'show' formove to show menu");
                Console.WriteLine("Enter 'save' for save students to {0}", FilePath);
                Console.WriteLine("Enter 'load' for load students from {0}", FilePath);
                Console.WriteLine("Enter 'change' for change path {0}", FilePath);
                Console.WriteLine("Enter 'exit' for exit from application");

                string command = Console.ReadLine();
                Console.Clear();
                switch (command)
                {
                    case "add":
                        addStudent();
                        break;
                    case "show":
                        showMenu();
                        break;
                    case "save":
                        saveStudents();
                        break;
                    case "load":
                        loadStudents();
                        break;
                    case "change":
                        changeFilePath();
                        break;
                    case "exit":
                        return;
                }
                Console.Clear();
            }

            void addStudent() {
                Student student = new Student();
                Console.WriteLine("Enter First Name: ");
                student.FirstName = Console.ReadLine();
                while (student.FirstName == String.Empty)
                {
                    Console.WriteLine("First Name required field, try again");
                    student.FirstName = Console.ReadLine();
                }

                Console.WriteLine("Enter Last Name: ");
                student.LastName = Console.ReadLine();
                while (student.LastName == String.Empty)
                {
                    Console.WriteLine("Last Name required field, try again");
                    student.LastName = Console.ReadLine();
                }

                Console.WriteLine("Enter Test Name: ");
                student.TestName = Console.ReadLine();
                while (student.TestName == String.Empty)
                {
                    Console.WriteLine("Test Name required field, try again");
                    student.TestName = Console.ReadLine();
                }

                Console.WriteLine("Enter Day Of Test (MM/DD/YY): ");
                DateTime testDay;
                while (true)
                {
                    if (DateTime.TryParse(Console.ReadLine(), out testDay))
                    {
                        student.TestDay = testDay;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Test Date required to be DateTime field, try again");
                    }
                }

                Console.WriteLine("Enter Test Mark: ");
                int mark;
                while (true)
                {
                    if (int.TryParse(Console.ReadLine(), out mark))
                    {
                        student.Mark = mark;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Mark required to be number field, try again");
                    }
                }

                Provider.Add(student);
            }

            void showMenu()
            {

            }

            void saveStudents() {

            }

            void loadStudents()
            {

            }

            void changeFilePath()
            {

            }
        }
    }
}
