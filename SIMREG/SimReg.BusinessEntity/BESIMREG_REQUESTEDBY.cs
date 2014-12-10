using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimReg.BusinessEntity
{
    public class BESIMREG_REQUESTEDBY : BEBase
    {
        public int REQUESTEDBYID { get; set; }

        public string TITLE { get; set; }
    }

    public class BESIMREG_REQUESTEDBYs : List<BESIMREG_REQUESTEDBY>
    {
    }
}
