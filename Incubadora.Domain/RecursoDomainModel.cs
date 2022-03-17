using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Incubadora.Domain
{
    public class RecursoDomainModel
    {
        public string Id { get; set; }

        public string StrNombreRecurso { get; set; }

        public string StrDescripcion { get; set; }

        public string StrNombrePersona { get; set; }

        public string StrApellidoPaterno { get; set; }

        public string StrApellidoMaterno { get; set; }

        public string IdUsuario { get; set; }
    }
}
