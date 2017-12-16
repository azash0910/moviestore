using MovieStore.Context;
using MovieStore.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace MovieStore.Controllers
{
    public class CustomerController : Controller
    {
        MovieContext db = new MovieContext();

        public ActionResult Index(string sort)
        {
            var customers = from s in db.Customers
                         select s;

            try
            {
                ViewBag.Order = sort.Split('_')[1];
            }
            catch
            {
                ViewBag.Order = "desc";
            }

            switch (sort)
            {
                case "firstname_desc":
                    customers = customers.OrderByDescending(s => s.Firstname);
                    break;
                case "firstname_asc":
                    customers = customers.OrderBy(s => s.Firstname);
                    break;
                case "lastname_desc":
                    customers = customers.OrderByDescending(s => s.Lastname);
                    break;
                case "lastname_asc":
                    customers = customers.OrderBy(s => s.Lastname);
                    break;
                default:
                    customers = customers.OrderBy(s => s.Lastname);
                    break;
            }

            return View(customers.ToList());
        }

        // GET: Customer/Details/5
        public ActionResult Details(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            CustomerModel customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);

        }

        // GET: Customer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customer/Create
        [HttpPost]
        public ActionResult Create(CustomerModel customer)
        {
            try
            {
                db.Customers.Add(customer);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Customer/Edit/5
        public ActionResult Edit(int id)
        {
            CustomerModel customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Customer/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, CustomerModel customer)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(customer).State = EntityState.Modified;
                    db.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Customer/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerModel customer = db.Customers.Find(id);

            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Customer/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                CustomerModel customer = db.Customers.Find(id);
                db.Customers.Remove(customer);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
