using DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class PriceBUS
    {
        public DataTable GetForDisplay()
        {
            return PriceDAO.Instance.GetForDisplay();
        }
        public object GetPriceByIdFlightAndIdTicketClass(string idFlight, string idTicketClass)
        {
            return PriceDAO.Instance.GetPriceByIdFlightAndIdTicketClass(idFlight, idTicketClass);
        }
    }
}
