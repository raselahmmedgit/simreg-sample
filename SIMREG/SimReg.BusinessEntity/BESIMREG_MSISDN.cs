using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimReg.BusinessEntity
{
    public class BESIMREG_MSISDN : BEBase
    {
        public int MSISDNID { get; set; }

        public string TITLE { get; set; }
    }

    public class BESIMREG_MSISDNs : List<BESIMREG_MSISDN>
    {
    }
}
