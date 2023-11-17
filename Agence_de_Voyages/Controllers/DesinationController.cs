using Agence_de_Voyages.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Agence_de_Voyages.Controllers
{
    public class DesinationController : Controller
    {
        private readonly ApplicationContext context;
        public DesinationController(ApplicationContext context)
        {
             this.context = context;
        }

        // GET: DesinationController
        public ActionResult Index()
        {
            List<Destination> destinationList = new List<Destination>();
            return View(destinationList);
        }

        // GET: DesinationController/Details/5
        public ActionResult Details(int id)
        {
            Destination? destination = context.Destinations
                .Where(dest => dest.DestinationId == id)
                .FirstOrDefault();
            return View(destination);
        }

        // GET: DesinationController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DesinationController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Destination destination)
        {
            try
            {
                ViewBag.ErrorMessage = "";
                if (ModelState.IsValid)
                {
                    var existingDestination = context.Destinations
                        .Where(dest => dest.CityName == destination.CityName)
                        .FirstOrDefault();
                    if (existingDestination != null)
                    {
                        ViewBag.ErrorMessage = "Destination already exists!";
                        return View(destination);
                    }

                    Destination dest = new Destination();
                    dest.CityName = destination.CityName;
                    dest.Country = destination.Country;
                    dest.AirportCode = destination.AirportCode;
                    dest.LocalTransport = destination.LocalTransport;
                    dest.PriceEstimate = destination.PriceEstimate;

                    context.Destinations.Add(dest);
                    context.SaveChanges();

                    return RedirectToAction("Index");

                }
                return View(destination);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error When creating a new Destination: " + e.Message);
                return RedirectToAction("Error");
            }
        }

        // GET: DesinationController/Edit/5
        public ActionResult Edit(int id)
        {
            Destination? destination = context.Destinations
                .Where(dest => dest.DestinationId == id)
                .FirstOrDefault();
            return View(destination);
        }

        // POST: DesinationController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id,Destination destination)
        {
            try
            {

                    ViewBag.ErrorMessage = "";
                    if (ModelState.IsValid)
                    {
                        var destToEdit = context.Destinations
                            .Where(dest => dest.CityName == destination.CityName)
                            .FirstOrDefault();
                        if (destToEdit == null)
                        {
                            ViewBag.ErrorMessage = "Destination does not exists!";
                            return View(destination);
                        }

                        destToEdit.CityName = destination.CityName;
                        destToEdit.Country = destination.Country;
                        destToEdit.AirportCode = destination.AirportCode;
                        destToEdit.LocalTransport = destination.LocalTransport;
                        destToEdit.PriceEstimate = destination.PriceEstimate;
                        context.SaveChanges();

                        return RedirectToAction("Index");
                    }
                    return View(destination);
                }
            catch(Exception e)
            {
                Console.WriteLine("Error when Updating Destination: " + e.Message);
                return RedirectToAction("Error");
            }
        }

        // GET: DesinationController/Delete/5
        public ActionResult Delete(int id)
        {
            Destination? destination = context.Destinations
                .Where(dest => dest.DestinationId == id)
                .FirstOrDefault();
            return View(destination);
        }

        // POST: DesinationController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                Destination? destination = context.Destinations
                    .Where(dest => dest.DestinationId == id)
                    .FirstOrDefault();
                context.Destinations.Remove(destination);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
