using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class TicketClassDAO
    {
        private static TicketClassDAO instance;
        public static TicketClassDAO Instance
        {
            get { if (instance == null) instance = new TicketClassDAO(); return TicketClassDAO.instance; }
            private set { TicketClassDAO.instance = value; }
        }

        private TicketClassDAO()
        { }

        public DataTable GetForDisplay()
        {
            string query = "SELECT * FROM dbo.TicketClasses";
            DataTable dt = DataProvider.Instance.ExecuteQuery(query);
            return dt;
        }

        public DataTable GetTicketClassForFlight(string idFlight)
        {
            string query = string.Format("EXEC dbo.USP_GetTicketClassForFlight '{0}'", idFlight);
            DataTable dt = DataProvider.Instance.ExecuteQuery(query);
            return dt;
        }
    }
}
