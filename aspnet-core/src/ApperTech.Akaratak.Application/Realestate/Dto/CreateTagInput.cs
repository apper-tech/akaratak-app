using System.ComponentModel.DataAnnotations;

namespace ApperTech.Akaratak.Realestate.Dto
{
    public class CreateTagInput
    {
        [Required, MinLength(3)] public string Name { get; set; }
    }
}