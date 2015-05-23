using NewsPortal.Data.Enums;

namespace NewsPortal.Data.Entities
{
    public class User : Entity
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public Role Role { get; set; }
    }
}
