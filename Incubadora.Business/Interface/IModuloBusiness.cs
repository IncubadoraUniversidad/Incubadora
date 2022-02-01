using Incubadora.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Incubadora.Business.Interface
{
    public interface IModuloBusiness
    {
        /// <summary>
        /// Este metodo se encarga de consultar todos los modulos del sistema
        /// </summary>
        /// <returns>regresa una lista de modulos</returns>
        List<ModulosDomainModel> GetModulosAll();
    }
}
