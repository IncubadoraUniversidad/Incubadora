using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Incubadora.Domain
{
    public class SubModulosDomainModel
    {
        public int Id { get; set; }
        public string StrValor { get; set; }

        public ModulosDomainModel ModulosDomainModel { get; set; }

        public List<SesionesDomainModel> SesionesDomainModels { get; set; }
    }
}
