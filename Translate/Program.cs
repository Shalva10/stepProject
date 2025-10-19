using Translate.Models;
using Translate.Services;


var folder = "C:\\Users\\short\\OneDrive\\Documents\\TranslateFolder";
var file = "Translate.json";
var path = Path.Combine(folder, file);

TranslateService trServices = new TranslateService("path");

if (!Directory.Exists(folder))
{
    Directory.CreateDirectory(folder);
}

if (!File.Exists(path))
{
    File.Create(path).Close();
}

while (true)
{
    Console.WriteLine("Choose language : En-Ge ; Ge-En ; En-Ru; Ru-En; Ge-Ru; Ru-Ge");
    var res = Console.ReadLine();

    Console.WriteLine("Enter a word to translate:");
    var sityva = Console.ReadLine();

    var translated = trServices.GetTranslate(res, sityva);

    if (translated != null)
    {
        Console.WriteLine("Translation: " + translated);
    }
    else
    {
        Console.WriteLine("The word does not exist. Please enter the translation if you want to add it, or press Enter to skip.");
        var userSuggestion = Console.ReadLine();

        if (!string.IsNullOrWhiteSpace(userSuggestion))
        {
            trServices.AddTranslate(new Translate.Models.Translate
            {
                Destination = userSuggestion,
                Language = res,
                Source = sityva,
            });
        }
    }

    Console.WriteLine("Do you want to continue? (y/n): ");
    string continueAnswer = Console.ReadLine();

    if (continueAnswer.ToLower() != "y")
        break;
}
