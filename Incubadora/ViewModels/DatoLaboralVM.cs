using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Incubadora.ViewModels
{
    public class DatoLaboralVM
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