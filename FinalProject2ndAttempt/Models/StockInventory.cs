using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject2ndAttempt.Models
{
    public class StockInventory
    {
        public StockInventory()
        {
        }
        public int StockNumber { get; set; }
        public int Year { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string Status { get; set; }
        public int DaysInInventory { get; set; }
        public double Price { get; set; }
        public string CarCondition { get; set; }
        public double SuggestedMSRP { get; set; }
        public int Mileage { get; set; }
        public int CategoryID { get; set; }
        public int DriveTrainID { get; set; }
        public string VIN { get; set; }
        public string InteriorColor { get; set; }
        public string ExteriorColor { get; set; }
        public int Seats { get; set; }
        public string VehicleClass { get; set; } //added this
        public string DriveTrain { get; set; }
    }
}
