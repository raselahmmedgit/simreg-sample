using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SimReg.BusinessEntity;
using SimReg.BusinessObject;
using SimReg.Web.Helpers;
using SimReg.Web.ViewModels;

namespace SimReg.Web.Controllers
{
    [Authorize]
    public class SimRegisterController : Controller
    {
        #region Global Variable

        BOSIMREG_DELIVEREDBY _boSIMREG_DELIVEREDBY;
        BOSIMREG_MSISDN _boSIMREG_MSISDN;
        BOSIMREG_NEWFORM _boSIMREG_NEWFORM;
        BOSIMREG_REQUESTEDBY _boSIMREG_REQUESTEDBY;
        BOSIMREG_REQUESTEDTYPE _boSIMREG_REQUESTEDTYPE;

        #endregion

        #region Action

        //
        // GET: /NEWFORM/

        public ActionResult Index()
        {

            _boSIMREG_REQUESTEDBY = new BOSIMREG_REQUESTEDBY();

            var sIMREG_REQUESTEDBYList = SelectListItemExtension.PopulateDropdownList(_boSIMREG_REQUESTEDBY.GetSIMREG_REQUESTEDBYs().ToList<BESIMREG_REQUESTEDBY>(), "REQUESTEDBYID", "TITLE").ToList();

            var sIMREG_NEWFORMSearchViewModel = new SIMREG_NEWFORMSearchViewModel();

            sIMREG_NEWFORMSearchViewModel.ddlREQUESTEDBYS = sIMREG_REQUESTEDBYList;

            //return View();
            return View(sIMREG_NEWFORMSearchViewModel);
        }

        //// for display jqGrid
        //public ActionResult GetSimRegisterList()
        //{
        //    var sIMREG_NEWFORMViewModelList = GetNEWFORMDataList().ToList();

        //    var viewModels = sIMREG_NEWFORMViewModelList.Select(data => new SIMREG_NEWFORMGridViewModel()
        //    {
        //        ID = Convert.ToString(data.ID),
        //        MSISDNID = Convert.ToString(data.MSISDNID),
        //        MSISDNTITLE = data.MSISDNTITLE,
        //        REQUESTEDDATE = Convert.ToDateTime(data.REQUESTEDDATE).ToString("dd-MMM-yyyy"),
        //        REQUESTEDBYID = Convert.ToString(data.REQUESTEDBYID),
        //        REQUESTEDBYTITLE = data.REQUESTEDBYTITLE,
        //        REQUESTEDTYPEID = Convert.ToString(data.REQUESTEDTYPEID),
        //        REQUESTEDTYPETITLE = data.REQUESTEDTYPETITLE,
        //        DELIVEREDBYDATE = Convert.ToDateTime(data.DELIVEREDBYDATE).ToString("dd-MMM-yyyy"),
        //        DELIVEREDBYID = Convert.ToString(data.DELIVEREDBYID),
        //        DELIVEREDBYTITLE = Convert.ToString(data.DELIVEREDBYTITLE),
        //        //IDATE = Convert.ToString(data.IDATE),
        //        //IUSER = Convert.ToString(data.IUSER),
        //        //IUSERNAME = Convert.ToString(data.IUSERNAME),
        //        //EDATE = data.EDATE.ToString("MM/dd/YYYY"),
        //        //EUSER = Convert.ToString(data.EUSER),
        //        //EUSERNAME = data.EUSERNAME,
        //        ActionLink = JQGridHelper.GenerateActionLink(data.ID.ToString(), "SimRegister")
        //    });

        //    //No of total records
        //    int totalRecords = (int)sIMREG_NEWFORMViewModelList.Count;
        //    //Calculate total no of page  
        //    int totalPages = 1;   // (int)Math.Ceiling((float)totalRecords / (float)Rows);
        //    var getdata = new
        //    {
        //        total = totalPages,
        //        page = 1,
        //        records = totalRecords,
        //        rows = (
        //            from jq in viewModels
        //            select new
        //            {
        //                cell = new string[] { 
        //                    jq.ID,
        //                    jq.MSISDNID,
        //                    jq.MSISDNTITLE,
        //                    jq.REQUESTEDDATE,
        //                    jq.REQUESTEDBYID,
        //                    jq.REQUESTEDBYTITLE,
        //                    jq.REQUESTEDTYPEID,
        //                    jq.REQUESTEDTYPETITLE,
        //                    jq.DELIVEREDBYDATE,
        //                    jq.DELIVEREDBYID,
        //                    jq.DELIVEREDBYTITLE,
        //                    jq.ActionLink }
        //            }).ToArray()
        //    };
        //    return Json(getdata);
        //}

        //private List<SIMREG_NEWFORMViewModel> GetNEWFORMDataList()
        //{
        //    _boSIMREG_NEWFORM = new BOSIMREG_NEWFORM();
        //    _boSIMREG_REQUESTEDBY = new BOSIMREG_REQUESTEDBY();
        //    _boSIMREG_REQUESTEDTYPE = new BOSIMREG_REQUESTEDTYPE();
        //    _boSIMREG_DELIVEREDBY = new BOSIMREG_DELIVEREDBY();

        //    List<SIMREG_NEWFORMViewModel> modellist = new List<SIMREG_NEWFORMViewModel>();

        //    var sIMREG_NEWFORMList = _boSIMREG_NEWFORM.GetSIMREG_NEWFORMs().ToList();

