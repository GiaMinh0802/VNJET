using BUS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VNJET
{
    public partial class frmQuanLySanBay : Form
    {
        AirportBUS airportbus = new AirportBUS();
        public frmQuanLySanBay()
        {
            InitializeComponent();
            LoadForm();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Parent.Dispose();
        }
        private void LoadForm()
        {
            LoadDTGVAirport();
            txtTenSanBay.Focus();
        }
        private void LoadDTGVAirport()
        {
            DataTable dtSanBay = airportbus.GetForDisplay();
            dtgvSanBay.DataSource = dtSanBay;
            dtgvSanBay.Columns[0].HeaderText = "Mã sân bay";
            dtgvSanBay.Columns[1].HeaderText = "Tên sân bay";
            dtgvSanBay.Columns[2].HeaderText = "Tên thành phố";
            dtgvSanBay.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtgvSanBay.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
        }

        private void dtgvSanBay_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;
            DataGridViewRow row = dtgvSanBay.Rows[e.RowIndex];
            txtMaSanBay.Text = row.Cells[0].Value.ToString();
            txtTenSanBay.Text = row.Cells[1].Value.ToString();
            txtTenThanhPho.Text = row.Cells[2].Value.ToString();
        }
    }
}
