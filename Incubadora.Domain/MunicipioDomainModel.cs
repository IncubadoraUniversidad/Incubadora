using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Incubadora.Domain
{
    public class MunicipioDomainModel
    {
        public int Id { get; set; }
        public string StrNombre { get; set; }
        public string StrDescripcion { get; set; }
        public int IdEstado { get; set; }
    }
}
