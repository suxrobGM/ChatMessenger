using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace ChatClient.Models.ApiClient
{
    public enum ApiVersion
    {
        v1,
        v2
    }

    public class ChatPrivateApiClient
    {
        private HttpClient request;
        private string host = "localhost:44328";
        //private string protectedAccessKey;
        private ApiVersion apiVersion = ApiVersion.v1;

        #region Constructors
        public ChatPrivateApiClient()
        {
            request = new HttpClient
            {
                BaseAddress = new Uri($"https://{host}/api/{apiVersion}/")
            };
        }

        public ChatPrivateApiClient(string host)
        {
            this.host = host;
            request = new HttpClient
            {
                BaseAddress = new Uri($"https://{host}/api/{apiVersion}/")
            };
        }
        #endregion

        #region Operations
        public async Task<bool> CheckUserLoginAsync(NetworkCredential networkCredential)
        {         
            var response = await request.GetAsync($"main/users?username={networkCredential.UserName}&email={networkCredential.UserName}");
            if (response.IsSuccessStatusCode)
            {
                try
                {
                    var jArray = JArray.Parse(await response.Content.ReadAsStringAsync());

                    var user = new User
                    {
                        Email = jArray[0]["email"].ToString(),
                        FirstName = jArray[0]["firstName"].ToString(),
                        LastName = jArray[0]["lastName"].ToString(),
                        Username = jArray[0]["username"].ToString(),
                        TelephoneNumber = jArray[0]["telephoneNumber"].ToString(),
                        Password = new NetworkCredential(null, jArray[0]["password"].ToString()).SecurePassword,
                        //Photo = jArray[0]["photo"]
                    };

                    string passwordFromDb = jArray[0]["password"].ToString();
                    if (passwordFromDb == networkCredential.Password)
                    {
                        SingletonModel.GetInstance().CurrentUser = user;
                        return true;
                    }
                        
                }
                catch (Exception)
                {
                    return false;
                }         
            }

            return false;
        }

        public async Task<int> AddNewUserAsync(User user)
        {
            int statusCode = 500; // 500 - server internal error code
            var jObject = JObject.Parse(user.GetJsonFormat());            
            var contentJson = new StringContent(jObject.ToString(), Encoding.UTF8, "application/json");
            try
            {
                var response = await request.PostAsync("main/users", contentJson); // POST request

                if (response.IsSuccessStatusCode)
                    statusCode = 200; // OK

                if ((int)response.StatusCode == 403)
                    statusCode = 403; // Username exists 
            }
            catch (Exception) { }              

            return statusCode;
        }
        #endregion
    }
}
