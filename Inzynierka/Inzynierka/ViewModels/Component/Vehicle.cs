using System;
using System.Collections.Generic;
using System.Text;

namespace Inzynierka.ViewModels.Component
{
    class Vehicle
    {
        private int id {get; set;}
        private string type { get; set; }
        private double cost { get; set; }
        private byte availability { get; set; }
        private byte damage { get; set; }
        private double latitude { get; set; }
        private double longitude { get; set; }


        public Vehicle(int id,string type, double cost, byte availability, byte damage, double latitude, double longitude)
        {
            this.id = id;
            this.type = type;
            this.cost = cost;
            this.damage = damage;
            this.availability = availability;
            this.latitude = latitude;
            this.longitude = longitude;
        }


    }
}
