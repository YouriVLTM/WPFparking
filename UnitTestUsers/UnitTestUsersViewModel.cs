using System;
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


    }
}
