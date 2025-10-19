using StudentOop.Students;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentOop.StudentServices
{
    public class StudentServices
    {

        private List<Students.Students> students = new List<Students.Students>();

        public void AddStudent()
        {
            Console.Write("Enter Student Name: ");
            string name = Console.ReadLine();

            int rollNumber;
            while (true)
            {
                Console.Write("Enter Roll Number (integer): ");
                if (int.TryParse(Console.ReadLine(), out rollNumber))
                    break;
                Console.WriteLine("Invalid roll number! Please enter a valid integer.");
            }

            char grade;
            while (true)
            {
                Console.Write("Enter Grade (A-F): ");
                if (char.TryParse(Console.ReadLine(), out grade) && "ABCDEF".Contains(char.ToUpper(grade)))
                    break;
                Console.WriteLine("Invalid grade! Please enter a valid grade between A and F.");
            }

            if (students.Any(s => s.RollNumber == rollNumber))
            {
                Console.WriteLine("A student with this roll number already exists.");
                return;
            }

            students.Add(new Students.Students(name, rollNumber, char.ToUpper(grade)));
            Console.WriteLine("Student added successfully.\n");
        }

        public void ViewAllStudents()
        {
            if (students.Count == 0)
            {
                Console.WriteLine("No students found.\n");
                return;
            }

            Console.WriteLine("Student List:");
            foreach (var student in students)
            {
                student.DisplayInfo();
            }
            Console.WriteLine();
        }

        public void SearchStudentByRollNumber()
        {
            Console.Write("Enter Roll Number to search: ");
            if (int.TryParse(Console.ReadLine(), out int rollNumber))
            {
                var student = students.FirstOrDefault(s => s.RollNumber == rollNumber);
                if (student != null)
                {
                    student.DisplayInfo();
                }
                else
                {
                    Console.WriteLine("Student not found.");
                }
            }
            else
            {
                Console.WriteLine("Invalid roll number!");
            }
            Console.WriteLine();
        }

        public void UpdateStudentGrade()
        {
            Console.Write("Enter Roll Number to update grade: ");
            if (int.TryParse(Console.ReadLine(), out int rollNumber))
            {
                var student = students.FirstOrDefault(s => s.RollNumber == rollNumber);
                if (student != null)
                {
                    Console.Write("Enter new grade (A-F): ");
                    if (char.TryParse(Console.ReadLine(), out char newGrade) && "ABCDEF".Contains(char.ToUpper(newGrade)))
                    {
                        student.Grade = char.ToUpper(newGrade);
                        Console.WriteLine("Grade updated successfully.");
                    }
                    else
                    {
                        Console.WriteLine("Invalid grade input.");
                    }
                }
                else
                {
                    Console.WriteLine("Student not found.");
                }
            }
            else
            {
                Console.WriteLine("Invalid roll number.");
            }
        }

    }
}
