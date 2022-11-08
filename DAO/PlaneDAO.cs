using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class PlaneDAO
    {
        private static PlaneDAO instance;
        public static PlaneDAO Instance
        {
            get { if (instance == null) instance = new PlaneDAO(); return PlaneDAO.instance; }
            private set { PlaneDAO.instance = value; }
        }

        private PlaneDAO()
        { }

        public DataTable GetForDisplay()
        {
            string query = "SELECT * FROM dbo.Planes";
            DataTable dt = DataProvider.Instance.ExecuteQuery(query);
            return dt;
        }
    }
}
