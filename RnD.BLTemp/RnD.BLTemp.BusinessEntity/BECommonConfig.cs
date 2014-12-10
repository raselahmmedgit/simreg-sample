using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RnD.BLTemp.BusinessEntity
{
    public class BECommonConfig : BEBase
    {
        public Int32 CommonConfigId { set; get; }
        public string CommonConfigName { set; get; }
        public string GroupName { set; get; }
    }

    public class BECommonConfigs : List<BECommonConfig>
    {
    }
}
