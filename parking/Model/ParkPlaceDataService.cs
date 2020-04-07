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
    public class ParkPlaceDataService : BaseModelDataService
    {


        public ObservableCollection<ParkPlace> GetParkPlace()
        {
            // Uitschrijven SQL statement & bewaren in een string. 
            string sql = "Select * from ParkPlace pp JOIN Building bu ON pp.buildingId = bu.Id JOIN Parking pa ON pp.parkingId = pa.Id Order By parkingId,row,cel";

            //Uitvoeren SQL statement op db instance 
            //Type casten van het generieke return type naar een collectie van contactpersonen
            var parkPlaces = db.Query<ParkPlace, Building, Parking, ParkPlace>(sql, (parkPlace, building, parking) =>
            {
                parkPlace.Parking = parking;
                parkPlace.Building = building;
                return parkPlace;
            },
            splitOn: "Id");

            return new ObservableCollection<ParkPlace>((List<ParkPlace>)parkPlaces);
        }

        public ParkPlace GetParkPlaceWithFK(ParkPlace parkPlace)
        {
            // Uitschrijven SQL statement & bewaren in een string. 
            string sql = "Select * from ParkPlace pp JOIN Building bu ON pp.buildingId = bu.Id JOIN Parking pa ON pp.parkingId = pa.Id " +
                "Where pp.Id = '" + parkPlace.Id + "' " +
                "Order By parkingId,row,cel";

            //Uitvoeren SQL statement op db instance 
            //Type casten van het generieke return type naar een collectie van contactpersonen
            var parkPlaces = db.Query<ParkPlace, Building, Parking, ParkPlace>(sql, (parkPlac, building, parking) =>
            {
                parkPlac.Parking = parking;
                parkPlac.Building = building;
                return parkPlac;
            },
            splitOn: "Id");

            if(parkPlaces != null)
            {
                return parkPlaces.First();
            }
            return null;
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
