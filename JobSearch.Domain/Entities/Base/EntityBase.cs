using System;
using System.ComponentModel.DataAnnotations;

namespace JobSearch.Domain.Entities.Base
{
    public abstract class EntityBase
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; }
        [Required]
        public DateTime UpdatedDate { get; set; }
        [Required]
        public bool IsDeleted { get; set; } = false;
    }
}
