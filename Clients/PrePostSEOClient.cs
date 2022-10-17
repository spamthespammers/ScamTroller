using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using ScamTroller.Models.PrePostSEO;

namespace ScamTroller.Clients
{
    public class PrePostSEOClient : IDisposable
    {
        public HttpClient HttpClient = new HttpClient();

        private readonly string BaseUrl = "https://www.prepostseo.com";

        public PrePostSEOClient()
        {

        }

        public async Task<FakeIdentity?> GetFakeIdentity()
        {
            HttpResponseMessage response = await HttpClient.PostAsync($"{BaseUrl}/frontend/fakeAddressGenerator", new FormUrlEncodedContent(new List<KeyValuePair<string, string>>{
                new KeyValuePair<string, string>("lang", "en_us")

            }));
            if(response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();

                var identities = JsonConvert.DeserializeObject<FakeIdentity[]>(json, new JsonSerializerSettings
                {
                    ContractResolver = new DefaultContractResolver
                    {
                        NamingStrategy = new CamelCaseNamingStrategy()
                    }
                });

                return identities[0];
            }
            return null;

        }

        public void Dispose()
        {
            HttpClient.Dispose();
        }
    }
}

