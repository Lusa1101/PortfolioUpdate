using Microsoft.AspNetCore.Mvc;

namespace Portfolio.Controllers
{
    public class FreelancingController : Controller
    {
        public FreelancingController()
        {

        }

        // GET: Contacts
        public async Task<IActionResult> Index()
        {
            await Task.Delay(10);

            return View();
        }

    }
}
