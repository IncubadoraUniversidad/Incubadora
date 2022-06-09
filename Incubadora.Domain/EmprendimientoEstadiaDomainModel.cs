using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Incubadora.Domain
{
    public class EmprendimientoEstadiaDomainModel
    {
        public string Id { get; set; }
        public string StrValor { get; set; }
        public string StrDescripcion { get; set; }
        public int IdStatus { get; set; }
        public StatusDomainModel StatusDomainModel { get; set; }

    }
}
