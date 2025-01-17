using System.ComponentModel.DataAnnotations;

namespace EnilsonSolution.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}