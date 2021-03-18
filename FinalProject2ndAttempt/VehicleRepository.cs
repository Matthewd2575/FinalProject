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
            return _conn.Query<StockInventory>("SELECT S.stocknumber, s.Year, s.Make, s.Model, s.status, s.Daysininventory, s.Price, s.Carcondition, s.Suggestedmsrp, s.Mileage, s.vin, s.interiorcolor, s.exteriorcolor, s.seats, d.drivetrain, c.vehicleclass from stockinventory as s left outer join classification as c on s.categoryid = c.categoryid left outer join drivetrain as d on s.drivetrainid = d.drivetrainid;");
        }
        public StockInventory GetVehicle(int id)
        {
            return _conn.QuerySingle<StockInventory>("SELECT S.stocknumber, s.Year, s.Make, s.Model, s.status, s.Daysininventory, s.Price, s.Carcondition, s.Suggestedmsrp, s.Mileage, s.vin, s.interiorcolor, s.exteriorcolor, s.seats, d.drivetrain, c.vehicleclass from stockinventory as s left outer join classification as c on s.categoryid = c.categoryid left outer join drivetrain as d on s.drivetrainid = d.drivetrainid WHERE s.StockNumber = @id;", 
                new { id = id });
        }
        public void UpdateVehicle(StockInventory vehicle)
        {
            _conn.Execute("UPDATE StockInventory SET VIN = @vin, Year = @year, Make = @make, Model = @model, ExteriorColor = @exteriorcolor, InteriorColor = @interiorcolor, Seats = @seats, Status = @status, DaysInInventory = @daysininventory, Price = @price, CarCondition = @carcondition, SuggestedMSRP = @suggestedmsrp, Mileage = @mileage, CategoryID = @categoryid, DriveTrainID = @drivetrainid WHERE StockNumber = @id;",
                new { vin = vehicle.VIN, year = vehicle.Year, make = vehicle.Make, model = vehicle.Model, exteriorcolor = vehicle.ExteriorColor, interiorcolor = vehicle.InteriorColor, seats = vehicle.Seats, status = vehicle.Status, daysininventory = vehicle.DaysInInventory, price = vehicle.Price, carcondition = vehicle.CarCondition, suggestedMSRP = vehicle.SuggestedMSRP, mileage = vehicle.Mileage, categoryid = vehicle.CategoryID, drivetrainid = vehicle.DriveTrainID, id = vehicle.StockNumber });
        }
        public void InsertVehicle(StockInventory vehicleToInsert) 
        {
            _conn.Execute("INSERT INTO StockInventory (VIN, Year, Make, Model, ExteriorColor, InteriorColor, Seats, Status, DaysInInventory, Price, CarCondition, SuggestedMSRP, Mileage, CategoryID, DrivetrainID) VALUES (@vin, @year, @make, @model, @exteriorcolor, @interiorcolor, @seats, @status, @daysininventory, @price, @carcondition, @suggestedmsrp, @mileage, @categoryID, @drivetrainID);",
                new
                {
                    vin = vehicleToInsert.VIN,
                    year = vehicleToInsert.Year,
                    make = vehicleToInsert.Make,
                    model = vehicleToInsert.Model,
                    exteriorcolor = vehicleToInsert.ExteriorColor,
                    interiorcolor = vehicleToInsert.InteriorColor,
                    seats = vehicleToInsert.Seats,
                    status = vehicleToInsert.Status,
                    daysininventory = vehicleToInsert.DaysInInventory,
                    price = vehicleToInsert.Price,
                    carcondition = vehicleToInsert.CarCondition,
                    suggestedmsrp = vehicleToInsert.SuggestedMSRP,
                    mileage = vehicleToInsert.Mileage,
                    categoryID = vehicleToInsert.CategoryID,
                    drivetrainID = vehicleToInsert.DriveTrainID
                    
                });
        }
        public IEnumerable<VehicleClassification> GetVehicleClasses() //added this 1st
        {
            return _conn.Query<VehicleClassification>("SELECT * FROM vehicleinventory.classification;");
        }
        public StockInventory AssignVehicle()//added this 1st
        {
            var vehicleList = GetVehicleClasses();
            var vehicle = new StockInventory();
            vehicle.VehicleClasses = vehicleList;

            return vehicle;
        }
        public IEnumerable<DriveTrainClassification> GetDriveTrains()//added this 2nd
        {
            return _conn.Query<DriveTrainClassification>("SELECT * FROM vehicleinventory.drivetrain;");
        }
        public void AssignDriveTrain(StockInventory vehicle) //added this 2nd
        {
            var driveTrainList = GetDriveTrains();
            //var vehicle2 = new StockInventory();
            vehicle.DriveTrains = driveTrainList;

            //return vehicle2;
        }
        public void DeleteVehicle(StockInventory vehicle)
        {

            _conn.Execute("DELETE FROM stockinventory WHERE stocknumber = @id;",
                                       new { id = vehicle.StockNumber });
        }
    }
}
