bool isCorrect = false;
Random random = new Random();
int randomNum = random.Next(1, 11);
int hp = 3;

Console.WriteLine("NUMBER GUESSING GAME");
Console.WriteLine("A number will be generated between 1 to 10");
Console.WriteLine("And you need to guess the correct number that will be generated");

while (!isCorrect)
{
    Console.WriteLine("Please enter your number");
    int guess = Convert.ToInt32(Console.ReadLine());

    if (guess > randomNum)
    {
        Console.WriteLine("Your guess is too high, try again");
        hp--;
    }
    else if (guess < randomNum)
    {
        Console.WriteLine("Your guess is too low, try again");
        hp--;
    }
    else
    {
        Console.WriteLine("Correct");
        isCorrect = true;
        Console.WriteLine($"You have {hp}HP");
        Console.WriteLine("Congratulations, you have won the game");
        break;
    }

    Console.WriteLine($"You have {hp}HP");

    if (hp == 0)
    {
        Console.WriteLine("GAME OVER");
        break;
    }
}
