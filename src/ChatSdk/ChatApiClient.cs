using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using ChatCore.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ChatSdk.Api
{
    public class ChatApiClient
    {
        private readonly HttpClient _request;
        private readonly string _host;
        private readonly string _token;

        public ChatApiClient()
        {
            _host = "localhost:44310";
            _request = new HttpClient()
            {
                BaseAddress = new Uri($"https://{_host}/api/")
            };
        }

        public async Task<bool> CheckUserExists(NetworkCredential networkCredential)
        {
            var response = await _request.GetAsync($"/users?username={networkCredential.UserName}");

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
