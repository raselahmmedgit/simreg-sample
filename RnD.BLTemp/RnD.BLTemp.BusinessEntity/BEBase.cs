using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Runtime.Serialization;

namespace RnD.BLTemp.BusinessEntity
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
            this.CreatedDate = DateTime.Now;
            this.UpdatedDate = DateTime.Now;
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
        public Int32 CreatedBy { set; get; }
        [XmlIgnoreAttribute]
        public DateTime CreatedDate { set; get; }
        [XmlIgnoreAttribute]
        public Int32 UpdatedBy { set; get; }
        [XmlIgnoreAttribute]
        public DateTime UpdatedDate { set; get; }
        [XmlIgnoreAttribute]
        public int Serial { set; get; }
        [XmlIgnoreAttribute]
        public int DeletedBy { set; get; }
        [XmlIgnoreAttribute]
        public DateTime DeletedDate { set; get; }
    }
}
