using System;
using System.Collections.Generic;
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
    public class RequestTypeController : Controller
    {
        #region Global Variable

        BOSIMREG_REQUESTEDTYPE _boSIMREG_REQUESTEDTYPE;

        #endregion

        #region Action

        //
        // GET: /REQUESTEDTYPE/

        public ActionResult Index()
        {
            return View();
        }

        // for display jqGrid
        public ActionResult GetRequestTypeList()
        {
            var sIMREG_REQUESTEDTYPEViewModelList = GetREQUESTEDTYPEDataList().ToList();

            bool canEdit = Session["CanEdit"] != null ? Convert.ToBoolean(Session["CanEdit"]) : false;

            var viewModels = sIMREG_REQUESTEDTYPEViewModelList.Select(data => new SIMREG_REQUESTEDTYPEGridViewModel()
            {
                REQUESTEDTYPEID = Convert.ToString(data.REQUESTEDTYPEID),
                TITLE = data.TITLE,
                //IDATE = Convert.ToString(data.IDATE),
                //IUSER = Convert.ToString(data.IUSER),
                //IUSERNAME = Convert.ToString(data.IUSERNAME),
                //EDATE = data.EDATE.ToString("MM/dd/YYYY"),
                //EUSER = Convert.ToString(data.EUSER),
                //EUSERNAME = data.EUSERNAME,
                ActionLink = JQGridHelper.GenerateActionLink(id: data.REQUESTEDTYPEID.ToString(), controllerName: "RequestType", isView: true, isEdit: canEdit)
            });

            //No of total records
            int totalRecords = (int)sIMREG_REQUESTEDTYPEViewModelList.Count;
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
							jq.REQUESTEDTYPEID,
							jq.TITLE,
							jq.ActionLink }
                    }).ToArray()
            };
            return Json(getdata);
        }

        private List<SIMREG_REQUESTEDTYPEViewModel> GetREQUESTEDTYPEDataList()
        {
            _boSIMREG_REQUESTEDTYPE = new BOSIMREG_REQUESTEDTYPE();

            List<SIMREG_REQUESTEDTYPEViewModel> modellist = new List<SIMREG_REQUESTEDTYPEViewModel>();

            var sIMREG_REQUESTEDTYPEList = _boSIMREG_REQUESTEDTYPE.GetSIMREG_REQUESTEDTYPEs().ToList();

            modellist = sIMREG_REQUESTEDTYPEList.Select(x => new SIMREG_REQUESTEDTYPEViewModel
            {
                REQUESTEDTYPEID = x.REQUESTEDTYPEID,
                TITLE = x.TITLE,
                IDATE = x.IDATE,
                IUSER = x.IUSER,
                EDATE = x.EDATE,
                EUSER = x.EUSER

            }).ToList();

            return modellist;
        }

        //
        // GET: /REQUESTEDTYPE/Details/by id

        public ActionResult Details(int id)
        {
            try
            {
                _boSIMREG_REQUESTEDTYPE = new BOSIMREG_REQUESTEDTYPE();

                var sIMREG_REQUESTEDTYPE = _boSIMREG_REQUESTEDTYPE.GetSIMREG_REQUESTEDTYPE(id);
                if (sIMREG_REQUESTEDTYPE != null)
                {
                    var sIMREG_REQUESTEDTYPEViewModel = new SIMREG_REQUESTEDTYPEViewModel
                    {
                        REQUESTEDTYPEID = sIMREG_REQUESTEDTYPE.REQUESTEDTYPEID,
                        TITLE = sIMREG_REQUESTEDTYPE.TITLE,
                        IDATE = sIMREG_REQUESTEDTYPE.IDATE,
                        IUSER = sIMREG_REQUESTEDTYPE.IUSER,
                        EDATE = sIMREG_REQUESTEDTYPE.EDATE,
                        EUSER = sIMREG_REQUESTEDTYPE.EUSER
                    };

                    return PartialView("_Details", sIMREG_REQUESTEDTYPEViewModel);
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
        // GET: /REQUESTEDTYPE/Add

        public ActionResult Add()
        {
            try
            {
                var sIMREG_REQUESTEDTYPEViewModel = new SIMREG_REQUESTEDTYPEViewModel();

                return PartialView("_Add", sIMREG_REQUESTEDTYPEViewModel);

            }
            catch (Exception ex)
            {
                ExceptionHelper.ExceptionMessageFormat(ex);
                return PartialView("_Error", ex);
            }


        }

        //
        // POST: /REQUESTEDTYPE/Create

        [HttpPost]
        public ActionResult Add(SIMREG_REQUESTEDTYPEViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _boSIMREG_REQUESTEDTYPE = new BOSIMREG_REQUESTEDTYPE();

                    var beSIMREG_REQUESTEDTYPE = new BESIMREG_REQUESTEDTYPE
                    {
                        REQUESTEDTYPEID = model.REQUESTEDTYPEID,
                        TITLE = model.TITLE,
                        IDATE = DateTime.Now,
                        IUSER = model.IUSER,
                        EDATE = DateTime.Now,
                        EUSER = model.EUSER,
                        IsNew = true
                    };

                    _boSIMREG_REQUESTEDTYPE.Save(beSIMREG_REQUESTEDTYPE);

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
        // GET: /REQUESTEDTYPE/Edit/by id

        public ActionResult Edit(int id)
        {
            try
            {
                _boSIMREG_REQUESTEDTYPE = new BOSIMREG_REQUESTEDTYPE();

                var sIMREG_REQUESTEDTYPE = _boSIMREG_REQUESTEDTYPE.GetSIMREG_REQUESTEDTYPE(id);
                if (sIMREG_REQUESTEDTYPE != null)
                {

                    var sIMREG_REQUESTEDTYPEViewModel = new SIMREG_REQUESTEDTYPEViewModel
                    {
                        REQUESTEDTYPEID = sIMREG_REQUESTEDTYPE.REQUESTEDTYPEID,
                        TITLE = sIMREG_REQUESTEDTYPE.TITLE,
                        IDATE = sIMREG_REQUESTEDTYPE.IDATE,
                        IUSER = sIMREG_REQUESTEDTYPE.IUSER,
                        EDATE = sIMREG_REQUESTEDTYPE.EDATE,
                        EUSER = sIMREG_REQUESTEDTYPE.EUSER
                    };

                    return PartialView("_Edit", sIMREG_REQUESTEDTYPEViewModel);
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
        // POST: /REQUESTEDTYPE/Edit/by model

        [HttpPost]
        public ActionResult Edit(SIMREG_REQUESTEDTYPEViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _boSIMREG_REQUESTEDTYPE = new BOSIMREG_REQUESTEDTYPE();

                    var sIMREG_REQUESTEDTYPE = _boSIMREG_REQUESTEDTYPE.GetSIMREG_REQUESTEDTYPE(model.REQUESTEDTYPEID);

                    if (sIMREG_REQUESTEDTYPE != null)
                    {
                        sIMREG_REQUESTEDTYPE.REQUESTEDTYPEID = model.REQUESTEDTYPEID;
                        sIMREG_REQUESTEDTYPE.TITLE = model.TITLE;
                        //sIMREG_REQUESTEDTYPE.IDATE = DateTime.Now;
                        //sIMREG_REQUESTEDTYPE.IUSER = model.IUSER;
                        sIMREG_REQUESTEDTYPE.EDATE = DateTime.Now;
                        sIMREG_REQUESTEDTYPE.EUSER = model.EUSER;
                        sIMREG_REQUESTEDTYPE.IsNew = false;

                        _boSIMREG_REQUESTEDTYPE.Save(sIMREG_REQUESTEDTYPE);

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
        // GET: /REQUESTEDTYPE/Delete/by id

        public ActionResult Delete(int id)
        {
            try
            {
                _boSIMREG_REQUESTEDTYPE = new BOSIMREG_REQUESTEDTYPE();

                var sIMREG_REQUESTEDTYPE = _boSIMREG_REQUESTEDTYPE.GetSIMREG_REQUESTEDTYPE(id);
                if (sIMREG_REQUESTEDTYPE != null)
                {
                    var sIMREG_REQUESTEDTYPEViewModel = new SIMREG_REQUESTEDTYPEViewModel
                    {
                        REQUESTEDTYPEID = sIMREG_REQUESTEDTYPE.REQUESTEDTYPEID,
                        TITLE = sIMREG_REQUESTEDTYPE.TITLE,
                        //IDATE = sIMREG_REQUESTEDTYPE.IDATE,
                        //IUSER = sIMREG_REQUESTEDTYPE.IUSER,
                        //EDATE = sIMREG_REQUESTEDTYPE.EDATE,
                        //EUSER = sIMREG_REQUESTEDTYPE.EUSER
                    };

                    return PartialView("_Delete", sIMREG_REQUESTEDTYPEViewModel);
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
        // POST: /REQUESTEDTYPE/Delete/by model

        [HttpPost]
        public ActionResult Delete(SIMREG_REQUESTEDTYPEViewModel model)
        {
            try
            {
                //if (ModelState.IsValid)
                //{
                _boSIMREG_REQUESTEDTYPE = new BOSIMREG_REQUESTEDTYPE();

                var sIMREG_REQUESTEDTYPE = _boSIMREG_REQUESTEDTYPE.GetSIMREG_REQUESTEDTYPE(model.REQUESTEDTYPEID);

                if (sIMREG_REQUESTEDTYPE != null)
                {
                    sIMREG_REQUESTEDTYPE.REQUESTEDTYPEID = model.REQUESTEDTYPEID;
                    sIMREG_REQUESTEDTYPE.TITLE = model.TITLE;
                    sIMREG_REQUESTEDTYPE.IDATE = model.IDATE;
                    sIMREG_REQUESTEDTYPE.IUSER = model.IUSER;
                    sIMREG_REQUESTEDTYPE.EDATE = model.EDATE;
                    sIMREG_REQUESTEDTYPE.EUSER = model.EUSER;

                    _boSIMREG_REQUESTEDTYPE.Delete(sIMREG_REQUESTEDTYPE);

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
                ExceptionHelper.ExceptionMessageFormat(ex);
                return Content("Sorry! Unable to delete this data.");
            }
        }

        #endregion

        #region Method

        #endregion

    }
}
