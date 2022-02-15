using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Forms.Maps;
using Inzynierka.Component;
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
            addPinsToMap();
            map.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(54.3514759094602, 18.6458255723119), Distance.FromMiles(1.0)));


        }

        private void OnChangeModeClicked(object sender, EventArgs e)
        {
            map.MapType = map.MapType == MapType.Street ? MapType.Hybrid : MapType.Street;
        }

        void OnMapClicked(object sender, MapClickedEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine($"MapClick: {e.Position.Latitude}, {e.Position.Longitude}");

            //pinItemsSourcePageViewModel.addPin("a","s",e.Position.Latitude, e.Position.Longitude);

        }

        private void OnAddPinButtonClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new GeocoderPage(pinItemsSourcePageViewModel));
            
        }

        private void addPinsToMap()
        {
            pinItemsSourcePageViewModel = new PinItemsSourcePageViewModel();
            map.CustomPins = pinItemsSourcePageViewModel.vehicles;
            foreach (Vehicle a in map.CustomPins)
            {
                map.Pins.Add(a);
            }
            
        }


    }
}