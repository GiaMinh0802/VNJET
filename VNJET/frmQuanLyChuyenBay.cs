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
    public partial class frmQuanLyChuyenBay : Form
    {
        FlightBUS flightbus = new FlightBUS();
        FlightRouteBUS flightroutebus = new FlightRouteBUS();
        PlaneBUS planebus = new PlaneBUS();
        TicketClassBUS ticketclassbus = new TicketClassBUS();
        AirportBUS airportbus = new AirportBUS();
        TicketStatusBUS ticketstatusbus = new TicketStatusBUS();
        bool flagHangVeCellClick = false;
        public frmQuanLyChuyenBay()
        {
            InitializeComponent();
            LoadAll();
        }

        private void LoadAll()
        {
            LoadFormFlight();
            LoadFormTicketClass();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Parent.Dispose();
        }


        #region Flight
        private void gbxThemHangVeChoChuyenBay_CursorChanged(object sender, EventArgs e)
        {
            AcceptButton = btnThemHV;
        }

        private void LoadFormFlight()
        {
            DataTable dtTuyenBay = flightroutebus.GetForDisplay();
            DataTable dtMayBay = planebus.GetForDisplay();
            DataTable dtHangVe = ticketclassbus.GetForDisplay();
            DataTable dtSanBayDi = airportbus.GetForDisplay();
            DataTable dtSanBayDen = airportbus.GetForDisplay();

            cboMaTuyenBay.DataSource = dtTuyenBay;
            cboMaTuyenBay.DisplayMember = "idFlightRoutes";
            cboMaTuyenBay.ValueMember = "idFlightRoutes";

            cboMaMayBay.DataSource = dtMayBay;
            cboMaMayBay.DisplayMember = "idPlane";
            cboMaMayBay.ValueMember = "idPlane";

            cboMaHangVe.DataSource = dtHangVe;
            cboMaHangVe.DisplayMember = "nameTicketClass";
            cboMaHangVe.ValueMember = "idTicketClass";

            cboSanBayDi.DataSource = dtSanBayDi;
            cboSanBayDi.DisplayMember = "nameAirport";
            cboSanBayDi.ValueMember = "idAirport";

            cboSanBayDen.DataSource = dtSanBayDen;
            cboSanBayDen.DisplayMember = "nameAirport";
            cboSanBayDen.ValueMember = "idAirport";

            gbxThemHangVeChoChuyenBay.Enabled = false;

            AcceptButton = btnThem;
            CancelButton = btnThoat;

            LoadDTGVFlight();
        }

        private void LoadDTGVFlight()
        {
            DataTable dtChuyenBay = flightbus.GetForDisplay();
            dtgvChuyenBay.DataSource = dtChuyenBay;
            dtgvChuyenBay.Columns[0].HeaderText = "Mã chuyến bay";
            dtgvChuyenBay.Columns[1].HeaderText = "Mã tuyến bay";
            dtgvChuyenBay.Columns[2].HeaderText = "Mã máy bay";
            dtgvChuyenBay.Columns[3].HeaderText = "Thời gian khởi hành";
            dtgvChuyenBay.Columns[4].HeaderText = "Thời gian hạ cánh";
            dtgvChuyenBay.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtgvChuyenBay.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
        }

        private void cboMaTuyenBay_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cboMaTuyenBay.SelectedValue != null)
            {
                DataTable dtTuyenBay = flightroutebus.GetOfIdFlightRoute(cboMaTuyenBay.SelectedValue.ToString());
                if (dtTuyenBay.Rows.Count == 0)
                    return;
                else
                {
                    DataRow row = dtTuyenBay.Rows[0];
                    cboSanBayDi.Text = row[2].ToString();
                    cboSanBayDi.SelectedValue = row[1].ToString();
                    cboSanBayDen.Text = row[4].ToString();
                    cboSanBayDen.SelectedValue = row[3].ToString();
                }
            }
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

        private void dtgvChuyenBay_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;
            DataGridViewRow row = dtgvChuyenBay.Rows[e.RowIndex];
            txtMaChuyenBay.Text = row.Cells[0].Value.ToString();
            cboMaTuyenBay.Text = row.Cells[1].Value.ToString();
            cboMaMayBay.Text = row.Cells[2].Value.ToString();
            dtpkThoiGianKhoiHanh.Value = Convert.ToDateTime(row.Cells[3].Value.ToString());
            dtpkThoiGianHaCanh.Value = Convert.ToDateTime(row.Cells[4].Value.ToString());
            gbxThemHangVeChoChuyenBay.Enabled = true;

            LoadDTGVTicketClassForFlight();
        }
        #endregion

        #region TicketClass
        private void LoadFormTicketClass()
        {
            DataTable dtHangVe = ticketclassbus.GetForDisplay();
            cboMaHangVe.DataSource = dtHangVe;
            cboMaHangVe.DisplayMember = "nameTicketClass";
            cboMaHangVe.ValueMember = "idTicketClass";
        }
        private void LoadDTGVTicketClassForFlight()
        {
            DataTable dtTicketclass = ticketclassbus.GetTicketClassForFlight(txtMaChuyenBay.Text);
            dtgvHangVe.DataSource = dtTicketclass;
            dtgvHangVe.Columns[0].HeaderText = "Mã chuyến bay";
            dtgvHangVe.Columns[1].HeaderText = "Tên hạng vé";
            dtgvHangVe.Columns[2].HeaderText = "Tổng số ghế";
            dtgvHangVe.Columns[3].HeaderText = "Tổng số ghế trống";
            dtgvHangVe.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtgvHangVe.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
        }
        private void dtgvHangVe_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;
            DataGridViewRow row = dtgvHangVe.Rows[e.RowIndex];
            cboMaHangVe.Text = row.Cells[1].Value.ToString();
            txtTongSoGhe.Text = row.Cells[2].Value.ToString();

            flagHangVeCellClick = true;
        }
        #endregion


    }
}
