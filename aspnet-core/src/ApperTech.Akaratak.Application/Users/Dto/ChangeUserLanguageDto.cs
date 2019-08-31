using System.ComponentModel.DataAnnotations;

namespace ApperTech.Akaratak.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}