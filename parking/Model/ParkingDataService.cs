using Dapper;
using parking.Extensions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace parking.Model
{
    public class ParkingDataService: BaseModelDataService
    { 

        public ObservableCollection<Parking> GetParking()
        {
            // Uitschrijven SQL statement & bewaren in een string. 
            string sql = "Select * from Pakring order by Id";

            //Uitvoeren SQL statement op db instance 
            //Type casten van het generieke return type naar een collectie van contactpersonen
            ObservableCollection<Parking> parkings = db.Query<Parking>(sql).ToObservableCollection();

            return parkings;
        }

        public void UpdateParking(Parking parking)
        {
            // SQL statement update 
            string sql = "Update Parking set name=@name where Id = @id";

            // Uitvoeren SQL statement en doorgeven parametercollectie
            db.Execute(sql, new { parking.Name, parking.Id });
        }

        public void DeleteParking(Parking parking)
        {
            // SQL statement delete 
            string sql = "Delete Parking where Id = @id";

            // Uitvoeren SQL statement en doorgeven parametercollectie
            db.Execute(sql, new { parking.Id });
        }

        public void InsertParking(Parking parking)
        {
            // SQL statement Insert 
            string sql = "Insert Parking(name) values(@name)";

            // Uitvoeren SQL statement en doorgeven parametercollectie
            db.Execute(sql, new { parking.Name });
        }
    }
}
