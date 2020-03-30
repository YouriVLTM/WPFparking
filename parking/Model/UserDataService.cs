using System.Data;
using System.Data.SqlClient;
using Dapper;
using System.Configuration;
using System.Collections.ObjectModel;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using parking.Extensions;


namespace parking.Model
{
    public class UserDataService
    {
        //public static string connectionStrings = ConfigurationManager.ConnectionStrings["youri"].ConnectionString;
        //test 
        //private static string connectionStringYouri = ConfigurationManager.ConnectionStrings["youri"].ConnectionString;
        // Ophalen ConnectionString uit App.config
        private static string connectionString = ConfigurationManager.ConnectionStrings["azure"].ConnectionString;

        // Aanmaken van een object uit de IDbConnection class en instantiëren van een SqlConnection.
        // Dit betekent dat de connectie met de database automatisch geopend wordt.
        private static IDbConnection db = new SqlConnection(connectionString);


        public ObservableCollection<User> GetUsers()
        {
            // Uitschrijven SQL statement & bewaren in een string. 
            string sql = "Select * from Userx";

            //Uitvoeren SQL statement op db instance 
            //Type casten van het generieke return type naar een collectie van contactpersonen
            ObservableCollection<User> users = db.Query<User>(sql).ToObservableCollection();

            return users;
        }

        public void UpdateUser(User user)
        {
            // SQL statement update 
            string sql = "Update User set prename = @prename, lastname = @lastname, phoneNumber=@phoneNumber, email=@email where Id = @id";

            // Uitvoeren SQL statement en doorgeven parametercollectie
            db.Execute(sql, new { user.Prename, user.Lastname, user.PhoneNumber, user.Email, user.Id });
        }

        public void DeleteUser(User user)
        {
            // SQL statement delete 
            string sql = "Delete User where Id = @id";

            // Uitvoeren SQL statement en doorgeven parametercollectie
            db.Execute(sql, new { user.Id });
        }

        public void InsertUser(User user)
        {
            // SQL statement delete 
            string sql = "Insert User(prename,lastname,phoneNumber,email) values(@prename,@lastname,@phoneNumber,@email)";

            // Uitvoeren SQL statement en doorgeven parametercollectie
            db.Execute(sql, new { user.Prename, user.Lastname, user.PhoneNumber, user.Email });
        }
    }
}
