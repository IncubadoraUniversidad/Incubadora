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
        /// Este método se encarga de crear 1 emprendedor en base de datos y hace la inserción en cascada
        /// de sus tablas relacionadas, las cuales son: Telefonos, Direcciones y DatosLaborales
        /// </summary>
        /// <param name="emprendedorDomainModel">Un objeto de tipo emprendedor</param>
        /// <returns>True si fue registrado, false si no</returns>
        bool Add(EmprendedorDomainModel emprendedorDomainModel);
        /// <summary>
        /// Este método se encarga de consultar y retornar todos los emprendedores de la base de datos
        /// </summary>
        /// <returns>Una lista de emprendedores</returns>
        List<EmprendedorDomainModel> GetEmprendedores();

        /// <summary>
        /// Este metodo se encarga de consultar todos los emprendedores y sus proyectos realcionados tomando como base la lista de proyectos
        /// </summary>
        /// <param name="catalogo">el catalogo relacionado con la tabla a consultar</param>
        /// <returns>la lista de proyectos</returns>
        List<ProyectoDomainModel> GetProyectoEmprendedores();

        /// <summary>
        /// Este método se encarga de buscar y retornar un emprendedor en base de datos de acuerdo al Id asociado
        /// de la tabla AspNetUsers.
        /// </summary>
        /// <param name="aspNetUserId">Id de la tabla AspNetUsers asociado a un emprendedor</param>
        /// <returns>Un Objeto de tipo EmprendedorDomainModel</returns>
        EmprendedorDomainModel GetEmprendedorByAspNetUserId(string aspNetUserId);
    }
}
