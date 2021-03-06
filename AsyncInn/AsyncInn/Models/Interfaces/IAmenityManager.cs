﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models.Interfaces
{
    public interface IAmenityManager 
    {
        // Create an amenity
        Task CreateAmenity(Amenities amenities);

        // Read an amenity
        Task<Amenities> GetAmenity(int id);

        Task<IEnumerable<Amenities>> GetAmenities();

        // Update an amenity
        Task UpdateAmenity(Amenities amenities);

        // Delete an amenity
        Task DeleteAmenity(int id);
    }
}
