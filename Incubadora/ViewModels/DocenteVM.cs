using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Incubadora.ViewModels
{
    public class DocenteVM
    {
        public string Id { get; set; }
        public string StrNombre { get; set; }
        public string StrApellidoPaterno { get; set; }
        public string StrApellidoMaterno { get; set; }
        public int IdSexo { get; set; }
        public string IdUsuario { get; set; }
        public AspNetUsersVM aspNetUserVM { get; set; }
    }
}