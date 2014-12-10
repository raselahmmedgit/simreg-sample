using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimReg.BusinessEntity
{
    public class BESIMREG_REQUESTEDTYPE : BEBase
    {
        public int REQUESTEDTYPEID { get; set; }

        public string TITLE { get; set; }
    }

    public class BESIMREG_REQUESTEDTYPEs : List<BESIMREG_REQUESTEDTYPE>
    {
    }
}
