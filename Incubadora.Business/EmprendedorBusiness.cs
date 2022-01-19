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

        public EmprendedorBusiness(IUnitOfWork _unitOfWork)
        {
            this.unitOfWork = _unitOfWork;
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
            emprendedorDomainModel.DatoLaboralDomainModel.IdStatus = 1;
            var telefonos = new Telefonos
            {
                Id = Guid.NewGuid().ToString(),
                StrTelefonoCelular = emprendedorDomainModel.TelefonoDomainModel.StrTelefonoCelular,
                StrTelefonoFijo = emprendedorDomainModel.TelefonoDomainModel.StrTelefonoFijo
            };
            var direcciones = new Direcciones
            {
                Id = Guid.NewGuid().ToString(),
                IdColonia = emprendedorDomainModel.DireccionDomainModel.IdColonia,
                IdEstado = emprendedorDomainModel.DireccionDomainModel.IdEstado,
                IdMunicipio = emprendedorDomainModel.DireccionDomainModel.IdMunicipio,
                StrCalle = emprendedorDomainModel.DireccionDomainModel.StrCalle
            };
            var datosLaborales = new DatosLaborales
            {
                Id = Guid.NewGuid().ToString(),
                IdCarrera = emprendedorDomainModel.DatoLaboralDomainModel.IdCarrera,
                IdCuatrimestre = emprendedorDomainModel.DatoLaboralDomainModel.IdCuatrimestre,
                IdStatus = emprendedorDomainModel.DatoLaboralDomainModel.IdStatus,
                IdUnidadAcademica = emprendedorDomainModel.DatoLaboralDomainModel.IdUnidadAcademica,
                StrObservaciones = emprendedorDomainModel.DatoLaboralDomainModel.StrObservaciones,
                IntOcupacion = emprendedorDomainModel.DatoLaboralDomainModel.IntOcupacion
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
