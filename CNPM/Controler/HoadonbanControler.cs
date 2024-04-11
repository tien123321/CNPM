using CNPM.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CNPM.Controler
{
    internal class HoadonbanControler
    {
        HoadonbanModel model=new HoadonbanModel();
        DataTable dt = new DataTable();
        public DataTable HoadonbanTable()
        {
            dt.Clear();
            dt = model.getdulieuHoadon();
            return dt;
        }
       
        public DataTable timKiemController(string tenkh, string tensach,string tennv)
        {

            dt.Clear();
            dt = model.timkiemhoadon(tenkh, tensach,tennv);
            return dt;
        }
    }
}
