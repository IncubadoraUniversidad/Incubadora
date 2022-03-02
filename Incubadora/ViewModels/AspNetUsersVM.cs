

using Incubadora.Helpers.CustomValidations;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Incubadora.ViewModels
{
    public class AspNetUsersVM
    {
        public string Id { get; set; }
        [Remote("IsUsernameTaken", "Account", HttpMethod = "POST")]
        [SoloLetras]
        [MaxLength(20, ErrorMessage = "Este campo no puede tener más de 20 caracteres")]
        [Required(ErrorMessage = "Este campo es requerido")]
        public string UserName { get; set; }
        public string NormalizedUserName { get; set; }
        [Remote("IsEmailTaken", "Account", HttpMethod = "POST")]
        [EmailAddress(ErrorMessage = "El formato de correo electrónico no es válido")]
        [MaxLength(30, ErrorMessage = "Este campo no puede tener más de 30 caracteres")]
        [Required(ErrorMessage = "Este campo es requerido")]
        public string Email { get; set; }
        public string NormalizedEmail { get; set; }
        public bool EmailConfirmed { get; set; }
        [MaxLength(20, ErrorMessage = "Este campo no puede tener más de 20 caracteres")]
        [Required(ErrorMessage = "Este campo es requerido")]
        public string PasswordHash { get; set; }
        public string SecurityStamp { get; set; }
        public string ConcurrencyStamp { get; set; }
        public string PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public bool LockoutEnabled { get; set; }
        public int AccessFailedCount { get; set; }
        public string StrFotoUrl { get; set; }
        public int? IdAvatar { get; set; }

        public AspNetRolesVM AspNetRolesVM { get; set; }
    }
}