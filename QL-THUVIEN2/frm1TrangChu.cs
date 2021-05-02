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

    public partial class frm1TrangChu : Form
    {

        public frm1TrangChu()
        {
            InitializeComponent();
        }
        SqlConnection cnn;
        string tk;

        public void KetNoi()
        {
            string ketnoi = @"Data Source=HD;Initial Catalog=DA_QLTV;Integrated Security=True";
            cnn = new SqlConnection(ketnoi);
            cnn.Open();
        }
        private void HienThi()
        {
            string sql = "select MaNV,TenNV,GioiTinh,DiaChi,SDT,NgaySinh,TaiKhoan from NHANVIEN";
            DataTable dtnv = new DataTable();
            DataSet dsnv = new DataSet();
            SqlCommand cmd = new SqlCommand(sql, cnn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dsnv);
            dtnv = dsnv.Tables[0];
            dgvnvdanhsach.DataSource = dtnv;
        }

        private void update()
        {
            string s = ttcnngaysinh.Value.Year + "/" + ttcnngaysinh.Value.Month + "/" + ttcnngaysinh.Value.Day;
            SqlCommand cmd = new SqlCommand("update NHANVIEN set TenNV=N'" + ttcnten.Text + "',GioiTinh=N'" + ttcngioitinh.Text + "',DiaChi=N'" + ttcndiachi.Text + "',SDT='" + ttcnsdt.Text + "',NgaySinh=convert(smalldatetime,'" + s.ToString() + "') where MaNV='" + ttcnma.Text + "'", cnn);
            cmd.ExecuteNonQuery();

        }
        private void delete()
        {
            try
            {
                string sql = "delete from NHANVIEN where MaNV='" + ttcnma.Text + "'";
                SqlCommand cmd = new SqlCommand(sql, cnn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception) { MessageBox.Show("Không thể xóa!"); }
        }
        private void insert()
        {

            string s = ttcnngaysinh.Value.Year + "/" + ttcnngaysinh.Value.Month + "/" + ttcnngaysinh.Value.Day;
            string sql =
                "insert into NHANVIEN(MaNV,TenNV,GioiTinh,DiaChi,SDT,NgaySinh) values('" + ttcnma.Text + "',N'" + ttcnten.Text + "',N'" + ttcngioitinh.Text + "',N'" + ttcndiachi.Text + "','" + ttcnsdt.Text + "',convert(smalldatetime,'" + s.ToString() + "'))";

            SqlCommand cmd = new SqlCommand(sql, cnn);
            cmd.Parameters.Add(new SqlParameter("@date", ttcnngaysinh.Value.Date));
            cmd.ExecuteNonQuery();

        }

        private void button22_Click(object sender, EventArgs e)
        {
            KetNoi();
            bientoancuc.dangnhap = 1;
            string sql = @"select * from NHANVIEN where TaiKhoan='" + txtdntaikhoan.Text + "' and MatKhau = '" + txtdnmatkhau.Text + "' ";
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();
            SqlCommand cmd = new SqlCommand(sql, cnn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            dt = ds.Tables[0];
            if (dt.Rows.Count > 0)
            {
                MessageBox.Show("Đăng nhập thành công !");
                bientoancuc.mk = txtdnmatkhau.Text;
                bientoancuc.tk = txtdntaikhoan.Text;
                bttdangnhap.Enabled = false;
                paneldsnv.Enabled = true;
                panelqlphieu.Enabled = true;
                panelqldocgia.Enabled = true;
                panelqlnhanvien.Enabled = true;
                paneldangnhap.Hide();
            }
            else
            {
                MessageBox.Show("Tài Khoản hoặc Mật khẩu\n không chính xác!");
                txtdntaikhoan.Focus();
            }
        }

        private void button23_Click(object sender, EventArgs e)
        {
            paneldangnhap.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtdnmatkhau.Clear();
            txtdntaikhoan.Clear();
            paneldangnhap.Visible = true;
            txtdntaikhoan.Focus();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            paneldsnv.Visible = true;
            HienThi();

        }
        private void dgvnvdanhsach_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.RowIndex;
            bttqltk.Visible = true;
            try
            {
                ttcnma.Text = dgvnvdanhsach.Rows[i].Cells[0].Value.ToString().Trim();
                ttcnten.Text = dgvnvdanhsach.Rows[i].Cells[1].Value.ToString().Trim();
                ttcngioitinh.Text = dgvnvdanhsach.Rows[i].Cells[2].Value.ToString().Trim();
                ttcndiachi.Text = dgvnvdanhsach.Rows[i].Cells[3].Value.ToString().Trim();
                ttcnsdt.Text = dgvnvdanhsach.Rows[i].Cells[4].Value.ToString().Trim();
                DateTime dt = Convert.ToDateTime(dgvnvdanhsach.Rows[i].Cells[5].Value.ToString());
                ttcnngaysinh.Value = dt;
                tk = dgvnvdanhsach.Rows[i].Cells[6].Value.ToString();

            }
            catch (Exception) { }
        }

        private void bttttcnluu_Click(object sender, EventArgs e)
        {
            if (bttttcnluu.Text == "Thêm Mới")
            {
                ttcngioitinh.Text = "";

                ttcnsdt.Clear();
                ttcnngaysinh.Text = "";
                ttcnten.Clear();
                ttcnma.Focus();
                ttcnma.Enabled = true;
                bttttcnluu.Text = "Đồng Ý";
                btsua.Hide();
                bttqlnvxoa.Hide();
                bttqltk.Hide();
                btback.Show();

            }
            else
            {
                if ((ttcnma.Text != "") && (ttcngioitinh.Text != "") && (ttcnten.Text != "") && (ttcnsdt.Text != "") && (ttcnngaysinh.Text != ""))
                {

                    ttcnma.Enabled = false;
                    try
                    {
                        insert();
                        HienThi();
                        bttttcnluu.Text = "Thêm Mới";
                        btsua.Show();
                        bttqlnvxoa.Show();
                        btback.Hide();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Đã tồn tại mã nhân viên. Hãy nhập một mã nhân viên khác!");
                    }
                }
                else
                    MessageBox.Show("Hãy nhập thông tin còn thiếu vào!");
            }
        }
        private void btsua_Click(object sender, EventArgs e)
        {
            update();
            HienThi();
        }
        private void bttqlnvxoa_Click(object sender, EventArgs e)
        {
            delete();
            HienThi();
        }
        private void bttqltk_Click(object sender, EventArgs e)
        {

            if (tk.ToString() == "")
            {
                frm2DKTK frm = new frm2DKTK();
                frm.MaNV = ttcnma.Text;
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Nhân viên này đã có tài khoản");
            }
        }
        private void listBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem.ToString() == "Nội Quy Thư Viện")
            {
                new frm8NoiQuy().ShowDialog();
            }
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void frm1TrangChu_Load(object sender, EventArgs e)
        {
            paneldangnhap.Hide();
            paneldsnv.Enabled = false;
            panelqlphieu.Enabled = false;
            panelqldocgia.Enabled = false;
            panelqlnhanvien.Enabled = false;
            KetNoi();
            btback.Hide();
            ttcnma.Enabled = false;
        }

        private void btback_Click(object sender, EventArgs e)
        {
            btsua.Show();
            bttqlnvxoa.Show();
            bttqltk.Show();
            btback.Hide();
            bttttcnluu.Text = "Thêm Mới";

        }

        private void btthoat_Click(object sender, EventArgs e)
        {
            DialogResult f = MessageBox.Show("Bạn có muốn thoát khỏi ứng dụng không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (f == DialogResult.Yes)
            {
                this.Close();
                Application.Exit();
            }
        }

        private void btdangxuat_Click(object sender, EventArgs e)
        {
            paneldangnhap.Hide();
            paneldsnv.Visible = false;
            panelqlphieu.Enabled = false;
            panelqldocgia.Enabled = false;
            panelqlnhanvien.Enabled = false;
            bttdangnhap.Enabled = true;
        }

        private void btdoimk_Click(object sender, EventArgs e)
        {
            frm2DKTK frm = new frm2DKTK();
            frm.ShowDialog();
        }

        private void btnhanvien_Click(object sender, EventArgs e)
        {
            KetNoi();
            paneldsnv.Visible = true;
            HienThi();
        }

        private void btdocgia_Click(object sender, EventArgs e)
        {

            frm3DocGia frm3 = new frm3DocGia();
            frm3.ShowDialog();
        }

        private void btsach_Click(object sender, EventArgs e)
        {
            frm4DanhMucSach frm4 = new frm4DanhMucSach();
            frm4.ShowDialog();
        }

        private void btnxb_Click(object sender, EventArgs e)
        {
            frm5NhaXuatBan frm5 = new frm5NhaXuatBan();
            frm5.ShowDialog();
        }

        private void bttheloai_Click(object sender, EventArgs e)
        {
            new frm9TheLoai().ShowDialog();
        }

        private void btphieumuon_Click(object sender, EventArgs e)
        {
            new frm6PhieuMuon().ShowDialog();
        }

        private void btphieutra_Click(object sender, EventArgs e)
        {
            new frm7PhieuTra().ShowDialog();
        }

        private void btlthoat_Click(object sender, EventArgs e)
        {
            DialogResult f = MessageBox.Show("Thoát khỏi Quản lý nhân viên?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (f == DialogResult.Yes)
            {
                paneldsnv.Hide();

            }
        }

        private void btht_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            HienThi();
        }

        private void cbmk_CheckedChanged(object sender, EventArgs e)
        {
            if (cbmk.Checked == true)
            {
                txtdnmatkhau.PasswordChar = (char)0;
            
            }
            else
            {
                txtdnmatkhau.PasswordChar = '*';
              
            }
        }
    }
}
