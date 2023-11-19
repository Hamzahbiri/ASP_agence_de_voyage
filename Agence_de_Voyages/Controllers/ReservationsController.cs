using Agence_de_Voyages.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Agence_de_Voyages.Controllers
{
    public class ReservationsController : Controller
    {
        private ApplicationContext context;

        public ReservationsController(ApplicationContext context)
        {
            this.context = context;
        }
        // GET: ReservationController
        public ActionResult Index()
        {
            List<Reservation> reservations = context.Reservations.ToList();
            return View(reservations);
        }

        // GET: ReservationController/Details/5
        public ActionResult Details(int id)
        {
            Reservation? reservation = context.Reservations
                .Where(r => r.ReservationId == id)
                .FirstOrDefault();
            return View(reservation);
        }

        // GET: ReservationController/Create
        public ActionResult Create()
        {
            ViewBag.Tours = context.Tours.ToList();
            return View();
        }

        // POST: ReservationController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Reservation reservation)
        {
            try
            {
                ViewBag.messageerror = "";

                if (ModelState.IsValid)
                {

                  
                    Reservation r = new Reservation();
                    r.Tour = reservation.Tour;
                    r.SubmissionDate = reservation.SubmissionDate;
                    r.ReviewDate = reservation.ReviewDate;
                    r.IsReviewed = reservation.IsReviewed;
                    r.IsDepositPaid = reservation.IsDepositPaid;
                    r.DepositAmount = reservation.DepositAmount;

                    context.Reservations.Add(r);
                    context.SaveChanges();

                    return RedirectToAction(nameof(Index));
                }

                return View(reservation);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error when creating reservation: ", e);
                return RedirectToAction("Error");
            }
        }

        // GET: ReservationController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ReservationController/Edit/5
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

        // GET: ReservationController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ReservationController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
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
