using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Incubadora.ViewModels
{
    public class ProyectoVM
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
        public EmprendedorVM  EmprendedorVM{get;set;}
        public List<RecursoProyectoVM> RecursosProyectosVM { get; set; }
        //public List<string> ServiciosUniversitariosIds { get; set; }
        public List<ServicioUniversitarioVM> ServiciosUniversitariosVM { get; set; }
        //public virtual ICollection<Colaboradores> Colaboradores { get; set; }
    }
}