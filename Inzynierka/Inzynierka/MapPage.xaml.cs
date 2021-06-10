﻿using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Forms.Maps;
using System.Windows.Input;
using WorkingWithMaps.ViewModels;

namespace WorkingWithMaps
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MapPage : ContentPage
    {

        public MapPage()
        {
            InitializeComponent();
            BindingContext = new PinItemsSourcePageViewModel();
            map.MoveToRegion(new MapSpan(new Position(54.3520500, 18.6463700), 0.01, 0.01));
        }

        void OnChangeModeClicked(object sender, EventArgs e)
        {
            Button button = sender as Button;

            if(map.MapType == MapType.Street)
            {
                map.MapType = MapType.Hybrid;
            }
            else
            {
                map.MapType = MapType.Street;
            }
        }

        void OnMapClicked(object sender, MapClickedEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine($"MapClick: {e.Position.Latitude}, {e.Position.Longitude}");
        }
    }
}