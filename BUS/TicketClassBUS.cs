using DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class TicketClassBUS
    {
        public DataTable GetForDisplay()
        {
            return TicketClassDAO.Instance.GetForDisplay();
        }

        public DataTable GetTicketClassForFlight(string idFlight)
        {
            return TicketClassDAO.Instance.GetTicketClassForFlight(idFlight);
        }
    }
}
