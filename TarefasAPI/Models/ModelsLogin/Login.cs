using System.ComponentModel.DataAnnotations;

namespace TarefasAPI.Models;

public class Login
{
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Email { get; set; }
        [Required]
        public string? Pass { get; set; }
}



