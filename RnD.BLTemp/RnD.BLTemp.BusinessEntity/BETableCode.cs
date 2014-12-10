using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RnD.BLTemp.BusinessEntity
{
    public class BETableCode
    {
        public Int32 ID { get; set; }
        public string TableName { get; set; }
        public Int32 MaxID { get; set; }
        public int CodeLength { get; set; }
        public int Year { get; set; }
        public bool ResetByYear { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
