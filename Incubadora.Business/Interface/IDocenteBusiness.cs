using Incubadora.Domain;

namespace Incubadora.Business.Interface
{
    public interface IDocenteBusiness
    {
        /// <summary>
        /// Este método se encarga de registrar un docente y enlazarlo con las tabla de
        /// AspNetUsers que maneja la seguridad en el sistema, además de registrar su rol
        /// correspondiente (Docente)
        /// </summary>
        /// <param name="docenteDM">Un objeto de tipo docente</param>
        /// <param name="rolId">El id del rol docente</param>
        /// <returns>True si se regsistró</returns>
        bool Add(DocenteDomainModel docenteDM, string rolId);
    }
}
