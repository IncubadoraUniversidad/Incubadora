using Incubadora.Business.Interface;
using Incubadora.Domain;
using Incubadora.Repository;
using Incubadora.Repository.Infraestructure.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Incubadora.Business
{
    public class EmprendedorBusiness : IEmprendedorBusiness
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly EmprendedorRepository repository;

        public EmprendedorBusiness(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            repository = new EmprendedorRepository(this.unitOfWork);
        }


        /// <summary>
        /// Este método se encarga de crear un emprendedor en base de datos y hace la inserción en cascada
        /// de sus tablas relacionadas, las cuales son: Telefonos, Direcciones y DatosLaborales
        /// </summary>
        /// <param name="emprendedorDomainModel">Un objeto de tipo emprendedor</param>
        /// <returns>True si fue registrado, false si no</returns>
        public bool Add(EmprendedorDomainModel emprendedorDomainModel)
        {
            emprendedorDomainModel.IdStatus = 1;
            //emprendedorDomainModel.StrFotoUrl = "";
            emprendedorDomainModel.DatoLaboral.IdStatus = 1;
            var telefonos = new Telefonos
            {
                Id = Guid.NewGuid().ToString(),
                StrTelefonoCelular = emprendedorDomainModel.Telefono.StrTelefonoCelular,
                StrTelefonoFijo = emprendedorDomainModel.Telefono.StrTelefonoFijo
            };
            var direcciones = new Direcciones
            {
                Id = Guid.NewGuid().ToString(),
                IdColonia = emprendedorDomainModel.Direccion.IdColonia,
                IdEstado = emprendedorDomainModel.Direccion.IdEstado,
                IdMunicipio = emprendedorDomainModel.Direccion.IdMunicipio,
                StrCalle = emprendedorDomainModel.Direccion.StrCalle
            };
            var datosLaborales = new DatosLaborales
            {
                Id = Guid.NewGuid().ToString(),
                IdCarrera = emprendedorDomainModel.DatoLaboral.IdCarrera,
                IdCuatrimestre = emprendedorDomainModel.DatoLaboral.IdCuatrimestre,
                IdStatus = emprendedorDomainModel.DatoLaboral.IdStatus,
                IdUnidadAcademica = emprendedorDomainModel.DatoLaboral.IdUnidadAcademica,
                StrObservaciones = emprendedorDomainModel.DatoLaboral.StrObservaciones,
                IntOcupacion = emprendedorDomainModel.DatoLaboral.IntOcupacion
            };
            var emprendedorEntity = new Emprendedores
            {
                Id = Guid.NewGuid().ToString(),
                StrNombre = emprendedorDomainModel.StrNombre,
                StrApellidoPaterno = emprendedorDomainModel.StrApellidoPaterno,
                StrApellidoMaterno = emprendedorDomainModel.StrApellidoMaterno,
                StrCurp = emprendedorDomainModel.StrCurp,
                StrFechaNacimiento = emprendedorDomainModel.StrFechaNacimiento,
                Telefonos = telefonos,
                Direcciones = direcciones,
                StrEmail = emprendedorDomainModel.StrEmail,
                StrFotoUrl = emprendedorDomainModel.StrFotoUrl,
                IdStatus = emprendedorDomainModel.IdStatus,
                DatosLaborales = datosLaborales
            };
            var emprendedordb = repository.Insert(emprendedorEntity);
            return emprendedordb != null;
        }
    }
}