        //    modellist = sIMREG_NEWFORMList.Select(x => new SIMREG_NEWFORMViewModel
        //    {

        //        ID = x.ID,
        //        MSISDNID = x.MSISDNID,
        //        //MSISDNTITLE = _boSIMREG_MSISDN.GetSIMREG_MSISDN(x.MSISDNID).TITLE,
        //        MSISDNTITLE = x.MSISDNTITLE,
        //        REQUESTEDDATE = x.REQUESTEDDATE,
        //        REQUESTEDBYID = x.REQUESTEDBYID,
        //        REQUESTEDBYTITLE = _boSIMREG_REQUESTEDBY.GetSIMREG_REQUESTEDBY(x.REQUESTEDBYID).TITLE,
        //        REQUESTEDTYPEID = x.REQUESTEDTYPEID,
        //        REQUESTEDTYPETITLE = _boSIMREG_REQUESTEDTYPE.GetSIMREG_REQUESTEDTYPE(x.REQUESTEDTYPEID).TITLE,
        //        DELIVEREDBYDATE = x.DELIVEREDBYDATE,
        //        DELIVEREDBYID = x.DELIVEREDBYID,
        //        DELIVEREDBYTITLE = _boSIMREG_DELIVEREDBY.GetSIMREG_DELIVEREDBY(x.DELIVEREDBYID).TITLE,
        //        IDATE = x.IDATE,
        //        IUSER = x.IUSER,
        //        EDATE = x.EDATE,
        //        EUSER = x.EUSER

        //    }).ToList();

        //    return modellist;
        //}

        // for display jqGrid
        public ActionResult GetSimRegisterList(string sidx, string sord, int page, int rows, string msisdnTitle, string requestById, string requestFromDate, string requestToDate, string deliverFromDate, string deliverToDate)
        {
            var sIMREG_NEWFORMViewModelList = GetNEWFORMDataList(sidx, sord, page, rows, msisdnTitle, requestById, requestFromDate, requestToDate, deliverFromDate, deliverToDate).ToList();

            bool canEdit = Session["CanEdit"] != null ? Convert.ToBoolean(Session["CanEdit"]) : false;

            var viewModels = sIMREG_NEWFORMViewModelList.Select(data => new SIMREG_NEWFORMGridViewModel()
            {
                ID = Convert.ToString(data.ID),
                MSISDNID = Convert.ToString(data.MSISDNID),
                MSISDNTITLE = data.MSISDNTITLE,
                REQUESTEDDATE = Convert.ToDateTime(data.REQUESTEDDATE).ToString("dd-MMM-yyyy"),
                REQUESTEDBYID = Convert.ToString(data.REQUESTEDBYID),
                REQUESTEDBYTITLE = data.REQUESTEDBYTITLE,
                REQUESTEDTYPEID = Convert.ToString(data.REQUESTEDTYPEID),
                REQUESTEDTYPETITLE = data.REQUESTEDTYPETITLE,
                DELIVEREDBYDATE = Convert.ToDateTime(data.DELIVEREDBYDATE).ToString("dd-MMM-yyyy"),
                DELIVEREDBYID = Convert.ToString(data.DELIVEREDBYID),
                DELIVEREDBYTITLE = Convert.ToString(data.DELIVEREDBYTITLE),
                //IDATE = Convert.ToString(data.IDATE),
                //IUSER = Convert.ToString(data.IUSER),
                //IUSERNAME = Convert.ToString(data.IUSERNAME),
                //EDATE = data.EDATE.ToString("MM/dd/YYYY"),
                //EUSER = Convert.ToString(data.EUSER),
                //EUSERNAME = data.EUSERNAME,
                ActionLink = JQGridHelper.GenerateActionLink(id: data.ID.ToString(), controllerName: "SimRegister", isView: true, isEdit: canEdit)
            });

            //No of total records
            //int totalRecords = (int)sIMREG_NEWFORMViewModelList.Count;
            int totalRecords = (int)GetTotalNEWFORM();
            //Calculate total no of page  
            int totalPages = (int)Math.Ceiling((float)totalRecords / (float)rows);
            var getdata = new
            {
                total = totalPages,
                page,
                records = totalRecords,
                rows = (
                    from jq in viewModels
                    select new
                    {
                        cell = new string[] { 
							jq.ID,
							jq.MSISDNID,
                            jq.MSISDNTITLE,
							jq.REQUESTEDDATE,
                            jq.REQUESTEDBYID,
							jq.REQUESTEDBYTITLE,
                            jq.REQUESTEDTYPEID,
							jq.REQUESTEDTYPETITLE,
                            jq.DELIVEREDBYDATE,
							jq.DELIVEREDBYID,
                            jq.DELIVEREDBYTITLE,
							jq.ActionLink }
                    }).ToArray()
            };
            return Json(getdata);
        }

