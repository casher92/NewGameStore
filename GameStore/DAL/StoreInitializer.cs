using GameStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GameStore.DAL
{
    public class StoreInitializer : System.Data.Entity. DropCreateDatabaseIfModelChanges<StoreContext>
    {
        protected override void Seed(StoreContext context)

        {

            var customers = new List<Customer>

            {

                new Customer{FirstName = "Carson", LastName = "Alexander", PurchaseDate=DateTime.Parse("2005-09-01")},

                new Customer{FirstName = "James", LastName = "TheJSWIzard", PurchaseDate=DateTime.Parse("2005-09-01")}

            };

            customers.ForEach(c => context.Customers.Add(c));

            context.SaveChanges();



            var products = new List<Product>

            {

                new Product{ProductName="BattleField1", Price = 40.45M, UPC = 20098, Inventory = 13}

            };



            products.ForEach(s => context.Products.Add(s));

            context.SaveChanges();



            var purchases = new List<Purchase>

            {

                new Purchase{CustomerID = 1220, PurchaseID = 2, EmployeeID = 233, ProductID = 3002}

            };

        }
    }
}