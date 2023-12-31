﻿using Agence_de_Voyages.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Agence_de_Voyages.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationContext context;

        public HomeController(ILogger<HomeController> logger, ApplicationContext context)
        {
            _logger = logger;
            this.context = context;
        }

        public IActionResult Index()

        {
			if (TempData.ContainsKey("SuccessMessage"))
			{
				ViewBag.SuccessMessage = TempData["SuccessMessage"];
			}

			ViewBag.messageerror = TempData["messageerror"];
		
			return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Sign_up()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
		public IActionResult Tour_view()
		{
            ViewBag.Tours = context.Tours.ToList();
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}