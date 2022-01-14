using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Incubadora.Domain
{
    public class EstadoDomainModel
    {
        public Guid Id { get; set; }
        public string StrNombre { get; set; }
        public string StrDescripcion { get; set; }
    }
}
