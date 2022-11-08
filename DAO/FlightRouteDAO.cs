using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class FlightRouteDAO
    {
        private static FlightRouteDAO instance;
        public static FlightRouteDAO Instance
        {
            get { if (instance == null) instance = new FlightRouteDAO(); return FlightRouteDAO.instance; }
            private set { FlightRouteDAO.instance = value; }
        }

        private FlightRouteDAO()
        { }
        public DataTable GetForDisplay()
        {
            string query = "SELECT * FROM UV_FlightRouteForDisplay ORDER BY idFlightRoutes";
            DataTable dt = DataProvider.Instance.ExecuteQuery(query);
            return dt;
        }
        public DataTable GetOfIdFlightRoute(string str)
        {
            string query = String.Format("SELECT * FROM UV_FlightRouteForDisplay WHERE idFlightRoutes = '{0}'", str);
            DataTable dt = DataProvider.Instance.ExecuteQuery(query);
            return dt;
        }

        public DataTable GetOfIdAirport(string idToGo, string idToCome)
        {
            string query = String.Format("SELECT * FROM dbo.FlightRoutes\r\n" +
                "WHERE idAirportToGo = '{0}' AND idAirportToCome = '{1}'", idToGo, idToCome);
            DataTable dt = DataProvider.Instance.ExecuteQuery(query);
            return dt;
        }
    }
}
