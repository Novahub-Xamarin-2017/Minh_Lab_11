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
using Refit;
using Exercise02.Models;
using System.Threading.Tasks;
using System.Net;
using Newtonsoft.Json;
using System.Net.NetworkInformation;

namespace Exercise02.Api
{
    class GitHub
    {
        public static GitHub gitHub = new GitHub();

        private string root = "https://api.github.com";

        private WebClient request = new WebClient();

        private void SetHeader()
        {
            request.Headers["User-Agent"] = "mytest";
        }

        public bool CheckForInternetConnection(Context context)
        {
            try
            {
                SetHeader();
                request.DownloadString(root);
            }
            catch(WebException e)
            {
                if (e.Status == WebExceptionStatus.NameResolutionFailure || e.Status == WebExceptionStatus.ReceiveFailure) 
                {
                    Toast.MakeText(context, "No Internet Access", ToastLength.Short).Show();

                    return false;
                } else
                {
                    throw;
                }
            }

            return true;
        }

        public List<User> GetUsers(string username)
        {
            SetHeader();
            var response = request.DownloadString($"{root}/search/users?q={username}");

            var users = JsonConvert.DeserializeObject<ListOfUser>(response);

            users.Users.ForEach(x =>
            {
                x.Detail = GetDetail(x.Url);
            });

            return users.Users;
        }

        public Detail GetDetail(string url)
        {
            SetHeader();
            var response = request.DownloadString(url);

            return JsonConvert.DeserializeObject<Detail>(response);
        }

        public List<string> GetRepositories(string url)
        {
            SetHeader();
            var response = request.DownloadString(url);

            return JsonConvert.DeserializeObject<List<Repository>>(response).Select(x => x.Name).ToList();
        }
    }
}