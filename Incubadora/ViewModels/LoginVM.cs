using System.ComponentModel.DataAnnotations;

namespace Incubadora.ViewModels
{
    public class LoginVM
    {
        public string Id { get; set; }
        [Required(ErrorMessage = "Este campo es requerido")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Este campo es requerido")]
        public string PasswordHash { get; set; }
        public string Email { get; set; }
        //Asociamos el rol a la entidad login
        public AspNetRolesVM aspNetRoles { get; set; }
    }
}