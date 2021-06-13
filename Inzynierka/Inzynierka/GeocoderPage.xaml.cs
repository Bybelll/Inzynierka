using System;
using System.Collections.Generic;
using System.Linq;
using WorkingWithMaps.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace WorkingWithMaps
{
    public partial class GeocoderPage : ContentPage
    {
        Geocoder geoCoder;
        Position pinPosition;
        PinItemsSourcePageViewModel pinViewKodelGeocoder;
        string address;

        public GeocoderPage(PinItemsSourcePageViewModel pinItemsSourcePageViewModel)
        {
            pinViewKodelGeocoder = pinItemsSourcePageViewModel;
            InitializeComponent();
            geoCoder = new Geocoder();
        }

        async void OnGeocodeButtonClicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(geocodeEntry.Text))
            {
                address = geocodeEntry.Text;
                IEnumerable<Position> approximateLocations = await geoCoder.GetPositionsForAddressAsync(address);
                Position position = approximateLocations.FirstOrDefault();
                geocodedOutputLabel.Text = $"{position.Latitude}, {position.Longitude}";

                pinPosition = position;
            }
        }

        async void OnReverseGeocodeButtonClicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(reverseGeocodeEntry.Text))
            {
                string[] coordinates = reverseGeocodeEntry.Text.Split(',');
                double? latitude = Convert.ToDouble(coordinates.FirstOrDefault());
                double? longitude = Convert.ToDouble(coordinates.Skip(1).FirstOrDefault());

                if (latitude != null && longitude != null)
                {
                    Position position = new Position(latitude.Value, longitude.Value);
                    IEnumerable<string> possibleAddresses = await geoCoder.GetAddressesForPositionAsync(position);
                    address = possibleAddresses.FirstOrDefault();
                    reverseGeocodedOutputLabel.Text = address;

                    pinPosition = position;
                }
            }
        }

        private void AddPin(object sender, EventArgs e)
        {
            pinViewKodelGeocoder.addPin(address, ".", pinPosition.Latitude, pinPosition.Longitude);
            Navigation.PopAsync();

        }
    }
}
