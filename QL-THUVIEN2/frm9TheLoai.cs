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
    public partial class frm9TheLoai : Form
    {
        public frm9TheLoai()
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
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();
            SqlCommand cmd = new SqlCommand("select *from THELOAI", cnn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            dt = ds.Tables[0];
            dgv.DataSource = dt;
        }
        private void Form9_Load(object sender, EventArgs e)
        {
            ma.Enabled = false;
            ketnoi();
            HienThi();
            if (bientoancuc.dangnhap == 0)
            {
                bttqlnvxoa.Hide();
                bttthemmoi.Hide();
                btsua.Hide();
            }
        }

        private void bttthemmoi_Click(object sender, EventArgs e)
        {
            bttqlnvxoa.Enabled = false;
            btsua.Enabled = false;
            if(bttthemmoi.Text=="Thêm Mới")
            {
                ma.Clear();
                ten.Clear();
                bttthemmoi.Text = "Đồng Ý";
                ma.Focus();
                ma.Enabled = true;
                
                return;
            }
            if (bttthemmoi.Text=="Đồng Ý")
            {
                try
                {
                    string sql = "insert into THELOAI values('" + ma.Text + "',N'" + ten.Text + "')";
                    SqlCommand cmd = new SqlCommand(sql, cnn);
                    cmd.ExecuteNonQuery();
                    HienThi();
                    
                    ma.Enabled = false;
                    bttthemmoi.Text = "Thêm Mới";
                    bttqlnvxoa.Enabled = true;
                    btsua.Enabled = true;
                    return;
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); };

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bttqlnvxoa_Click(object sender, EventArgs e)
        {
            DialogResult f = MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (f == DialogResult.Yes)
            {
                SqlCommand cmd = new SqlCommand("delete from THELOAI where MaTL='" + ma.Text + "'", cnn);
                cmd.ExecuteNonQuery();
                HienThi();
            }
           
        }
        private void search()
        {

            SqlCommand cmd;
            cmd = cnn.CreateCommand();
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();
            cmd.CommandText = "select* from THELOAI where MaTL like '%" + tbtk.Text + "%' or TenTL like N'%" + tbtk.Text + "%' ";
            adapter.SelectCommand = cmd;
            table.Clear();
            adapter.Fill(table);
            dgv.DataSource = table;

        }
        private void bttk_Click(object sender, EventArgs e)
        {
            search();
        }

        private void btht_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            HienThi();
        }

        private void btsua_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("update THELOAI set  TenTL=N'" + ten.Text + "' where MaTL='" + ma.Text + "' ", cnn);
            cmd.ExecuteNonQuery();
            HienThi();
        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.RowIndex;
            try
            {
                ma.Text = dgv.Rows[i].Cells[0].Value.ToString().Trim();
                ten.Text = dgv.Rows[i].Cells[1].Value.ToString().Trim();
            }
            catch (Exception) { }
        }
    }
}
