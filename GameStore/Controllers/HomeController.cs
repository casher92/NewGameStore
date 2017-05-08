using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GameStore.DAL;
using GameStore.ViewModels;

namespace GameStore.Controllers
{
    public class HomeController : Controller
    {
        private StoreContext db = new StoreContext();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            IQueryable<PurchaseDateGroup> data = from customer in db.Customers
                      group customer by customer.PurchaseDate into dateGroup
                      select new PurchaseDateGroup()
                      {
                          PurchaseDate = dateGroup.Key,
                          PurchaseCount = dateGroup.Count()
                      };
            return View(data.ToList());
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Our Location and Email";

            return View();
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}