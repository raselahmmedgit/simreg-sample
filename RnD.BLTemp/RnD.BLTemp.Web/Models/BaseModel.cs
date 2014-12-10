using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace RnD.BLTemp.Web.Models
{
    public class BaseModel
    {
        public BaseModel()
        {
            this.Code = string.Empty;
            this.IsNew = true;
            this.IsDeleted = false;
            this.IsChecked = false;
            this.CreatedDate = DateTime.Now;
            this.UpdatedDate = DateTime.Now;
            this.IsActive = true;

            string area = HttpContext.Current.Request.RequestContext.RouteData.DataTokens.ContainsKey("area") ? HttpContext.Current.Request.RequestContext.RouteData.DataTokens["area"].ToString() : null;
            string controller = HttpContext.Current.Request.RequestContext.RouteData.Values["controller"].ToString();
            string action = HttpContext.Current.Request.RequestContext.RouteData.Values["action"].ToString();

            this.AreaName = area;
            this.ControllerName = controller;
            this.ActionName = action;

            //this.ButtonName = this.ActionName;

            //if (this.ActionName == "Add")
            //{
            //    this.IsSubmitable = true;
            //    this.ButtonName = "Save";
            //    this.IsSaveMode = Boolean.TrueString;
            //    this.DialogMessage = "Data saved successfully.";
            //}
            //else if (this.ActionName == "Edit")
            //{
            //    this.IsSubmitable = true;
            //    this.ButtonName = "Update";
            //    this.DialogMessage = "Data updated successfully.";
            //}
            //else if (this.ActionName == "Delete")
            //{
            //    this.IsSubmitable = true;
            //    this.ButtonName = "Delete";
            //    this.DialogMessage = "Data deleted successfully.";
            //}
            //else
            //{
            //    this.IsSubmitable = false;
            //    this.DialogMessage = string.Empty;
            //}

        }
        public bool IsNew { get; set; }
        public bool IsActive { get; set; }
        public bool IsChecked { get; set; }
        public bool IsDeleted { get; set; }
        public string Code { set; get; }
        public Int32 CreatedBy { set; get; }
        public DateTime CreatedDate { set; get; }
        public Int32 UpdatedBy { set; get; }
        public DateTime UpdatedDate { set; get; }
        public int Serial { set; get; }
        public int DeletedBy { set; get; }
        public DateTime DeletedDate { set; get; }

        public string AreaName { set; get; }
        public string ControllerName { set; get; }
        public string ActionName { set; get; }

        public string IsSaveMode { set; get; }

        public string ButtonName { set; get; }

        public bool IsSubmitable { get; set; }

        public string DialogMessage { set; get; }
    }
}