using System;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Collections.Generic;
using Newtonsoft.Json;
using RestSharp;

namespace RbDmsRestAPI
{
    public class Dms
    {
        static HttpClient rbdms = new HttpClient();
        public Token GetToken(Options options)
        {
            var clt = new RestClient(options.oauthUrl);
            var request = new RestRequest(Method.POST);
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("content-type", "application/x-www-form-urlencoded");

            IRestResponse rsp = clt.Execute(request);
            string content = rsp.Content;
            Token tkn = JsonConvert.DeserializeObject<Token>(content);
            
            //Set default values
            rbdms.BaseAddress = new Uri(options.uri);
            rbdms.DefaultRequestHeaders.Accept.Clear();
            rbdms.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            rbdms.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tkn.access_token);

            return tkn;
        }

        public async Task<Uri> CreateInventoryAsync(List<Inventory> inventory, Options options)
        {
            HttpResponseMessage response = await rbdms.PostAsJsonAsync(options.apiPath, inventory);
            if (response.IsSuccessStatusCode)
            {
                string result = response.Content.ReadAsStringAsync().Result;
                if (result != null)
                {
                    Console.WriteLine($"Response from Post: {JsonConvert.DeserializeObject(result)}");
                }
            }
            response.EnsureSuccessStatusCode();
            
            return response.Headers.Location;
        }

        public async Task<string> GetInventoryAsync(string path)
        {
            string getRsp = null;

            HttpResponseMessage response = await rbdms.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                getRsp = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Response from GET: {getRsp}");
            }
            return getRsp;
        }
    }
}
