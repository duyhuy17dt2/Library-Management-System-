﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace QL_THUVIEN2
{
    public partial class frm3DocGia : Form
    {
        public frm3DocGia()
        {
            InitializeComponent();
        }
        SqlConnection cnn;
        private void ketnoi()
        {
            string ketnoi = @"Data Source=HD;Initial Catalog=DA_QLTV;Integrated Security=True";
            cnn = new SqlConnection(ketnoi);
            cnn.Open();
        }
        private void HienThi()
        {
            string sql = "select * from DOCGIA";
            DataTable dtdg = new DataTable();
            DataSet dsdg = new DataSet();
            SqlCommand cmd = new SqlCommand(sql, cnn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dsdg);
            dtdg = dsdg.Tables[0];
            dgvdsdg.DataSource = dtdg; 
        }
        private void insert()
        {
            try
            {
                string s = txtns.Value.Year + "/" + txtns.Value.Month + "/" + txtns.Value.Day;
                string sql =
                    "insert into DOCGIA (MaDG,TenDG,GioiTinh,DiaChi,SDT,NgaySinh) values ('" + txtma.Text + "',N'" + txtten.Text + "',N'" + txtgt.Text + "',N'" + txtdc.Text + "','" + txtstd.Text + "',convert(smalldatetime,'" + s.ToString() + "'))";
                SqlCommand cmd = new SqlCommand(sql, cnn);
                cmd.ExecuteNonQuery();
                cmd.Parameters.Add(new SqlParameter("@date", txtns.Value.Date));
            }
            catch (Exception) { MessageBox.Show("Độc giả này đã có tài khoản"); }
        }
        private void update()
        {
            string s = txtns.Value.Year + "/" + txtns.Value.Month + "/" + txtns.Value.Day;
            string update =
                "update DOCGIA set TenNV='" + txtten.Text + "',GioiTinh=N'" + txtgt.Text + "',DiaChi=N'" + txtdc.Text + "',SDT='" + txtstd.Text + "',NgaySinh='" + Convert.ToDateTime(s.ToString()) + "' WHERE MaDG='" + txtma + "'";
            SqlCommand cmd = new SqlCommand(update, cnn);
             cmd.Parameters.Add(new SqlParameter("@date", txtns.Value.Date));
            cmd.ExecuteNonQuery();
        }
        private void delete()
        {
            string delete = "delete from DOCGIA where MaDG='" + txtma.Text + "'";
            SqlCommand cmd = new SqlCommand(delete, cnn);
            cmd.ExecuteNonQuery();
        }
        private void Form3_Load(object sender, EventArgs e)
        {
            paneldg.Visible = true;
            ketnoi();
            HienThi();
            txtma.Enabled = false;
        }

        private void bttttcnluu_Click(object sender, EventArgs e)
        {
            txtdc.Clear();
            txtma.Clear();
            txtstd.Clear();
            txtten.Clear();
            txtma.Focus();
        }

        
        private void dgvdsdg_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.RowIndex;
            try
            {
                txtma.Text = dgvdsdg.Rows[i].Cells[0].Value.ToString().Trim();
                txtten.Text = dgvdsdg.Rows[i].Cells[1].Value.ToString().Trim();
                txtgt.Text = dgvdsdg.Rows[i].Cells[2].Value.ToString().Trim();
                txtdc.Text = dgvdsdg.Rows[i].Cells[3].Value.ToString().Trim();
                txtstd.Text = dgvdsdg.Rows[i].Cells[4].Value.ToString().Trim();
                DateTime dt = Convert.ToDateTime(dgvdsdg.Rows[i].Cells[5].Value.ToString());
                txtns.Value = dt;
            }
            catch(Exception ex) {MessageBox.Show(ex.Message);}
        }

        private void bttttcnluu_Click_1(object sender, EventArgs e)
        {
            if (bttthemmoi.Text == "Thêm Mới")
            {
               // txtma.Focus();
                txtma.Clear();
                txtstd.Clear();
                txtten.Clear();
                txtdc.Clear();
                txtma.Enabled = true;
                bttthemmoi.Text = "Đồng Ý";
                button1.Enabled = false;
                bttqlnvxoa.Enabled = false;
                txtma.Focus();

            }
            else
            {
                insert();
                HienThi();
                txtma.Enabled = false;
                bttthemmoi.Text = "Thêm Mới";
                button1.Enabled = true;
                bttqlnvxoa.Enabled = true;
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            update();
            insert();
            HienThi();
        }

        private void bttqlnvxoa_Click_1(object sender, EventArgs e)
        {
            DialogResult f = MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (f == DialogResult.Yes)
            {
                delete();
                HienThi();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