        private List<SIMREG_NEWFORMViewModel> GetNEWFORMDataList(string sidx, string sord, int page, int rows, string msisdnTitle, string requestById, string requestFromDate, string requestToDate, string deliverFromDate, string deliverToDate)
        {
            _boSIMREG_NEWFORM = new BOSIMREG_NEWFORM();
            _boSIMREG_REQUESTEDBY = new BOSIMREG_REQUESTEDBY();
            _boSIMREG_REQUESTEDTYPE = new BOSIMREG_REQUESTEDTYPE();
            _boSIMREG_DELIVEREDBY = new BOSIMREG_DELIVEREDBY();

            if (!String.IsNullOrEmpty(requestFromDate))
            {
                requestFromDate = Convert.ToDateTime(requestFromDate).ToString("dd-MMM-yyyy");
            }

            if (!String.IsNullOrEmpty(requestToDate))
            {
                requestToDate = Convert.ToDateTime(requestToDate).ToString("dd-MMM-yyyy");
            }

            if (!String.IsNullOrEmpty(deliverFromDate))
            {
                deliverFromDate = Convert.ToDateTime(deliverFromDate).ToString("dd-MMM-yyyy");
            }

            if (!String.IsNullOrEmpty(deliverToDate))
            {
                deliverToDate = Convert.ToDateTime(deliverToDate).ToString("dd-MMM-yyyy");
            }

            List<SIMREG_NEWFORMViewModel> modellist = new List<SIMREG_NEWFORMViewModel>();

            var sIMREG_NEWFORMList = _boSIMREG_NEWFORM.GetSIMREG_NEWFORMs(sidx, sord, page, rows, msisdnTitle, requestById, requestFromDate, requestToDate, deliverFromDate, deliverToDate).ToList();

            modellist = sIMREG_NEWFORMList.Select(x => new SIMREG_NEWFORMViewModel
            {

                ID = x.ID,
                MSISDNID = x.MSISDNID,
                //MSISDNTITLE = _boSIMREG_MSISDN.GetSIMREG_MSISDN(x.MSISDNID).TITLE,
                MSISDNTITLE = x.MSISDNTITLE,
                REQUESTEDDATE = x.REQUESTEDDATE,
                REQUESTEDBYID = x.REQUESTEDBYID,
                REQUESTEDBYTITLE = _boSIMREG_REQUESTEDBY.GetSIMREG_REQUESTEDBY(x.REQUESTEDBYID).TITLE,
                REQUESTEDTYPEID = x.REQUESTEDTYPEID,
                REQUESTEDTYPETITLE = _boSIMREG_REQUESTEDTYPE.GetSIMREG_REQUESTEDTYPE(x.REQUESTEDTYPEID).TITLE,
                DELIVEREDBYDATE = x.DELIVEREDBYDATE,
                DELIVEREDBYID = x.DELIVEREDBYID,
                DELIVEREDBYTITLE = _boSIMREG_DELIVEREDBY.GetSIMREG_DELIVEREDBY(x.DELIVEREDBYID).TITLE,
                IDATE = x.IDATE,
                IUSER = x.IUSER,
                EDATE = x.EDATE,
                EUSER = x.EUSER

            }).ToList();

            return modellist;
        }

        private int GetTotalNEWFORM()
        {
            _boSIMREG_NEWFORM = new BOSIMREG_NEWFORM();

            int totalRow = 0;

            return totalRow = _boSIMREG_NEWFORM.TotalDataCount();
        }

        public ActionResult Search()
        {
            try
            {
                _boSIMREG_REQUESTEDBY = new BOSIMREG_REQUESTEDBY();
                _boSIMREG_REQUESTEDTYPE = new BOSIMREG_REQUESTEDTYPE();
                _boSIMREG_DELIVEREDBY = new BOSIMREG_DELIVEREDBY();

                var sIMREG_NEWFORMSearchViewModel = new SIMREG_NEWFORMSearchViewModel();

                var sIMREG_REQUESTEDBYList = SelectListItemExtension.PopulateDropdownList(_boSIMREG_REQUESTEDBY.GetSIMREG_REQUESTEDBYs().ToList<BESIMREG_REQUESTEDBY>(), "REQUESTEDBYID", "TITLE").ToList();

                var sIMREG_REQUESTEDTYPEList = SelectListItemExtension.PopulateDropdownList(_boSIMREG_REQUESTEDTYPE.GetSIMREG_REQUESTEDTYPEs().ToList<BESIMREG_REQUESTEDTYPE>(), "REQUESTEDTYPEID", "TITLE").ToList();

                var sIMREG_DELIVEREDBYList = SelectListItemExtension.PopulateDropdownList(_boSIMREG_DELIVEREDBY.GetSIMREG_DELIVEREDBYs().ToList<BESIMREG_DELIVEREDBY>(), "DELIVEREDBYID", "TITLE").ToList();

                sIMREG_NEWFORMSearchViewModel.ddlREQUESTEDBYS = sIMREG_REQUESTEDBYList;
                sIMREG_NEWFORMSearchViewModel.ddlREQUESTEDTYPES = sIMREG_REQUESTEDTYPEList;
                sIMREG_NEWFORMSearchViewModel.ddlDELIVEREDBYS = sIMREG_DELIVEREDBYList;

                return View(sIMREG_NEWFORMSearchViewModel);

            }
            catch (Exception ex)
            {
                ExceptionHelper.ExceptionMessageFormat(ex);
                return View("Error", ex);
            }
        }

