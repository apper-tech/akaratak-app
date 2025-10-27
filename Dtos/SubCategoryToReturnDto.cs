namespace akaratak_app.Dtos
{
    public class SubCategoryToReturnDto
    {
        public int ID { get; set; }

        public int CategoryID { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public CategoryToReturnDto Category { get; set; }
    }
}