using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimReg.BusinessEntity
{
    public class BESIMREG_NEWFORM : BEBase
    {
        public int ID { get; set; }

        public int MSISDNID { get; set; }

        public string MSISDNTITLE { get; set; }

        public DateTime REQUESTEDDATE { get; set; }

        public int REQUESTEDBYID { get; set; }

        public int REQUESTEDTYPEID { get; set; }

        public DateTime DELIVEREDBYDATE { get; set; }

        public int DELIVEREDBYID { get; set; }
    }

    public class BESIMREG_NEWFORMs : List<BESIMREG_NEWFORM>
    {
    }
}
