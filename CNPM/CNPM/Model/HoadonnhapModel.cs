using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNPM.Model
{
    internal class HoadonnhapModel
    {
        private static string constr = System.Configuration.ConfigurationManager.ConnectionStrings["BanhangnhasachTienPhong"].ToString();
        public DataTable getdulieuHoadon()
        {
            DataTable dataTable = new DataTable();
            using(SqlConnection connection = new SqlConnection(constr))
            {
                using(SqlCommand command = new SqlCommand(" select PK_iMayeucaunhap,dNgaylap,sTennhanvien from" +
                    " tblNhanvien join tblPhieuyeucau on tblNhanvien.PK_iNhanvien=tblPhieuyeucau.FK_iNhanVien ",connection))
                {
                    connection.Open();
                    dataTable.Load(command.ExecuteReader());
                    connection.Close();
                }
            }
            return dataTable;
        }
    }
}
