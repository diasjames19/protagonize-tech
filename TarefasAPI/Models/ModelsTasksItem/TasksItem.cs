using System.ComponentModel.DataAnnotations;

namespace TarefasAPI.Models;

public class TasksItem  
{
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Title { get; set; }
        public bool Completed { get; set; }
        public int UserId { get; set; }
        public Users? User { get; set; }
}
