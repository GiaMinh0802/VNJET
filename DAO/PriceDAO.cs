using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class PriceDAO
    {
        private static PriceDAO instance;
        public static PriceDAO Instance
        {
            get { if (instance == null) instance = new PriceDAO(); return PriceDAO.instance; }
            private set { PriceDAO.instance = value; }
        }

        private PriceDAO()
        { }

        public DataTable GetForDisplay()
        {
            string query = "SELECT * FROM dbo.Prices";
            DataTable dt = DataProvider.Instance.ExecuteQuery(query);
            return dt;
        }
        public object GetPriceByIdFlightAndIdTicketClass(string idFlight, string idTicketClass)
        {
            string query = string.Format("SELECT dbo.UF_GetPriceByIdFlightAndIdTicketClass('{0}','{1}')", idFlight, idTicketClass);
            object dt = DataProvider.Instance.ExecuteScalar(query);
            return dt;
        }
    }
}