        // for display jqGrid
        //public ActionResult GetSimRegisterListByParam(string msisdnTitle, string requestById, string requestTypeId, string deliverById, string fromDate, string toDate)
        public ActionResult GetSimRegisterListByParam(string sidx, string sord, int page, int rows, string msisdnTitle, string requestById, string requestTypeId, string deliverById, string requestFromDate, string requestToDate, string deliverFromDate, string deliverToDate)
        {
            //var sIMREG_NEWFORMViewModelList = GetNEWFORMDataList(msisdnTitle, requestById, requestTypeId, deliverById, fromDate, toDate).ToList();
            var sIMREG_NEWFORMViewModelList = GetNEWFORMDataList(sidx, sord, page, rows, msisdnTitle, requestById, requestTypeId, deliverById, requestFromDate, requestToDate, deliverFromDate, deliverToDate).ToList();

            var viewModels = sIMREG_NEWFORMViewModelList.Select(data => new SIMREG_NEWFORMGridViewModel()
            {
                ID = Convert.ToString(data.ID),
                MSISDNID = Convert.ToString(data.MSISDNID),
                MSISDNTITLE = data.MSISDNTITLE,
                REQUESTEDDATE = Convert.ToDateTime(data.REQUESTEDDATE).ToString("dd-MMM-yyyy"),
                REQUESTEDBYID = Convert.ToString(data.REQUESTEDBYID),
                REQUESTEDBYTITLE = data.REQUESTEDBYTITLE,
                REQUESTEDTYPEID = Convert.ToString(data.REQUESTEDTYPEID),
                REQUESTEDTYPETITLE = data.REQUESTEDTYPETITLE,
                DELIVEREDBYDATE = Convert.ToDateTime(data.DELIVEREDBYDATE).ToString("dd-MMM-yyyy"),
                DELIVEREDBYID = Convert.ToString(data.DELIVEREDBYID),
                DELIVEREDBYTITLE = Convert.ToString(data.DELIVEREDBYTITLE),
                //IDATE = Convert.ToString(data.IDATE),
                //IUSER = Convert.ToString(data.IUSER),
                //IUSERNAME = Convert.ToString(data.IUSERNAME),
                //EDATE = data.EDATE.ToString("MM/dd/YYYY"),
                //EUSER = Convert.ToString(data.EUSER),
                //EUSERNAME = data.EUSERNAME,
                //ActionLink = JQGridHelper.GenerateActionLink(data.ID.ToString(), "SimRegister")
            });

            //No of total records
            //int totalRecords = (int)sIMREG_NEWFORMViewModelList.Count;
            int totalRecords = (int)GetTotalNEWFORM();
            //Calculate total no of page  
            int totalPages = (int)Math.Ceiling((float)totalRecords / (float)rows);
            var getdata = new
            {
                total = totalPages,
                page,
                records = totalRecords,
                rows = (
                    from jq in viewModels
                    select new
                    {
                        cell = new string[] { 
							jq.ID,
							jq.MSISDNID,
                            jq.MSISDNTITLE,
							jq.REQUESTEDDATE,
                            jq.REQUESTEDBYID,
							jq.REQUESTEDBYTITLE,
                            jq.REQUESTEDTYPEID,
							jq.REQUESTEDTYPETITLE,
                            jq.DELIVEREDBYDATE,
							jq.DELIVEREDBYID,
                            jq.DELIVEREDBYTITLE,
							jq.ActionLink }
                    }).ToArray()
            };
            return Json(getdata);
        }

        //[HttpPost]
        //public void ExportToExcel(string msisdnTitle, string requestById, string requestTypeId, string deliverById, string fromDate, string toDate)
        [HttpPost]
        public void ExportToExcel(SIMREG_NEWFORMSearchViewModel model)
        {
            //BOUser boUser = new BOUser();
            BOSIMREG_NEWFORM boSim = new BOSIMREG_NEWFORM();

            ExcelManager ex = new ExcelManager("SimRegisterReport.csv", false);

            System.Data.DataSet ds = new System.Data.DataSet();

            //boSim.GetSIMREG_NEWFORMs(ds);
            boSim.GetSIMREG_NEWFORMs(model.MSISDNTITLE, model.REQUESTEDBYID, model.REQUESTEDBYID, model.DELIVEREDBYID,
                model.REQUESTEDDATE.ToString(), model.DELIVEREDBYDATE.ToString(), ds);

            ex.ExportData(ds.Tables[0], Response);

        }

