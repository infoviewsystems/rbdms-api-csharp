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
            string oauthUrl = options.oauthUri + "token?grant_type=CLIENT_CREDENTIALS&client_id=" + options.client_id + "&client_secret=" + options.client_secret;
            var clt = new RestClient(oauthUrl);
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

        public async Task<Uri> PostDataAsync<T>(Options options, List<T> dataList)
        {
            string path = "npapi/" + options.endpoint + "?countryCode=" + options.countryCode + "&dbName=" + options.dbName;
            HttpResponseMessage response = await rbdms.PostAsJsonAsync(path, dataList);
            if (response.IsSuccessStatusCode)
            {
                string result = response.Content.ReadAsStringAsync().Result;
                if (result != null)
                {
                    Console.WriteLine($"Response from Post: {JsonConvert.DeserializeObject(result)}\n");
                }
            }
            response.EnsureSuccessStatusCode();
            
            return response.Headers.Location;
        }

        public async Task<string> GetDataAsync(Options options)
        {
            string getRsp = null;
            string path = "npapi/" + options.endpoint + "?countryCode=" + options.countryCode + "&dbName=" + options.dbName;

            HttpResponseMessage response = await rbdms.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                getRsp = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Response from GET: {getRsp}\n");
            }
            return getRsp;
        }
    }
}
