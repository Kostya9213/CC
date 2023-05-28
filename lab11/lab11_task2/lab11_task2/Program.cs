using System;
using System.Collections.Generic;

namespace StudentApp
{
    class Program
    {
        static void Main()
        {
            List<Student> students = new List<Student>
            {
                new Student("John", "Doe", 20),
                new Student("Alice", "Smith", 18),
                new Student("Andrew", "Johnson", 22),
                new Student("Emily", "Anderson", 19),
                new Student("Alex", "Thompson", 21),
                new Student("Jessica", "Brown", 17),
                new Student("Michael", "Davis", 23),
                new Student("Olivia", "Miller", 20),
                new Student("Daniel", "Wilson", 25),
                new Student("Sophia", "Taylor", 24)
            };

            List<Student> adults = students.FindStudents(Student.IsAdult);
            Console.WriteLine("Adult students:");
            PrintStudents(adults);

            List<Student> startsWithA = students.FindStudents(Student.StartsWithA);
            Console.WriteLine("\nStudents with first name starting with 'A':");
            PrintStudents(startsWithA);

            List<Student> lastNameLengthGreaterThan3 = students.FindStudents(Student.LastNameLengthGreaterThan3);
            Console.WriteLine("\nStudents with last name length greater than 3:");
            PrintStudents(lastNameLengthGreaterThan3);

            List<Student> ageBetween20And25 = students.FindStudents(delegate (Student s) { return s.Age >= 20 && s.Age <= 25; });
            Console.WriteLine("\nStudents with age between 20 and 25 (using anonymous method):");
            PrintStudents(ageBetween20And25);

            List<Student> firstNameAndrew = students.FindStudents(s => s.FirstName == "Andrew");
            Console.WriteLine("\nStudents with first name 'Andrew' (using lambda expression):");
            PrintStudents(firstNameAndrew);

            List<Student> lastNameTroelsen = students.FindStudents(s => s.LastName == "Troelsen");
            Console.WriteLine("\nStudents with last name 'Troelsen' (using lambda expression):");
            PrintStudents(lastNameTroelsen);
        }

        static void PrintStudents(List<Student> students)
        {
            foreach (var student in students)
            {
                Console.WriteLine($"Name: {student.FirstName} {student.LastName}, Age: {student.Age}");
            }
        }
    }

    static class Extension
    {
        public static List<Student> FindStudents(this List<Student> students, StudentPredicateDelegate predicate)
        {
            List<Student> result = new List<Student>();
            foreach (var student in students)
            {
                if (predicate(student))
                {
                    result.Add(student);
                }
            }
            return result;
        }
    }

    class Student
    {
        public string FirstName { get; }
        public string LastName { get; }
        public int Age { get; }

        public Student(string firstName, string lastName, int age)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
        }

        public static bool IsAdult(Student student)
        {
            return student.Age >= 18;
        }

        public static bool StartsWithA(Student student)
        {
            return student.FirstName.StartsWith("A", StringComparison.OrdinalIgnoreCase);
        }

        public static bool LastNameLengthGreaterThan3(Student student)
        {
            return student.LastName.Length > 3;
        }
    }

    delegate bool StudentPredicateDelegate(Student student);
}
