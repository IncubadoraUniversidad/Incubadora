using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Incubadora.ViewModels
{
    public class TelefonoVM
    {
        public Guid Id { get; set; }
        public string StrTelefonoFijo { get; set; }
        public string StrTelefonoCelular { get; set; }
    }
}