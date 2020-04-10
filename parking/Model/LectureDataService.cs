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
    public class LectureDataService : BaseModelDataService
    {

        public ObservableCollection<Lecture> GetLecture()
        {
            // Uitschrijven SQL statement & bewaren in een string. 
            string sql = "Select * from Lecture order by Id";

            //Uitvoeren SQL statement op db instance 
            //Type casten van het generieke return type naar een collectie van contactpersonen
            ObservableCollection<Lecture> lectures = db.Query<Lecture>(sql).ToObservableCollection();

            return lectures;
        }

        public Boolean IsValidLecture(Lecture lecture)
        {
            string sql = "Select * from Lecture " +
                "Where location = @location AND course = @course AND date = @date";
            Lecture lectures = db.Query<Lecture>(sql, new { lecture.Location, lecture.Course, lecture.Date }).FirstOrDefault();
            return lectures == null;
        }

        public void UpdateLecture(Lecture lecture)
        {
            // SQL statement update 
            string sql = "Update Lecture set startTime = @startTime, endTime = @endTime, location=@location, course=@course, date=@date, buildingId=@buildingId where Id = @id";

            // Uitvoeren SQL statement en doorgeven parametercollectie
            db.Execute(sql, new { lecture.StartTime, lecture.EndTime, lecture.Location, lecture.Course, lecture.Date, lecture.BuildingId, lecture.Id });
        }

        public void DeleteLecture(Lecture lecture)
        {
            // SQL statement delete 
            string sql = "Delete Lecture where Id = @id";

            // Uitvoeren SQL statement en doorgeven parametercollectie
            db.Execute(sql, new { lecture.Id });
        }

        public void InsertLecture(Lecture lecture)
        {
            // SQL statement Insert 
            string sql = "Insert Lecture(startTime,endTime,location,course,date,buildingId) values(@startTime,@endTime,@location, @course,@date,@buildingId)";

            // Uitvoeren SQL statement en doorgeven parametercollectie
            db.Execute(sql, new {lecture.StartTime, lecture.EndTime, lecture.Location, lecture.Course, lecture.Date, lecture.BuildingId });
        }
    }
}
