using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RnD.BLTemp.BusinessEntity
{
    public class BECategory : BEBase
    {
        public Int32 CategoryId { set; get; }
        public string CategoryName { set; get; }
    }

    public class BECategorys : List<BECategory>
    {
    }
}
