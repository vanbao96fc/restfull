using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace users
{
    public partial class UpdateInfo : ContentPage
    {
        public UpdateInfo(string User, string Name, string Date, string Number, string Mail)
        {
            InitializeComponent();
            Username.Text = User;
            Nameuser.Text = Name;
            Birthday.Text = Date;
            Numberphone.Text = Number;
            Email.Text = Mail;
        }

        private async void put(object sender, EventArgs e)
        {
            var client = new HttpClient();
            string jsonData = @"[{""Name"" : """ + Nameuser.Text +
                               @""", ""Birthday"" : """ + Birthday.Text +
                               @""", ""Numberphone"" : """ + Numberphone.Text +
                               @""", ""Email"" : """ + Email.Text +
                               @"""}]";
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            string url = "http://ilandapp.com/users/update.php?username=" + Username.Text;
            var result = await client.PutAsync(url, content);
            if (result.IsSuccessStatusCode)
            {
                await Navigation.PushAsync(new infouser(Username.Text));
            }
            else
                await DisplayAlert("Update failed", null, "Close");
            
        }
    }
}
