using System.ComponentModel.DataAnnotations;

namespace NewsPortal.Data.Entities
{
    public abstract class Entity
    {
        [Key]
        public int Id { get; set; }
    }
}
