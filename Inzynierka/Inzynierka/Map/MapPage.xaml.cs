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


        private void OnSingInButtonClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new SignPage());
        }

        private void OnMyAccountButtonClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MyAccount());
        }

        private void OnPodsumowanieClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new SummaryRent());
        }

        private void FinishRent(object sender, EventArgs e)
        {
            Navigation.PushAsync(new SummaryRent());
            
        }

        private void OnHelpButtonClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new HelpPage());
        }
    }
}


//public void RentVehicle()
//{
//    timer.start();
//    Application.Current.Properties["rentalTime"] = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
//    Application.Current.Properties["startPosition"] = vehicle.Position;
//    RentTimeStackLayout.IsVisible = true;
//}


//public void FinishRent()
//{

//    timer.stop();
//    RentTimeStackLayout.IsVisible = false;
//    int rentTime = timer.getRentalTime();
//    int usersID = Application.Current.Properties["usersID"] as int;
//    DateTime rentalTime = Application.Current.Properties["rentalTime"] as DateTime;
//    Position startPosition = Application.Current.Properties["startPosition"] as Position;
//    double cost = CalculateCost(rentTime, vehicle.cost);

//    dbConnect.InsertRental(NULL, users.ID, vehicle.ID, rentalTime, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
//        startPosition.latitude, startPosition.longitude, vehicle.Position.latitude, vehicle.Position.longitude, cost, rentTime);

//    Navigation.PushAsync(new SummaryRent(vehicle.ID, vehicle.Type, vehicle.Cost, rentTime,));

//}


