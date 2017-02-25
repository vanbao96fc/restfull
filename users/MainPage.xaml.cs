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
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void sigin(object sender, EventArgs e)
        {
            var client = new HttpClient();
            string url = "http://ilandapp.com/users/login.php?username=" + Username.Text + @"&password=" + Password.Text;
            var uri = new Uri(url);
              var response = await client.GetAsync(uri);
            if (response.IsSuccessStatusCode)
                {
                    var contentGet = await response.Content.ReadAsStringAsync();
                    var item = JsonConvert.DeserializeObject<List<Stt>>(contentGet);
                    if (item[0].stt == "1")
                    {
                        await DisplayAlert("Đăng nhập thành công", null, "Close");
                    await Navigation.PushAsync(new infouser(Username.Text));
                    }
                    else
                        await DisplayAlert("Sai tên đăng nhập hoặc mật khẩu", null, "Close");

                }
        }

        private async void sigup(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Sigup());
        }
    }    
}
