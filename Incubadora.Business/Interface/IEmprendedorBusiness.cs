using Incubadora.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Incubadora.Business.Interface
{
    public interface IEmprendedorBusiness
    {
        /// <summary>
        /// Este método se encarga de crear un emprendedor en base de datos y hace la inserción en cascada
        /// de sus tablas relacionadas, las cuales son: Telefonos, Direcciones y DatosLaborales
        /// </summary>
        /// <param name="emprendedorDomainModel">Un objeto de tipo emprendedor</param>
        /// <returns>True si fue registrado, false si no</returns>
        bool Add(EmprendedorDomainModel emprendedorDomainModel);
    }
}
