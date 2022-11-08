using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class FlightDAO
    {
        private static FlightDAO instance;
        public static FlightDAO Instance
        {
            get { if (instance == null) instance = new FlightDAO(); return FlightDAO.instance; }
            private set { FlightDAO.instance = value; }
        }

        private FlightDAO()
        { }

        public DataTable GetForDisplay()
        {
            string query = "SELECT * FROM dbo.Flights ORDER BY idFlights";
            DataTable dt = DataProvider.Instance.ExecuteQuery(query);
            return dt;
        }

        public DataTable GetForFlight()
        {
            string query = "SELECT * FROM dbo.Flights ORDER BY idFlights";
            DataTable dt = DataProvider.Instance.ExecuteQuery(query);
            return dt;
        }

        public DataTable GetFlightByIdFlight(string idFlight)
        {
            string query = String.Format("EXEC dbo.USP_GetFlightByIdFlight '{0}'", idFlight);
            DataTable dt = DataProvider.Instance.ExecuteQuery(query);
            return dt;
        }

        public object GetFlightByAirportAndTime(string idAirportToGo, string idAirportToCome, DateTime thoiGianKHTu, DateTime thoiGianKHDen)
        {
            string query = String.Format("EXEC dbo.USP_GetFlightByAirportAndTime '{0}', '{1}', '{2}', '{3}'", idAirportToGo, idAirportToCome, thoiGianKHTu, thoiGianKHDen);
            DataTable dt = DataProvider.Instance.ExecuteQuery(query);
            return dt;
        }
    }
}
