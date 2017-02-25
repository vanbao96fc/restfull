using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace users
{
    public partial class infouser : ContentPage
    {
        public infouser(string name)
        {
            InitializeComponent();
            Username.Text = name;

        }

        private async void open(object sender, EventArgs e)
        {
            HttpClient client = new HttpClient();
            string url = "http://ilandapp.com/users/info.php?username=" + Username.Text;
            var uri = new Uri(url);
            var response = await client.GetAsync(uri);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var item = JsonConvert.DeserializeObject<List<user>>(content);
                Name.Text = "Name: " + item[0].Name;
                Birthday.Text = "Birthday: " + item[0].Birthday;
                Numberphone.Text = "Numberphone: " + item[0].Numberphone;
                Email.Text = "Email: " + item[0].Email;
            }
            Update.IsVisible = true;
            btnDel.IsVisible = true;
            
        }

        private async void put(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new UpdateInfo(Username.Text, Name.Text, Birthday.Text, Numberphone.Text, Email.Text));
        }

        private async void delete(object sender, EventArgs e)
        {
            var client = new HttpClient();
            string url = "http://ilandapp.com/users/delete.php?username=" + Username.Text;
            var result = await client.DeleteAsync(url);
            if (result.IsSuccessStatusCode)
            {
                await DisplayAlert("Delete successful", null, "Close");
                await Navigation.PushAsync(new MainPage());
            }
            else
                await DisplayAlert("Delete failed", null, "Close");

        }
    }
}

