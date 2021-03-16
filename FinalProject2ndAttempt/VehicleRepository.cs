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
    }
}
