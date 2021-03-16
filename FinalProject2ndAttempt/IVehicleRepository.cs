using FinalProject2ndAttempt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject2ndAttempt
{
    public interface IVehicleRepository
    {
        public IEnumerable<StockInventory> GetAllVehicles();
        public StockInventory GetVehicle(int id);
        public void UpdateVehicle(StockInventory vehicle);
    }
}
