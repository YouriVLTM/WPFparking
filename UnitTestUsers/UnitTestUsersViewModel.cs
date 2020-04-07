using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using parking;
using parking.Model;
using parking.ViewModel;


namespace UnitTestParking
{
    [TestClass]
    public class UnitTestUsersViewModel
    {
        [TestMethod]
        public void TestMethodParameters()
        {
            User user = new User();
            user.Prename = "Youri";
            user.Lastname = "Van Laer";
            user.PhoneNumber = "014588620";
            user.Email = "youri.vanlaer@hotmail.com";

            Assert.AreEqual("Youri", user.Prename);
            Assert.AreEqual("Van Laer", user.Lastname);
            Assert.AreEqual("014588620", user.PhoneNumber);
            Assert.AreEqual("youri.vanlaer@hotmail.com", user.Email);


        }

        [TestMethod]
        public void TestMethodAantalUsers()
        {
            var viewmodel = new UsersViewModel();
            Assert.AreEqual(8, viewmodel.Users.Count);
        }

        [TestMethod]
        public void TestMethodSelectUser()
        {
            var viewmodel = new UsersViewModel();
            viewmodel.SelectedUser = viewmodel.Users.First();
            Assert.AreEqual("Youri", viewmodel.SelectedUser.Prename);

        }

        [TestMethod]
        public void TestMethodUserExist()
        {
            UserDataService db = new UserDataService();
            User user = new User();
            user.Email = "youri.vanlaer@hotmail.com";

            User us = db.UserExist(user);
            
            Assert.AreEqual(1,us.Id);

        }


        


    }


    [TestClass]
    public class UnitTestParkingViewModel
    {
        [TestMethod]
        public void TestMethodParameters()
        {
            ParkPlace parkPlace = new ParkPlace();

            Parking parking = new Parking();
            Building building = new Building();

            parking.Name = "ParkingYouri";

            building.Place = "B blok";
            building.Description = "Mooi gebouw";
            building.Location = "B202";

            parkPlace.Parking = parking;
            parkPlace.Building = building;
            parkPlace.Row = 10;
            parkPlace.Cel = 1;
            parkPlace.Description = "Hello world";

            Assert.AreEqual(parking, parkPlace.Parking);
            Assert.AreEqual(building, parkPlace.Building);
            Assert.AreEqual(10, parkPlace.Row);
            Assert.AreEqual(1, parkPlace.Cel);
            Assert.AreEqual("Hello world", parkPlace.Description);

        }

        [TestMethod]
        public void TestMethodAantalParkPlaces()
        {
            var viewmodel = new ParkingViewModel();
            Assert.AreEqual(8, viewmodel.ParkPlaces.Count);

        }

        [TestMethod]
        public void TestMethodSelectParkPlace()
        {
            var viewmodel = new ParkingViewModel();
            viewmodel.SelectedParkPlace = viewmodel.ParkPlaces.First();
            Assert.AreEqual(5, viewmodel.SelectedParkPlace.Cel);

        }

        [TestMethod]
        public void TestMethodSelectParkPlacesList()
        {
            var viewmodel = new ParkingViewModel();
            ObservableCollection<ParkPlace> park = viewmodel.ParkPlaces;
            Assert.AreEqual(1, 1);

        }

        [TestMethod]
        public void TestMethodSelectParkPlacesRow()
        {
            var viewmodel = new ParkingViewModel();
            List<ParkPlaceRow> park = viewmodel.RowViewParkPlaces;
            Assert.AreEqual(1, 1);

        }

        [TestMethod]
        public void TestMethodGetParkPlaceWithFK()
        {

            ParkPlace park = new ParkPlace();
            park.Id = 2;
            ParkPlaceDataService db = new ParkPlaceDataService();

            ParkPlace newpark = db.GetParkPlaceWithFK(park);

            Assert.AreEqual(2, newpark.Id);

        }



        


    }

    [TestClass]
    public class UnitTestReserverenViewModel
    {
        [TestMethod]
        public void TestMethodGetNewParkPlaces()
        {
            Reservation reservation = new Reservation();

            ReservationDataService ds = new ReservationDataService();

            reservation.BeginTime = DateTime.Parse("05/04/2020 11:50:00");
            reservation.EndTime = DateTime.Parse("05/04/2020 12:50:00");
            String location = "A202";

            ParkPlace park = ds.GetNewParkPlaces(reservation, location);



            Assert.AreEqual(9, park.Id);

        }

        [TestMethod]
        public void TestMethodGetReservationParkPlace()
        {
            ParkPlace parkplace = new ParkPlace();
            parkplace.Id = 2;

            ReservationDataService ds = new ReservationDataService();

            ObservableCollection<Reservation> reservations = ds.GetReservationParkPlace(parkplace);
            Assert.AreEqual(4, reservations.Count);

        }



        
    }
}
