using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCRUD.Models;
using System.Data.Entity;

namespace MvcCRUD.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer/Index
        public ActionResult Index()
        {
            using(DBModels dBModels = new DBModels())
            {
                //to get all the customer data into view 
                return View(dBModels.customers.ToList());
            }
        }

        // GET: Customer/Details/5
        public ActionResult Details(int id)
        {
            //To get the details of the customer after clicking on the details button
            using (DBModels dBModels = new DBModels())
            {
                return View(dBModels.customers.Where(x => x.customerId == id).FirstOrDefault());
            }
        }

        // GET: Customer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customer/Create
        [HttpPost]
        public ActionResult Create(customer customer)
        {
            try
            {
                // TODO: Add insert logic here
                using(DBModels dBModels = new DBModels())
                {
                    dBModels.customers.Add(customer);
                    dBModels.SaveChanges();
                }
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
            //To edit the details of the customer after clicking on the edit button
            using (DBModels dBModels = new DBModels())
            {
                return View(dBModels.customers.Where(x => x.customerId == id).FirstOrDefault());
            }
        }

        //after editing it will goes to the https post edit and from there it will save it into the index 
        // POST: Customer/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, customer customer)
        {
            try
            {
                // TODO: Add update logic here
                using(DBModels dBModels = new DBModels())
                {
                    dBModels.Entry(customer).State = EntityState.Modified;
                    dBModels.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Customer/Delete/5
        public ActionResult Delete(int id)
        {
            //To delete the details of the customer after clicking on the delete button
            using (DBModels dBModels = new DBModels())
            {
                return View(dBModels.customers.Where(x => x.customerId == id).FirstOrDefault());
            }
        }

        // POST: Customer/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                using (DBModels dBModels = new DBModels())
                {
                    customer customer =  (dBModels.customers.Where(x => x.customerId == id).FirstOrDefault());
                    dBModels.customers.Remove(customer);
                    dBModels.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
