using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Incubadora.Domain
{
    public class ModulosDomainModel
    {
        public int Id { get; set; }
        public string StrValor { get; set; }

        List<SubModulosDomainModel> SubModulosDomainModel { get; set; }
    }
}
