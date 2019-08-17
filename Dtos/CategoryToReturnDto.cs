using System.Collections.Generic;

namespace akaratak_app.Dtos
{
    public class CategoryToReturnDto
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

       public ICollection<SubCategoryToReturnDto> SubCategory { get; set; }
    }
}