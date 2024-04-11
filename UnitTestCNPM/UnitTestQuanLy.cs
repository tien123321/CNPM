using CNPM.Model;
using CNPM.Model.ClassData;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestCNPM
{
    [TestClass]
    public class UnitTestQuanLy
    {
        [TestMethod]
        public void TestThemNhanVien()
        {
            string tenNV = "nhan vien 1";
            DateTime ngaySinh = new DateTime(2000,1,1);
            int gioiTinh = 1;
            string queQuan = "Ha Noi";
            DateTime ngayVaoLam = new DateTime(2023, 10, 30);
            string sdt = "0123456789";
            int trangThai = 0;
            float luong = 10000;
            NhanvienModel nhanVien = new NhanvienModel();
            bool check = nhanVien.themNhanVien(tenNV, ngaySinh.ToShortDateString(),
                gioiTinh, queQuan, ngayVaoLam.ToShortDateString(), 
                sdt, trangThai, luong);
            Assert.IsTrue(check);
        }

        [TestMethod]
        public void TestThemKhachHang()
        {
            Custemer cus = new Custemer("Nguyen Van A","Ba Dinh, Ha Noi","0912345678");

            CustomerModel model = new CustomerModel();

            Assert.IsTrue(model.createTest(cus));
        }

        [TestMethod]
        public void TestThemSach()
        {
            string ten = "Sach 1";
            string tacgia = "Tac gia 1";
            string dongia = "1000";
            string soluong = "100";
            int maNXB = 1;
            int loaiSach = 1;
            QuanlysachModel model = new QuanlysachModel();
            Assert.IsTrue(model.ThemSach(ten,tacgia,dongia,soluong,maNXB,loaiSach));
        }
    }
}
