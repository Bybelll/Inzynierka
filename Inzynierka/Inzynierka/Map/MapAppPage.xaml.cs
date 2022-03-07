using System;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Inzynierka
{
    // WARNING: when adding latitude/longitude values be careful of localization.
    // European (and other countries) use a comma as the separator, which will break the request
    public partial class MapAppPage : ContentPage
    {
        public MapAppPage()
        {
            InitializeComponent();
        }

        async void OnLocationButtonClicked(object sender, EventArgs e)
        {
                 if (Device.RuntimePlatform == Device.Android)
            {
                // opens the Maps app directly
                await Launcher.OpenAsync("geo:0,0?q=394+Pacific+Ave+San+Francisco+CA");
            }

        }

        async void OnDirectionButtonClicked(object sender, EventArgs e)
        {
                 if (Device.RuntimePlatform == Device.Android)
            {
                // opens the 'task chooser' so the user can pick Maps, Chrome or other mapping app
                await Launcher.OpenAsync("http://maps.google.com/?daddr=San+Francisco,+CA&saddr=Mountain+View");
            }

        }
    }
}
