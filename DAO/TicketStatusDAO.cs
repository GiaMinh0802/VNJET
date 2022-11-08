using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class TicketStatusDAO
    {
        private static TicketStatusDAO instance;
        public static TicketStatusDAO Instance
        {
            get { if (instance == null) instance = new TicketStatusDAO(); return TicketStatusDAO.instance; }
            private set { TicketStatusDAO.instance = value; }
        }

        private TicketStatusDAO()
        { }

        public object GetEmptySeatsByIdFlightAndIdTicketClass(string idFlight, string idTicketClass)
        {
            string query = string.Format("SELECT dbo.UF_GetEmptySeatsByIdFlightAndIdTicketClass('{0}','{1}')", idFlight, idTicketClass);
            object dt = DataProvider.Instance.ExecuteScalar(query);
            return dt;
        }

        public DataTable GetTicketStatusByIdFlight(string IdFlight)
        {
            string query = string.Format("EXEC dbo.USP_GetTicketStatusByIdFlight '{0}'", IdFlight);
            DataTable dt = DataProvider.Instance.ExecuteQuery(query);
            return dt;
        }
    }
}
