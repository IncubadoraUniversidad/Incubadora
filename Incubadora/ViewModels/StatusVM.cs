using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Incubadora.ViewModels
{
    public class StatusVM
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        public string StrValor { get; set; }
        //public string StrDescripcion { get; set; }
    }
}