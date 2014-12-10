using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SimReg.BusinessEntity
{
    [DataContract, Serializable]
    public class BEBase
    {
        public BEBase()
        {
            this.Code = string.Empty;
            this.IsNew = true;
            this.IsDeleted = false;
            this.IsChecked = false;
            this.IDATE = DateTime.Now;
            this.EDATE = DateTime.Now;
            this.IsActive = true;
        }
        [DataMember]
        [XmlIgnoreAttribute]
        public bool IsNew { get; set; }
        [XmlIgnoreAttribute]
        public bool IsActive { get; set; }
        [XmlIgnoreAttribute]
        public bool IsChecked { get; set; }
        [XmlIgnoreAttribute]
        public bool IsDeleted { get; set; }
        [DataMember]
        [XmlIgnoreAttribute]
        public string Code { set; get; }
        [DataMember]
        [XmlIgnoreAttribute]
        public Int32 IUSER { set; get; }
        [XmlIgnoreAttribute]
        public DateTime IDATE { set; get; }
        [XmlIgnoreAttribute]
        public Int32 EUSER { set; get; }
        [XmlIgnoreAttribute]
        public DateTime EDATE { set; get; }
        [XmlIgnoreAttribute]
        public int Serial { set; get; }
        [XmlIgnoreAttribute]
        public int DeletedBy { set; get; }
        [XmlIgnoreAttribute]
        public DateTime DeletedDate { set; get; }

        public string ActionLink { get; set; }
    }
}
