using Incubadora.Business.Interface;
using Incubadora.Domain;
using Incubadora.Repository;
using Incubadora.Repository.Infraestructure.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Incubadora.Business
{
    public class StatusBusiness : IStatusBusiness
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly StatusRepository repository;

        public StatusBusiness(IUnitOfWork _unitOfWork)
        {
            this.unitOfWork = _unitOfWork;
            repository = new StatusRepository(this.unitOfWork);
        }
        public List<StatusDomainModel> GetStatus()
        {
            List<StatusDomainModel> status = null;
            status = repository.GetAll().Select(p => new StatusDomainModel
            {
                Id = p.Id,
                StrValor = p.StrValor,
                //StrDescripcion = p.StrDescripcion

            }).ToList();
            return status;
        }
        /// <summary>
        /// Este metodo se encarga de agregar  actualziar un status
        /// </summary>
        /// <param name="statusDM">la entidad AspNetRoles</param>
        /// <returns>un valor boolean true/false</returns>
        public bool AddUpdateStatus(StatusDomainModel statusDM)
        {
            bool respuesta = false;
            if (statusDM != null)
            {
                Status status = repository.SingleOrDefault(p => p.Id == statusDM.Id);
                if(status != null)
                {
                    status.StrValor = statusDM.StrValor;
                    repository.Update(status);
                    respuesta = true;
                }
                else
                {
                    var Identificador = Guid.NewGuid();
                    Status aspNet = new Status
                    {
                        StrValor = statusDM.StrValor
                    };
                    repository.Insert(aspNet);
                    respuesta = true;
                }
            }
            return respuesta;
        }
        /// <summary>
        /// Este metodo se encarga de validar que una entidad no exista 
        /// </summary>
        /// <param name="strValor">El parametro a buscar  </param>
        /// <returns>Valor boleano true o false</returns>
        /// 
        public bool ValidateStatusValue (string strValor)
        {
            bool respuesta = false;
            try
            {
                Expression<Func<Status, bool>> predicate = p => p.StrValor == strValor.ToLower();
                respuesta = repository.Exists(predicate);
            }
            catch (Exception ex)
            {
                string mensajeErr = ex.Message;
            }
            return respuesta;
        }
    }
}
