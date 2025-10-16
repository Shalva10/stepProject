using System;

class Program
{
    static void Main()
    {
        bool isCorrect = false;
        Random random = new Random();
        int randomNum = random.Next(1, 11);

        Console.WriteLine("NUMBER GUESSING GAME");
        Console.WriteLine("A number will be generated between 1 to 10");
        Console.WriteLine("And you need to guess the correct number that will be generated");


        while (!isCorrect)
        {

        }

        Console.ReadKey();

    }
}
