using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BikeRentalAgency.Models;
using BikeRentalMVC.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BikeRentalMVC.Controllers
{
    public class CustomerController : Controller
    {

        private ICustomerRepository repo;
        public CustomerController(ICustomerRepository repository)
        {
            repo = repository;
        }

        // GET: Customer
        public ActionResult Index()
        {
            return View();
        }

        // GET: Customer/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Customer/Create
        [HttpGet("Customer")]
        public async Task<ActionResult> CreateCustomer()
        {
            return View();
        }

        // POST: Customer/Create
        [HttpPost("Customer")]
        public async Task<ActionResult> CreateCustomer(Customer customer)
        {
            TempData["message"] = string.Empty;
            if (customer == null) return View(new Customer());

            bool succeeded = await repo.AddCustomer(customer);
            if (succeeded)
            {
                return RedirectToAction("Index");
            }

            return View(customer);

        }

        

        


        // GET: Customer/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Customer/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Customer/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Customer/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}