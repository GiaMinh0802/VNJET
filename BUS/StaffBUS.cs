using DAO;
using DTO;
using System;
using System.Data;

namespace BUS
{
    public class StaffBUS
    {
        public DataTable GetUsernameAndPassword(string user, string pass)
        { 
            return StaffDAO.Instance.GetUsernameAndPassword(user, pass);
        }
        public DataTable GetForDisplay()
        {
            return StaffDAO.Instance.GetForDisplay();
        }
        public bool DeleteStaff(string idStaff)
        {
            return StaffDAO.Instance.DeleteStaff(idStaff);
        }
        public bool InsertStaff(StaffDTO dto)
        {
            return StaffDAO.Instance.InsertStaff(dto);
        }
        public bool UpdateStaff(StaffDTO dto)
        {
            return StaffDAO.Instance.UpdateStaff(dto);
        }
        public DataTable SearchByName(string name)
        {
            return StaffDAO.Instance.SearchByName(name);
        }
    }
}
