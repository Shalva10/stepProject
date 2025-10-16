string[] words = { "apple", "banana", "computer", "program", "keyboard", "pneumonoultramicroscopicsilicovolcanoconiosis" };

Random rand = new Random();
int wordIndex = rand.Next(0, words.Length);
string selectedWord = words[wordIndex];

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

    Console.WriteLine("Attempts left: " + attemptsLeft);
    Console.Write("Enter a letter: ");
    string input = Console.ReadLine();

    if (input == null || input.Length != 1)
    {
        Console.WriteLine("Please enter one letter.");
        continue;
    }

    char guess = input[0];

    bool alreadyGuessed = false;
    for (int i = 0; i < guessedLetters.Count; i++)
    {
        if (guessedLetters[i] == guess)
        {
            alreadyGuessed = true;
            break;
        }
    }

    if (alreadyGuessed)
    {
        Console.WriteLine("You already guessed that letter.");
        continue;
    }

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