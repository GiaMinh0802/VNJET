using BUS;
using DAO;
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
    public partial class frmBanVe : Form
    {
        TicketFlightBUS ticketFlightBUS = new TicketFlightBUS();
        FlightBUS flightBUS = new FlightBUS();
        TicketClassBUS ticketClassBUS = new TicketClassBUS();
        PriceBUS priceBUS = new PriceBUS();
        TicketStatusBUS ticketStatusBUS = new TicketStatusBUS();
        CustomerBUS customerBUS = new CustomerBUS();
        string idStaff;
        string idTicket;
        public frmBanVe(DataRow row)
        {
            InitializeComponent();
            this.idStaff = row[2].ToString();
            LoadForm();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Parent.Dispose();
        }

        private void LoadForm()
        {
            DataTable dtCB = flightBUS.GetForDisplay();
            cboMaChuyenBay.DataSource = dtCB;
            cboMaChuyenBay.DisplayMember = "idFlights";
            cboMaChuyenBay.ValueMember = "idFlights";


            DataTable dtHV = ticketClassBUS.GetForDisplay();
            cboHangVe.DataSource = dtHV;
            cboHangVe.DisplayMember = "nameTicketClass";
            cboHangVe.ValueMember = "idTicketClass";

            LoadDTGV();
        }

        private void LoadDTGV()
        {
            DataTable dtVe = ticketFlightBUS.GetForDisplay();
            dtgvVe.DataSource = dtVe;
            dtgvVe.Columns[0].HeaderText = "Mã vé";
            dtgvVe.Columns[1].HeaderText = "Tên khách hàng";
            dtgvVe.Columns[2].HeaderText = "CMND";
            dtgvVe.Columns[3].HeaderText = "SĐT";
            dtgvVe.Columns[4].HeaderText = "Mã chuyến bay";
            dtgvVe.Columns[5].HeaderText = "Tên hạng vé";
            dtgvVe.Columns[6].HeaderText = "Giá vé";
            dtgvVe.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtgvVe.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
        }
        private void dtgvVe_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;
            DataGridViewRow row = dtgvVe.Rows[e.RowIndex];
            txtCMND.Text = row.Cells[2].Value.ToString();
            cboMaChuyenBay.SelectedValue = row.Cells[4].Value.ToString();
            cboHangVe.Text = row.Cells[5].Value.ToString();
            this.idTicket = row.Cells[0].Value.ToString();
        }
        private void cboMaChuyenBay_SelectedValueChanged(object sender, EventArgs e)
        {
            DataTable dtChuyenBay = flightBUS.GetFlightByIdFlight(cboMaChuyenBay.Text);
            if (dtChuyenBay.Rows.Count == 0)
            {
                txtMaTuyenBay.Clear();
                txtSanBayDi.Clear();
                txtSanBayDen.Clear();
                txtThoiGianKhoiHanh.Clear();
                txtThoiGianHaCanh.Clear();
            }
            else
            {
                DataRow row = dtChuyenBay.Rows[0];
                txtMaTuyenBay.Text = row[1].ToString();
                txtSanBayDi.Text = row[5].ToString();
                txtSanBayDen.Text = row[6].ToString();
                txtThoiGianKhoiHanh.Text = row[3].ToString();
                txtThoiGianHaCanh.Text = row[4].ToString();
                LoadEmptySeat();
            }
        }
        private void cboHangVe_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cboHangVe.SelectedValue != null)
            {
                object unitprice = priceBUS.GetPriceByIdFlightAndIdTicketClass(cboMaChuyenBay.SelectedValue.ToString(), cboHangVe.SelectedValue.ToString());
                txtGiaTien.Text = unitprice.ToString();
                LoadEmptySeat();
            }
        }
        private void LoadEmptySeat()
        {
            if (cboHangVe.SelectedValue != null)
            {
                object emptyseat = ticketStatusBUS.GetEmptySeatsByIdFlightAndIdTicketClass(cboMaChuyenBay.SelectedValue.ToString(), cboHangVe.SelectedValue.ToString());
                txtSoGheTrong.Text = emptyseat.ToString();
            }
        }

        private void txtGiaTien_TextChanged(object sender, EventArgs e)
        {
            if (txtGiaTien.Text == "")
                return;
            string text = txtGiaTien.Text.Replace(",", "");
            decimal value = Convert.ToDecimal(text);
            txtGiaTien.Text = string.Format("{0:0,0}", value);
        }

        private void txtCMND_TextChanged(object sender, EventArgs e)
        {
            DataTable dtKhachHang = customerBUS.GetByCMND(txtCMND.Text);
            if (dtKhachHang.Rows.Count == 0)
            {
                txtTenKhachHang.Clear();
                txtSDT.Clear();
            }
            else
            {
                DataRow row = dtKhachHang.Rows[0];
                txtTenKhachHang.Text = row[1].ToString();
                txtSDT.Text = row[3].ToString();
            }
        }

        private void btnChiTietGheTrong_Click(object sender, EventArgs e)
        {
            Form frm = new frmTinhTrangVe(cboMaChuyenBay.Text);
            frm.Show();
        }

        private void btnTraCuu_Click(object sender, EventArgs e)
        {
            Form frm = new frmTraCuu(cboMaChuyenBay);
            frm.Show();
        }
    }
}
