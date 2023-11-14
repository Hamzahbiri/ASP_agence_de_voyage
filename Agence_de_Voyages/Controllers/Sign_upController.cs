using Agence_de_Voyages.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Agence_de_Voyages.Controllers
{
    public class Sign_upController : Controller
    {

        private readonly ApplicationContext context;


        public Sign_upController(ApplicationContext context)
        {
            this.context = context;
        }

        // GET: Sign_upController
        public ActionResult Index()
        {
            return View();
        }

        // GET: Sign_upController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Sign_upController/Create
        public ActionResult CreateUser()
        {
            return View();
        }

        // POST: Sign_upController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateUser(User Users)
        {
            try
            {
                ViewBag.messageerror = "";

                if (ModelState.IsValid)
                {
                    // Check if a user with the same email already exists
                    var existingUser = context.Users.FirstOrDefault(x => x.Email == Users.Email);

                    if (existingUser != null)
                    {
                        ViewBag.messageerror = "User with the same email already exists.";
                        return View("~/Views/Home/Sign_up.cshtml", Users);

                    }

                    User s = new User();
                    s.Name = Users.Name;
                    s.Age = Users.Age;
                    s.Gender = Users.Gender;
                    s.Email = Users.Email;
                    s.Phone = Users.Phone;
                    s.Type = Users.Type;
                    s.Password = Users.Password;

                    context.Users.Add(s);
                    context.SaveChanges();

                    TempData["SuccessMessage"] = "Add successful";

                    return RedirectToAction("Index", "Home");


                }

                return View("~/Views/Home/Sign_up.cshtml", Users);
            }
            catch (Exception ex)
            {
                // Log the exception for debugging
                // You can use a logging framework like Serilog or simply log to a file.
                Console.WriteLine("erreuuuuuuuuuuuuuuuur" + ex.Message);

                // Redirect to an error page or action
                return RedirectToAction("Error");
            }
        }

        // GET: Sign_upController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Sign_upController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

  
       
    }
}
