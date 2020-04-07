﻿using Dapper;
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
    public class ReservationDataService : BaseModelDataService
    {


        public ObservableCollection<Reservation> GetReservation()
        {
            // Uitschrijven SQL statement & bewaren in een string. 
            string sql = "Select * from Reservation order by Id";

            //Uitvoeren SQL statement op db instance 
            //Type casten van het generieke return type naar een collectie van contactpersonen
            ObservableCollection<Reservation> reservations = db.Query<Reservation>(sql).ToObservableCollection();

            return reservations;
        }

        public ParkPlace GetMostReservedParkingPlace()
        {
            string sql = "Select * " +
                "From ParkPlace pp " +
                "JOIN Parking pa ON pa.Id = pp.parkingId " +
                "JOIN Building bu ON bu.Id = pp.buildingId " +
                "WHERE pp.Id = ( " +
                    "Select TOP 1 re.parkPlaceId " +
                    "From Reservation re " +
                    "GROUP BY re.parkPlaceId " +
                    "ORDER BY Count(parkPlaceId) DESC " +
                 ")";


            var park= db.Query<ParkPlace,Parking,Building,ParkPlace>(sql,(parkPlace, parking, building) =>
            {
                parkPlace.Parking = parking;
                parkPlace.Building = building;
                return parkPlace;
            },
            splitOn: "Id").First();

            return park;
        }


        public User GetMostReservedUser()
        {
            string sql = "Select * From Userx u " +
                "where u.Id = ( " +
                    "Select TOP 1 re.userId " +
                    "From Reservation re " +
                    "GROUP BY re.userId " +
                    "ORDER BY Count(userId) DESC " +
                ")";


           User user = db.Query<User>(sql).First();

            return user;
        }

        public List<Graph<string,int>> GetCountReservationEveryDay()
        {
            string sql = "set datefirst 1;" +
                "Select DATENAME(WEEKDAY, re.beginTime) as xvalue, count(*) as yvalue from Reservation re " +
                "GROUP BY DATENAME(WEEKDAY, re.beginTime),DATEPART(WEEKDAY, re.beginTime) " +
                "ORDER BY DATEPART(WEEKDAY, re.beginTime)";

            var result = db.Query<Graph<string,int>>(sql).ToList();

            return result;

        }        

        public ObservableCollection<Reservation> GetReservationParkPlace(ParkPlace parkPlace)
        {
            // Uitschrijven SQL statement & bewaren in een string. 
            string sql = "Select * From Reservation re " +
                "INNER JOIN Userx us ON us.id = re.userId " +
                "Where parkPlaceId = '" + parkPlace.Id + "' " +
                "ORDER BY beginTime DESC";

            //Uitvoeren SQL statement op db instance 
            //Type casten van het generieke return type naar een collectie van contactpersonen
            var reservations = db.Query<Reservation, User, Reservation>(sql, (reservation, user) =>
             {
                 reservation.User = user;
                 return reservation;
             },
            splitOn: "Id");

            return new ObservableCollection<Reservation>(reservations);
        }


        public ParkPlace GetNewParkPlaces(Reservation reservation, String location)
        {
            // Uitschrijven SQL statement & bewaren in een string. 
            string sql = "Select TOP 1 PERCENT pa.* from Reservation res " +
                "RIGHT JOIN ParkPlace pa ON pa.id = res.parkPlaceId " +
                "JOIN Building bu ON pa.buildingId = bu.Id " +
                "Where " +
                "bu.location ='" + location + "' "+
                "AND " +
                "( " +
                "res.beginTime NOT BETWEEN CONVERT(datetime, '"+ reservation.BeginTime + "') AND CONVERT(datetime, '" + reservation.EndTime + "') " +
                "OR " +
                "res.beginTime IS NULL " +
                ") " +
                "AND " +
                "( " +
                "res.endTime NOT BETWEEN CONVERT(datetime, '" + reservation.BeginTime + "') AND CONVERT(datetime, '" + reservation.EndTime + "') " +
                "OR " +
                "res.endTime IS NULL " +
                ") " +
                "AND " +
                "pa.Id NOT IN( " +
                "Select pa.Id from Reservation res " +
                "RIGHT JOIN ParkPlace pa ON pa.id = res.parkPlaceId " +
                "JOIN Building bu ON pa.buildingId = bu.Id " +
                "Where " +
                "bu.location ='" + location + "' " +
                "AND " +
                "res.beginTime BETWEEN CONVERT(datetime, '" + reservation.BeginTime + "') AND CONVERT(datetime, '" + reservation.EndTime + "') " +
                "OR " +
                "res.endTime BETWEEN CONVERT(datetime, '" + reservation.BeginTime + "') AND CONVERT(datetime, '" + reservation.EndTime + "') " +
                ") " +
                "ORDER by res.Id";

            //Uitvoeren SQL statement op db instance 
            //Type casten van het generieke return type naar een collectie van contactpersonen

            List<ParkPlace> parkPlaces = db.Query<ParkPlace>(sql).ToList();

            ParkPlace parkplace;


            if (parkPlaces.Count == 0)
            {
                parkplace = null;
            }
            else
            {
                parkplace = parkPlaces.First();
            }

            return parkplace;
        }

        public void UpdateReservation(Reservation reservation)
        {
            // SQL statement update 
            string sql = "Update Reservation set userId=@userId, parkPlaceId=@parkPlaceId, status=@status, beginTime=@beginTime, endTime=@endTime where Id = @id";

            // Uitvoeren SQL statement en doorgeven parametercollectie
            db.Execute(sql, new { reservation.UserId, reservation.ParkPlaceId, reservation.Status, reservation.BeginTime, reservation.EndTime, reservation.Id });
        }

        public void DeletReservation(Reservation reservation)
        {
            // SQL statement delete 
            string sql = "Delete Reservation where Id = @id";

            // Uitvoeren SQL statement en doorgeven parametercollectie
            db.Execute(sql, new { reservation.Id });
        }

        public void InsertReservation(Reservation reservation)
        {
            // SQL statement Insert 
            string sql = "Insert Reservation(userId,parkPlaceId,status,beginTime,endTime) values(@userId,@parkPlaceId,@status,@beginTime,@endTime)";

            // Uitvoeren SQL statement en doorgeven parametercollectie
            db.Execute(sql, new { reservation.UserId, reservation.ParkPlaceId, reservation.Status, reservation.BeginTime, reservation.EndTime });
        }
    }
}
