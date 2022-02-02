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
            //BindingContext = pinItemsSourcePageViewModel;
            // map.MoveToRegion(new MapSpan(new Position(54.3520500, 18.6463700), 0.01, 0.01));

            DBConnect dBConnect = new DBConnect();
      


            CustomPin pin = new CustomPin
            {
                Type = PinType.Place,
                Position = new Position(54.79752, 18.40183),
                Label = "Przykładowa pinezka",
                Address = "Władysławowo, Starowiejska 4",
                Name = "Xamarin",
                Url = "http://xamarin.com/about/"
            };
            map.CustomPins = new System.Collections.Generic.List<CustomPin> { pin };
            map.Pins.Add(pin);
            Console.WriteLine("Pin added");
            map.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(54.79752, 18.40183), Distance.FromMiles(1.0)));




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