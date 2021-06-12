using System.Collections;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace WorkingWithMaps.ViewModels
{
    public class PinItemsSourcePageViewModel
    {
        int _pinCreatedCount = 0;
        readonly ObservableCollection<Location> _locations;

        public IEnumerable Locations => _locations;

        public ICommand AddLocationCommand { get; }
        public ICommand RemoveLocationCommand { get; }
        public ICommand ClearLocationsCommand { get; }
        public ICommand UpdateLocationsCommand { get; }
        public ICommand ReplaceLocationCommand { get; }

        public PinItemsSourcePageViewModel()
        {
            _locations = new ObservableCollection<Location>()
            {
                new Location("New York, USA", "The City That Never Sleeps", new Position(40.67, -73.94)),
                new Location("Los Angeles, USA", "City of Angels", new Position(34.11, -118.41)),
                new Location("San Francisco, USA", "Bay City", new Position(37.77, -122.45))
            };

            AddLocationCommand = new Command(AddLocation);
            RemoveLocationCommand = new Command(RemoveLocation);

        }

        void AddLocation()
        {
            _locations.Add(NewLocation());
        }

        void RemoveLocation()
        {
            if (_locations.Any())
            {
                _locations.Remove(_locations.First());
            }
        }


        Location NewLocation()
        {
            _pinCreatedCount++;
            return new Location(
                $"Pin {_pinCreatedCount}", 
                $"Desc {_pinCreatedCount}", 
                RandomPosition.Next(new Position(39.8283459, -98.5794797), 8, 19));
        }

        public void addPin(double latitude, double longitude)
        {
            _locations.Add(new Location("1", "2", new Position(latitude, longitude)));
        }
    }
}
