using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class TicketFlightDAO
    {
        private static TicketFlightDAO instance;
        public static TicketFlightDAO Instance
        {
            get { if (instance == null) instance = new TicketFlightDAO(); return TicketFlightDAO.instance; }
            private set { TicketFlightDAO.instance = value; }
        }

        private TicketFlightDAO()
        { }

        public DataTable GetForDisplay()
        {
            string query = "SELECT * FROM dbo.UV_TicketFlightForDisplay ORDER BY idTicket";
            DataTable dt = DataProvider.Instance.ExecuteQuery(query);
            return dt;
        }
    }
}
