using CNPM.Controler;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CNPM.View
{
    public partial class Quanlycuahangview : Form
    {
        public Quanlycuahangview()
        {
            InitializeComponent();
        }
        QUanlysachControler quanlysachControler= new QUanlysachControler();

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void label36_Click(object sender, EventArgs e)
        {

        }

        private void btnTimKiemDT_Click(object sender, EventArgs e)
        {
            this.quanlysachControler.TimKiemSach(mtbTenDT.Text, mtbRom.Text, mtbGiaFrom.Text, soluong.Text, cBHangSX.Text, comboBox3.Text, dataGridView1);
        }
        public void LoadQuanlysach()
        {
            quanlysachControler.QuanLyLoad(cBHangSX, comboBox3, dataGridView1);
        }
        private void Quanlycuahangview_Load(object sender, EventArgs e)
        {
            LoadQuanlysach();
        }

        private void btnThemDT_Click(object sender, EventArgs e)
        {
            if (this.quanlysachControler.checktensach(mtbTenDT.Text))
            {
                MessageBox.Show("Không được nhập trùng tên sách");
                return;
            }

            int dongia = int.Parse(mtbGiaFrom.Text.ToString());
            int sl = int.Parse(soluong.Text.ToString());

            if (dongia < 0 || sl < 0)
            {
                MessageBox.Show("Không được nhập số âm ");
                return;
            }

            if (mtbRom.Text == "" || mtbTenDT.Text == "" || mtbGiaFrom.Text == "" || soluong.Text == "")
            {
                MessageBox.Show("Không được để rỗng !");
            }
            else
            {
                try
                {
                    this.quanlysachControler.ThemSachController(mtbTenDT.Text, mtbRom.Text, mtbGiaFrom.Text, soluong.Text, cBHangSX.SelectedValue.ToString(), comboBox3.SelectedValue.ToString(), dataGridView1);
                    MessageBox.Show("Thêm thành công ");
                }
                catch
                {
                    MessageBox.Show(" Thêm không thành công");
                }
                hienSach();
            }
        }
        private void hienSach()
        {
            /* start */
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            this.quanlysachControler.hienSach(dataGridView1);
        }

        private void btnSuaDT_Click(object sender, EventArgs e)
        {
            int dongia = int.Parse(mtbGiaFrom.Text.ToString());
            int sl = int.Parse(soluong.Text.ToString());

            if (dongia < 0 || sl < 0)
            {
                MessageBox.Show("Không được cập nhập số âm ");
                return;
            }

            if (mtbRom.Text == "" || mtbTenDT.Text == "" || mtbGiaFrom.Text == "" || soluong.Text == "")
            {
                MessageBox.Show("Không được để rỗng !");
            }
            else
            {
                try
                {
                    this.quanlysachControler.SuaSach(mtbTenDT.Text, mtbRom.Text, mtbGiaFrom.Text, soluong.Text, cBHangSX.SelectedValue.ToString(), comboBox3.SelectedValue.ToString(), dataGridView1);
                    MessageBox.Show("Sửa thành công");
                }
                catch
                {
                    MessageBox.Show("Sửa không thành công");
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            mtbTenDT.Text = dataGridView1.CurrentRow.Cells["sTensach"].Value.ToString();
            mtbRom.Text = dataGridView1.CurrentRow.Cells["sTentacgia"].Value.ToString();
            mtbGiaFrom.Text = dataGridView1.CurrentRow.Cells["iDongia"].Value.ToString();
            soluong.Text = dataGridView1.CurrentRow.Cells["iSoluong"].Value.ToString();
            cBHangSX.Text = dataGridView1.CurrentRow.Cells["sTennhaxuatban"].Value.ToString();
            comboBox3.Text = dataGridView1.CurrentRow.Cells["sTenloaisach"].Value.ToString();
        }

        private void btnXoaDT_Click(object sender, EventArgs e)
        {
            this.quanlysachControler.XoaSach(mtbRom.Text, dataGridView1);
        }

        private void btnLamMoiDT_Click(object sender, EventArgs e)
        {
            mtbTenDT.Text = "";
            mtbRom.Text = "";
            mtbGiaFrom.Text = "";
            soluong.Text = "";
            hienSach();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void button17_Click(object sender, EventArgs e)
        {

        }
    }
}
