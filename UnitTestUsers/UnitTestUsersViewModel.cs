using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using parking;
using parking.ViewModel;


namespace UnitTestParking
{
    [TestClass]
    public class UnitTestUsersViewModel
    {
        [TestMethod]
        public void TestMethodAantalUsers()
        {
            var viewmodel = new UsersViewModel();

            Assert.AreEqual(7, viewmodel.Users.Count);

        }
    }
}
