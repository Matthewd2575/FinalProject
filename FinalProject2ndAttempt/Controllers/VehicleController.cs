using FinalProject2ndAttempt.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject2ndAttempt.Controllers
{
    public class VehicleController : Controller
    {
        private readonly IVehicleRepository repo;
        public VehicleController(IVehicleRepository repo)
        {
            this.repo = repo;
        }
        public IActionResult Index()
        {
            var vehicles = repo.GetAllVehicles();
            return View(vehicles);
        }
        public IActionResult ViewVehicle(int id)
        {
            var vehicle = repo.GetVehicle(id);

            return View(vehicle);
        }
        public IActionResult UpdateVehicle(int id)
        {
            StockInventory prod = repo.GetVehicle(id);

            prod.VehicleClasses = repo.GetVehicleClasses();
            
            repo.AssignDriveTrain(prod); 

            if (prod == null)
            {
                return View("VehicleNotFound");
            }

            return View(prod);
        }
        public IActionResult UpdateVehicleToDatabase(StockInventory vehicle)
        {
            repo.UpdateVehicle(vehicle);

            return RedirectToAction("ViewVehicle", new {id = vehicle.StockNumber});
        }
        public IActionResult InsertVehicle()
        {
            var prod = repo.AssignVehicle();
            repo.AssignDriveTrain(prod); 

            return View(prod);
        }
        public IActionResult InsertVehicleToDatabase(StockInventory vehicleToInsert)
        {
            repo.InsertVehicle(vehicleToInsert);

            return RedirectToAction("Index");
        }
        public IActionResult DeleteVehicle(StockInventory vehicle)
        {
            repo.DeleteVehicle(vehicle);

            return RedirectToAction("Index");
        }
        public IActionResult Search(string searchString)
        {
            var search = repo.SearchVehicle(searchString);
            return View(search);
        }
    }
}
