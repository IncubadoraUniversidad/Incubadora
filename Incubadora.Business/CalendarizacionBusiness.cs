using Incubadora.Business.Interface;
using Incubadora.Repository;
using Incubadora.Repository.Infraestructure.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Incubadora.Business
{
    public class CalendarizacionBusiness : ICalendarizacionBusiness
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly CalendarizacionRepository repository;
    }
   
}
