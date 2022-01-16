using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Incubadora.ViewModels
{
    public class DireccionVM
    {
        public string Id { get; set; }
        public string StrCalle { get; set; }
        public int IdEstado { get; set; }
        public int IdMunicipio { get; set; }
        public int IdColonia { get; set; }
        public int? IntNumeroInterior { get; set; }

        public int? IntNumeroExterior { get; set; }
    }
}