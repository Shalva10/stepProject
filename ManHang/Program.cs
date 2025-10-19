using ManHang;
using System;
using System.Collections.Generic;
using System.Linq;

bool playAgain = true;

while (playAgain)
{
    string[] words = Words.GetWords();
    Random rand = new Random();
    string selectedWord = words[rand.Next(words.Length)].ToLower();

    char[] hiddenWord = new char[selectedWord.Length];
    for (int i = 0; i < hiddenWord.Length; i++)
    {
        hiddenWord[i] = '_';
    }

    List<char> guessedLetters = new List<char>();
    int maxAttempts = 6;
    int attemptsLeft = maxAttempts;

    Console.WriteLine("HANGMAN");

    while (attemptsLeft > 0)
    {
        Console.Write("Word: ");
        for (int i = 0; i < hiddenWord.Length; i++)
        {
            Console.Write(hiddenWord[i] + " ");
        }
        Console.WriteLine();

        Console.WriteLine("Attempts left: " + attemptsLeft);
        Console.Write("Enter your guess (one or more letters): ");
        string input = Console.ReadLine().ToLower();

        if (string.IsNullOrWhiteSpace(input) || !input.All(char.IsLetter))
        {
            Console.WriteLine("Please enter valid letter(s).");
            continue;
        }

        bool foundAny = false;

        foreach (char guess in input)
        {
            if (guessedLetters.Contains(guess))
                continue;

            guessedLetters.Add(guess);

            bool found = false;
            for (int i = 0; i < selectedWord.Length; i++)
            {
                if (selectedWord[i] == guess)
                {
                    hiddenWord[i] = guess;
                    found = true;
                }
            }

            if (found)
                foundAny = true;
        }

        if (foundAny)
        {
            Console.WriteLine("Correct!");
        }
        else
        {
            Console.WriteLine("Wrong!");
            attemptsLeft--;
        }

        bool allGuessed = true;
        for (int i = 0; i < hiddenWord.Length; i++)
        {
            if (hiddenWord[i] == '_')
            {
                allGuessed = false;
                break;
            }
        }

        if (allGuessed)
        {
            Console.WriteLine("Congratulations! You guessed the word: " + selectedWord);
            break;
        }
    }

    if (attemptsLeft == 0)
    {
        Console.WriteLine("You lost! The word was: " + selectedWord);
    }

    Console.Write("Do you want to play again? (y/n): ");
    string response = Console.ReadLine().Trim().ToLower();
    if (response != "y")
    {
        playAgain = false;
        Console.WriteLine("Thanks for playing!");
    }
}
