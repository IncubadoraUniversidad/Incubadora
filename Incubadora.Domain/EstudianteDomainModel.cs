using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Incubadora.Domain
{
    public class EstudianteDomainModel
    {
        public string Id { get; set; }
        public string StrNombre { get; set; }
        public string StrApellidoPaterno { get; set; }
        public string StrApellidoMaterno { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public string IdTelefono { get; set; }
        public string IdCarrera { get; set; }
        public string IdCatGrupo { get; set; }
        public string StrGrupoDescripcion { get; set; }
        public string IdCatPeriodoEstadia { get; set; }
        public string IdEmprendimientoEstadia { get; set; }
        public TelefonoDomainModel TelefonoDomainModel { get; set; }
        public GrupoDomainModel GrupoDomainModel { get; set; }
        public EmprendimientoEstadiaDomainModel EmprendimientoEstadiaDomainModel { get; set; }
        public PeriodoEstadiaDomainModel PeriodoEstadiaDomainModel { get; set; }
        public CarreraDomainModel CarreraDomainModel { get; set; }
    }
}
