using System;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace mapasycirculos.Views
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            Task.Run(GetPosition);
           
        }

        private async void GetPosition()
        {
            await Device.InvokeOnMainThreadAsync(async () => await Permissions.RequestAsync<Permissions.LocationAlways>());
            while(true)
            {
                Location position = await Geolocation.GetLocationAsync(new GeolocationRequest(GeolocationAccuracy.Best, TimeSpan.FromSeconds(10)));
                Device.BeginInvokeOnMainThread(() => map.UserCurrentLocation = position);
            }
        }
       
    }
}
