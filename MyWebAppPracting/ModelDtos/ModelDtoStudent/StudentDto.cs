using MyWebAppPracting.Models.ModelsUser;
using System.ComponentModel.DataAnnotations;

namespace MyWebAppPracting.ModelDtos.ModelDtoUser
{
    public class StudentDto
    {
        [Required]
        [MinLength(5)]
        public string Name { get; set; } = null!;
        [Required]
        [MinLength(5)]
        public string Surname { get; set; } = null!;
        [Required]
        [Range(1, 2)]
        public int GenId { get; set; }

    }

}
