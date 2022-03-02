using Incubadora.Helpers.CustomValidations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Incubadora.ViewModels
{
    public class DocenteVM
    {
        public string Id { get; set; }
        [SoloLetras]
        [MaxLength(20, ErrorMessage = "Este campo no puede tener más de 20 caracteres")]
        [Required(ErrorMessage = "Este campo es requerido")]
        public string StrNombre { get; set; }
        [SoloLetras]
        [MaxLength(20, ErrorMessage = "Este campo no puede tener más de 20 caracteres")]
        [Required(ErrorMessage = "Este campo es requerido")]
        public string StrApellidoPaterno { get; set; }
        [SoloLetras]
        [MaxLength(20, ErrorMessage = "Este campo no puede tener más de 20 caracteres")]
        [Required(ErrorMessage = "Este campo es requerido")]
        public string StrApellidoMaterno { get; set; }
        [Required(ErrorMessage = "Este campo es requerido")]
        public int IdSexo { get; set; }
        public string IdUsuario { get; set; }
        public AspNetUsersVM AspNetUserVM { get; set; }
    }
}