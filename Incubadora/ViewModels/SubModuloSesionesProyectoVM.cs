using Incubadora.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Incubadora.ViewModels
{
    public class SubModuloSesionesProyectoVM
    {
        public string IdProyecto { get; set; }
        public Nullable<int> IdSesion { get; set; }
        public DateTime DteFechaInicio { get; set; }
        public DateTime DteFechaTermino { get; set; }
        public string StrAsunto { get; set; }
        public string StrDescripcion { get; set; }
        public string StrColorTema { get; set; }
        public Nullable<int> IdStatus { get; set; }

        public string FechaInicioFormatted {
            get
            {
                return DteFechaInicio.ToShortDateString();
            }
        }

        public string FechaTerminoFormatted
        {
            get
            {
                return DteFechaTermino.ToShortDateString();
            }
        }

        public ProyectoDomainModel ProyectoDomainModel { get; set; }
        public SesionesDomainModel SesionesDomainModel { get; set; }
        public StatusDomainModel StatusDomainModel { get; set; }
    }
}