        //private List<SIMREG_NEWFORMViewModel> GetNEWFORMDataList(string msisdnTitle, string requestById, string requestTypeId, string deliverById, string fromDate, string toDate)
        private List<SIMREG_NEWFORMViewModel> GetNEWFORMDataList(string sidx, string sord, int page, int rows, string msisdnTitle, string requestById, string requestTypeId, string deliverById, string requestFromDate, string requestToDate, string deliverFromDate, string deliverToDate)
        {
            _boSIMREG_NEWFORM = new BOSIMREG_NEWFORM();
            _boSIMREG_REQUESTEDBY = new BOSIMREG_REQUESTEDBY();
            _boSIMREG_REQUESTEDTYPE = new BOSIMREG_REQUESTEDTYPE();
            _boSIMREG_DELIVEREDBY = new BOSIMREG_DELIVEREDBY();

            if (!String.IsNullOrEmpty(requestFromDate))
            {
                requestFromDate = Convert.ToDateTime(requestFromDate).ToString("dd-MMM-yyyy");
            }

            if (!String.IsNullOrEmpty(requestToDate))
            {
                requestToDate = Convert.ToDateTime(requestToDate).ToString("dd-MMM-yyyy");
            }

            if (!String.IsNullOrEmpty(deliverFromDate))
            {
                deliverFromDate = Convert.ToDateTime(deliverFromDate).ToString("dd-MMM-yyyy");
            }

            if (!String.IsNullOrEmpty(deliverToDate))
            {
                deliverToDate = Convert.ToDateTime(deliverToDate).ToString("dd-MMM-yyyy");
            }

            List<SIMREG_NEWFORMViewModel> modellist = new List<SIMREG_NEWFORMViewModel>();

            var sIMREG_NEWFORMList = _boSIMREG_NEWFORM.GetSIMREG_NEWFORMs(sidx, sord, page, rows, msisdnTitle, requestById, requestTypeId, deliverById, requestFromDate, requestToDate, deliverFromDate, deliverToDate).ToList();

            modellist = sIMREG_NEWFORMList.Select(x => new SIMREG_NEWFORMViewModel
            {

                ID = x.ID,
                MSISDNID = x.MSISDNID,
                //MSISDNTITLE = _boSIMREG_MSISDN.GetSIMREG_MSISDN(x.MSISDNID).TITLE,
                MSISDNTITLE = x.MSISDNTITLE,
                REQUESTEDDATE = x.REQUESTEDDATE,
                REQUESTEDBYID = x.REQUESTEDBYID,
                REQUESTEDBYTITLE = _boSIMREG_REQUESTEDBY.GetSIMREG_REQUESTEDBY(x.REQUESTEDBYID).TITLE,
                REQUESTEDTYPEID = x.REQUESTEDTYPEID,
                REQUESTEDTYPETITLE = _boSIMREG_REQUESTEDTYPE.GetSIMREG_REQUESTEDTYPE(x.REQUESTEDTYPEID).TITLE,
                DELIVEREDBYDATE = x.DELIVEREDBYDATE,
                DELIVEREDBYID = x.DELIVEREDBYID,
                DELIVEREDBYTITLE = _boSIMREG_DELIVEREDBY.GetSIMREG_DELIVEREDBY(x.DELIVEREDBYID).TITLE,
                IDATE = x.IDATE,
                IUSER = x.IUSER,
                EDATE = x.EDATE,
                EUSER = x.EUSER

            }).ToList();

            return modellist;
        }

        //[HttpPost]
        //public ActionResult ExportToExcel(List<SIMREG_NEWFORMViewModel> modelList)
        //{
        //    try
        //    {

        //        if (modelList.Count > 0)
        //        {
        //            var modelDataTable = ConvertHelper.ConvertToDataTable<SIMREG_NEWFORMViewModel>(modelList);

        //            //ExportHelper exportHelper = new ExportHelper("SimRegisterReport.csv", true);

        //            //string expData = exportHelper.ExportData(modelDataTable, System.Web.HttpContext.Current.Response);

        //            //return File(new System.Text.UTF8Encoding().GetBytes(expData), "text/csv", "Report123.csv");

        //            return Content(Boolean.TrueString);

        //        }
        //        else
        //        {
        //            return Content("Sorry! Unable to export null data.");
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        return Content(ExceptionHelper.ExceptionMessageFormat(ex));
        //    }
        //}

        //
        // GET: /NEWFORM/Details/by id

        public ActionResult Details(int id)
        {
            try
            {
                _boSIMREG_NEWFORM = new BOSIMREG_NEWFORM();
                _boSIMREG_REQUESTEDBY = new BOSIMREG_REQUESTEDBY();
                _boSIMREG_REQUESTEDTYPE = new BOSIMREG_REQUESTEDTYPE();
                _boSIMREG_DELIVEREDBY = new BOSIMREG_DELIVEREDBY();

                var sIMREG_NEWFORM = _boSIMREG_NEWFORM.GetSIMREG_NEWFORM(id);
                if (sIMREG_NEWFORM != null)
                {
                    var sIMREG_NEWFORMViewModel = new SIMREG_NEWFORMViewModel
                    {
                        ID = sIMREG_NEWFORM.ID,
                        MSISDNID = sIMREG_NEWFORM.MSISDNID,
                        //MSISDNTITLE = _boSIMREG_MSISDN.GetSIMREG_MSISDN(sIMREG_NEWFORM.MSISDNID).TITLE,
                        MSISDNTITLE = sIMREG_NEWFORM.MSISDNTITLE,
                        REQUESTEDDATE = sIMREG_NEWFORM.REQUESTEDDATE,
                        REQUESTEDBYID = sIMREG_NEWFORM.REQUESTEDBYID,
                        REQUESTEDBYTITLE = _boSIMREG_REQUESTEDBY.GetSIMREG_REQUESTEDBY(sIMREG_NEWFORM.REQUESTEDBYID).TITLE,
                        REQUESTEDTYPEID = sIMREG_NEWFORM.REQUESTEDTYPEID,
                        REQUESTEDTYPETITLE = _boSIMREG_REQUESTEDTYPE.GetSIMREG_REQUESTEDTYPE(sIMREG_NEWFORM.REQUESTEDTYPEID).TITLE,
                        DELIVEREDBYDATE = sIMREG_NEWFORM.DELIVEREDBYDATE,
                        DELIVEREDBYID = sIMREG_NEWFORM.DELIVEREDBYID,
                        DELIVEREDBYTITLE = _boSIMREG_DELIVEREDBY.GetSIMREG_DELIVEREDBY(sIMREG_NEWFORM.DELIVEREDBYID).TITLE,
                        IDATE = sIMREG_NEWFORM.IDATE,
                        IUSER = sIMREG_NEWFORM.IUSER,
                        EDATE = sIMREG_NEWFORM.EDATE,
                        EUSER = sIMREG_NEWFORM.EUSER
                    };

                    return PartialView("_Details", sIMREG_NEWFORMViewModel);
                }
                else
                {
                    return PartialView("_Error", "Could not found, your request data.");
                }

            }
            catch (Exception ex)
            {
                ExceptionHelper.ExceptionMessageFormat(ex);
                return PartialView("_Error", ex);
            }
        }

