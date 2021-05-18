using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PruebaTecnica.Desarrollo.Users.Domain.Entities
{
    [Table("UsuarioClaims")]
    public class CustomClaimEntity
    {
        [Key]
        [StringLength(50)]
        [Required]
        public string Id { get; private set; }

        [Column("UsuarioId")]
        [StringLength(50)]
        [Required]
        public string UserId { get; private set; }


        public virtual UserEntity User { get; set; }

        [Column("Campo")]
        [StringLength(50)]
        [Required]
        public string Property { get; private set; }


        [Column("Valor")]
        [StringLength(100)]
        [Required]
        public string PropertyValue { get; private set; }

        /// <summary>
        /// Constructor para mapeos EF.
        /// </summary>
        public CustomClaimEntity()
        {
        }


        public CustomClaimEntity(string id, string userId, string property, string propertyValue)
        {
            this.Id = string.IsNullOrEmpty(id) ? Guid.NewGuid().ToString() : id;
            this.UserId = userId;
            this.Property = property;
            this.PropertyValue = propertyValue;
        }

    }
}
