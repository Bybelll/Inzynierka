using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms.Maps;

namespace Inzynierka.Component
{
    public class Vehicle : Pin
    {

        private int id { get; set; }
        private string type { get; set; }
        private double cost { get; set; }
        private byte availability { get; set; }
        private byte damage { get; set; }



        public Vehicle(int id, string type, double cost, byte availability, byte damage, double latitude, double longitude)
        {
            Label = "test";
            this.id = id;
            this.type = type;
            this.cost = cost;
            this.damage = damage;
            this.availability = availability;
            Position = new Position(latitude, longitude);
            
        }



    }
}
