using System.ComponentModel.DataAnnotations;

namespace MyWebAppPracting.Models.ModelsUser
{
    public class User
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }


        public List<string> roles { get; set; }

    }
}
