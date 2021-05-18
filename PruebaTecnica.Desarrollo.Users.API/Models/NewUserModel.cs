using PruebaTecnica.Desarrollo.Users.API.Infrastructure.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PruebaTecnica.Desarrollo.Users.API.Models
{
    public class NewUserModel
    {
        [Required(ErrorMessage = ConstantValues.NameRequiredMessage)]
        [MaxLength(ConstantValues.NameMaxLength, ErrorMessage = ConstantValues.NameLengthMessage)]
        public string Name { get; set; }

        [Required(ErrorMessage = ConstantValues.LastNameRequiredMessage)]
        [MaxLength(ConstantValues.LastNameMaxLength, ErrorMessage = ConstantValues.LastNameLengthMessage)]
        public string LastName { get; set; }

        [Required(ErrorMessage = ConstantValues.UserNameRequiredMessage)]
        [MaxLength(ConstantValues.UserNameMaxLength, ErrorMessage = ConstantValues.UserNameMaxLengthMessage)]
        [MinLength(ConstantValues.UserNameMinLength, ErrorMessage = ConstantValues.UserNameMinLengthMessage)]
        public string UserName { get; set; }

        [Required(ErrorMessage = ConstantValues.PasswordRequiredMessage)]
        [MinLength(ConstantValues.PasswordMinLength, ErrorMessage = ConstantValues.PasswordMinLengthMessage)]
        public string Password { get; set; }

        [Required(ErrorMessage = ConstantValues.EmailRequiredMessage)]
        [EmailAddress(ErrorMessage = ConstantValues.EmailWrongFormatMessage)]
        public string Email { get; set; }

        [JsonIgnore]
        public string RoleId { get; set; }
    }
}
