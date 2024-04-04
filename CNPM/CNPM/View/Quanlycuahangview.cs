using CNPM.Controler;
using CNPM.Model.ClassData;
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
        CustomerController _customerController=new CustomerController();

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
            string Tabquanly = Properties.Settings.Default.tabdulieu;
            string loaitk = Properties.Settings.Default.Loaitk;
            MessageBox.Show(loaitk);
            if(Tabquanly== "Quanlythongtin")
            {
                tabControl1.TabPages.RemoveAt(6);
                tabControl1.TabPages.RemoveAt(6);
                tabControl1.TabPages.RemoveAt(6);
                //tài khoản
                if (loaitk == "Nhanvien")
                {
                    tabControl1.TabPages.RemoveAt(3);
                    tabControl1.TabPages.RemoveAt(3);
                    tabControl1.TabPages.RemoveAt(3);
                }
                else
                {

                }
                LoadQuanlysach();
                List<Custemer> customers = this._customerController.allCustomers();
                int customerQuantity = customers.Count;
                if (customerQuantity > 0)
                {
                    foreach (var customer in customers)
                    {
                        dgvCustomer.Rows.Add(customer.Id, customer.Fullname, customer.Phone, customer.Address);
                    }
                }
            }
            else
            {
                for(int i = 0; i < 6; i++)
                {
                    tabControl1.TabPages.RemoveAt(0);
                }
            }
         
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

        private void btnSearchCustomer_Click(object sender, EventArgs e)
        {
            dgvCustomer.DataSource = null;
            dgvCustomer.Rows.Clear();
            String customerName, customerAddress, customerPhone;
            customerName = txtCustomerName.Text;
            customerAddress = txtCustomerAddress.Text;
            customerPhone = txtCustomerPhone.Text;

            Custemer filterCustomer = new Custemer(1, customerName, customerAddress, customerPhone);
            List<Custemer> customers = this._customerController.searchCustomers(filterCustomer);
            int customerQuantity = customers.Count;
            if (customerQuantity > 0)
            {
                foreach (var customer in customers)
                {

                    dgvCustomer.Rows.Add(customer.Id, customer.Fullname, customer.Phone, customer.Address);
                }
            }
        }

        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            String customerName, customerAddress, customerPhone;
            customerName = txtCustomerName.Text;
            customerAddress = txtCustomerAddress.Text;
            customerPhone = txtCustomerPhone.Text;

            Custemer customer = new Custemer(1, customerName, customerAddress, customerPhone);

            bool isValid = customer.requiredFields();
            bool isPhone = customer.isPhoneNumber();
            bool isExistCustomer = this._customerController.isExistCustomer(customer);
            if (!isValid)
            {
                MessageBox.Show("Điền đầy đủ thông tin khách hàng");
                return;
            }
            if (!isPhone)
            {

                MessageBox.Show("Số điện thoại không đúng định dạng");
                return;
            }

            if (isExistCustomer)
            {
                MessageBox.Show("Số điện thoại đã tồn tại trong hệ thống");
                return;
            }

            Custemer createdCustomer = this._customerController.createCustomer(customer);
            if (createdCustomer.Id == 1)
            {
                MessageBox.Show("Tạo khách hàng thất bại");
            }
            else
            {
                MessageBox.Show("Tạo khách hàng thành công");

            }

            //refresh dataGridView
            dgvCustomer.DataSource = null;
            dgvCustomer.Rows.Clear();
            List<Custemer> afterCustomerCreatedList = this._customerController.allCustomers();
            int customerQuantity = afterCustomerCreatedList.Count;
            if (customerQuantity > 0)
            {
                foreach (var item in afterCustomerCreatedList)
                {
                    dgvCustomer.Rows.Add(item.Id, item.Fullname, item.Phone, item.Address);
                }
            }
        }

        private void btnUpdateCustomer_Click(object sender, EventArgs e)
        {
            String customerName, customerAddress, customerPhone;
            customerName = txtCustomerName.Text;
            customerAddress = txtCustomerAddress.Text;
            customerPhone = txtCustomerPhone.Text;

            Custemer customer = new Custemer(1, customerName, customerAddress, customerPhone);

            bool isValid = customer.requiredFields();
            bool isPhone = customer.isPhoneNumber();
            Console.Write("editing");
            if (!isValid)
            {
                MessageBox.Show("Điền đầy đủ thông tin khách hàng");
                return;
            }
            if (!isPhone)
            {

                MessageBox.Show("Số điện thoại không đúng định dạng");
                return;
            }



            Custemer createdCustomer = this._customerController.updateCustomer(customer);
            if (createdCustomer.Id == 1)
            {
                MessageBox.Show("Cập nhật khách hàng thất bại");
            }
            else
            {
                MessageBox.Show("Cập khách hàng thành công");

            }

            //refresh dataGridView
            dgvCustomer.DataSource = null;
            dgvCustomer.Rows.Clear();
            List<Custemer> afterUpdateList = this._customerController.allCustomers();
            int customerQuantity = afterUpdateList.Count;
            if (customerQuantity > 0)
            {
                foreach (var item in afterUpdateList)
                {
                    dgvCustomer.Rows.Add(item.Id, item.Fullname, item.Phone, item.Address);
                }
            }
        }

        private void dgvCustomer_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvCustomer_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtCustomerName.Text = dgvCustomer.CurrentRow.Cells[1].Value.ToString();
            txtCustomerPhone.Text = dgvCustomer.CurrentRow.Cells[2].Value.ToString();
            txtCustomerAddress.Text = dgvCustomer.CurrentRow.Cells[3].Value.ToString();
        }

        private void btnDeleteCustomer_Click(object sender, EventArgs e)
        {
            String customerName, customerAddress, customerPhone;
            customerName = txtCustomerName.Text;
            customerAddress = txtCustomerAddress.Text;
            customerPhone = txtCustomerPhone.Text;

            Custemer customer = new Custemer(1, customerName, customerAddress, customerPhone);
            this._customerController.deleteCustomer(customer);

            //refresh dataGridView
            dgvCustomer.DataSource = null;
            dgvCustomer.Rows.Clear();
            List<Custemer> afterList = this._customerController.allCustomers();
            int customerQuantity = afterList.Count;
            if (customerQuantity > 0)
            {
                foreach (var item in afterList)
                {
                    dgvCustomer.Rows.Add(item.Id, item.Fullname, item.Phone, item.Address);
                }
            }
        }

        private void btnRefreshCustomer_Click(object sender, EventArgs e)
        {

            txtCustomerName.Text = "";
            txtCustomerPhone.Text = "";
            txtCustomerAddress.Text = "";
        }
    }
}
