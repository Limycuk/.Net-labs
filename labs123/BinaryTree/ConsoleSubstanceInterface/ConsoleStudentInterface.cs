using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
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
                while (true)
                {
                    Console.WriteLine("Enter 'show' for show all students");
                    Console.WriteLine("Enter 'filter' for set filter of students");
                    Console.WriteLine("Enter 'sort' for set sort of students");
                    Console.WriteLine("Enter 'exit' for exit from show menu");

                    string command = Console.ReadLine();
                    Console.Clear();
                    switch (command)
                    {
                        case "show":
                            showStudents();
                            break;
                        case "filter":
                            changeFilter();
                            break;
                        case "sort":
                            changeSort();
                            break;
                        case "exit":
                            return;
                    }
                    Console.Clear();
                }
            }

            void saveStudents() {
                Provider.Save(FilePath);
                Console.WriteLine("Students successful saved to {0}", FilePath);
                Console.WriteLine("\nPress any key to continue");
                Console.ReadKey();
            }

            void loadStudents()
            {
                Provider.Load(FilePath);
                Console.WriteLine("Students successful loaded from {0}", FilePath);
                Console.WriteLine("\nPress any key to continue");
                Console.ReadKey();
            }

            void showStudents()
            {
                IEnumerable<Student> students = Provider.Show();
                foreach (Student student in students)
                {
                    Console.WriteLine("{0} {1} {2} {3}", student.FirstName, student.LastName, student.TestName, student.Mark);
                }
                Console.WriteLine("\nPress any key to continue");
                Console.ReadKey();
            }

            void changeFilter()
            {
                string sign;
                int value;
                while (true)
                {
                    Console.WriteLine("Enter '-1' for sign <");
                    Console.WriteLine("Enter '0' for sign ==");
                    Console.WriteLine("Enter '1' for sign >");
                    Console.WriteLine("Enter 'exit' for exit from sort menu");

                    sign = Console.ReadLine();
                    if (sign == "-1" || sign == "0" || sign == "1")
                    {
                        break;
                    }
                    else if (sign == "exit")
                    {
                        return;
                    }
                    Console.Clear();
                }

                while (true)
                {
                    Console.Clear();
                    Console.WriteLine("Enter int value for mark");
                    Console.WriteLine("Enter 'exit' for exit from sort menu");
                    string command = Console.ReadLine();
                    if (int.TryParse(command, out value))
                    {
                        break;
                    }
                    else if (command == "exit")
                    {
                        return;
                    }
                }

                switch (sign)
                {
                    case "-1":
                        Provider.Filters.Add(student => student.Mark < value);
                        break;
                    case "0":
                        Provider.Filters.Add(student => student.Mark == value);
                        break;
                    case "1":
                        Provider.Filters.Add(student => student.Mark > value);
                        break;
                }
            }
        }
        void changeSort()
        {
            while (true)
            {
                Console.WriteLine("Enter 'first asc' for ASC sort by First Name");
                Console.WriteLine("Enter 'first desc' for DESC sort by First Name");
                Console.WriteLine("Enter 'mark asc' for ASC sort by Mark");
                Console.WriteLine("Enter 'mark desc' for DESC sort by Mark");
                Console.WriteLine("Enter 'exit' for exit from sort menu");

                string command = Console.ReadLine();
                switch (command)
                {
                    case "first asc":
                        Provider.SortField = "FirstName";
                        Provider.SortType = "ASC";
                        break;
                    case "first desc":
                        Provider.SortField = "FirstName";
                        Provider.SortType = "DESC";
                        break;
                    case "mark asc":
                        Provider.SortField = "Mark";
                        Provider.SortType = "ASC";
                        break;
                    case "mark desc":
                        Provider.SortField = "Mark";
                        Provider.SortType = "DESC";
                        break;
                    case "exit":
                        return;
                }
                Console.Clear();
            }
        }

    }
}
