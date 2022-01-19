using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Incubadora.Domain
{
    public class DatoLaboralDomainModel
    {
        public string Id { get; set; }
        public int IntOcupacion { get; set; }
        public string StrObservaciones { get; set; }
        public string IdUnidadAcademica { get; set; }
        public string IdCarrera { get; set; }
        public string IdCuatrimestre { get; set; }
        public int IdStatus { get; set; }
    }
}