        //
        // GET: /NEWFORM/Add

        public ActionResult Add()
        {
            try
            {
                _boSIMREG_REQUESTEDBY = new BOSIMREG_REQUESTEDBY();
                _boSIMREG_REQUESTEDTYPE = new BOSIMREG_REQUESTEDTYPE();
                _boSIMREG_DELIVEREDBY = new BOSIMREG_DELIVEREDBY();

                var sIMREG_NEWFORMViewModel = new SIMREG_NEWFORMViewModel();

                var sIMREG_REQUESTEDBYList = SelectListItemExtension.PopulateDropdownList(_boSIMREG_REQUESTEDBY.GetSIMREG_REQUESTEDBYs().ToList<BESIMREG_REQUESTEDBY>(), "REQUESTEDBYID", "TITLE").ToList();

                var sIMREG_REQUESTEDTYPEList = SelectListItemExtension.PopulateDropdownList(_boSIMREG_REQUESTEDTYPE.GetSIMREG_REQUESTEDTYPEs().ToList<BESIMREG_REQUESTEDTYPE>(), "REQUESTEDTYPEID", "TITLE").ToList();

                //var sIMREG_DELIVEREDBYList = SelectListItemExtension.PopulateDropdownList(_boSIMREG_DELIVEREDBY.GetSIMREG_DELIVEREDBYs().ToList<BESIMREG_DELIVEREDBY>(), "DELIVEREDBYID", "TITLE").ToList();

                string userName = Session["UserName"] != null ? Session["UserName"].ToString() : string.Empty;

                var sIMREG_DELIVEREDBY = _boSIMREG_DELIVEREDBY.GetSIMREG_DELIVEREDBYbyUSERNAME(userName);

                sIMREG_NEWFORMViewModel.ddlREQUESTEDBYS = sIMREG_REQUESTEDBYList;
                sIMREG_NEWFORMViewModel.ddlREQUESTEDTYPES = sIMREG_REQUESTEDTYPEList;
                sIMREG_NEWFORMViewModel.DELIVEREDBYID = sIMREG_DELIVEREDBY.DELIVEREDBYID;
                sIMREG_NEWFORMViewModel.DELIVEREDBYTITLE = sIMREG_DELIVEREDBY.TITLE;
                //sIMREG_NEWFORMViewModel.ddlDELIVEREDBYS = sIMREG_DELIVEREDBYList;
                //sIMREG_NEWFORMViewModel.REQUESTEDDATE = DateTime.Now;
                sIMREG_NEWFORMViewModel.DELIVEREDBYDATE = DateTime.Now;

                return PartialView("_Add", sIMREG_NEWFORMViewModel);

            }
            catch (Exception ex)
            {
                ExceptionHelper.ExceptionMessageFormat(ex);
                return PartialView("_Error", ex);
            }


        }

        //
        // POST: /NEWFORM/Create

        [HttpPost]
        public ActionResult Add(SIMREG_NEWFORMViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _boSIMREG_NEWFORM = new BOSIMREG_NEWFORM();

                    var beSIMREG_NEWFORM = new BESIMREG_NEWFORM
                    {
                        MSISDNID = model.MSISDNID,
                        MSISDNTITLE = model.MSISDNTITLE,
                        REQUESTEDDATE = Convert.ToDateTime(model.REQUESTEDDATE),
                        REQUESTEDBYID = model.REQUESTEDBYID,
                        REQUESTEDTYPEID = model.REQUESTEDTYPEID,
                        DELIVEREDBYDATE = Convert.ToDateTime(model.DELIVEREDBYDATE),
                        DELIVEREDBYID = model.DELIVEREDBYID,
                        IDATE = DateTime.Now,
                        IUSER = model.IUSER,
                        EDATE = DateTime.Now,
                        EUSER = model.EUSER,
                        IsNew = true
                    };

                    _boSIMREG_NEWFORM.Save(beSIMREG_NEWFORM);

                    return Content(Boolean.TrueString);
                }

