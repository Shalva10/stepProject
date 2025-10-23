namespace Translate.Models
{
    public class Translate
    {
        public string Source { get; set; }

        public string Translation { get; set; }

        public string Language { get; set; }

        public override string ToString()
        {
            return $"Source:{Source}; Translation:{Translation}; Language: {Language}";
        }
    }
}
