using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Incubadora.Domain
{
    public class ColoniaDomainModel
    {
        public int Id { get; set; }
        public string StrNombre { get; set; }
        public string StrDescripcion { get; set; }
        public string StrCodigoPostal { get; set; }
        public int IdMunicipio { get; set; }
    }
}
