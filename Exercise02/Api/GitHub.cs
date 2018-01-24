﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Refit;
using Exercise02.Models;
using System.Threading.Tasks;
using System.Net;
using Newtonsoft.Json;

namespace Exercise02.Api
{
    class GitHub
    {
        public static GitHub gitHub = new GitHub();

        private string root = "https://api.github.com";

        private WebClient request = new WebClient();

        public List<User> GetUsers(string username)
        {
            request.Headers["User-Agent"] = "mytest";

            var response = "";

            try
            {
                response = request.DownloadString($"{root}/search/users?q={username}");
            }
            catch (WebException e)
            {
                throw;
            }

            var users = JsonConvert.DeserializeObject<ListOfUser>(response);

            users.Users.ForEach(x =>
            {
                x.Detail = GetDetail(x.Url);
            });

            return users.Users;
        }

        public Detail GetDetail(string url)
        {
            var response = "";

            try
            {
                request.Headers["User-Agent"] = "mytest";
                response = request.DownloadString(url);
            }
            catch (WebException e)
            {
                throw;
            }

            return JsonConvert.DeserializeObject<Detail>(response);
        }

        public List<string> GetRepositories(string url)
        {
            var response = "";

            try
            {
                request.Headers["User-Agent"] = "mytest";
                response = request.DownloadString(url);
            }
            catch (WebException e)
            {
                throw;
            }

            return JsonConvert.DeserializeObject<List<Repository>>(response).Select(x => x.Name).ToList();
        }
    }
}