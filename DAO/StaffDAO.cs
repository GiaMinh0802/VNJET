﻿using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DAO
{
    public class StaffDAO
    {
        private static StaffDAO instance;
        public static StaffDAO Instance
        {
            get { if (instance == null) instance = new StaffDAO(); return StaffDAO.instance; }
            private set { StaffDAO.instance = value; }
        }

        private StaffDAO()
        { }

        public DataTable GetForDisplay()
        {
            string query = "SELECT * FROM dbo.UV_StaffForDisplay ORDER BY idStaffs";
            DataTable dt = DataProvider.Instance.ExecuteQuery(query);
            return dt;
        }

        public DataTable GetUsernameAndPassword(string user, string pass)
        {
            string query = String.Format("SELECT * FROM dbo.Accounts WHERE userAcc='{0}' AND passAcc='{1}'", user, pass);
            DataTable dt = DataProvider.Instance.ExecuteQuery(query);
            return dt;
        }

        public bool DeleteStaff(string idStaff)
        {
            try
            {
                string query = String.Format("DELETE dbo.Accounts WHERE idStaffs='{0}'", idStaff);
                int result = DataProvider.Instance.ExecuteNonQuery(query);
                return result > 0;
            }
            catch
            {
                return false;
            }
        }

        public bool InsertStaff(StaffDTO dto)
        {
            try
            {
                string query = String.Format("DELETE dbo.Accounts WHERE idStaffs='{0}'");
                int result = DataProvider.Instance.ExecuteNonQuery(query);
                return result > 0;
            }
            catch
            {
                return false;
            }
        }
    }
}
