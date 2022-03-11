using Incubadora.Domain;

namespace Incubadora.Business.Interface
{
    public interface IEmailBusiness
    {
        bool SendForgotPasswordEmail(AspNetUsersDomainModel aspNetUserDM);
    }
}
