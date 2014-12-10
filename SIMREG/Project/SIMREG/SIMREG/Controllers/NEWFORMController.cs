using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SIMREG.Data.Repositories;
using SIMREG.ViewModels;
using SIMREG.Helpers;
using SIMREG.Models;

namespace SIMREG.Controllers
{
    public class NEWFORMController : Controller
    {
        #region Global Variable

        SIMREG_DELIVEREDBYRepository _sIMREG_DELIVEREDBYRepository;
        SIMREG_MSISDNRepository _sIMREG_MSISDNRepository;
        SIMREG_NEWFORMRepository _sIMREG_NEWFORMRepository;
        SIMREG_REQUESTEDBYRepository _sIMREG_REQUESTEDBYRepository;
        SIMREG_REQUESTEDTYPERepository _sIMREG_REQUESTEDTYPERepository;

        #endregion

        #region Action

        //
        // GET: /NEWFORM/

        public ActionResult Index()
        {
            return View();
        }

        // for display jqGrid
        public ActionResult GetNEWFORMList()
        {
            var sIMREG_NEWFORMViewModelList = GetNEWFORMDataList().ToList();

            var viewModels = sIMREG_NEWFORMViewModelList.Select(data => new SIMREG_NEWFORMGridViewModel()
            {
                ID = Convert.ToString(data.ID),
                MSISDNID = Convert.ToString(data.MSISDNID),
                MSISDNTITLE = data.MSISDNTITLE,
                REQUESTEDDATE = data.REQUESTEDDATE.ToString("MM/dd/YYYY"),
                REQUESTEDBYID = Convert.ToString(data.REQUESTEDBYID),
                REQUESTEDBYTITLE = data.REQUESTEDBYTITLE,
                REQUESTEDTYPEID = Convert.ToString(data.REQUESTEDTYPEID),
                REQUESTEDTYPETITLE = data.REQUESTEDTYPETITLE,
                DELIVEREDBYDATE = data.DELIVEREDBYDATE.ToString("MM/dd/YYYY"),
                DELIVEREDBYID = Convert.ToString(data.DELIVEREDBYID),
                DELIVEREDBYTITLE = Convert.ToString(data.DELIVEREDBYTITLE),
                //IDATE = Convert.ToString(data.IDATE),
                //IUSER = Convert.ToString(data.IUSER),
                //IUSERNAME = Convert.ToString(data.IUSERNAME),
                //EDATE = data.EDATE.ToString("MM/dd/YYYY"),
                //EUSER = Convert.ToString(data.EUSER),
                //EUSERNAME = data.EUSERNAME,
                ActionLink = JQGridHelper.GenerateActionLink(data.ID.ToString(), "NEWFORM")
            });

            //No of total records
            int totalRecords = (int)sIMREG_NEWFORMViewModelList.Count;
            //Calculate total no of page  
            int totalPages = 1;   // (int)Math.Ceiling((float)totalRecords / (float)Rows);
            var getdata = new
            {
                total = totalPages,
                page = 1,
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

        private List<SIMREG_NEWFORMViewModel> GetNEWFORMDataList()
        {
            _sIMREG_NEWFORMRepository = new SIMREG_NEWFORMRepository();
            _sIMREG_REQUESTEDBYRepository = new SIMREG_REQUESTEDBYRepository();
            _sIMREG_REQUESTEDTYPERepository = new SIMREG_REQUESTEDTYPERepository();
            _sIMREG_DELIVEREDBYRepository = new SIMREG_DELIVEREDBYRepository();

            List<SIMREG_NEWFORMViewModel> modellist = new List<SIMREG_NEWFORMViewModel>();

            var sIMREG_NEWFORMList = _sIMREG_NEWFORMRepository.GetAll().ToList();

            modellist = sIMREG_NEWFORMList.Select(x => new SIMREG_NEWFORMViewModel
                {

                    ID = x.ID,
                    MSISDNID = x.MSISDNID,
                    MSISDNTITLE = _sIMREG_MSISDNRepository.GetById(x.MSISDNID).TITLE,
                    REQUESTEDDATE = x.REQUESTEDDATE,
                    REQUESTEDBYID = x.REQUESTEDBYID,
                    REQUESTEDBYTITLE = _sIMREG_REQUESTEDBYRepository.GetById(x.REQUESTEDBYID).TITLE,
                    REQUESTEDTYPEID = x.REQUESTEDTYPEID,
                    REQUESTEDTYPETITLE = _sIMREG_REQUESTEDTYPERepository.GetById(x.REQUESTEDTYPEID).TITLE,
                    DELIVEREDBYDATE = x.DELIVEREDBYDATE,
                    DELIVEREDBYID = x.DELIVEREDBYID,
                    DELIVEREDBYTITLE = _sIMREG_DELIVEREDBYRepository.GetById(x.DELIVEREDBYID).TITLE,
                    IDATE = x.IDATE,
                    IUSER = x.IUSER,
                    EDATE = x.EDATE,
                    EUSER = x.EUSER

                }).ToList();

            return modellist;
        }

        //
        // GET: /NEWFORM/Details/by id

        public ActionResult Details(int id)
        {
            try
            {
                _sIMREG_NEWFORMRepository = new SIMREG_NEWFORMRepository();
                _sIMREG_REQUESTEDBYRepository = new SIMREG_REQUESTEDBYRepository();
                _sIMREG_REQUESTEDTYPERepository = new SIMREG_REQUESTEDTYPERepository();
                _sIMREG_DELIVEREDBYRepository = new SIMREG_DELIVEREDBYRepository();

                var sIMREG_NEWFORM = _sIMREG_NEWFORMRepository.GetById(id);
                if (sIMREG_NEWFORM != null)
                {
                    var sIMREG_NEWFORMViewModel = new SIMREG_NEWFORMViewModel
                    {
                        ID = sIMREG_NEWFORM.ID,
                        MSISDNID = sIMREG_NEWFORM.MSISDNID,
                        MSISDNTITLE = _sIMREG_MSISDNRepository.GetById(sIMREG_NEWFORM.MSISDNID).TITLE,
                        REQUESTEDDATE = sIMREG_NEWFORM.REQUESTEDDATE,
                        REQUESTEDBYID = sIMREG_NEWFORM.REQUESTEDBYID,
                        REQUESTEDBYTITLE = _sIMREG_REQUESTEDBYRepository.GetById(sIMREG_NEWFORM.REQUESTEDBYID).TITLE,
                        REQUESTEDTYPEID = sIMREG_NEWFORM.REQUESTEDTYPEID,
                        REQUESTEDTYPETITLE = _sIMREG_REQUESTEDTYPERepository.GetById(sIMREG_NEWFORM.REQUESTEDTYPEID).TITLE,
                        DELIVEREDBYDATE = sIMREG_NEWFORM.DELIVEREDBYDATE,
                        DELIVEREDBYID = sIMREG_NEWFORM.DELIVEREDBYID,
                        DELIVEREDBYTITLE = _sIMREG_DELIVEREDBYRepository.GetById(sIMREG_NEWFORM.DELIVEREDBYID).TITLE,
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
                _sIMREG_REQUESTEDBYRepository = new SIMREG_REQUESTEDBYRepository();
                _sIMREG_REQUESTEDTYPERepository = new SIMREG_REQUESTEDTYPERepository();
                _sIMREG_DELIVEREDBYRepository = new SIMREG_DELIVEREDBYRepository();

                var sIMREG_NEWFORMViewModel = new SIMREG_NEWFORMViewModel();

                var sIMREG_REQUESTEDBYList = _sIMREG_REQUESTEDBYRepository.GetAll();
                var sIMREG_REQUESTEDTYPEList = _sIMREG_REQUESTEDTYPERepository.GetAll();
                var sIMREG_DELIVEREDBYList = _sIMREG_DELIVEREDBYRepository.GetAll();

                sIMREG_NEWFORMViewModel.ddlREQUESTEDBYS = SelectListItemExtension.PopulateDropdownList();

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
                    _sIMREG_NEWFORMRepository = new SIMREG_NEWFORMRepository();

                    var sIMREG_NEWFORM = new SIMREG_NEWFORM
                    {
                        MSISDNID = model.MSISDNID,
                        REQUESTEDDATE = model.REQUESTEDDATE,
                        REQUESTEDBYID = model.REQUESTEDBYID,
                        REQUESTEDTYPEID = model.REQUESTEDTYPEID,
                        DELIVEREDBYDATE = model.DELIVEREDBYDATE,
                        DELIVEREDBYID = model.DELIVEREDBYID,
                        IDATE = model.IDATE,
                        IUSER = model.IUSER,
                        EDATE = model.EDATE,
                        EUSER = model.EUSER

                    };

                    _sIMREG_NEWFORMRepository.Insert(sIMREG_NEWFORM);

                    return Content(Boolean.TrueString);
                }

                return Content(ExceptionHelper.ModelStateErrorFormat(ModelState));
            }
            catch (Exception ex)
            {
                ExceptionHelper.ExceptionMessageFormat(ex);
                return Content("Sorry! Unable to add this data.");
            }
        }

        //
        // GET: /NEWFORM/Edit/by id

        public ActionResult Edit(int id)
        {
            try
            {
                _sIMREG_NEWFORMRepository = new SIMREG_NEWFORMRepository();
                _sIMREG_REQUESTEDBYRepository = new SIMREG_REQUESTEDBYRepository();
                _sIMREG_REQUESTEDTYPERepository = new SIMREG_REQUESTEDTYPERepository();
                _sIMREG_DELIVEREDBYRepository = new SIMREG_DELIVEREDBYRepository();

                var sIMREG_NEWFORM = _sIMREG_NEWFORMRepository.GetById(id);
                if (sIMREG_NEWFORM != null)
                {
                    var sIMREG_NEWFORMViewModel = new SIMREG_NEWFORMViewModel
                    {
                        ID = sIMREG_NEWFORM.ID,
                        MSISDNID = sIMREG_NEWFORM.MSISDNID,
                        MSISDNTITLE = _sIMREG_MSISDNRepository.GetById(sIMREG_NEWFORM.MSISDNID).TITLE,
                        REQUESTEDDATE = sIMREG_NEWFORM.REQUESTEDDATE,
                        REQUESTEDBYID = sIMREG_NEWFORM.REQUESTEDBYID,
                        REQUESTEDBYTITLE = _sIMREG_REQUESTEDBYRepository.GetById(sIMREG_NEWFORM.REQUESTEDBYID).TITLE,
                        REQUESTEDTYPEID = sIMREG_NEWFORM.REQUESTEDTYPEID,
                        REQUESTEDTYPETITLE = _sIMREG_REQUESTEDTYPERepository.GetById(sIMREG_NEWFORM.REQUESTEDTYPEID).TITLE,
                        DELIVEREDBYDATE = sIMREG_NEWFORM.DELIVEREDBYDATE,
                        DELIVEREDBYID = sIMREG_NEWFORM.DELIVEREDBYID,
                        DELIVEREDBYTITLE = _sIMREG_DELIVEREDBYRepository.GetById(sIMREG_NEWFORM.DELIVEREDBYID).TITLE,
                        IDATE = sIMREG_NEWFORM.IDATE,
                        IUSER = sIMREG_NEWFORM.IUSER,
                        EDATE = sIMREG_NEWFORM.EDATE,
                        EUSER = sIMREG_NEWFORM.EUSER
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
                    _sIMREG_NEWFORMRepository = new SIMREG_NEWFORMRepository();

                    var sIMREG_NEWFORM = _sIMREG_NEWFORMRepository.GetById(model.ID);

                    if (sIMREG_NEWFORM != null)
                    {
                        sIMREG_NEWFORM.ID = model.ID;
                        sIMREG_NEWFORM.MSISDNID = model.MSISDNID;
                        sIMREG_NEWFORM.REQUESTEDDATE = model.REQUESTEDDATE;
                        sIMREG_NEWFORM.REQUESTEDBYID = model.REQUESTEDBYID;
                        sIMREG_NEWFORM.REQUESTEDTYPEID = model.REQUESTEDTYPEID;
                        sIMREG_NEWFORM.DELIVEREDBYDATE = model.DELIVEREDBYDATE;
                        sIMREG_NEWFORM.DELIVEREDBYID = model.DELIVEREDBYID;
                        sIMREG_NEWFORM.IDATE = model.IDATE;
                        sIMREG_NEWFORM.IUSER = model.IUSER;
                        sIMREG_NEWFORM.EDATE = model.EDATE;
                        sIMREG_NEWFORM.EUSER = model.EUSER;

                        _sIMREG_NEWFORMRepository.Update(sIMREG_NEWFORM);

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
                ExceptionHelper.ExceptionMessageFormat(ex);
                return Content("Sorry! Unable to edit this data.");
            }
        }

        //
        // GET: /NEWFORM/Delete/by id

        public ActionResult Delete(int id)
        {
            try
            {
                _sIMREG_NEWFORMRepository = new SIMREG_NEWFORMRepository();
                _sIMREG_REQUESTEDBYRepository = new SIMREG_REQUESTEDBYRepository();
                _sIMREG_REQUESTEDTYPERepository = new SIMREG_REQUESTEDTYPERepository();
                _sIMREG_DELIVEREDBYRepository = new SIMREG_DELIVEREDBYRepository();

                var sIMREG_NEWFORM = _sIMREG_NEWFORMRepository.GetById(id);
                if (sIMREG_NEWFORM != null)
                {
                    var sIMREG_NEWFORMViewModel = new SIMREG_NEWFORMViewModel
                    {
                        ID = sIMREG_NEWFORM.ID,
                        MSISDNID = sIMREG_NEWFORM.MSISDNID,
                        MSISDNTITLE = _sIMREG_MSISDNRepository.GetById(sIMREG_NEWFORM.MSISDNID).TITLE,
                        REQUESTEDDATE = sIMREG_NEWFORM.REQUESTEDDATE,
                        REQUESTEDBYID = sIMREG_NEWFORM.REQUESTEDBYID,
                        REQUESTEDBYTITLE = _sIMREG_REQUESTEDBYRepository.GetById(sIMREG_NEWFORM.REQUESTEDBYID).TITLE,
                        REQUESTEDTYPEID = sIMREG_NEWFORM.REQUESTEDTYPEID,
                        REQUESTEDTYPETITLE = _sIMREG_REQUESTEDTYPERepository.GetById(sIMREG_NEWFORM.REQUESTEDTYPEID).TITLE,
                        DELIVEREDBYDATE = sIMREG_NEWFORM.DELIVEREDBYDATE,
                        DELIVEREDBYID = sIMREG_NEWFORM.DELIVEREDBYID,
                        DELIVEREDBYTITLE = _sIMREG_DELIVEREDBYRepository.GetById(sIMREG_NEWFORM.DELIVEREDBYID).TITLE,
                        IDATE = sIMREG_NEWFORM.IDATE,
                        IUSER = sIMREG_NEWFORM.IUSER,
                        EDATE = sIMREG_NEWFORM.EDATE,
                        EUSER = sIMREG_NEWFORM.EUSER
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
                if (ModelState.IsValid)
                {
                    _sIMREG_NEWFORMRepository = new SIMREG_NEWFORMRepository();

                    var sIMREG_NEWFORM = _sIMREG_NEWFORMRepository.GetById(model.ID);

                    if (sIMREG_NEWFORM != null)
                    {
                        sIMREG_NEWFORM.ID = model.ID;
                        sIMREG_NEWFORM.MSISDNID = model.MSISDNID;
                        sIMREG_NEWFORM.REQUESTEDDATE = model.REQUESTEDDATE;
                        sIMREG_NEWFORM.REQUESTEDBYID = model.REQUESTEDBYID;
                        sIMREG_NEWFORM.REQUESTEDTYPEID = model.REQUESTEDTYPEID;
                        sIMREG_NEWFORM.DELIVEREDBYDATE = model.DELIVEREDBYDATE;
                        sIMREG_NEWFORM.DELIVEREDBYID = model.DELIVEREDBYID;
                        sIMREG_NEWFORM.IDATE = model.IDATE;
                        sIMREG_NEWFORM.IUSER = model.IUSER;
                        sIMREG_NEWFORM.EDATE = model.EDATE;
                        sIMREG_NEWFORM.EUSER = model.EUSER;

                        _sIMREG_NEWFORMRepository.Delete(sIMREG_NEWFORM);

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
                ExceptionHelper.ExceptionMessageFormat(ex);
                return Content("Sorry! Unable to delete this data.");
            }
        }

        #endregion

        #region Method

        #endregion

    }
}
