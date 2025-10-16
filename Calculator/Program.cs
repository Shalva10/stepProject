Console.WriteLine("CALCULATOR");

double num1 = ReadNumber("Enter the first number: ");
double num2 = ReadNumber("Enter the second number: ");

Console.Write("Enter operation (+, -, *, /): ");
string op = Console.ReadLine();

double result = 0;
bool valid = true;

if (op == "+")
    result = num1 + num2;
else if (op == "-")
    result = num1 - num2;
else if (op == "*")
    result = num1 * num2;
else if (op == "/")
{
    if (num2 == 0)
    {
        Console.WriteLine("Error: Cannot divide by zero.");
        valid = false;
    }
    else
    {
        result = num1 / num2;
    }
}
else
{
    Console.WriteLine("Invalid operation.");
    valid = false;
}

if (valid)
    Console.WriteLine($"Result: {result}");

static double ReadNumber(string message)
{
    Console.Write(message);
    string input = Console.ReadLine();
    double number;

    if (double.TryParse(input, out number))
    {
        return number;
    }
    else
    {
        Console.WriteLine("Write a number");
        return ReadNumber(message);
    }
}
