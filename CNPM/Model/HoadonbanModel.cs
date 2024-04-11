using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CNPM.Model
{
    internal class HoadonbanModel
    {
        DataTable dataTable = new DataTable();
        private static string constr = System.Configuration.ConfigurationManager.ConnectionStrings["BanhangnhasachTienPhong"].ToString();
        public DataTable getdulieuHoadon()
        {
            dataTable.Clear();
            using (SqlConnection connection = new SqlConnection(constr))
            {
                using (SqlCommand command = new SqlCommand("  select tblHoadonban.PK_iMahoadonban,sTennhanvien,sTenkhachhang,iSoluongban,sTensach,iDongia from tblKhachhang " +
                    "join tblHoadonban on tblKhachhang.PK_iKhachhang=tblHoadonban.FK_iKhachhang\r\n  join tblNhanvien on tblNhanvien.PK_iNhanvien=tblHoadonban.FK_iNhanvien\r\n " +
                    " join tblChitietHDB on tblChitietHDB.FK_iMahoadonban=tblHoadonban.PK_iMahoadonban\r\n  join tblSach on tblSach.PK_iSach=tblChitietHDB.FK_iSach" 
                    , connection))
                {
                    connection.Open();
                    dataTable.Load(command.ExecuteReader());
                    connection.Close();
                }
            }
            return dataTable;
        }
        public DataTable timkiemhoadon(string tenkh,string tensach,string tennv)
        {
            string cmd = "select tblHoadonban.PK_iMahoadonban,sTennhanvien,sTenkhachhang,iSoluongban,sTensach,iDongia from tblKhachhang " +
                "join tblHoadonban on tblKhachhang.PK_iKhachhang=tblHoadonban.FK_iKhachhang " +
                " join tblNhanvien on tblNhanvien.PK_iNhanvien=tblHoadonban.FK_iNhanvien" +
                " join tblChitietHDB on tblChitietHDB.FK_iMahoadonban=tblHoadonban.PK_iMahoadonban  join tblSach on tblSach.PK_iSach=tblChitietHDB.FK_iSach";
            string dieukienLoc = "";
            if (!string.IsNullOrEmpty(tenkh))
                dieukienLoc += string.Format(" where sTenkhachhang like N'%{0}%'",tenkh);

            if (!string.IsNullOrEmpty(tensach))
                dieukienLoc += string.Format(" AND sTensach LIKE N'%{0}%'", tensach);
            if (!string.IsNullOrEmpty(tennv))
                dieukienLoc += string.Format(" AND sTennhanvien LIKE N'%{0}%'", tennv);
            using (SqlConnection connection = new SqlConnection(constr))
            {
                using (SqlCommand command = new SqlCommand(cmd + dieukienLoc, connection))
                {
                    connection.Open();
                    dataTable.Load(command.ExecuteReader());
                    connection.Close();
                }
            }
            Console.WriteLine(cmd + dieukienLoc);
            return dataTable;
        }
    }
}
