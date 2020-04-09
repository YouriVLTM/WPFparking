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

        public ParkingsView GetParkingsView()
        {
            string sql = "Select * From ParkPlace pa " +
                "JOIN Parking pr ON pr.Id = pa.parkingId " +
                "JOIN Building bu ON bu.Id = pa.buildingId";

            var park = db.Query<ParkPlace, Parking, Building, ParkPlace > (sql, (parkPlace, parking, building) =>
            {
                parkPlace.Parking = parking;
                parkPlace.Building = building;

                return parkPlace;
            },
           splitOn: "Id").ToObservableCollection();

            // all parkings
            ObservableCollection<Parking> parkings = park.GroupBy(x => x.Parking.Id)
                .Select(y => y.FirstOrDefault().Parking)
                .ToObservableCollection();

            //new
            ParkingsView parkingsview = new ParkingsView();
            ParkingView parkingView;
            ObservableCollection<int> parkingRows;
            ParkingRowView parkingRowView;
            ObservableCollection<ParkPlace> parkingRow;
            ParkPlaceView parkPlaceView;

            // voeg parings toe
            foreach (Parking parking in parkings)
            {
                //new parking 
                parkingView = new ParkingView();
                parkingView.Parking = parking;
                parkingsview.Parkings.Add(parkingView);

                //parkplace rows
                parkingRows = park.Where(T => T.ParkingId == parking.Id)
                   .GroupBy(x => x.Row)
                   .Select(y => y.FirstOrDefault().Row)
                   .ToObservableCollection();

                foreach (int rowNumber in parkingRows)
                {
                    //add Parking rows 
                    parkingRowView = new ParkingRowView();
                    parkingRowView.RowNumber = rowNumber;
                    parkingView.Rows.Add(parkingRowView);


                    parkingRow = park.Where(T => (T.ParkingId == parking.Id && T.Row == rowNumber))
                      .GroupBy(x => x.Id)
                      .Select(y => y.FirstOrDefault())
                      .ToObservableCollection();


                    //rows = new ObservableCollection<ParkPlaceView>();

                    foreach (ParkPlace parkplace in parkingRow)
                    {
                        //ADD row
                        parkPlaceView = new ParkPlaceView(parkplace);
                        parkingRowView.Row.Add(parkPlaceView);
                    }



                }



            }

            return parkingsview;
        }


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

        public ParkPlaceView GetParkPlaceWithFKView(ParkPlace parkPlace)
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
                return new ParkPlaceView(parkPlaces.First());
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
