using System;
using System.Collections.Generic;

public class PropertyToListDto
{
    private const int MaxPageSize = 50;
    public int PageNumber { get; set; } = 1;
    private int pageSize = 10;
    public int PageSize
    {
        get { return pageSize; }
        set { pageSize = value < MaxPageSize ? value : MaxPageSize; }
    }
    public DateTime PublishDate { get; set; }
    public int Country_ID { get; set; }

    public int City_ID { get; set; }

    public int Area { get; set; } = 0;

    public string OfferType { get; set; }

    public int Owners { get; set; }

    public int Rooms { get; set; }

    public int Bathrooms { get; set; }

    public int Balconies { get; set; }

    public int PropertyAge { get; set; }
    public bool Cladding { get; set; }

    public bool Direction_South { get; set; }
    public bool Direction_North { get; set; }
    public bool Direction_East { get; set; }
    public bool Direction_West { get; set; }

    public bool Empty { get; set; }

    public bool Heating { get; set; }

    public bool GasLine { get; set; }

    public bool Internet { get; set; }

    public bool Elevator { get; set; }

    public bool Parking { get; set; }

    public ICollection<string> Tags { get; set; }

    public string OrderBy { get; set; }

}