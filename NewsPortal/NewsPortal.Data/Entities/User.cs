using System.ComponentModel.DataAnnotations;
using NewsPortal.Data.Enums;

namespace NewsPortal.Data.Entities
{
    public class User : Entity
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public Role Role { get; set; }
        [Required]
        public int Likes { get; set; }
    }
}
