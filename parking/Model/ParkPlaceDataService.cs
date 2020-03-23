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
    class ParkPlaceDataService
    {
        // Ophalen ConnectionString uit App.config
        private static string connectionString = ConfigurationManager.ConnectionStrings["azure"].ConnectionString;

        // Aanmaken van een object uit de IDbConnection class en instantiëren van een SqlConnection.
        // Dit betekent dat de connectie met de database automatisch geopend wordt.
        private static IDbConnection db = new SqlConnection(connectionString);


        public ObservableCollection<ParkPlace> GetParkPlace()
        {
            // Uitschrijven SQL statement & bewaren in een string. 
            string sql = "Select * from ParkPlace order by Id";

            //Uitvoeren SQL statement op db instance 
            //Type casten van het generieke return type naar een collectie van contactpersonen
            ObservableCollection<ParkPlace> parkPlaces = db.Query<ParkPlace>(sql).ToObservableCollection();

            return parkPlaces;
        }

        public void UpdateParkPlace(ParkPlace parkplace)
        {
            // SQL statement update 
            string sql = "Update ParkPlace set parkingId=@parkinId, buildingId=@buildingId, row=@row, cel=@cel, description=@description where Id = @id";

            // Uitvoeren SQL statement en doorgeven parametercollectie
            db.Execute(sql, new { parkplace.ParkingId, parkplace.BuildingId, parkplace.Row, parkplace.Cel, parkplace.Description, parkplace.Id });
        }

        public void DeleteParkPlace(ParkPlace parkplace)
        {
            // SQL statement delete 
            string sql = "Delete ParkPlace where Id = @id";

            // Uitvoeren SQL statement en doorgeven parametercollectie
            db.Execute(sql, new { parkplace.Id });
        }

        public void InsertParkPlace(ParkPlace parkplace)
        {
            // SQL statement Insert 
            string sql = "Insert Lecture(parkingId,buildingId,row,cel,description) values(@parkingId,@buildingId,@row,@cel,@description)";

            // Uitvoeren SQL statement en doorgeven parametercollectie
            db.Execute(sql, new { parkplace.ParkingId, parkplace.BuildingId, parkplace.Row, parkplace.Cel, parkplace.Description });
        }
    }
}
