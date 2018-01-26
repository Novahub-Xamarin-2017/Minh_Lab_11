using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System.Net;
using Newtonsoft.Json;
using Exercise01.Api.Models;

namespace Exercise01.Api
{
    class Api
    {
        public static Api api = new Api();

        public string messageCurrent;

        private string cookie;

        private string root = "https://salty-mesa-4348.herokuapp.com/";

        public void Login(string login, string password)
        {
            messageCurrent = "";

            var request = new WebClient();
            request.Headers["Content-Type"] = "application/json";

            var user = new
            {
                login = login,
                password = password
            };

            try
            {
                var response = request.UploadString(root + "login", JsonConvert.SerializeObject(user));

                cookie = request.ResponseHeaders.Get("Set-Cookie").Split(';')[0];
            } catch(WebException e)
            {
                messageCurrent = e.Message;
            }
        }

        public List<Tweet> GetTweets()
        {
            messageCurrent = "";

            var request = new WebClient();
            request.Headers["Content-Type"] = "application/json";
            request.Headers["Cookie"] = cookie;

            var response = "";

            try
            {
                response = request.DownloadString(root + "tweets");
            }
            catch (WebException e)
            {
                messageCurrent = e.Message;
            }

            return JsonConvert.DeserializeObject<List<Tweet>>(response);
        }

        public void Logout()
        {
            messageCurrent = "";

            var request = new WebClient();
            request.Headers["Content-Type"] = "application/json";
            request.Headers["Cookie"] = cookie;

            try
            {
                var response = request.UploadString(root + "logout", "DELETE", "");
            }
            catch (WebException e)
            {
                messageCurrent = e.Message;
            }
        }
    }
}