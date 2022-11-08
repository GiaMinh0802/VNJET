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
    public partial class frmQuanLyHangVe : Form
    {
        TicketClassBUS ticketclassbus = new TicketClassBUS();
        public frmQuanLyHangVe()
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
            LoadDTGVTicketClass();
            txtTenHangVe.Focus();
        }

        private void LoadDTGVTicketClass()
        {
            DataTable dtHangVe = ticketclassbus.GetForDisplay();
            dtgvHangVe.DataSource = dtHangVe;
            dtgvHangVe.Columns[0].HeaderText = "Mã hạng vé";
            dtgvHangVe.Columns[1].HeaderText = "Tên hạng vé";
            dtgvHangVe.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtgvHangVe.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
        }

        private void dtgvHangVe_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;
            DataGridViewRow row = dtgvHangVe.Rows[e.RowIndex];
            txtMaHangVe.Text = row.Cells[0].Value.ToString();
            txtTenHangVe.Text = row.Cells[1].Value.ToString();
        }

        
    }
}
