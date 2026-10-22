using Microsoft.AspNetCore.Mvc;

namespace SchoolEventsMini.Web.Controllers
{
    public class SchoolEventsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }
    }
}