                return Content(ExceptionHelper.ModelStateErrorFormat(ModelState));
            }
            catch (Exception ex)
            {
                return Content(ExceptionHelper.ExceptionMessageFormat(ex));
            }
        }

        //
        // GET: /NEWFORM/Edit/by id

        public ActionResult Edit(int id)
        {
            try
            {
                _boSIMREG_NEWFORM = new BOSIMREG_NEWFORM();
                _boSIMREG_REQUESTEDBY = new BOSIMREG_REQUESTEDBY();
                _boSIMREG_REQUESTEDTYPE = new BOSIMREG_REQUESTEDTYPE();
                _boSIMREG_DELIVEREDBY = new BOSIMREG_DELIVEREDBY();

                var sIMREG_NEWFORM = _boSIMREG_NEWFORM.GetSIMREG_NEWFORM(id);
                if (sIMREG_NEWFORM != null)
                {

                    var sIMREG_REQUESTEDBYList = SelectListItemExtension.PopulateDropdownList(_boSIMREG_REQUESTEDBY.GetSIMREG_REQUESTEDBYs().ToList<BESIMREG_REQUESTEDBY>(), "REQUESTEDBYID", "TITLE", isEdit: true, selectedValue: sIMREG_NEWFORM != null ? sIMREG_NEWFORM.REQUESTEDBYID.ToString() : "0").ToList();

                    var sIMREG_REQUESTEDTYPEList = SelectListItemExtension.PopulateDropdownList(_boSIMREG_REQUESTEDTYPE.GetSIMREG_REQUESTEDTYPEs().ToList<BESIMREG_REQUESTEDTYPE>(), "REQUESTEDTYPEID", "TITLE", isEdit: true, selectedValue: sIMREG_NEWFORM != null ? sIMREG_NEWFORM.REQUESTEDTYPEID.ToString() : "0").ToList();

                    var sIMREG_DELIVEREDBYList = SelectListItemExtension.PopulateDropdownList(_boSIMREG_DELIVEREDBY.GetSIMREG_DELIVEREDBYs().ToList<BESIMREG_DELIVEREDBY>(), "DELIVEREDBYID", "TITLE", isEdit: true, selectedValue: sIMREG_NEWFORM != null ? sIMREG_NEWFORM.DELIVEREDBYID.ToString() : "0").ToList();

                    var sIMREG_NEWFORMViewModel = new SIMREG_NEWFORMViewModel
                    {
                        ID = sIMREG_NEWFORM.ID,
                        MSISDNID = sIMREG_NEWFORM.MSISDNID,
                        //MSISDNTITLE = _boSIMREG_MSISDN.GetSIMREG_MSISDN(sIMREG_NEWFORM.MSISDNID).TITLE,
                        MSISDNTITLE = sIMREG_NEWFORM.MSISDNTITLE,
                        REQUESTEDDATE = sIMREG_NEWFORM.REQUESTEDDATE,
                        REQUESTEDBYID = sIMREG_NEWFORM.REQUESTEDBYID,
                        REQUESTEDBYTITLE = _boSIMREG_REQUESTEDBY.GetSIMREG_REQUESTEDBY(sIMREG_NEWFORM.REQUESTEDBYID).TITLE,
                        REQUESTEDTYPEID = sIMREG_NEWFORM.REQUESTEDTYPEID,
                        REQUESTEDTYPETITLE = _boSIMREG_REQUESTEDTYPE.GetSIMREG_REQUESTEDTYPE(sIMREG_NEWFORM.REQUESTEDTYPEID).TITLE,
                        DELIVEREDBYDATE = sIMREG_NEWFORM.DELIVEREDBYDATE,
                        DELIVEREDBYID = sIMREG_NEWFORM.DELIVEREDBYID,
                        DELIVEREDBYTITLE = _boSIMREG_DELIVEREDBY.GetSIMREG_DELIVEREDBY(sIMREG_NEWFORM.DELIVEREDBYID).TITLE,
                        IDATE = sIMREG_NEWFORM.IDATE,
                        IUSER = sIMREG_NEWFORM.IUSER,
                        EDATE = sIMREG_NEWFORM.EDATE,
                        EUSER = sIMREG_NEWFORM.EUSER,
                        ddlREQUESTEDBYS = sIMREG_REQUESTEDBYList,
                        ddlREQUESTEDTYPES = sIMREG_REQUESTEDTYPEList,
                        //ddlDELIVEREDBYS = sIMREG_DELIVEREDBYList
                    };

                    return PartialView("_Edit", sIMREG_NEWFORMViewModel);
                }
                else
                {
                    return PartialView("_Error", "Could not found, your request data.");
                }

            }
            catch (Exception ex)
            {
                ExceptionHelper.ExceptionMessageFormat(ex);
                return PartialView("_Error", ex);
            }
        }

        //
        // POST: /NEWFORM/Edit/by model

        [HttpPost]
        public ActionResult Edit(SIMREG_NEWFORMViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _boSIMREG_NEWFORM = new BOSIMREG_NEWFORM();

                    var sIMREG_NEWFORM = _boSIMREG_NEWFORM.GetSIMREG_NEWFORM(model.ID);

                    if (sIMREG_NEWFORM != null)
                    {
                        sIMREG_NEWFORM.ID = model.ID;
                        sIMREG_NEWFORM.MSISDNID = model.MSISDNID;
                        sIMREG_NEWFORM.MSISDNTITLE = model.MSISDNTITLE;
                        sIMREG_NEWFORM.REQUESTEDDATE = Convert.ToDateTime(model.REQUESTEDDATE);
                        sIMREG_NEWFORM.REQUESTEDBYID = model.REQUESTEDBYID;
                        sIMREG_NEWFORM.REQUESTEDTYPEID = model.REQUESTEDTYPEID;
                        sIMREG_NEWFORM.DELIVEREDBYDATE = Convert.ToDateTime(model.DELIVEREDBYDATE);
                        sIMREG_NEWFORM.DELIVEREDBYID = model.DELIVEREDBYID;
                        //sIMREG_NEWFORM.IDATE = DateTime.Now;
                        //sIMREG_NEWFORM.IUSER = model.IUSER;
                        sIMREG_NEWFORM.EDATE = DateTime.Now;
                        sIMREG_NEWFORM.EUSER = model.EUSER;
                        sIMREG_NEWFORM.IsNew = false;

                        _boSIMREG_NEWFORM.Save(sIMREG_NEWFORM);

                        return Content(Boolean.TrueString);
                    }
                    else
                    {
                        return Content("Could not found, your request data.");
                    }
                }

                return Content(ExceptionHelper.ModelStateErrorFormat(ModelState));
            }
            catch (Exception ex)
            {
                return Content(ExceptionHelper.ExceptionMessageFormat(ex));
            }
        }

        //
        // GET: /NEWFORM/Delete/by id

        public ActionResult Delete(int id)
        {
            try
            {
                _boSIMREG_NEWFORM = new BOSIMREG_NEWFORM();
                _boSIMREG_REQUESTEDBY = new BOSIMREG_REQUESTEDBY();
                _boSIMREG_REQUESTEDTYPE = new BOSIMREG_REQUESTEDTYPE();
                _boSIMREG_DELIVEREDBY = new BOSIMREG_DELIVEREDBY();

                var sIMREG_NEWFORM = _boSIMREG_NEWFORM.GetSIMREG_NEWFORM(id);
                if (sIMREG_NEWFORM != null)
                {
                    var sIMREG_NEWFORMViewModel = new SIMREG_NEWFORMViewModel
                    {
                        ID = sIMREG_NEWFORM.ID,
                        MSISDNID = sIMREG_NEWFORM.MSISDNID,
                        //MSISDNTITLE = _boSIMREG_MSISDN.GetSIMREG_MSISDN(sIMREG_NEWFORM.MSISDNID).TITLE,
                        MSISDNTITLE = sIMREG_NEWFORM.MSISDNTITLE,
                        REQUESTEDDATE = sIMREG_NEWFORM.REQUESTEDDATE,
                        REQUESTEDBYID = sIMREG_NEWFORM.REQUESTEDBYID,
                        REQUESTEDBYTITLE = _boSIMREG_REQUESTEDBY.GetSIMREG_REQUESTEDBY(sIMREG_NEWFORM.REQUESTEDBYID).TITLE,
                        REQUESTEDTYPEID = sIMREG_NEWFORM.REQUESTEDTYPEID,
                        REQUESTEDTYPETITLE = _boSIMREG_REQUESTEDTYPE.GetSIMREG_REQUESTEDTYPE(sIMREG_NEWFORM.REQUESTEDTYPEID).TITLE,
                        DELIVEREDBYDATE = sIMREG_NEWFORM.DELIVEREDBYDATE,
                        DELIVEREDBYID = sIMREG_NEWFORM.DELIVEREDBYID,
                        DELIVEREDBYTITLE = _boSIMREG_DELIVEREDBY.GetSIMREG_DELIVEREDBY(sIMREG_NEWFORM.DELIVEREDBYID).TITLE,
                        //IDATE = sIMREG_NEWFORM.IDATE,
                        //IUSER = sIMREG_NEWFORM.IUSER,
                        //EDATE = sIMREG_NEWFORM.EDATE,
                        //EUSER = sIMREG_NEWFORM.EUSER
                    };

                    return PartialView("_Delete", sIMREG_NEWFORMViewModel);
                }
                else
                {
                    return PartialView("_Error", "Could not found, your request data.");
                }

            }
            catch (Exception ex)
            {
                ExceptionHelper.ExceptionMessageFormat(ex);
                return PartialView("_Error", ex);
            }
        }

        //
        // POST: /NEWFORM/Delete/by model

        [HttpPost]
        public ActionResult Delete(SIMREG_NEWFORMViewModel model)
        {
            try
            {
                //if (ModelState.IsValid)
                //{
                _boSIMREG_NEWFORM = new BOSIMREG_NEWFORM();

                var sIMREG_NEWFORM = _boSIMREG_NEWFORM.GetSIMREG_NEWFORM(model.ID);

                if (sIMREG_NEWFORM != null)
                {
                    sIMREG_NEWFORM.ID = model.ID;
                    //sIMREG_NEWFORM.MSISDNID = model.MSISDNID;
                    sIMREG_NEWFORM.MSISDNTITLE = model.MSISDNTITLE;
                    sIMREG_NEWFORM.REQUESTEDDATE = Convert.ToDateTime(model.REQUESTEDDATE);
                    sIMREG_NEWFORM.REQUESTEDBYID = model.REQUESTEDBYID;
                    sIMREG_NEWFORM.REQUESTEDTYPEID = model.REQUESTEDTYPEID;
                    sIMREG_NEWFORM.DELIVEREDBYDATE = Convert.ToDateTime(model.DELIVEREDBYDATE);
                    sIMREG_NEWFORM.DELIVEREDBYID = model.DELIVEREDBYID;
                    sIMREG_NEWFORM.IDATE = model.IDATE;
                    sIMREG_NEWFORM.IUSER = model.IUSER;
                    sIMREG_NEWFORM.EDATE = model.EDATE;
                    sIMREG_NEWFORM.EUSER = model.EUSER;

                    _boSIMREG_NEWFORM.Delete(sIMREG_NEWFORM);

                    return Content(Boolean.TrueString);
                }
                else
                {
                    return Content("Could not found, your request data.");
                }
                //}

                //return Content(ExceptionHelper.ModelStateErrorFormat(ModelState));
            }
            catch (Exception ex)
            {
                return Content(ExceptionHelper.ExceptionMessageFormat(ex));
            }
        }

        #endregion

        #region Method

        #endregion
    }
}
