using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentOop.Students
{
    public class Students
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public int RollNumber { get; set; }
        public char Grade { get; set; }

        public Students(string name, int rollNumber, char grade)
        {
            Name = name;
            RollNumber = rollNumber;
            Grade = grade;
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"Name: {Name}, Roll Number: {RollNumber}, Grade: {Grade}");
        }
    }
}
