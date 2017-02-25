
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace users
{
    public partial class Sigup : ContentPage
    {
        public Sigup()
        {
            InitializeComponent();
        }
                private async void post(object sender, EventArgs e)
                {
                    var client = new HttpClient();
                    string jsonData = @"[{ ""Username"" : """ + Username.Text +
                                       @""", ""Password"" : """ + Password.Text +
                                       @""", ""Name"" : """ + Name.Text +
                                       @""", ""Birthday"" : """ + Birthday.Text +
                                       @""", ""Numberphone"" : """ + Numberphone.Text +
                                       @""", ""Email"" : """ + Email.Text +
                                       @"""}]";
                    var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                    string url = "http://ilandapp.com/users/insert.php";
                    var result = await client.PostAsync(url, content);
                    if (result.IsSuccessStatusCode)
                    {
                        await DisplayAlert("Create account successful", null, "Close");
                        await Navigation.PushAsync(new MainPage());
                    }
                    else
                        await DisplayAlert("Update failed", null, "Close");
                }
 
    }
}
