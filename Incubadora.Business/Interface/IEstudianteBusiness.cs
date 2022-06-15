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
        /// Este método se encarga de consultar un estudiante mediante el id del emprendimientoEstadia
        /// </summary>
        /// <param name="IdEmprendimientoEstadia"></param>
        /// <returns>Un estudiante</returns>
        EstudianteDomainModel GetEstudianteByIdEmprendimiento(string IdEmprendimientoEstadia);
    }
}
