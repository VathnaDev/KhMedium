using System.Web.Mvc;

namespace KhMedium.Controllers
{
    public class PublicationController : Controller
    {
        // GET
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }
    }
}