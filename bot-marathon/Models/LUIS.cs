using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Rest
{
    public class Intent
    {
        public string intent { get; set; }
        public double score { get; set; }
    }

    public class Entity
    {
        public string entity { get; set; }
        public string type { get; set; }
        public int startIndex { get; set; }
        public int endIndex { get; set; }
        public double score { get; set; }
    }

    public class Result
    {
        public string query { get; set; }
        public Intent topScoringIntent { get; set; }
        public List<Intent> intents { get; set; }
        public List<Entity> entities { get; set; }
    }

    public class LUIS
    {
        public async static Task<Result> GetAsync(string query)
        {
            var url = $"https://westus.api.cognitive.microsoft.com/luis/v2.0/apps/665cf406-6a1a-45b7-862d-d5a139148e58?subscription-key=f10adae4fce74d34b038231802f41a22&verbose=true&timezoneOffset=0&q={query}";

            using (var client = new HttpClient())
            {
                var json = await client.GetStringAsync(url);

                var result = Newtonsoft.Json.JsonConvert.DeserializeObject<Result>(json);

                return result;
            }
        }
    }
}