using System;
using Android.App;
using Android.Widget;
using Android.OS;
using System.Text;
using System.IO;
using System.Net;

namespace App1
{
    [Activity(Label = "App1", MainLauncher = true, Icon = "@drawable/icon")]
    class Connection
    {
        public bool chk;
        public string GET(string Url, string Data)
        {
            WebRequest req = WebRequest.Create(Url + "?" + Data);
            WebResponse resp = req.GetResponse();
            Stream stream = resp.GetResponseStream();
            StreamReader sr = new StreamReader(stream, Encoding.GetEncoding(1251));
            string Out = sr.ReadToEnd();
            sr.Close();
            return Out;
        }
        public bool CHECK_CON(string Url)
        {
            HttpWebRequest myRequest = (HttpWebRequest)HttpWebRequest.Create(Url);
            HttpWebResponse myResponse = (HttpWebResponse)myRequest.GetResponse();
            if (myResponse.StatusCode == HttpStatusCode.OK) chk = true;
            else
            {
                chk = false;
            }
            //StreamReader myFile = new StreamReader(myResponse.GetResponseStream(), Encoding.GetEncoding(1251));
            return chk;
        }
    }
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            
            // Set our view from the "main" layout resource
            SetContentView (Resource.Layout.Main);
            EditText text = FindViewById<EditText>(Resource.Id.editText1);
            Button btn = FindViewById<Button>(Resource.Id.button1);
            TextView text2 = FindViewById<TextView>(Resource.Id.textView2);
            btn.Enabled = false;
            btn.Click += (object sender, EventArgs e) =>
            {
                if (String.IsNullOrWhiteSpace(Convert.ToString(text)))
                {
                    btn.Text = "Input here";
                    btn.Enabled = false;
                }
                else
                {
                    Connection obj1 = new Connection();
                    if (obj1.CHECK_CON(text.Text))
                    {
                        text2.Text = "Соединение установлено!";
                    }
                }
            };

        }
    }
}

