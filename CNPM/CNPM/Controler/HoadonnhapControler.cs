using CNPM.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNPM.Controler
{
    internal class HoadonnhapControler
    {
        HoadonnhapModel model=new HoadonnhapModel();
        public  DataTable HoadonnhapTable()
        {
            return model.getdulieuHoadon();
        }
    }
}
