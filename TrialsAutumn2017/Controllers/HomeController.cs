using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrialsAutumn2017.Models;

namespace TrialsAutumn2017.Controllers
{
    public class HomeController : Controller
    {
        TestPrivatePartsDb db = new TestPrivatePartsDb();
        public ActionResult Index()
        {
            var res = new Reservation
            {
                CreatedTime = DateTime.Parse("2017-10-01"),
                Price = 10.50m,
                Time = DateTime.Parse("2017-10-05")
            };
            res.UpdateMyStatus(ReservationStatus.Pending);

            db.Reservations.Add(res);
            db.SaveChanges();
            return View();
        }

        public ActionResult About()
        {
            var res = db.Reservations.FirstOrDefault();
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            db.Reservations.Remove(db.Reservations.FirstOrDefault());
            var result = db.SaveChanges();
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}