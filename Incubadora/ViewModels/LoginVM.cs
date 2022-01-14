using System.ComponentModel.DataAnnotations;

namespace Incubadora.ViewModels
{
    public class LoginVM
    {
        [Required(ErrorMessage = "Este campo es requerido")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Este campo es requerido")]
        public string PasswordHash { get; set; }
    }
}