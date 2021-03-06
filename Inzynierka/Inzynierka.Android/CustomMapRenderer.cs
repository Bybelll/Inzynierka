using Android.Content;
using Android.Widget;
using System;
using System.Collections.Generic;
using Android.Gms.Maps;
using Android.Gms.Maps.Model;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Maps.Android;
using Inzynierka.Component;



[assembly: ExportRenderer(typeof(CustomMap), typeof(Inzynierka.Droid.CustomMapRenderer))]
namespace Inzynierka.Droid
{
    public class CustomMapRenderer : MapRenderer, GoogleMap.IInfoWindowAdapter
    {
        List<Vehicle> vehicles;

        public CustomMapRenderer(Context context) : base(context) {}

        protected override void OnElementChanged(Xamarin.Forms.Platform.Android.ElementChangedEventArgs<Map> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement != null)
            {
                NativeMap.InfoWindowClick -= OnInfoWindowClick;
            }

            if (e.NewElement != null)
            {
                var formsMap = (CustomMap)e.NewElement;
                vehicles = formsMap.CustomPins;
            }
        }

        protected override void OnMapReady(GoogleMap map)
        {
            base.OnMapReady(map);

            NativeMap.InfoWindowClick += OnInfoWindowClick;
            NativeMap.SetInfoWindowAdapter(this);
        }

        protected override MarkerOptions CreateMarker(Pin pin)
        {
            var marker = new MarkerOptions();
            marker.SetPosition(new LatLng(pin.Position.Latitude, pin.Position.Longitude));
            marker.SetTitle(pin.Label);
            marker.SetSnippet(pin.Address);
            return marker;
        }


        void OnInfoWindowClick(object sender, GoogleMap.InfoWindowClickEventArgs e)
        {
            var customPin = GetCustomPin(e.Marker);
            if (customPin == null)
            {
                
                throw new Exception("Custom pin not found");
            }
        }
        public Android.Views.View GetInfoContents(Marker marker)
        {
            var inflater = Android.App.Application.Context.GetSystemService(Context.LayoutInflaterService) as Android.Views.LayoutInflater;
            if (inflater != null)
            {
                Android.Views.View view;

                var customPin = GetCustomPin(marker);
                if (customPin == null)
                {
                    
                    throw new Exception("Custom pin not found");
                }
                
                if (customPin.type.Equals("rower"))
                {
                    view = inflater.Inflate(Resource.Layout.BikeInfoWindow, null);
                }
                else if (customPin.type.Equals("hulajnoga"))
                {
                    
                    view = inflater.Inflate(Resource.Layout.ScooterInfoWindow, null);
                }
                else
                {
                    view = inflater.Inflate(Resource.Layout.MapInfoWindow, null);
                }
                var infoAdress = view.FindViewById<TextView>(Resource.Id.InfoWindowAdress);

                view.FindViewById<TextView>(Resource.Id.InfoWindowCost).Text = "Opłata: " + customPin.cost + " zł/min";
                view.FindViewById<TextView>(Resource.Id.InfoWindowIDVehicle).Text = "Nr pojazdu: " + customPin.id.ToString();
                infoAdress.Text = "Adres: " + marker.Title;

                return view;
            }
            return null;
        }

        public Android.Views.View GetInfoWindow(Marker marker)
        {
            return null;
        }

        Vehicle GetCustomPin(Marker annotation)
        {
            var position = new Position(annotation.Position.Latitude, annotation.Position.Longitude);
            foreach (var pin in vehicles)
            {
                if (pin.Position == position)
                {
                    return pin;
                }
            }
            return null;
        }

    
    }
}
