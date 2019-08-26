using System.ComponentModel.DataAnnotations;

namespace Akaratak.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}