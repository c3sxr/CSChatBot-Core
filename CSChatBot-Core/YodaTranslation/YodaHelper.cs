using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using YodaTranslation.Models;

namespace YodaTranslation
{
    public class YodaHelper
    {
        public async Task<YodaTranslationClient> GetTranslation(string originalText)
        {
            YodaTranslationClient yodaTranslationClient;

            try
            {

                using (var httpClient = new HttpClient())
                {
                    using (var response = await httpClient.GetAsync("https://api.funtranslations.com/translate/yoda.json?text=" + originalText))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        yodaTranslationClient = JsonConvert.DeserializeObject<YodaTranslationClient>(apiResponse);
                    }

                }
            }
            catch (Exception)
            {
                //Return an empy yoda tranlation client
                yodaTranslationClient = new YodaTranslationClient();
            }

            return yodaTranslationClient;
        }
    }
}
