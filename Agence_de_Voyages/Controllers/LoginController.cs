using Agence_de_Voyages.Models;
using Microsoft.AspNetCore.Mvc;

namespace Agence_de_Voyages.Controllers
{
    public class LoginController : Controller
    {
        private readonly ApplicationContext context;

        public LoginController(ApplicationContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {

            return View();
        }

        public ActionResult Auth()
        {
            return View();
        }
        [HttpPost]
		public ActionResult Auth(string useremail, string password)
		{
			try
			{
				ViewBag.messageerror = "";
				User user = context.Users.FirstOrDefault(x => x.Email == useremail && x.Password == password);
				if (user == null)
				{
					ViewBag.messageerror = "No user found!";
					return View("~/Views/Home/Login.cshtml");
				}
				else
				{
					TempData["messageerror"] = "Welcome " + user.Name.ToString();
					return RedirectToAction("Index", "Home");
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine("Error: " + ex.Message);
				return RedirectToAction("Error");
			}
		}


	}
}


