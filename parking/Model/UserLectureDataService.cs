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
    class UserLectureDataService
    {
        // Ophalen ConnectionString uit App.config
        private static string connectionString = ConfigurationManager.ConnectionStrings["azure"].ConnectionString;

        // Aanmaken van een object uit de IDbConnection class en instantiëren van een SqlConnection.
        // Dit betekent dat de connectie met de database automatisch geopend wordt.
        private static IDbConnection db = new SqlConnection(connectionString);


        public ObservableCollection<UserLecture> GetUserLecture()
        {
            // Uitschrijven SQL statement & bewaren in een string. 
            string sql = "Select * from UserLecture order by Id";

            //Uitvoeren SQL statement op db instance 
            //Type casten van het generieke return type naar een collectie van contactpersonen
            ObservableCollection<UserLecture> userLectures = db.Query<UserLecture>(sql).ToObservableCollection();

            return userLectures;
        }

        public void UpdateUserLecture(UserLecture userLecture)
        {
            // SQL statement update 
            string sql = "Update UserLecture set lectureId=@lectureId, userId=@userId where Id = @id";

            // Uitvoeren SQL statement en doorgeven parametercollectie
            db.Execute(sql, new { userLecture.LectureId, userLecture.UserId, userLecture.Id });
        }

        public void DeletUserLecture(UserLecture userLecture)
        {
            // SQL statement delete 
            string sql = "Delete UserLecture where Id = @id";

            // Uitvoeren SQL statement en doorgeven parametercollectie
            db.Execute(sql, new { userLecture.Id });
        }

        public void InsertUserLecture(UserLecture userLecture)
        {
            // SQL statement Insert 
            string sql = "Insert UserLecture(lectureId,userId) values(@lectureId,@userId)";

            // Uitvoeren SQL statement en doorgeven parametercollectie
            db.Execute(sql, new { userLecture.LectureId, userLecture.UserId  });
        }
    }
}
