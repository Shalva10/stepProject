using StudentOop.StudentServices;

StudentServices studentService = new StudentServices();
bool exit = false;

var folder = "C:\\Users\\short\\OneDrive\\Documents\\StudentOop";
var file = "StudentOop.json";
var path = Path.Combine(folder, file);

if (!Directory.Exists(folder))
{
    Directory.CreateDirectory(folder);
}

if (!File.Exists(path))
{
    File.Create(path).Close();
}

while (!exit)
{
    Console.WriteLine("STUDENT OOP");
    Console.WriteLine("1. Add New Student");
    Console.WriteLine("2. View All Students");
    Console.WriteLine("3. Search Student by Roll Number");
    Console.WriteLine("4. Update Student Grade");
    Console.WriteLine("5. Exit");
    Console.Write("Choose an option: ");

    string choice = Console.ReadLine();
    Console.WriteLine();

    switch (choice)
    {
        case "1":
            studentService.AddStudent();
            break;
        case "2":
            studentService.ViewAllStudents();
            break;
        case "3":
            studentService.SearchStudentByRollNumber();
            break;
        case "4":
            studentService.UpdateStudentGrade();
            break;
        case "5":
            exit = true;
            Console.WriteLine("Exiting the program. Goodbye!");
            break;
        default:
            Console.WriteLine("Invalid option. Please try again.\n");
            break;
    }
}