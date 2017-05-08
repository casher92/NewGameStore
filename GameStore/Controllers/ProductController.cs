using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GameStore.DAL;
using GameStore.Models;
using System.Data.Entity.Infrastructure;
namespace GameStore.Controllers
{
    [Authorize]
    public class ProductController : Controller
    {
        private StoreContext db = new StoreContext();

        // GET: Product
        public ActionResult Index(string sortOrder, string searchString)
        {
            ViewBag.NameSortParm = string.IsNullOrEmpty(sortOrder) ? "name-desc" : "";
            ViewBag.DateSortParm = sortOrder == "ProductID" ? "productID-desc" : "";

            var products = from c in db.Products select c;

            if (!String.IsNullOrEmpty(searchString))
            {
                products = products.Where(c => c.ProductName.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "name-desc":
                    products = products.OrderByDescending(c => c.ProductName);
                    break;
                case "Date":
                    products = products.OrderBy(c => c.ProductID);
                    break;
                case "productID-desc":
                    products = products.OrderByDescending(c => c.ProductID);
                    break;
                default:
                    products = products.OrderBy(c => c.ProductName);
                    break;
            }

            return View(products.ToList());
        }

        public ActionResult Create([Bind(Include = "ProductName,ProductID,Customer")] Product product)
        {
            try
            {


                if (ModelState.IsValid)
                {
                    db.Products.Add(product);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                ModelState.AddModelError("", "Unable to save changes!");
            }
            return View(product);
        }
    }
}