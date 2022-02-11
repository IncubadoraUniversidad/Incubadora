using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Incubadora.Domain
{
    public class DocenteDomainModel
    {
        public string Id { get; set; }
        public string StrNombre { get; set; }
        public string StrApellidoPaterno { get; set; }
        public string StrApellidoMaterno { get; set; }
        public int IdSexo { get; set; }
        public string IdUsuario { get; set; }
        public AspNetUsersDomainModel aspNetUserDomainModel { get; set; }
    }
}
