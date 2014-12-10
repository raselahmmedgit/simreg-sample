using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimReg.BusinessEntity
{
    public class BESIMREG_DELIVEREDBY : BEBase
    {
        public int DELIVEREDBYID { get; set; }

        public string TITLE { get; set; }

        public string USERNAME { get; set; }

        public bool CANEDIT { get; set; }

    }

    public class BESIMREG_DELIVEREDBYs : List<BESIMREG_DELIVEREDBY>
    {
    }
}
