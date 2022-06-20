using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Incubadora.ViewModels
{
    public class EstudianteVM
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
        public string IdStatus { get; set; }
        public TelefonoVM TelefonoVM { get; set; }
        public GrupoVM GrupoVM { get; set; }
        public EmprendimientoEstadiaVM EmprendimientoEstadiaVM { get; set; }
        public PeriodoEstadiaVM PeriodoEstadiaVM { get; set; }
        public CarreraVM CarreraVM { get; set; }
    }
}