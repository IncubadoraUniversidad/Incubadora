using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Incubadora.Domain
{
    public class EmprendedorDomainModel
    {
        public Guid Id { get; set; }
        public string StrNombre { get; set; }
        public string StrApellidoPaterno { get; set; }
        public string StrApellidoMaterno { get; set; }
        public string StrCurp { get; set; }
        public DateTime? StrFechaNacimiento { get; set; }
        public string StrEmail { get; set; }
        public string StrFotoUrl { get; set; }
        public Guid IdTelefono { get; set; }
        public Guid IdDireccion { get; set; }
        public int IdStatus { get; set; }
        public Guid? IdAvatar { get; set; }
        public Guid IdDatoLaboral { get; set; }

        //public CatAvatars CatAvatars { get; set; }
        public DatoLaboralDomainModel DatoLaboral { get; set; }
        public DireccionDomainModel Direccion { get; set; }
        //public Status Status { get; set; }
        public TelefonoDomainModel Telefono { get; set; }
    }
}
