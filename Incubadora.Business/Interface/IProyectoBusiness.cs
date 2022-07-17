﻿using Incubadora.Domain;
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
        /// <summary>
        /// Este metodo se encarga de consultar un proyecto en especifico por Id y su emprendedor
        /// </summary>
        /// <param name="Id">el identificador del emprendedor</param>
        /// <returns>la entidad del tipo ProyectoDomainModel</returns>
        ProyectoDomainModel GetProyectoEmprendedorById(string Id);
        /// <summary>
        /// Este metodo se encarga de eliminar logicamente de la base de datos un proyecto especifico
        /// </summary>
        /// <param name="Id">el identificador del proyecto</param>
        /// <returns>regresa true o false dependiendo de la acción</returns>
        bool DeleteProyecto(string Id);
        /// <summary>
        /// Este metodo se encarga de actualizar los datos basicos del proyecto
        /// </summary>
        /// <param name="proyectoDM">la entidad proyecto</param>
        /// <returns>un valor boolean true/false</returns>
        bool UpdateProyecto(ProyectoDomainModel proyectoDM);


        /// <summary>
        /// Este metodo se encarga de consultar un proyecto por Id
        /// </summary>
        /// <param name="Id">el identificador del proyecto</param>
        /// <returns>regresa la entidad del proyecto</returns>
        ProyectoDomainModel GetProyectoById(string Id);

        /// <summary>
        /// Este metodo se encarga de consultar todos los proyectos de la base de datos
        /// </summary>
        /// <returns>retorna una lista de proyectos</returns>
        List<ProyectoDomainModel> GetProyectos();

        List<ProyectoDomainModel> GetProyectoByIdUser(String Id);
        /// <summary>
        /// Este metodo se encarga de consultar los proyectos por id para mandar a una lista
        /// con sus datos y a su vez ocuparlo para la exportacion
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        List<ExportaDM> GetProyectoByIdNew(string Id);

        #region Se encarga de consultar los poryectos por su giro
        List<EstadisticasGiroEmpresarialDM> TotalProyectosGiro();

        #endregion

        #region Se enacrga de contar los proyectos por su estatus legal
        List<EstatusLegalDM> TotalConstituidos();
        #endregion

        #region Se encarga de hacer la consulta para graficar la tabla
        List<EstadisticasGiroEmpresarialDM> TablaDeGiros();
        #endregion

    }
}
