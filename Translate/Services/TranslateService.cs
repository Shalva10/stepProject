using System.Text.Json;
using System.Text.Json.Serialization;

namespace Translate.Services
{
    public class TranslateService
    {
        protected List<Models.Translate> translates;
        private readonly string url;
        public TranslateService(string url)
        {
            this.url = url;
            translates = new List<Models.Translate>();
        }

        public Models.Translate GetTranslate(string language, string text)
        {
            
            return translates.FirstOrDefault(i => i.Language == language && i.Source == text);
        }


        public List<Models.Translate> GetTranslates()
        {
            return translates;
        }

        public void AddTranslate(Models.Translate req)
        {
            var exist = translates.FirstOrDefault(i => i.Language == req.Language && i.Source == req.Source && i.Translation == req.Translation);


            if (exist != null)  
            {
                Console.WriteLine("msgavsi chanaweri ukve arsebobs");
            }
            else
            {
                translates.Add(req);
                
            }
        }
    }
}
