using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Incubadora.ViewModels
{
    public class MunicipioVM
    {
        public int Id { get; set; }
        public string StrNombre { get; set; }
        public string StrDescripcion { get; set; }
        public int IdEstado { get; set; }
    }
}