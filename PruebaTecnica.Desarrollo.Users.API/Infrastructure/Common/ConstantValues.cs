using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaTecnica.Desarrollo.Users.API.Infrastructure.Common
{
    public static class ConstantValues
    {

        #region Números

        public const int NameMaxLength = 50;

        public const int LastNameMaxLength = 50;

        public const int MinPasswordLength = 6;

        public const int UserNameMinLength = 8;

        public const int UserNameMaxLength = 16;

        public const int PasswordMinLength = 6;


        #endregion

        #region Mensajes (string)

        public const string NameRequiredMessage = "El Nombre es obligatorio.";

        public const string NameLengthMessage = "El Nombre debe tener una longitud máxima de 50 caracteres.";

        public const string LastNameRequiredMessage = "El Apellido es obligatorio.";

        public const string LastNameLengthMessage = "El Apellido debe tener una longitud máxima de 50 caracteres.";


        public const string UserNameMaxLengthMessage = "El UserName debe tener una longitud máxima de 16 caracteres.";

        public const string UserNameMinLengthMessage = "El UserName debe tener una longitud mínima de 8 caracteres.";

        public const string UserNameRequiredMessage = "El UserName es obligatorio.";

        public const string PasswordRequiredMessage = "El password es obligatorio.";

        public const string PasswordMinLengthMessage = "El password debe de tener una longitud mínima de 6 caracteres.";

        public const string EmailRequiredMessage = "El correo es obligatorio.";

        public const string EmailWrongFormatMessage = "El correo no es valido.";

        #endregion
    }
}
