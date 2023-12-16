using System.ComponentModel.DataAnnotations;

namespace MyWebAppPracting.Models.ModelsUser
{
    public class ModelUserLoginSuccsess
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Token { get; set; }
    }
}
