using StudentOop.Students;
using System.Text.Json;

namespace StudentOop.StudentServices
{
    public class StudentServices
    {
        private List<Students.Students> students;
        private readonly string filePath;

        public StudentServices(string path)
        {
            filePath = path;
            students = LoadFromFile();
        }

        public void AddStudent()
        {
            Console.Write("Enter Student Name: ");
            string name = Console.ReadLine();
            Console.Write("Enter Student Lastname: ");
            string lastname = Console.ReadLine();

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
            SaveToFile();
            Console.WriteLine("Student added successfully.");
        }

        public void ViewAllStudents()
        {
            if (students.Count == 0)
            {
                Console.WriteLine("No students found.");
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
                        SaveToFile();
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

        private List<Students.Students> LoadFromFile()
        {
            try
            {
                string json = File.ReadAllText(filePath);
                var loadedStudents = JsonSerializer.Deserialize<List<Students.Students>>(json);

                if (loadedStudents != null)
                {
                    return loadedStudents;
                }
                else
                {
                    return new List<Students.Students>();
                }
            }
            catch
            {
                return new List<Students.Students>();
            }
        }


        private void SaveToFile()
        {
            string json = JsonSerializer.Serialize(students, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filePath, json);
        }
    }
}
