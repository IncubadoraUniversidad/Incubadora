using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Incubadora.Domain
{
    public class SesionesDomainModel
    {
        public int Id { set; get; }
        public string StrValor { get; set; }
        public SubModulosDomainModel SubModulosDomainModel { get; set; }

        public List<SubModuloSesionesProyectoDomainModel> SubModuloSesionesProyectosDomainModel { get; set; } 
    }
}
