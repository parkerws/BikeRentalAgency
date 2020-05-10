using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using BikeRentalAgency.Models;
using BikeRentalMVC.Repository;
using BikeRentalMVC.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BikeRentalMVC.Controllers
{
    public class AdminController : Controller
    {

        private IAdminRepository repo;
        public AdminController(IAdminRepository repository)
        {
            repo = repository;
        }


        [HttpGet("Employees")]
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

        [HttpGet("GetBikes")]
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

        // GET: Reservation/Create
        [HttpGet("NewReservation")]
        public async Task<ActionResult> NewReservation()
        {
            var bikes = await repo.GetBikes();
            return View(bikes);
        }

        [HttpGet("Reservation")]
        public async Task<ActionResult> ConfirmReservation(Bikes bike)
        {
            ReservationCreateViewModel reserve = new ReservationCreateViewModel {Bike = bike};

            return View("Reservation", reserve);
        }

        // POST: Reservation/Create
        [HttpPost("Reserve")]
        public async Task<ActionResult> Reserve(ReservationCreateViewModel res)
        {
            TempData["message"] = string.Empty;
            //if (res == null) return View(new ReservationCreateViewModel());
            Reservations reserve = new Reservations
            {
                Bikes = res.Bike,
                BeginDate = res.BeginDate,
                EndDate = res.EndDate

            };



            bool succeeded = await repo.AddReservation(reserve);
            //if (succeeded)
            //{
            //    return RedirectToAction("NewReservation");
            //}

            //return View("BikeIndex");
            return RedirectToAction("ReserveComplete");

        }

        [HttpGet("ReserveComplete")]
        public ActionResult ReserveComplete()
        {
            return View();
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