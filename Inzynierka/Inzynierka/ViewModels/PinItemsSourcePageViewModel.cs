using Inzynierka.Component;
using System.Collections.Generic;

namespace Inzynierka.ViewModels
{
    public class PinItemsSourcePageViewModel
    {
        public List<Vehicle> vehicles { get; set; }

        public PinItemsSourcePageViewModel()
        {
            DBConnect dBConnect = new DBConnect();
            vehicles = dBConnect.Select();

        }
    }
}
