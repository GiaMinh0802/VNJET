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
    public partial class frmQuanLyDonGia : Form
    {
        PriceBUS pricebus = new PriceBUS();
        FlightRouteBUS flightroutebus = new FlightRouteBUS();
        AirportBUS airportbus = new AirportBUS();
        TicketClassBUS ticketclassbus = new TicketClassBUS();
        bool flagCellClick;
        public frmQuanLyDonGia()
        {
            InitializeComponent();
            flagCellClick = false;
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Parent.Dispose();
        }

        private void LoadForm()
        {
            DataTable dtTuyenBay = flightroutebus.GetForDisplay();
            cboMaTuyenBay.DataSource = dtTuyenBay;
            cboMaTuyenBay.DisplayMember = "idFlightRoutes";
            cboMaTuyenBay.ValueMember = "idFlightRoutes";

            DataTable dtHangVe = ticketclassbus.GetForDisplay();
            cboMaHangVe.DataSource = dtHangVe;
            cboMaHangVe.DisplayMember = "nameTicketClass";
            cboMaHangVe.ValueMember = "idTicketClass";

            DataTable dtSanBayDi = airportbus.GetForDisplay();
            cboSanBayDi.DataSource = dtSanBayDi;
            cboSanBayDi.DisplayMember = "nameAirport";
            cboSanBayDi.ValueMember = "idAirport";

            DataTable dtSanBayDen = airportbus.GetForDisplay();
            cboSanBayDen.DataSource = dtSanBayDen;
            cboSanBayDen.DisplayMember = "nameAirport";
            cboSanBayDen.ValueMember = "idAirport";

            LoadDTGVPrice();

            cboSanBayDi.Focus();
        }
        private void LoadDTGVPrice()
        {
            DataTable dtDonGia = pricebus.GetForDisplay();
            dtgvDonGia.DataSource = dtDonGia;
            dtgvDonGia.Columns[0].HeaderText = "Mã tuyến bay";
            dtgvDonGia.Columns[1].HeaderText = "Mã hạng vé";
            dtgvDonGia.Columns[2].HeaderText = "Đơn giá";
            dtgvDonGia.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtgvDonGia.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            dtgvDonGia.Columns[2].DefaultCellStyle.Format = "#,####.####";
        }

        private void dtgvDonGia_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;
            DataGridViewRow row = dtgvDonGia.Rows[e.RowIndex];
            cboMaTuyenBay.SelectedValue = row.Cells[0].Value.ToString();
            cboMaHangVe.SelectedValue = row.Cells[1].Value.ToString();
            txtDonGia.Text = row.Cells[2].Value.ToString();
            flagCellClick = true;
            cboMaTuyenBay_SelectionChangeCommitted(sender, e);
        }

        private void cboMaTuyenBay_SelectionChangeCommitted(object sender, EventArgs e)
        {
            DataTable dtTuyenBay = flightroutebus.GetOfIdFlightRoute(cboMaTuyenBay.SelectedValue.ToString());
            if (dtTuyenBay.Rows.Count == 0)
                return;
            DataRow row = dtTuyenBay.Rows[0];

            cboSanBayDi.SelectedValue = row["idAirportToGo"].ToString();

            cboSanBayDen.SelectedValue = row["idAirportToCome"].ToString();
        }

        private void cboSanBayDi_SelectionChangeCommitted(object sender, EventArgs e)
        {
            DataTable dtTuyenBay = flightroutebus.GetOfIdAirport(cboSanBayDi.SelectedValue.ToString(), cboSanBayDen.SelectedValue.ToString());
            if (dtTuyenBay.Rows.Count == 0)
            {
                cboMaTuyenBay.Text = "";
            }
            else
            {
                DataRow row = dtTuyenBay.Rows[0];
                cboMaTuyenBay.Text = row["idFlightRoutes"].ToString();
            }
        }

        private void txtDonGia_TextChanged(object sender, EventArgs e)
        {
            if (txtDonGia.Text == "")
            {
                lbDonGia.Text = "";
                return;
            }
            decimal value = Convert.ToDecimal(txtDonGia.Text);
            lbDonGia.Text = string.Format("{0:0,0 VNĐ}", value);
        }

        private void frmQuanLyDonGia_Shown(object sender, EventArgs e)
        {
            LoadForm();
            cboMaTuyenBay_SelectionChangeCommitted(sender, e);
        }
    }
}
