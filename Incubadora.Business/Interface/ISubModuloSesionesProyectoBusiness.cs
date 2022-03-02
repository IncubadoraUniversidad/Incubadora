using Incubadora.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Incubadora.Business.Interface
{
    public interface ISubModuloSesionesProyectoBusiness
    {
        /// <summary>
        /// Este metodo se encarga de agregar  actualziar un rol
        /// </summary>
        /// <param name="submodulosDM">la entidad AspNetRoles</param>
        /// <returns>un valor boolean true/false</returns>
        bool AddSubModuloSesiones(SubModuloSesionesProyectoDomainModel submodulosDM);
        /// <summary>
        /// Este metodo se encarga de consultar en la tabla SubModuloSesionesProyecto
        /// </summary>
        /// <returns>regresa una lista de SubModuloSesionesProyecto</returns>
        List<SubModuloSesionesProyectoDomainModel> GetEventos();



    }
}
