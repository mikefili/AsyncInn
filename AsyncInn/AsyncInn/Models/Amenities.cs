﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models
{
    public class Amenities
    {
        public int ID { get; set; }
        public string Name { get; set; }

        // navigation properties
        public RoomAmenities RoomAmenities { get; set; }
    }
}
