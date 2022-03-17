using Incubadora.Domain;
using System.Collections.Generic;

namespace Incubadora.Business.Interface
{
    public interface IRecursoBusiness
    {
        /// <summary>
        /// Este método se encarga de registrar un recurso de proyecto en base de datos
        /// </summary>
        /// <param name="recursoDM">Un obeto de tipo RecursoDomainModel</param>
        /// <returns>True si todo salió bien.</returns>
        bool Add(RecursoDomainModel recursoDM);

        /// <summary>
        /// Este método se encarga de consultar todos los recursos de proyectos que le pertenecen a un
        /// emprendedor
        /// </summary>
        /// <param name="userId">El Id de la sesión del usuario (AspNetUsers)</param>
        /// <returns>Una lista de RecursosDomainModel</returns>
        List<RecursoDomainModel> GetRecursosByUserId(string userId);

        /// <summary>
        /// Este método se encarga de consultar un recurso en bd por Id
        /// </summary>
        /// <param name="id">El Id del recurso</param>
        /// <returns>Un objeto de tipo RecursoDomainModel o null</returns>
        RecursoDomainModel GetRecursoById(string id);

        /// <summary>
        /// Este método se encarga de actualizar un recurso
        /// </summary>
        /// <param name="recursoDM">Un objeto de tipo RecursoDomainModel</param>
        /// <returns>True si se actualizó</returns>
        bool Update(RecursoDomainModel recursoDM);

        /// <summary>
        /// Este método se encarga de eliminar un recurso de base de datos 
        /// </summary>
        /// <param name="id">El id del recurso a eliminar</param>
        void Delete(string id);
    }
}
