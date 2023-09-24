using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLSV_test1
{
        public partial class Form2 : Form
        {
            public string masv;
            public string hoten;
            public string email;
            public string khoa;
            public string diemtb;
            public string gioitinh;

            public Form2()
            {
                InitializeComponent();
            }

            private void btnClose_Click(object sender, EventArgs e)
            {
                DialogResult rs = MessageBox.Show("Bạn muốn thoát?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rs == DialogResult.Yes)
                {
                    this.Close();
                }
            }

            private void Form2_Load(object sender, EventArgs e)
            {
                cmbKhoa.SelectedIndex = 0;

            }

            private void btnAdd_Click(object sender, EventArgs e)
            {
                if (txtMaSV.Text != "" && txtTen.Text !=  "" && txtDTB.Text != "")
                {
                    masv = txtMaSV.Text;
                    diemtb = txtDTB.Text;
                    khoa = cmbKhoa.Text;
                    hoten = txtTen.Text;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Phải nhập đủ dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            private void txtMaSV_Leave(object sender, EventArgs e)
            {
                if (txtMaSV.Text.Length != 10)
                {
                    MessageBox.Show("Mã số sinh viên không hợp lệ! Vui lòng nhập lại");
                    txtMaSV.Text = "";
                }
            }

            private void txtTen_Leave(object sender, EventArgs e)
            {
                if (txtTen.Text.Length < 3 || txtTen.Text.Length > 100)
                {
                    MessageBox.Show("Họ tên không hợp lệ! Vui lòng nhập lại");
                    txtTen.Text = "";
                }
            }

          

            private void txtDTB_TextChanged(object sender, EventArgs e)
            {

            }

            private void txtDTB_Leave(object sender, EventArgs e)
            {
                float n;
                var isNumberic = float.TryParse(txtDTB.Text, out n);
                if (!isNumberic || float.Parse(txtDTB.Text) < 0 || float.Parse(txtDTB.Text) > 10)
                {
                    MessageBox.Show("Điểm không hợp lệ! Vui lòng nhập lại");
                    txtDTB.Text = "";
                }
            }

           
  
            private void txtTen_KeyPress(object sender, KeyPressEventArgs e)
            {
                e.Handled = !((e.KeyChar >= 65 && e.KeyChar <= 122 && e.KeyChar != 91 && e.KeyChar != 92 && e.KeyChar != 93 && e.KeyChar != 94 && e.KeyChar != 95 && e.KeyChar != 96) || (e.KeyChar == 32)) || (e.KeyChar == 8);
            }

            private void txtMaSV_KeyPress(object sender, KeyPressEventArgs e)
            {
                if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                    e.Handled = true;
            }

            private void txtDTB_KeyPress(object sender, KeyPressEventArgs e)
            {
                e.Handled = !((e.KeyChar >= 48 && e.KeyChar <= 57) || (e.KeyChar == 46)) || (e.KeyChar == 8);
            }

       
    }
    
}
