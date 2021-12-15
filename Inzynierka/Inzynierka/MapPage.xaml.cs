using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Forms.Maps;
using Inzynierka.Component;
using System.Windows.Input;
using Inzynierka.ViewModels;



namespace Inzynierka
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MapPage : ContentPage
    {
        PinItemsSourcePageViewModel pinItemsSourcePageViewModel = new PinItemsSourcePageViewModel();
        public MapPage()
        {
            InitializeComponent();
            BindingContext = pinItemsSourcePageViewModel;
            // map.MoveToRegion(new MapSpan(new Position(54.3520500, 18.6463700), 0.01, 0.01));

            CustomPin pin = new CustomPin
            {
                Type = PinType.Place,
                Position = new Position(37.79752, -122.40183),
                Label = "Xamarin San Francisco Office",
                Address = "394 Pacific Ave, San Francisco CA",
                Name = "Xamarin",
                Url = "http://xamarin.com/about/"
            };
            map.CustomPins = new System.Collections.Generic.List<CustomPin> { pin };
            map.Pins.Add(pin);
            map.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(37.79752, -122.40183), Distance.FromMiles(1.0)));




        }

        private void OnChangeModeClicked(object sender, EventArgs e)
        {
            map.MapType = map.MapType == MapType.Street ? MapType.Hybrid : MapType.Street;
        }

        void OnMapClicked(object sender, MapClickedEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine($"MapClick: {e.Position.Latitude}, {e.Position.Longitude}");

            pinItemsSourcePageViewModel.addPin("a","s",e.Position.Latitude, e.Position.Longitude);
           
        }

        private void OnAddPinButtonClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new GeocoderPage(pinItemsSourcePageViewModel));
        }



    }
}