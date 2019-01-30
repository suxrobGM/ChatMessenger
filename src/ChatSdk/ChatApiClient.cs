using System;
using System.Net.Http;

namespace ChatSdk.Api
{
    public class ChatApiClient
    {
        private readonly HttpClient _request;
        private readonly string _host;

        public ChatApiClient()
        {
            _host = "localhost:44310";
            _request = new HttpClient()
            {
                BaseAddress = new Uri($"https://{_host}/api/")
            };
        }


    }
}
