using Incubadora.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Incubadora.Business.Interface
{
    public interface ISubModuloBusiness
    {
        /// <summary>
        /// Este metodo se encarga de consultar todos los submodulos del sistema
        /// </summary>
        /// <returns>regresa una lista de submodulos</returns>
        List<SubModulosDomainModel> GetSubModulosAll();
    }
}
