﻿using System.Net.Http.Headers;

namespace Domain_Models.Webshop.Models
{
    public class Seller : User
    {
        // Properties
        public int Rating { get; set; }
        public List<Listing> Listings { get; set; } = new List<Listing>();

        // Methods specific to Seller
        public bool CreateListing(Media media) { return true; }
    }
}