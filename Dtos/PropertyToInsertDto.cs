using System;
using System.Collections.Generic;
using akaratak_app.Models;
using akaratak_app.Dtos;
using Microsoft.AspNetCore.Http;

public class PropertyToInsertDto
{
    /*---------------------- Basic ----------------------- */
    public string Title { get; set; }
    
    public string Description { get; set; }

    public ICollection<int> Tags { get; set; }

    public OfferToInsertDto Offer { get; set; }

    public int Type { get; set; }

    /*---------------------- Address ----------------------- */

    public string Country { get; set; }

    public int City { get; set; }

    public string Location { get; set; }

    public string ZipCode { get; set; }

    public string Street { get; set; }

    public float Latitude { get; set; }

    public float Longitude { get; set; }

    /*---------------------- Additional ----------------------- */

    public int Area { get; set; } = 0;

    public int Owners { get; set; }

    public int Rooms { get; set; }

    public int Bedrooms { get; set; }

    public int Bathrooms { get; set; }

    public int Balconies { get; set; }

    public int PropertyAge { get; set; }

    /*---------------------- Direction ----------------------- */
    public bool DirectionSouth { get; set; }
    public bool DirectionNorth { get; set; }
    public bool DirectionEast { get; set; }
    public bool DirectionWest { get; set; }

    /*---------------------- Features ----------------------- */
    public bool Cladding { get; set; }

    public bool Empty { get; set; }

    public bool Heating { get; set; }

    public bool GasLine { get; set; }

    public bool Internet { get; set; }

    public bool Elevator { get; set; }

    public bool Parking { get; set; }

}