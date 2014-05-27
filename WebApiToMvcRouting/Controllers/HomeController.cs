using System.Web.Mvc;

namespace WebApiToMvcRouting.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        public ActionResult Index()
        {
            return View();
        }
	}
}