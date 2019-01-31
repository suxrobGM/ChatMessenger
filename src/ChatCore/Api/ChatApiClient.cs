using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using ChatCore.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ChatCore.Api
{
    public enum ApiVersion
    {
        v1,
        v2
    }

    public class ChatApiClient
    {
        private readonly HttpClient _request;
        private readonly string _host;
        private readonly string _token;
        private ApiVersion _apiVersion;

        public ApiVersion ApiVersion { get; set; }

        public ChatApiClient(ApiVersion apiVersion = ApiVersion.v1)
        {
            _host = "localhost:44310";
            _apiVersion = apiVersion;
            _request = new HttpClient()
            {
                BaseAddress = new Uri($"https://{_host}/api/{_apiVersion}/")
            };
        }

        public async Task<bool> CheckUserExists(NetworkCredential networkCredential)
        {
            var response = await _request.GetAsync($"users?username={networkCredential.UserName}");

            if (response.IsSuccessStatusCode)
            {                
                var jArray = JArray.Parse(await response.Content.ReadAsStringAsync());
                
                if (jArray.Count > 0)
                {                  
                    var user = JsonConvert.DeserializeObject<User>(jArray[0].ToString());
                    if (user.CheckPassword(networkCredential.Password))
                        return true;
                }
            }

            return false;
        }
    }
}
