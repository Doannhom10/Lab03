using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLSV_test1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private int ktraMSSV(string masv)
        {
            for (int i = 0; i < dgvSV.Rows.Count - 1; i++)
            {
                if (dgvSV.Rows[i].Cells[1].Value.ToString().CompareTo(masv) == 0)
                    return i;
            }
            return -1;
        }
        /*private int demSV()
        {
            int dem = 0;
            for (int i = 0; i < dgvSV.Rows.Count - 1; i++)
                if (dgvSV.Rows[i].Cells[3].Value.ToString() == "Nam")
                    dem++;
            return dem;
        }
        private void setTongso()
        {
            int tongsosvnam = demSV();
            txtTongnam.Text = tongsosvnam.ToString();
            txtTongNu.Text = (dgvSV.Rows.Count - 1 - tongsosvnam).ToString();
        }*/

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Form2 frm2 = new Form2();
            frm2.ShowDialog();
            int i = ktraMSSV(frm2.masv);
            if (i != -1)
            {
                dgvSV.Rows[i].Cells[1].Value = frm2.masv;
                dgvSV.Rows[i].Cells[2].Value = frm2.hoten;
                dgvSV.Rows[i].Cells[5].Value = frm2.khoa;
                dgvSV.Rows[i].Cells[6].Value = frm2.diemtb;

                MessageBox.Show("Cập nhật dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (frm2.masv != null)
                {
                    DataGridViewRow row = (DataGridViewRow)dgvSV.Rows[0].Clone();
                    row.Cells[0].Value = dgvSV.Rows.Count;
                    row.Cells[1].Value = frm2.masv;
                    row.Cells[2].Value = frm2.hoten;
                    row.Cells[3].Value = frm2.khoa;
                    row.Cells[4].Value = frm2.diemtb;
                    dgvSV.Rows.Add(row);
                    MessageBox.Show("Thêm dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }



        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult rs = MessageBox.Show("Bạn muốn thoát?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void txtTimkiem_TextChanged(object sender, EventArgs e)
        {
            if (txtTimkiem.Text != "")
            {
                for (int i = 0; i < dgvSV.Rows.Count - 1; i++)
                {
                    int j = dgvSV.Rows[i].Cells[2].Value.ToString().LastIndexOf(" ");
                    string s = dgvSV.Rows[i].Cells[2].Value.ToString().Substring(j + 1);
                    if (!s.ToLower().StartsWith(txtTimkiem.Text.ToLower()))
                        dgvSV.Rows[i].Visible = false;
                }
            }
            else
            {
                foreach (DataGridViewRow row in dgvSV.Rows)
                {
                    row.Visible = true;
                }
            }
        }

        private void thốngKêToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string s = string.Format("Xuất sắc: {0,3} | Giỏi: {1,3} | Khá: {2,3} | Trung bình: {3,3} | Yếu: {4,3} | Kém: {5,3}", DemXepLoai(dgvSV, 9, 10), DemXepLoai(dgvSV, 8, 9), DemXepLoai(dgvSV, 7, 8), DemXepLoai(dgvSV, 5, 7), DemXepLoai(dgvSV, 4, 5), DemXepLoai(dgvSV, 0, 4));
            MessageBox.Show(s, "Thống kê xếp loại sinh viên", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private static int DemXepLoai(DataGridView dgv, int min, int max)
        {
            int dem = 0;
            if (max == 10)
            {
                for (int i = 0; i < dgv.Rows.Count - 1; i++)
                {
                    if (float.Parse(dgv.Rows[i].Cells[6].Value.ToString()) >= 9 && float.Parse(dgv.Rows[i].Cells[6].Value.ToString()) <= 10)
                        dem++;
                }
            }
            else
            {
                for (int i = 0; i < dgv.Rows.Count - 1; i++)
                {
                    if (float.Parse(dgv.Rows[i].Cells[6].Value.ToString()) >= min && float.Parse(dgv.Rows[i].Cells[6].Value.ToString()) < max)
                        dem++;

                }
            }
            return dem;
        }
        
        private void thoátToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            DialogResult rs = MessageBox.Show("Bạn muốn thoát?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                this.Close();
            }
        }

     
    }
}
