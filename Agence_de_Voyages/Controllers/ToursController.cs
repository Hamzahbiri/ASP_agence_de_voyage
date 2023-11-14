using Agence_de_Voyages.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Agence_de_Voyages.Controllers
{
    public class ToursController : Controller
    {
        private readonly ApplicationContext context;

        public ToursController(ApplicationContext context)
        {
            this.context = context;
        }

        // GET: ToursController
        public ActionResult Index()
        {
            List<Tour> Tours = context.Tours.ToList();
            return View(Tours);
        }

        // GET: ToursController/Details/5
        public ActionResult Details(int id)
        {
            Tour Tours = context.Tours.Where(x => x.TourId == id).FirstOrDefault();

            return View(Tours);
        }

        // GET: ToursController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ToursController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Tour Tours )
        {
            try
            {
                ViewBag.messageerror = "";

                if (ModelState.IsValid)
                {
                  
                    var existingTour = context.Tours.FirstOrDefault(x => x.Name == Tours.Name);

                    if (existingTour != null)
                    {
                        ViewBag.messageerror = "Tour already exists.";

                        return View(Tours);
                    }

                    Tour t = new Tour();
                    t.Name = Tours.Name;
                    t.Location = Tours.Location;
                    t.Date_of_departure=Tours.Date_of_departure;
                    t.Venues = Tours.Venues;    
                    t.Destinations = Tours.Destinations;    
                    t.Days_number = Tours.Days_number;  
                    t.Image = Tours.Image;  
                    t.Price = Tours.Price;  
                                     

                    context.Tours.Add(t);
                    context.SaveChanges();

                    return RedirectToAction(nameof(Index));
                }

                return View(Tours);
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

        // GET: ToursController/Edit/5
        public ActionResult Edit(int id)
        {
            Tour Tours = context.Tours.Where(x => x.TourId == id).FirstOrDefault();
            return View(Tours);
        }

        // POST: ToursController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Tour editedTour)
        {
            try
            {
                if (ModelState.IsValid)
                {
                 
                    var TourToEdit = context.Tours.FirstOrDefault(x => x.TourId == id);

                    if (TourToEdit == null)
                    {
                        
                        return RedirectToAction("Index");
                    }


                    TourToEdit.Name = editedTour.Name;
                    TourToEdit.Location = editedTour.Location;
                    TourToEdit.Date_of_departure = editedTour.Date_of_departure;
                    TourToEdit.Venues = editedTour.Venues;
                    TourToEdit.Destinations = editedTour.Destinations;
                    TourToEdit.Days_number = editedTour.Days_number;
                    TourToEdit.Image = editedTour.Image;
                    TourToEdit  .Price = editedTour.Price;

                    // Save the changes to the database
                    context.SaveChanges();

                    return RedirectToAction(nameof(Index));
                }

                return View(editedTour);
            }
            catch (Exception ex)
            {
                // Log the exception for debugging
                Console.WriteLine("Error: " + ex.Message);
                // Redirect to an error page or action
                return RedirectToAction("Error");
            }
        }

        // GET: ToursController/Delete/5
        public ActionResult Delete(int id)
        {
            Tour Tours = context.Tours.Where(x => x.TourId == id).FirstOrDefault();
            return View(Tours); 
        }

        // POST: ToursController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {

            try
            {
                Tour Tours = context.Tours.Where(x => x.TourId == id).FirstOrDefault();
                context.Tours.Remove(Tours);
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

