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
    }
}
