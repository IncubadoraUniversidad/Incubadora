using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;

namespace Incubadora.Security
{
    public static class ClaimsPersister
    {
        /// <summary>
        /// Este metodo se encarga de consultar el nombre del rol que tiene asignado el usuario dentro del sistema
        /// </summary>
        /// <returns>el nombre del rol asignado al usuario</returns>
        public static string GetRoleClaim()
        {
            ClaimsPrincipal principal = HttpContext.Current.GetOwinContext().Authentication.User as System.Security.Claims.ClaimsPrincipal;
            var rolName = principal.Claims.Where(p => p.Type == ClaimTypes.Role).Select(p => p.Value).SingleOrDefault();
            return rolName;
        }

        /// <summary>
        /// Este  metodo se encarga de consultar el identificador de un usuario
        /// </summary>
        /// <returns>retorna el identificador del usuario</returns>
        public static string GetUserId()
        {
            ClaimsPrincipal principal = HttpContext.Current.GetOwinContext().Authentication.User as System.Security.Claims.ClaimsPrincipal;
            var UserId = principal.Claims.Where(p => p.Type == ClaimTypes.NameIdentifier).Select(p => p.Value).SingleOrDefault();
            return UserId;
        }
        
    }
}