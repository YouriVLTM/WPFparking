using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace parking.Model
{
    public class BaseModelDataService
    {
        // Ophalen ConnectionString uit App.config
        protected static string connectionString = ConfigurationManager.ConnectionStrings["local"].ConnectionString;

        // Aanmaken van een object uit de IDbConnection class en instantiëren van een SqlConnection.
        // Dit betekent dat de connectie met de database automatisch geopend wordt.
        protected static IDbConnection db = new SqlConnection(connectionString);
    }
}
