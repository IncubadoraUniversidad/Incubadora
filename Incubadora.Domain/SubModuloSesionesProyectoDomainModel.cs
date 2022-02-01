using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Incubadora.Domain
{
    public class SubModuloSesionesProyectoDomainModel
    {
        public ProyectoDomainModel ProyectoDomainModel { get; set; }
        public SesionesDomainModel SesionesDomainModel { get; set; }
        public StatusDomainModel StatusDomainModel { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaTermino { get; set; }
        public string StrAsunto { get; set; }
        public string StrDescripcion { get; set; }

        public string StrColorTema { get; set; }
    }
}
