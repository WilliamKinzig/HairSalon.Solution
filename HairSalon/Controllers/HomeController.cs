using Microsoft.AspNetCore.Mvc;

namespace HairSalon.Controllers
{
    public class HomeController : Controller
    {

        [HttpGet("/")]
        public ActionResult Index()
        {
            //return new EmptyResult();//FAIL
            return View();
        }
    }
}
