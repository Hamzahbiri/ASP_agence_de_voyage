﻿using Agence_de_Voyages.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Agence_de_Voyages.Controllers
{
	public class UsersController : Controller
	{
		private readonly ApplicationContext context;

		public UsersController(ApplicationContext context)
		{
			this.context = context;
		}

		// GET: UsersController
		public ActionResult Index()
				
		{
			List<UsersModel> Users = context.Users.ToList();

			return View(Users);
		}

		// GET: UsersController/Details/5
		public ActionResult Details(int id)

		{
			UsersModel Users = context.Users.Where(x => x.Id == id).FirstOrDefault();

			return View(Users);
		}

		// GET: UsersController/Create
		public ActionResult Create()
		{
			return View();
		}

        // POST: UsersController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UsersModel Users)
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
                        return View(Users);
                    }

                    UsersModel s = new UsersModel();
                    s.Name = Users.Name;
                    s.Age = Users.Age;
                    s.Gender= Users.Gender; 
                    s.Email = Users.Email;
                    s.Phone = Users.Phone;
                    s.Type = Users.Type;
                    s.Password = Users.Password;

                    context.Users.Add(s);
                    context.SaveChanges();

                    return RedirectToAction(nameof(Index));
                }

                return View(Users);
            }
            catch (Exception ex)
            {
                // Log the exception for debugging
                // You can use a logging framework like Serilog or simply log to a file.
                Console.WriteLine("erreuuuuuuuuuuuuuuuur"+ex.Message);

                // Redirect to an error page or action
                return RedirectToAction("Error");
            }
        }


        // GET: UsersController/Edit/5
        public ActionResult Edit(int id)
		{
            UsersModel Users = context.Users.Where(x => x.Id == id).FirstOrDefault();
            return View(Users);
        }

		// POST: UsersController/Edit/5
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

		// GET: UsersController/Delete/5
		public ActionResult Delete(int id)
		{
            UsersModel Users = context.Users.Where(x => x.Id == id).FirstOrDefault();
            return View(Users);
         
		}

		// POST: UsersController/Delete/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Delete(int id, IFormCollection collection)
		{
            try
            {
                UsersModel Users = context.Users.Where(x => x.Id == id).FirstOrDefault();
                context.Users.Remove(Users);
                context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {

                return View();
            }
        }
	}
}