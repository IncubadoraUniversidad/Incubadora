using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Incubadora.ViewModels
{
    public class DatoLaboralVM
    {
        public Guid Id { get; set; }
        public string StrOcupacion { get; set; }
        public string StrObservaciones { get; set; }
        public Guid? IdUnidadAcademica { get; set; }
        public Guid? IdCarrera { get; set; }
        public Guid? IdCuatrimestre { get; set; }
        public int IdStatus { get; set; }
    }
}