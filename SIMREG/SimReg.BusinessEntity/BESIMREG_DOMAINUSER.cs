using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimReg.BusinessEntity
{
    #region Object of BESIMREG_DOMAINUSER

    public class BESIMREG_DOMAINUSER : BEBase
    {
        #region Constructor
        public BESIMREG_DOMAINUSER() { }
        #endregion

        #region Destructor
        ~BESIMREG_DOMAINUSER() { }
        #endregion

        #region Property

        public int userid { get; set; }

        public string loginname { get; set; }

        public string username { get; set; }

        #endregion
    }

    #endregion

    #region Collectin Object of BESIMREG_DOMAINUSER

    public class BESIMREG_DOMAINUSERs : List<BESIMREG_DOMAINUSER>
    {
        #region Constructor
        public BESIMREG_DOMAINUSERs() { }
        #endregion

        #region Destructor
        ~BESIMREG_DOMAINUSERs() { }
        #endregion

        #region Functions
        #endregion
    }

    #endregion
}
