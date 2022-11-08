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
    public partial class frmQuanLyTuyenBay : Form
    {
        FlightRouteBUS flightroutebus = new FlightRouteBUS();
        AirportBUS airportbus = new AirportBUS();
        public frmQuanLyTuyenBay()
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

            DataTable dtSanBayDen = airportbus.GetForDisplay();
            DataTable dtSanBayDi = airportbus.GetForDisplay();

            cboSanBayDen.DataSource = dtSanBayDen;
            cboSanBayDen.DisplayMember = "nameAirport";
            cboSanBayDen.ValueMember = "idAirport";

            cboSanBayDi.DataSource = dtSanBayDi;
            cboSanBayDi.DisplayMember = "nameAirport";
            cboSanBayDi.ValueMember = "idAirport";

            LoadDTGVFlightRoute();

            cboSanBayDi.Focus();
        }
        private void LoadDTGVFlightRoute()
        {
            DataTable dtTuyenBay = flightroutebus.GetForDisplay();
            dtgvTuyenBay.DataSource = dtTuyenBay;
            dtgvTuyenBay.Columns[0].HeaderText = "Mã tuyến bay";
            dtgvTuyenBay.Columns[2].HeaderText = "Tên sân bay đi";
            dtgvTuyenBay.Columns[4].HeaderText = "Tên sân bay đến";
            dtgvTuyenBay.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtgvTuyenBay.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
        }

        private void dtgvTuyenBay_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;
            DataGridViewRow row = dtgvTuyenBay.Rows[e.RowIndex];
            txtMaTuyenBay.Text = row.Cells[0].Value.ToString();
            cboSanBayDi.Text = row.Cells[2].Value.ToString();
            cboSanBayDen.Text = row.Cells[4].Value.ToString();
        }
    }
}
