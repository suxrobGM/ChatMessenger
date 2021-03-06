﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using ChatClient.Models.ApiClient;

namespace ChatClient.Models
{  
    public class SingletonModel
    {
        private static SingletonModel instance;    
        //private readonly ChatPrivateApiClient privateApiClient;

        public ChatPrivateApiClient PrivateApiClient { get; }
        public User CurrentUser { get; set; }

        private SingletonModel()
        {
            PrivateApiClient = new ChatPrivateApiClient();
        }


        public static SingletonModel GetInstance()
        {
            if (instance == null)
                instance = new SingletonModel();

            return instance;
        }
                     
    }
}
