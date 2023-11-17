using Agence_de_Voyages.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Agence_de_Voyages.Controllers
{
    public class VenueController : Controller
    {
        private readonly ApplicationContext context;

        public VenueController(ApplicationContext context)
        {
            this.context = context;
        }
        // GET: VenueController
        public ActionResult Index()
        {
            List<Venue> venues = context.Venues.ToList();
            return View(venues);
        }

        // GET: VenueController/Details/5
        public ActionResult Details(int id)
        {
            Venue? venue = context.Venues
                .Where(v => v.VenueId == id)
                .FirstOrDefault();
            return View(venue);
        }

        // GET: VenueController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VenueController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Venue venue)
        {
            try
            {
                ViewBag.messageerror = "";

                if (ModelState.IsValid)
                { 
                    var existingVenue = context.Venues
                        .Where(v => v.Name == venue.Name)
                        .FirstOrDefault();
                    if (existingVenue != null)
                    {
                        ViewBag.messageerror = "Venue already exists.";

                        return View(venue);
                    }

                    Venue newVenue= new Venue();
                    newVenue.Name = venue.Name;
                    newVenue.Type = venue.Type;
                    newVenue.Rating = venue.Rating;
                    newVenue.CostIndicator = venue.CostIndicator;
                    newVenue.HasFreeWiFi = venue.HasFreeWiFi;
                    newVenue.PricePerNight = venue.PricePerNight;
                    newVenue.CuisineType = venue.CuisineType;
                    newVenue.EntryFee = venue.EntryFee;

                    context.Venues.Add(newVenue);
                    context.SaveChanges();

                    return RedirectToAction(nameof(Index));
                }
                return View(venue);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error when creating a Venue: " + e.Message);
                return RedirectToAction("Error");
            }
        }

        // GET: VenueController/Edit/5
        public ActionResult Edit(int id)
        {
            Venue? venue = context.Venues
             .Where(v => v.VenueId == id)
             .FirstOrDefault();
            return View(venue);
        }

        // POST: VenueController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Venue venue)
        {
            try
            {
                ViewBag.messageerror = "";

                if (ModelState.IsValid)
                {
                    var venueToEdit = context.Venues
                        .Where(v => v.VenueId == id)
                        .FirstOrDefault();
                    if (venueToEdit == null)
                    {
                        ViewBag.messageerror = "Venue does not exists!";

                        return View(venue);
                    }

                    venueToEdit.Name = venue.Name;
                    venueToEdit.Type = venue.Type;
                    venueToEdit.Rating = venue.Rating;
                    venueToEdit.CostIndicator = venue.CostIndicator;
                    venueToEdit.HasFreeWiFi = venue.HasFreeWiFi;
                    venueToEdit.PricePerNight = venue.PricePerNight;
                    venueToEdit.CuisineType = venue.CuisineType;
                    venueToEdit.EntryFee = venue.EntryFee;

                    context.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }
                return View(venue);
                    
            }
            catch (Exception e)
            {
                Console.WriteLine("Error when editing a Venue: " + e.Message);
                return RedirectToAction("Error");
            }
        }

        // GET: VenueController/Delete/5
        public ActionResult Delete(int id)
        {
            var venue = context.Venues
                       .Where(v => v.VenueId == id)
                       .FirstOrDefault();
            return View(venue);
        }

        // POST: VenueController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {

                var venue = context.Venues
                           .Where(v => v.VenueId == id)
                           .FirstOrDefault();
                context.Venues.Remove(venue);
                context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch(Exception e)
            {
                Console.WriteLine("Error when deleting a Venue: " + e.Message);
                return RedirectToAction("Error");
            }
        }
    }
}
