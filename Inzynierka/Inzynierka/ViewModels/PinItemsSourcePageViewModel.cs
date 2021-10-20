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
                new Location("Forum", "Galeria", new Position(54.3488669,18.6433859)),
                new Location("Powale Grodzkie", "Dworzec Główny", new Position(54.355476, 18.645044)),
                new Location("test","test",new Position(37.779167, -122.419167))
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

        public void addPin(string adress,string desciption, double latitude, double longitude)
        {
            _pinCreatedCount++;
            _locations.Add(new Location(adress, desciption, new Position(latitude, longitude)));
        }
    }
}
