using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Incubadora.ViewModels
{
    public class EmprendimientoEstadiaVM
    {
        //
        public string Id { get; set; }
        public string StrValor { get; set; }
        public string StrDescripcion { get; set; }
        public int IdStatus { get; set; }
        public StatusVM StatusVM { get; set; }

    }
}