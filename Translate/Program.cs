using Translate.Models;
using Translate.Services;

TranslateService trServices = new TranslateService("service/translators.json");

while (true)
{
    Console.WriteLine("Airchie ena. En-Ka ; Ka-En ; En-Ru; Ru-En; Ka-Ru; Ru-Ka");

    var res = Console.ReadLine();

    Console.WriteLine("SHEMOIYVANE SITYVA");
    var sityva = Console.ReadLine();

    var translated = trServices.GetTranslate(res, sityva);
    if (translated != null)
    {
        Console.WriteLine(translated);
    }
    else
    {
        Console.WriteLine("chanaweri ar arsebobs mitxari ra chavwero mnishvnelobashi, tu ar ginda press left");
        var userSugegst = Console.ReadLine();
        if (userSugegst != null)
        {
            trServices.AddTranslate(new Translate.Models.Translate
            {
                Destination = userSugegst,
                Language = res,
                Source = sityva,
            });
        }

    }

}