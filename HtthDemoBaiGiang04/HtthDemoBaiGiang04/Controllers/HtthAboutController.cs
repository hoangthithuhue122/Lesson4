using Microsoft.AspNetCore.Mvc;

namespace HtthDemoBaiGiang04.Controllers
{

    //name: HtthAbout
    //author: thu hue
    public class HtthAboutController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.name = "Hoang Thi Thu Hue";
            ViewData["classes"] = "K65 CNT2-LTW";
            TempData["module"] = "Lap trinh web";
            return View();
        }
    }
}
