using Incubadora.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Incubadora.Business.Interface
{
    public interface IEstudianteBusiness
    {
        /// <summary>
        /// Este método se encarga de insertar un estudiante en base de datos y hace la inserción en cascada 
        /// de sus tablas relacionadas, las cuales son: Telefonos y EmprendimientoEstadia
        /// </summary>
        /// <param name="estudianteDM"></param>
        /// <returns>True si fue registrado, false si no</returns>
        bool Add(EstudianteDomainModel estudianteDM);

        /// <summary>
        /// Este método se encarga de consultar todos los estudiantes del catálogo de la bd
        /// </summary>
        /// <returns>Una lista de estudiantes</returns>
        List<EstudianteDomainModel> GetEstudiantes();

        /// <summary>
        /// Este método se encarga de consultar un estudiante mediante su id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns>Un estudiante</returns>
        EstudianteDomainModel GetEstudianteById(string Id);

        /// <summary>
        /// Este método se encarga de consultar un estudiante mediante el id del emprendimientoEstadia
        /// </summary>
        /// <param name="IdEmprendimientoEstadia"></param>
        /// <returns>Un estudiante</returns>
        EstudianteDomainModel GetEstudianteByIdEmprendimiento(string IdEmprendimientoEstadia);
        /// <summary>
        /// Este metodo se encarga de actualizar los datos del estudiante
        /// </summary>
        /// <param name="estudianteDM">la entidad Estudiante</param>    
        /// <returns>Un valor boolean true/false</returns>
        bool UpdateEstudiante(EstudianteDomainModel estudianteDM);

        /// <summary>
        /// Este metodo se encarga de eliminar logicamente de la base de datos un estudiante especifico
        /// </summary>
        /// <param name="Id">el identificador del estudiante</param>
        /// <returns>regresa true o false dependiendo de la acción</returns>
        bool DeleteEstudiante(string Id);

        /// <summary>
        /// Este método se encarga de consultar un emprendimiento por id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns>un emprendimiento</returns>
        EmprendimientoEstadiaDomainModel GetEmprendimientoById(string Id);
    }
}
