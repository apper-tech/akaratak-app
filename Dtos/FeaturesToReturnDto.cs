using System.Collections.Generic;

namespace akaratak_app.Dtos
{
    public class FeaturesToReturnDto
    {
        public DirectionToReturnDto Directon { get; set; }

        public bool Cladding { get; set; }

        public bool Empty { get; set; }

        public bool Heating { get; set; }

        public bool GasLine { get; set; }

        public bool Internet { get; set; }

        public bool Elevator { get; set; }

        public bool Parking { get; set; }

        public int Area { get; set; }

        public int Owners { get; set; }

        public int Rooms { get; set; }


        public int Bathrooms { get; set; }

        public int Bedrooms { get; set; }
        
        public int Balconies { get; set; }


        public int PropertyAge { get; set; }


        public string Title { get; set; }

        public string Description { get; set; }



        public ICollection<TagsToReturnDto> Tags { get; set; }
    }
}