using System;
using System.Net;
using ScamTroller.Models;

namespace ScamTroller.Clients
{

    public class TrollClientArgs
    {
        public string BaseUrl;

        public string GetProspectUrl;
        public string PostProspectUrl;

        public string GetDownSellUrl;
        public string PostDownSellUrl;

        public TrollClientArgs()
        {

        }

        public TrollClientArgs(string baseUrl, int affiliateId = 2)
        {
            BaseUrl = baseUrl;
            GetProspectUrl = $"{baseUrl}/?affId={affiliateId}";
            PostProspectUrl = $"{baseUrl}/ajax.php/prospect";

            GetDownSellUrl = GetProspectUrl;
            PostDownSellUrl = $"{baseUrl}/ajax.php/downsell";
        }
    }

    public class TrollClient
    {
        public HttpClient Client = new HttpClient();

        private TrollClientArgs Args;

        public TrollClient(TrollClientArgs args)
        {
            Args = args;
        }

        public string BaseUrl => Args.BaseUrl;

        public async Task<(HttpStatusCode Status, HttpContent Content)> PostProspect(Identity identity)
        {
            //Get cookie required for Post
            HttpResponseMessage response = await Client.GetAsync(Args.GetProspectUrl);


            response = await Client.PostAsync(Args.PostProspectUrl, identity.ToProspectFormUrlEncodedContent());

            return (response.StatusCode, response.Content);
        }

        public async Task<(HttpStatusCode Status, HttpContent Content)> PostDownsell(Identity identity)
        {
            //Get cookie required for Post
            HttpResponseMessage response = await Client.GetAsync(Args.GetDownSellUrl);


            response = await Client.PostAsync(Args.PostDownSellUrl, identity.ToDownsellFormUrlEncodedContent());

            return (response.StatusCode, response.Content);
        }



    }
}

