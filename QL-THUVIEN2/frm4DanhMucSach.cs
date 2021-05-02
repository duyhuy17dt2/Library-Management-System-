using System;
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
    public partial class frm4DanhMucSach : Form
    {
        public frm4DanhMucSach()
        {
            InitializeComponent();
        }
        SqlConnection cnn;
        string matl,manxb;
        private void HienThi()
        {
            string sql = "select * from SACH";
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();
            SqlCommand cmd = new SqlCommand(sql, cnn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            dt = ds.Tables[0];
            dgvsach.DataSource = dt;
        }
      
        private void loadmanxb()
        {
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();
            SqlCommand cmd = new SqlCommand("select * from NXB", cnn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            dt = ds.Tables[0];
            txtnxb.DataSource = dt;
            txtnxb.DisplayMember = "TenNXB";
            txtnxb.ValueMember = "MaNXB";
        }
        private void loadtl()
        {
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();
            SqlCommand cmd = new SqlCommand("select * from theloai", cnn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            dt = ds.Tables[0];
            txttheloai.DataSource = dt;
            txttheloai.DisplayMember = "TenTL";
            txttheloai.ValueMember = "MaTL";
            
            
        }
        private void ketnoi()
        {
            string ketnoi = @"Data Source=HD;Initial Catalog=DA_QLTV;Integrated Security=True";
            cnn = new SqlConnection(ketnoi);
            cnn.Open();
        }

        private void update()
        {


            SqlCommand cmd = new SqlCommand("update SACH set TenSach=N'" + txtten.Text + "',Gia=" + txtgia.Text + ",MaNXB='" + manxb + "',MaTL=N'" + matl + "',SoLuong = '" + txtsoluong.Text + "', TinhTrang='" + Convert.ToByte(txttinhtrang.Checked) + "' where MaSach='" + txtma.Text + "'", cnn);
            cmd.ExecuteNonQuery();
        }
        private void insert()
        {

                string sql = "insert into SACH values('" + txtma.Text + "',N'" + txtten.Text + "','" + txtgia.Text + "','" + manxb + "','"+matl+ "','" + txtsoluong.Text + "','" + Convert.ToByte(txttinhtrang.Checked) + "')";
                SqlCommand cmd = new SqlCommand(sql, cnn);
                cmd.ExecuteNonQuery();
          
        
        }
        private void delete()
        {
            try
            {
                string sql = "delete from SACH where MaSach='" + txtma.Text + "'";
                SqlCommand cmd = new SqlCommand(sql, cnn);
                cmd.ExecuteNonQuery();
            }catch (Exception)
            {
                MessageBox.Show("Lỗi!");
            }
        }
        private void search()
        {
            SqlCommand cmd;
            cmd = cnn.CreateCommand();
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();
            cmd.CommandText = "select* from Sach where MaSach like '%" + tbtk.Text + "%' or TenSach like N'%" + tbtk.Text + "%' or Gia like '%" + tbtk.Text + "%' or MaNXB like '%" + tbtk.Text + "%' or MaTL like '%" + tbtk.Text + "%' or SoLuong like '%" + tbtk.Text + "%'";
            adapter.SelectCommand = cmd;
            table.Clear();
            adapter.Fill(table);
            dgvsach.DataSource = table;
        }
        private void frm4DanhMucSach_Load(object sender, EventArgs e)
        {
            ketnoi();
            HienThi();
            loadmanxb();
            loadtl();
            txtma.Enabled = false;
            txtnxb_SelectedIndexChanged(sender, e);
            txttheloai_SelectedIndexChanged(sender, e);
            btback.Hide();
            if (bientoancuc.dangnhap == 0)
            {
                btback.Hide();
                btsua.Hide();
                bttqlnvxoa.Hide();
                bttttcnluu.Hide();
                btkt.Hide();
         
          
            }
        }
        private void bttttcnluu_Click(object sender, EventArgs e)
        {

            if (bttttcnluu.Text == "Thêm Mới")
            {
                txttheloai.Text = "";
                txtgia.Clear();
                txtma.Clear();
                txtnxb.Text = "";
                txtten.Clear();
                txtma.Focus();
                txtma.Enabled = true;
                bttttcnluu.Text = "Đồng Ý";
                btsua.Hide();
                bttqlnvxoa.Hide();
                btback.Show();

            }
            else
            {
                if ((txtma.Text != "") && (txtten.Text != "") && (txttheloai.Text != "") && (txtnxb.Text != ""))
                {

                    txtma.Enabled = false;
                    try
                    {
                        insert();
                        HienThi();
                        bttttcnluu.Text = "Thêm Mới";
                        bttqlnvxoa.Show();
                        btsua.Show();
                        btback.Hide();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Đã tồn tại mã sách. Hãy nhập một mã sách khác!");
                    }
                }
                else
                    MessageBox.Show("Hãy nhập thông tin còn thiếu vào!");
            }
        }

     

        private void bttqlnvxoa_Click(object sender, EventArgs e)
        {
            delete();
            HienThi();
        }

  

        private void txtnxb_SelectedIndexChanged(object sender, EventArgs e)
        {
            manxb = txtnxb.SelectedValue.ToString();
            
        }




        private void dgvsach_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.RowIndex;
            try
            {

                txtma.Text = dgvsach.Rows[i].Cells[0].Value.ToString();
                txtten.Text = dgvsach.Rows[i].Cells[1].Value.ToString();
                txtgia.Text = dgvsach.Rows[i].Cells[2].Value.ToString();
                txtnxb.SelectedValue = dgvsach.Rows[i].Cells[3].Value.ToString();
                txttheloai.SelectedValue = dgvsach.Rows[i].Cells[4].Value.ToString();
                txtsoluong.Text = dgvsach.Rows[i].Cells[5].Value.ToString();
                string tl = dgvsach.Rows[i].Cells[6].Value.ToString();
                if (tl.ToString() == "True")
                    txttinhtrang.Checked = true;
                else txttinhtrang.Checked = false;

            }
            catch (Exception) { }
        }


        private void btsua_Click(object sender, EventArgs e)
        {

                update();
                HienThi();
          
        }

        private void btthoat_Click(object sender, EventArgs e)
        {
            DialogResult f = MessageBox.Show("Bạn có muốn thoát không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (f == DialogResult.Yes)
            {
                this.Close();

            }
        }


        private void btback_Click(object sender, EventArgs e)
        {
            btsua.Show();
            bttqlnvxoa.Show();
            bttttcnluu.Text = "Thêm Mới";
            btback.Hide();

        }
        private void btkt_Click(object sender, EventArgs e)
        {
            txtgia.Text = "";
            txtma.Text = "";
            txtnxb.Text = "";
            txtsoluong.Text = "";
            txtten.Text = "";
            txttheloai.Text = "";
        }
        private void bttk_Click(object sender, EventArgs e)
        {
            search();
        }

        private void btload_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            HienThi();
        }
        private void txttheloai_SelectedIndexChanged(object sender, EventArgs e)
        {
            matl = txttheloai.SelectedValue.ToString();
          
        }

    }
}
