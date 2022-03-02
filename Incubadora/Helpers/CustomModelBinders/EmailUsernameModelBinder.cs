using System.Web.Mvc;

namespace Incubadora.Helpers.CustomModelBinders
{
    public class EmailUsernameModelBinder : DefaultModelBinder
    {
        public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var request = controllerContext.HttpContext.Request;
            var email = request.Form.Get("Email") ?? request.Form.Get("AspNetUserVM.Email");
            var username = request.Form.Get("UserName") ?? request.Form.Get("AspNetUserVM.UserName");
            return email ?? username;
        }
    }
}