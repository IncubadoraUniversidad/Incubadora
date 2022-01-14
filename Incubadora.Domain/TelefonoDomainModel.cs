using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Incubadora.Domain
{
    public class TelefonoDomainModel
    {
        public Guid Id { get; set; }
        public string StrTelefonoFijo { get; set; }
        public string StrTelefonoCelular { get; set; }
    }
}
