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
            return _conn.Query<StockInventory>("SELECT S.stocknumber, s.Year, s.Make, s.Model, s.status, s.Daysininventory, s.Price, s.Carcondition, s.Suggestedmsrp, s. Mileage, s.vin, s.interiorcolor, s.exteriorcolor, s.seats, d.drivetrain, c.vehicleclass from stockinventory as s left outer join classification as c on s.categoryid = c.categoryid left outer join drivetrain as d on s.drivetrainid = d.drivetrainid;");
        }
        public StockInventory GetVehicle(int id)
        {
            return _conn.QuerySingle<StockInventory>("SELECT S.stocknumber, s.Year, s.Make, s.Model, s.status, s.Daysininventory, s.Price, s.Carcondition, s.Suggestedmsrp, s. Mileage, s.vin, s.interiorcolor, s.exteriorcolor, s.seats, d.drivetrain, c.vehicleclass from stockinventory as s left outer join classification as c on s.categoryid = c.categoryid left outer join drivetrain as d on s.drivetrainid = d.drivetrainid WHERE StockNumber = @id",
                new { id = id });
        }
        public void UpdateVehicle(StockInventory vehicle)
        {
            _conn.Execute("UPDATE StockInventory SET VIN = @vin, Year = @year, Make = @make, Model = @model, ExteriorColor = @exteriorcolor, InteriorColor = @interiorcolor, Seats = @seats, Status = @status, DaysInInventory = @daysininventory, Price = @price, CarCondition = @carcondition, SuggestedMSRP = @suggestedmsrp, Mileage = @mileage, CategoryID = @categoryid, DriveTrainID = @drivetrainid WHERE StockNumber = @id",
                new { vin = vehicle.VIN, year = vehicle.Year, make = vehicle.Make, model = vehicle.Model, exteriorcolor = vehicle.ExteriorColor, interiorcolor = vehicle.InteriorColor, seats = vehicle.Seats, status = vehicle.Status, daysininventory = vehicle.DaysInInventory, price = vehicle.Price, carcondition = vehicle.CarCondition, suggestedMSRP = vehicle.SuggestedMSRP, mileage = vehicle.Mileage, categoryid = vehicle.CategoryID, drivetrainid = vehicle.DriveTrainID, id = vehicle.StockNumber });
        }
    }
}
