using Incubadora.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Incubadora.Business.Interface
{
    public interface IProyectoBusiness
    {
        /// <summary>
        /// Este método se encarga de insertar en cascade un Proyecto en base de datos
        /// Las entidades (tablas) que inserta en cascada son:
        /// ServiciosUniversitarios y RecursosProyectos
        /// </summary>
        /// <param name="proyectoDomainModel">Un objeto de tipo ProyectoDomainModel que contiene todos los datos</param>
        /// <returns>True si fue registrado, false si no</returns>
        bool Add(ProyectoDomainModel proyectoDomainModel);
    }
}
