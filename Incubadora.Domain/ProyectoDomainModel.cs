using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Incubadora.Domain
{
    public class ProyectoDomainModel
    {
        public string Id { get; set; }
        public string StrNombre { get; set; }
        public string StrNombreEmpresa { get; set; }
        public string IdGiro { get; set; }
        public string StrDescripcion { get; set; }
        public string IdFase { get; set; }
        public int IntConstituidaLegal { get; set; }
        public string StrObservaciones { get; set; }
        public string StrRFC { get; set; }
        public System.DateTime DtFechaRegistro { get; set; }
        public string IdEmprendedor { get; set; }

        public EmprendedorDomainModel EmprendedorDomainModel { get; set; }

        public List<RecursoProyectDomainModel> RecursosProyectosDomainModel { get; set; }
        public List<ServicioUniversitarioDomainModel> ServiciosUniversitariosDomainModel { get; set; }
        //public virtual ICollection<Colaboradores> Colaboradores { get; set; }
    }
}
