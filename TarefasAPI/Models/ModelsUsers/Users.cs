using System.ComponentModel.DataAnnotations;

namespace TarefasAPI.Models;

public class Users
{
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        [Required]      
        public string? Email { get; set; }
        [Required]
        public string? Pass { get; set; }
        
}
