namespace PruebaTecnica.Desarrollo.Users.Domain.Entities
{
    using PruebaTecnica.Desarrollo.Users.Domain.Security;
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Usuario")]
    public class UserEntity
    {
        [Key]
        [Required]
        [Column("Id")]
        [StringLength(50)]
        public string UserId { get; private set; }

        [Required]
        [Column("Nombre")]
        [StringLength(100)]
        public string Name { get; private set; }

        [Required]
        [Column("Apellido")]
        [StringLength(100)]
        public string LastName { get; private set; }

        [Required]
        [Column("NombreUsuario")]
        [StringLength(15)]
        public string UserName { get; private set; }

        [Required]
        [Column("Clave")]
        [StringLength(500)]
        public string Password { get; private set; }

        [Required]
        [Column("FechaCreacion")]
        public DateTime CreateAt { get; private set; }

        [Required]
        [Column("RolId")]
        [StringLength(50)]
        [ForeignKey("Rol.Id")]
        public string RoleId { get; private set; }

        public virtual RoleEntity Role { get; set; }

        [Required]
        [Column("Activo")]
        public bool Active { get; private set; }


        public UserEntity()
        {

        }

        /// <summary>
        /// Constructor para obtener usuarios.
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="name"></param>
        /// <param name="lastName"></param>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="createAt"></param>
        /// <param name="roleId"></param>
        /// <param name="active"></param>
        public UserEntity(string userId,
                          string name,
                          string lastName,
                          string userName,
                          string password,
                          DateTime createAt,
                          string roleId,
                          bool active
                          )
        {

            this.UserId = string.IsNullOrEmpty(userId) ? Guid.NewGuid().ToString() : userId;
                this.Name = name;
                this.LastName = lastName;
                this.UserName = userName;
                this.Password = EncryptPassword.Encrypt256(password);
                this.CreateAt = DateTime.Now;
                this.RoleId = roleId;
                this.Active = active;
        }
    }
}
