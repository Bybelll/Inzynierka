﻿using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms.Maps;

namespace Inzynierka.Component
{
    public class CustomMap : Map
    {
        public List<Vehicle> CustomPins { get; set; }
    }
}
