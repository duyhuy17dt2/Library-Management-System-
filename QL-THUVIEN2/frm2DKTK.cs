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
    public partial class frm2DKTK : Form
    {

        private string _manv;

        public frm2DKTK()
        {
            InitializeComponent();
        }
        SqlConnection cnn;

        public void KetNoi()
        {
            string ketnoi = @"Data Source=HD;Initial Catalog=DA_QLTV;Integrated Security=True";
            cnn = new SqlConnection(ketnoi);
            cnn.Open();
        }
        public string MaNV
        {
            get { return _manv; }
            set { _manv = value; }
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            
            lbltaikhoan.Text = bientoancuc.tk;
  
            KetNoi();
            if (bientoancuc.tk != null)
            {
                panel1.Visible=true;
                panel2.Hide();
            }
            if (_manv != null)
            {
                panel1.Hide();
                panel2.Visible = true;
            }
        }    
   
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void button5_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            panel2.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            panel2.Visible = true;
            panel1.Hide();
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            if (txtmkcu.Text == bientoancuc.mk)
            {
                if (txtmkmoi.Text == txtmklai.Text)
                {
                    try
                    {
                        string sql = "update NHANVIEN set MatKhau='" + txtmkmoi.Text + "' where TaiKhoan='" + lbltaikhoan.Text + "' ";
                        SqlCommand cmd = new SqlCommand(sql, cnn);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Thay đổi thành công !");
                        this.Close();
                    }
                    catch (Exception ) { MessageBox.Show("Lỗi !"); }
                }
                else { MessageBox.Show("Mật khẩu mới không khớp!");
                txtmkmoi.Focus();
                }
            }
            else
            {
                MessageBox.Show("Mật khẩu không chính xác !");
                txtmkcu.Focus(); 
            }
        }

        private void btthoat_Click(object sender, EventArgs e)
        {
            DialogResult f = MessageBox.Show("Bạn có muốn thoát không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (f == DialogResult.Yes)
            {
                this.Close();
                
            }
        }

        private void btluu_Click(object sender, EventArgs e)
        {


            if ((txtmk1.Text == txtmk.Text) && (txtmk.Text != ""))
            {
                try
                {
                    string sql = @"select TaiKhoan  from NHANVIEN where MaNV='" + _manv.ToString() + "' and TaiKhoan='" + null + "' ";
                    DataTable dt = new DataTable();
                    DataSet ds = new DataSet();
                    SqlCommand cmd = new SqlCommand(sql, cnn);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(ds);
                    dt = ds.Tables[0];
                    string insert = "update NHANVIEN set TaiKhoan='" + txttk.Text + "',MatKhau='" + txtmk.Text + "' where MaNV='" + _manv.ToString() + "' ";
                    
                    SqlCommand cmd1 = new SqlCommand(insert, cnn);
                    cmd1.ExecuteNonQuery();
                    MessageBox.Show("Tạo  tài khoản thành công!");
                    this.Close();

                }
                catch (Exception) { MessageBox.Show("Trùng tên tài khoản. Vui lòng nhập tài khoản khác!"); }

            }
            else if (txtmk.Text == "") MessageBox.Show("Vui lòng nhập mật khẩu vào.");
            else MessageBox.Show("Mật khẩu không khớp!");
        
        }

        private void cbmk_CheckedChanged(object sender, EventArgs e)
        {
            if (cbmk.Checked == true)
            {
                txtmkcu.PasswordChar = (char)0;
                txtmkmoi.PasswordChar = (char)0;
                txtmklai.PasswordChar = (char)0;
            }
            else
            {
                txtmkcu.PasswordChar = '*';
                txtmkmoi.PasswordChar = '*';
                txtmklai.PasswordChar = '*';
            }
        }

        private void cbhien_CheckedChanged(object sender, EventArgs e)
        {
            if (cbhien.Checked == true)
            {
                txtmk.PasswordChar = (char)0;
                txtmk1.PasswordChar = (char)0;
                
            }
            else
            {
                txtmk.PasswordChar = '*';
                txtmk1.PasswordChar = '*';
            }
        }
    }
}
