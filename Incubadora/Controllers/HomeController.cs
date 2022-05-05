using System.Web.Mvc;

namespace Incubadora.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// modificamos para hacer pruebas
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult AnotherLink()
        {
            return View("Index");
        }
    }
}
