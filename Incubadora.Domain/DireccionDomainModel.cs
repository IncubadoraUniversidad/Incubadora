using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Incubadora.Domain
{
    public class DireccionDomainModel
    {
        public Guid Id { get; set; }
        public string StrCalle { get; set; }
        public Guid IdEstado { get; set; }
        public Guid IdMunicipio { get; set; }
        public Guid IdColonia { get; set; }
    }
}
