using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Incubadora.Domain
{
    public class SubModuloSesionesProyectoDomainModel
    {

        public int Id { get; set; }
        public string IdProyecto { get; set; }
        public Nullable<int> IdSesion { get; set; }
        public DateTime DteFechaInicio { get; set; }
        public DateTime DteFechaTermino { get; set; }
        public string StrAsunto { get; set; }
        public string StrDescripcion { get; set; }
        public string StrColorTema { get; set; }
        public Nullable<int> IdStatus { get; set; }

        public ProyectoDomainModel ProyectoDomainModel { get; set; }
        public SesionesDomainModel SesionesDomainModel { get; set; }
        public StatusDomainModel StatusDomainModel { get; set; }
    }
}
