
namespace PruebaTecnica.Desarrollo.Users.Domain.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Rol")]
    public class RoleEntity
    {
        [Key]
        [Column("Id")]
        [Required]
        [StringLength(50)]
        public string RoleId { get; private set; }

        [Column("Nombre")]
        [Required]
        [StringLength(50)]
        public string Name { get; private set; }

        public RoleEntity(string roleId, string name)
        {
            this.RoleId = string.IsNullOrEmpty(roleId) ? Guid.NewGuid().ToString() : roleId;
            this.Name = name;
        }
    }
}
