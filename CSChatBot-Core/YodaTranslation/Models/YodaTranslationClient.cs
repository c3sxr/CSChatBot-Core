using Newtonsoft.Json;

namespace YodaTranslation.Models
{
    public class YodaTranslationClient
    {
        [JsonProperty("contents")]
        public Contents contents { get; set; }
    }

    public class Contents
    {
        public string translated { get; set; }
        
        public string text { get; set; }

        public string translation { get; set; }
    }
}
