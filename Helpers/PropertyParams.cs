using akaratak_app.Models;

namespace akaratak_app.Helpers
{
    public class PropertyParams
    {
        private const int MaxPageSize = 50;
        public int PageNumber { get; set; } = 1;
        private int pageSize = 10;
        public int PageSize
        {
            get { return pageSize; }
            set { pageSize = value < MaxPageSize ? value : MaxPageSize; }
        }
        public Address Address { get; set; }

        public int BathroomNumber { get; set; } = 0;

        public int Area { get; set; } = 0;

        public bool Cladding { get; set; }

        public string OrderBy { get; set; }

    }
}
