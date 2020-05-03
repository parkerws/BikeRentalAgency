using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using BikeRentalAgency.Models;
using BikeRentalMVC.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BikeRentalMVC.Controllers
{
    public class AdminController : Controller
    {
        private string baseUrl = "https://localhost:44354/admin/";

        private IAdminRepository repo;
        public AdminController(IAdminRepository repository)
        {
            repo = repository;
        }
        [HttpGet("Employee")]
        public async Task<ActionResult> EmployeeIndex()
        {
            var model = await repo.GetEmployees();
            return View(model);
        }

        [HttpGet("Employees/{id}")]
        public async Task<ActionResult> EmployeeDetails(int id)
        {
            var employee = await repo.GetEmployee(id);
            return View(employee);
        }

        [HttpGet("Bikes")]
        public async Task<ActionResult> BikeIndex()
        {
            var model = await repo.GetBikes();
            return View(model);
        }

        [HttpGet("Locations")]
        public async Task<ActionResult> LocationsIndex(int? id)
        {
            var model = await repo.GetLocations(id);
            return View(model);
        }

        [HttpGet("Bikes/{id}")]
        public async Task<ActionResult> BikeDetails(int id)
        {
            var bike = await repo.GetBike(id);
            return View(bike);
        }

        // GET: Admin/Create
        [HttpPost("Employees")]
        public async Task<IActionResult> EmployeeCreate(Employees employee)
        {

            TempData["message"] = string.Empty;
            string message;
            if (employee == null) return View(new Employees());

            bool succeeded = await repo.AddEmployee(employee);
            if (succeeded)
            {
                return RedirectToAction("EmployeeIndex");
            }

            return View(employee);

        }

        [HttpPost("Bikes")]
        public async Task<IActionResult> BikeCreate(Bikes bike)
        {

            TempData["message"] = string.Empty;
            string message;
            if (bike == null) return View(new Bikes());

            bool succeeded = await repo.AddBike(bike);
            if (succeeded)
            {
                return RedirectToAction("BikeIndex");
            }

            return View(bike);

        }


        //// GET: Admin/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: Admin/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add delete logic here

        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}