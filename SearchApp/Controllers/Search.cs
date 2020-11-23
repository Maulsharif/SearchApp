using Microsoft.AspNetCore.Mvc;

namespace SearchApp.Controllers
{
    public class Search : Controller
    {
      
        public IActionResult GetResult()
        {
            return View();
        }
    }
}