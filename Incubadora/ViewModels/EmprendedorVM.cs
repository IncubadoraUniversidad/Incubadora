using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Incubadora.ViewModels
{
    public class EmprendedorVM
    {
        public string Id { get; set; }
        public string StrNombre { get; set; }
        public string StrApellidoPaterno { get; set; }
        public string StrApellidoMaterno { get; set; }
        public string StrCurp { get; set; }
        public DateTime? StrFechaNacimiento { get; set; }
        public string StrEmail { get; set; }
        public string StrFotoUrl { get; set; }
        public string IdTelefono { get; set; }
        public string IdDireccion { get; set; }
        public int IdStatus { get; set; }
        public string IdAvatar { get; set; }
        public string IdDatoLaboral { get; set; }

        //public CatAvatars CatAvatars { get; set; }
        public DatoLaboralVM DatoLaboral { get; set; }
        public DireccionVM Direccion { get; set; }
        //public Status Status { get; set; }
        public TelefonoVM Telefono { get; set; }
    }
}