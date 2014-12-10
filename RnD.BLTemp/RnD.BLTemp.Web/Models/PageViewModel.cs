using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RnD.BLTemp.Web.Models
{
    public class PageViewModel
    {
        public string Link { get; set; }
        public string LinkPre { get; set; }
        public string LinkNext { get; set; }
        public string LinkIstDot { get; set; }
        public string Link2ndDot { get; set; }
        public string LinkIstPage { get; set; }
        public string LinkLastPage { get; set; }
        public string LinkDynamicPage { get; set; }

        public string PageSize { get; set; }
        public string Index { get; set; }

        public string PageNumber10Class { get; set; }
        public string PageNumber20Class { get; set; }
        public string PageNumber30Class { get; set; }
        public string PageNumber40Class { get; set; }
        public string PageNumber50Class { get; set; }
        public string PageNumber60Class { get; set; }
        public string PageNumber70Class { get; set; }
        public string PageNumber80Class { get; set; }
        public string PageNumber90Class { get; set; }
        public string PageNumber100Class { get; set; }
    }
}