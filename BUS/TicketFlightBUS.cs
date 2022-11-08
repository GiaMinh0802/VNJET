using DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class TicketFlightBUS
    {
        public DataTable GetForDisplay()
        {
            return TicketFlightDAO.Instance.GetForDisplay();
        }
    }
}
