using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class AirportDAO
    {
        private static AirportDAO instance;
        public static AirportDAO Instance
        {
            get { if (instance == null) instance = new AirportDAO(); return AirportDAO.instance; }
            private set { AirportDAO.instance = value; }
        }

        private AirportDAO()
        { }

        public DataTable GetForDisplay()
        {
            string query = "SELECT * FROM dbo.Airports";
            DataTable dt = DataProvider.Instance.ExecuteQuery(query);
            return dt;
        }
    }
}
