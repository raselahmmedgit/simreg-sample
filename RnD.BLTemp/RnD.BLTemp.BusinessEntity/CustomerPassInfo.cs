using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RnD.BLTemp.BusinessEntity
{
    public class CustomerPassInfo
    {
        public string ContractNumber { set; get; }
        public string MSISDN { set; get; }
        public bool CustomerRegisteredOnWeb { set; get; }
        public string CustPass { set; get; }
    }
}
