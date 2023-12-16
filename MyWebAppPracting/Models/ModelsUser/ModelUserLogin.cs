using System.ComponentModel.DataAnnotations;

namespace MyWebAppPracting.Models.ModelsUser
{
    public class ModelUserLogin
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
