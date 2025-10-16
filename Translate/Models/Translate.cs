namespace Translate.Models
{
    public class Translate
    {
        public string Source { get; set; }

        public string Destination { get; set; }

        public string Language { get; set; }

        public override string ToString()
        {
            return $"Source:{Source};Destination:{Destination};Language: {Language}";
        }
    }
}
