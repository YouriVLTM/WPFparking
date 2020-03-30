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
            Assert.AreEqual("youri", viewmodel.SelectedUser.Prename);

        }

        
    }
}
