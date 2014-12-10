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
    public class RequestByController : Controller
    {
        #region Global Variable

        BOSIMREG_REQUESTEDBY _boSIMREG_REQUESTEDBY;

        #endregion

        #region Action

        //
        // GET: /REQUESTEDBY/

        public ActionResult Index()
        {
            return View();
        }

        // for display jqGrid
        public ActionResult GetRequestByList()
        {
            var sIMREG_REQUESTEDBYViewModelList = GetREQUESTEDBYDataList().ToList();

            bool canEdit = Session["CanEdit"] != null ? Convert.ToBoolean(Session["CanEdit"]) : false;

            var viewModels = sIMREG_REQUESTEDBYViewModelList.Select(data => new SIMREG_REQUESTEDBYGridViewModel()
            {
                REQUESTEDBYID = Convert.ToString(data.REQUESTEDBYID),
                TITLE = data.TITLE,
                //IDATE = Convert.ToString(data.IDATE),
                //IUSER = Convert.ToString(data.IUSER),
                //IUSERNAME = Convert.ToString(data.IUSERNAME),
                //EDATE = data.EDATE.ToString("MM/dd/YYYY"),
                //EUSER = Convert.ToString(data.EUSER),
                //EUSERNAME = data.EUSERNAME,
                ActionLink = JQGridHelper.GenerateActionLink(id: data.REQUESTEDBYID.ToString(), controllerName: "RequestBy", isView: true, isEdit: canEdit)
            });

            //No of total records
            int totalRecords = (int)sIMREG_REQUESTEDBYViewModelList.Count;
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
							jq.REQUESTEDBYID,
							jq.TITLE,
							jq.ActionLink }
                    }).ToArray()
            };
            return Json(getdata);
        }

        private List<SIMREG_REQUESTEDBYViewModel> GetREQUESTEDBYDataList()
        {
            _boSIMREG_REQUESTEDBY = new BOSIMREG_REQUESTEDBY();

            List<SIMREG_REQUESTEDBYViewModel> modellist = new List<SIMREG_REQUESTEDBYViewModel>();

            var sIMREG_REQUESTEDBYList = _boSIMREG_REQUESTEDBY.GetSIMREG_REQUESTEDBYs().ToList();

            modellist = sIMREG_REQUESTEDBYList.Select(x => new SIMREG_REQUESTEDBYViewModel
            {
                REQUESTEDBYID = x.REQUESTEDBYID,
                TITLE = x.TITLE,
                IDATE = x.IDATE,
                IUSER = x.IUSER,
                EDATE = x.EDATE,
                EUSER = x.EUSER

            }).ToList();

            return modellist;
        }

        //
        // GET: /REQUESTEDBY/Details/by id

        public ActionResult Details(int id)
        {
            try
            {
                _boSIMREG_REQUESTEDBY = new BOSIMREG_REQUESTEDBY();

                var sIMREG_REQUESTEDBY = _boSIMREG_REQUESTEDBY.GetSIMREG_REQUESTEDBY(id);
                if (sIMREG_REQUESTEDBY != null)
                {
                    var sIMREG_REQUESTEDBYViewModel = new SIMREG_REQUESTEDBYViewModel
                    {
                        REQUESTEDBYID = sIMREG_REQUESTEDBY.REQUESTEDBYID,
                        TITLE = sIMREG_REQUESTEDBY.TITLE,
                        IDATE = sIMREG_REQUESTEDBY.IDATE,
                        IUSER = sIMREG_REQUESTEDBY.IUSER,
                        EDATE = sIMREG_REQUESTEDBY.EDATE,
                        EUSER = sIMREG_REQUESTEDBY.EUSER
                    };

                    return PartialView("_Details", sIMREG_REQUESTEDBYViewModel);
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
        // GET: /REQUESTEDBY/Add

        public ActionResult Add()
        {
            try
            {
                var sIMREG_REQUESTEDBYViewModel = new SIMREG_REQUESTEDBYViewModel();

                return PartialView("_Add", sIMREG_REQUESTEDBYViewModel);

            }
            catch (Exception ex)
            {
                ExceptionHelper.ExceptionMessageFormat(ex);
                return PartialView("_Error", ex);
            }


        }

        //
        // POST: /REQUESTEDBY/Create

        [HttpPost]
        public ActionResult Add(SIMREG_REQUESTEDBYViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _boSIMREG_REQUESTEDBY = new BOSIMREG_REQUESTEDBY();

                    var beSIMREG_REQUESTEDBY = new BESIMREG_REQUESTEDBY
                    {
                        REQUESTEDBYID = model.REQUESTEDBYID,
                        TITLE = model.TITLE,
                        IDATE = DateTime.Now,
                        IUSER = model.IUSER,
                        EDATE = DateTime.Now,
                        EUSER = model.EUSER,
                        IsNew = true
                    };

                    _boSIMREG_REQUESTEDBY.Save(beSIMREG_REQUESTEDBY);

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
        // GET: /REQUESTEDBY/Edit/by id

        public ActionResult Edit(int id)
        {
            try
            {
                _boSIMREG_REQUESTEDBY = new BOSIMREG_REQUESTEDBY();

                var sIMREG_REQUESTEDBY = _boSIMREG_REQUESTEDBY.GetSIMREG_REQUESTEDBY(id);
                if (sIMREG_REQUESTEDBY != null)
                {

                    var sIMREG_REQUESTEDBYViewModel = new SIMREG_REQUESTEDBYViewModel
                    {
                        REQUESTEDBYID = sIMREG_REQUESTEDBY.REQUESTEDBYID,
                        TITLE = sIMREG_REQUESTEDBY.TITLE,
                        IDATE = sIMREG_REQUESTEDBY.IDATE,
                        IUSER = sIMREG_REQUESTEDBY.IUSER,
                        EDATE = sIMREG_REQUESTEDBY.EDATE,
                        EUSER = sIMREG_REQUESTEDBY.EUSER
                    };

                    return PartialView("_Edit", sIMREG_REQUESTEDBYViewModel);
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
        // POST: /REQUESTEDBY/Edit/by model

        [HttpPost]
        public ActionResult Edit(SIMREG_REQUESTEDBYViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _boSIMREG_REQUESTEDBY = new BOSIMREG_REQUESTEDBY();

                    var sIMREG_REQUESTEDBY = _boSIMREG_REQUESTEDBY.GetSIMREG_REQUESTEDBY(model.REQUESTEDBYID);

                    if (sIMREG_REQUESTEDBY != null)
                    {
                        sIMREG_REQUESTEDBY.REQUESTEDBYID = model.REQUESTEDBYID;
                        sIMREG_REQUESTEDBY.TITLE = model.TITLE;
                        //sIMREG_REQUESTEDBY.IDATE = model.IDATE;
                        //sIMREG_REQUESTEDBY.IUSER = model.IUSER;
                        sIMREG_REQUESTEDBY.EDATE = DateTime.Now;
                        sIMREG_REQUESTEDBY.EUSER = model.EUSER;
                        sIMREG_REQUESTEDBY.IsNew = false;

                        _boSIMREG_REQUESTEDBY.Save(sIMREG_REQUESTEDBY);

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
        // GET: /REQUESTEDBY/Delete/by id

        public ActionResult Delete(int id)
        {
            try
            {
                _boSIMREG_REQUESTEDBY = new BOSIMREG_REQUESTEDBY();

                var sIMREG_REQUESTEDBY = _boSIMREG_REQUESTEDBY.GetSIMREG_REQUESTEDBY(id);
                if (sIMREG_REQUESTEDBY != null)
                {
                    var sIMREG_REQUESTEDBYViewModel = new SIMREG_REQUESTEDBYViewModel
                    {
                        REQUESTEDBYID = sIMREG_REQUESTEDBY.REQUESTEDBYID,
                        TITLE = sIMREG_REQUESTEDBY.TITLE,
                        //IDATE = sIMREG_REQUESTEDBY.IDATE,
                        //IUSER = sIMREG_REQUESTEDBY.IUSER,
                        //EDATE = sIMREG_REQUESTEDBY.EDATE,
                        //EUSER = sIMREG_REQUESTEDBY.EUSER
                    };

                    return PartialView("_Delete", sIMREG_REQUESTEDBYViewModel);
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
        // POST: /REQUESTEDBY/Delete/by model

        [HttpPost]
        public ActionResult Delete(SIMREG_REQUESTEDBYViewModel model)
        {
            try
            {
                //if (ModelState.IsValid)
                //{
                    _boSIMREG_REQUESTEDBY = new BOSIMREG_REQUESTEDBY();

                    var sIMREG_REQUESTEDBY = _boSIMREG_REQUESTEDBY.GetSIMREG_REQUESTEDBY(model.REQUESTEDBYID);

                    if (sIMREG_REQUESTEDBY != null)
                    {
                        sIMREG_REQUESTEDBY.REQUESTEDBYID = model.REQUESTEDBYID;
                        sIMREG_REQUESTEDBY.TITLE = model.TITLE;
                        //sIMREG_REQUESTEDBY.IDATE = model.IDATE;
                        //sIMREG_REQUESTEDBY.IUSER = model.IUSER;
                        //sIMREG_REQUESTEDBY.EDATE = model.EDATE;
                        //sIMREG_REQUESTEDBY.EUSER = model.EUSER;

                        _boSIMREG_REQUESTEDBY.Delete(sIMREG_REQUESTEDBY);

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
