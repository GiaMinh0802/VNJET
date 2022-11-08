using DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class TicketStatusBUS
    {
        public object GetEmptySeatsByIdFlightAndIdTicketClass(string IdFlight, string IdTicketClass)
        {
            return TicketStatusDAO.Instance.GetEmptySeatsByIdFlightAndIdTicketClass(IdFlight, IdTicketClass);
        }
        public DataTable GetTicketStatusByIdFlight(string IdFlight)
        {
            return TicketStatusDAO.Instance.GetTicketStatusByIdFlight(IdFlight);

        }
    }
}
