using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CNPM.View
{
    public partial class FormInHoaDon : Form
    {
        public int sohd;
        public FormInHoaDon()
        {
            InitializeComponent();
        }

        private void FormInHoaDon_Load(object sender, EventArgs e)
        {
            DataSet dataSet = new DataSet();

            // Kết nối đến cơ sở dữ liệu và truy vấn dữ liệu
            string connectionString = ConfigurationManager.ConnectionStrings["BanhangnhasachTienPhong"].ConnectionString;
            string query = "SELECT * FROM tblHoadonban WHERE PK_iMahoadonban = "+sohd; // Điều kiện lọc dữ liệu

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(dataSet, "tblHoadonban"); // Tên bảng dữ liệu
            }

            // Tạo một ReportDocument và tải báo cáo
            ReportDocument reportDocument = new ReportDocument();
            reportDocument.Load("C:\\Users\\Admin\\Downloads\\CNPM\\CNPM\\CNPM\\View\\CrystalReport2.rpt");

            // Đổ dữ liệu từ DataSet vào báo cáo
            reportDocument.SetDataSource(dataSet);
            // Thiết lập ReportSource cho CrystalReportViewer
            crystalReportViewer1.ReportSource = reportDocument;
            crystalReportViewer1.Refresh();
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
