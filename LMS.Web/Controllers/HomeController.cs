using Microsoft.AspNetCore.Mvc;

namespace LMS.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        // Returns home view.
        public ActionResult Home()
        {
            return View();
        }

        // Returns about view.
        public ActionResult About()
        {
            return View();
        }

        // Returns contact view.
        public ActionResult Contact()
        {
            return View();
        }

        // Returns login view.
        public ActionResult Login()
        {
            return View();
        }
    }
}
