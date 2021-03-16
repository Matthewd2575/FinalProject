using Dapper;
using FinalProject2ndAttempt.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject2ndAttempt
{
    public class VehicleRepository : IVehicleRepository
    {
        private readonly IDbConnection _conn;
        public VehicleRepository(IDbConnection conn)
        {
            _conn = conn;
        }
        public IEnumerable<StockInventory> GetAllVehicles()
        {
            return _conn.Query<StockInventory>("SELECT s.*, VehicleClass from stockinventory as s inner join classification as c on s.categoryid = c.categoryid; ");
        }
        public StockInventory GetVehicle(int id)
        {
            return _conn.QuerySingle<StockInventory>("SELECT * FROM StockInventory WHERE StockNumber = @id",
                new { id = id });
        }
        public void UpdateVehicle(StockInventory vehicle)
        {
            _conn.Execute("UPDATE StockInventory SET VIN = @vin, Year = @year, Make = @make, Model = @model, ExteriorColor = @exteriorcolor, InteriorColor = @interiorcolor, Seats = @seats, Status = @status, DaysInInventory = @daysininventory, Price = @price, CarCondition = @carcondition, SuggestedMSRP = @suggestedmsrp, Mileage = @mileage WHERE StockNumber = @id",
                new { vin = vehicle.VIN, year = vehicle.Year, make = vehicle.Make, model = vehicle.Model, exteriorcolor = vehicle.ExteriorColor, interiorcolor = vehicle.InteriorColor, seats = vehicle.Seats, status = vehicle.Status, daysininventory = vehicle.DaysInInventory, price = vehicle.Price, carcondition = vehicle.CarCondition, suggestedMSRP = vehicle.SuggestedMSRP, mileage = vehicle.Mileage, id = vehicle.StockNumber });
        }
    }
}
