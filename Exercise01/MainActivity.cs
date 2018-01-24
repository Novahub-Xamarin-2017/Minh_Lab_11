using Android.App;
using Android.Widget;
using Android.OS;
using MainApi = Exercise01.Api.Api;

namespace Exercise01
{
    [Activity(Label = "Login", Theme = "@android:style/Theme.Material.Light.DarkActionBar", MainLauncher = true)]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Login);

            FindViewById<Button>(Resource.Id.btn_login).Click += delegate
            {
                MainApi.api.Login(FindViewById<EditText>(Resource.Id.et_user).Text, FindViewById<EditText>(Resource.Id.et_password).Text);
                if (MainApi.api.messageCurrent.Equals(""))
                {
                    StartActivity(typeof(Tweets));
                } else
                {
                    Toast.MakeText(this, MainApi.api.messageCurrent, ToastLength.Short).Show();
                }
            };
        }
    }
}

