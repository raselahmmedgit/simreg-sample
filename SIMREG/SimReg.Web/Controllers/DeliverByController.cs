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
    public class DeliverByController : Controller
    {
        #region Global Variable

        BOSIMREG_DELIVEREDBY _boSIMREG_DELIVEREDBY;

        #endregion

        #region Action

        //
        // GET: /DELIVEREDBY/

        public ActionResult Index()
        {
            return View();
        }

        // for display jqGrid
        public ActionResult GetDeliverByList()
        {
            var sIMREG_DELIVEREDBYViewModelList = GetDELIVEREDBYDataList().ToList();

            bool canEdit = Session["CanEdit"] != null ? Convert.ToBoolean(Session["CanEdit"]) : false;

            var viewModels = sIMREG_DELIVEREDBYViewModelList.Select(data => new SIMREG_DELIVEREDBYGridViewModel()
            {
                DELIVEREDBYID = Convert.ToString(data.DELIVEREDBYID),
                TITLE = data.TITLE,
                USERNAME = data.USERNAME,
                CANEDIT = data.CANEDIT,
                //IDATE = Convert.ToString(data.IDATE),
                //IUSER = Convert.ToString(data.IUSER),
                //IUSERNAME = Convert.ToString(data.IUSERNAME),
                //EDATE = data.EDATE.ToString("MM/dd/YYYY"),
                //EUSER = Convert.ToString(data.EUSER),
                //EUSERNAME = data.EUSERNAME,
                ActionLink = JQGridHelper.GenerateActionLink(id: data.DELIVEREDBYID.ToString(), controllerName: "DeliverBy", isView: true, isEdit: canEdit)
            });

            //No of total records
            int totalRecords = (int)sIMREG_DELIVEREDBYViewModelList.Count;
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
							jq.DELIVEREDBYID,
							jq.TITLE,
                            jq.USERNAME,
                            jq.CANEDIT,
							jq.ActionLink }
                    }).ToArray()
            };
            return Json(getdata);
        }

        private List<SIMREG_DELIVEREDBYViewModel> GetDELIVEREDBYDataList()
        {
            _boSIMREG_DELIVEREDBY = new BOSIMREG_DELIVEREDBY();

            List<SIMREG_DELIVEREDBYViewModel> modellist = new List<SIMREG_DELIVEREDBYViewModel>();

            var sIMREG_DELIVEREDBYList = _boSIMREG_DELIVEREDBY.GetSIMREG_DELIVEREDBYs().ToList();

            modellist = sIMREG_DELIVEREDBYList.Select(x => new SIMREG_DELIVEREDBYViewModel
            {
                DELIVEREDBYID = x.DELIVEREDBYID,
                TITLE = x.TITLE,
                USERNAME = x.USERNAME,
                CANEDIT = x.CANEDIT == true ? "Yes" : "No",
                IDATE = x.IDATE,
                IUSER = x.IUSER,
                EDATE = x.EDATE,
                EUSER = x.EUSER

            }).ToList();

            return modellist;
        }

        //
        // GET: /DELIVEREDBY/Details/by id

        public ActionResult Details(int id)
        {
            try
            {
                _boSIMREG_DELIVEREDBY = new BOSIMREG_DELIVEREDBY();

                var sIMREG_DELIVEREDBY = _boSIMREG_DELIVEREDBY.GetSIMREG_DELIVEREDBY(id);
                if (sIMREG_DELIVEREDBY != null)
                {
                    var sIMREG_DELIVEREDBYViewModel = new SIMREG_DELIVEREDBYViewModel
                    {
                        DELIVEREDBYID = sIMREG_DELIVEREDBY.DELIVEREDBYID,
                        TITLE = sIMREG_DELIVEREDBY.TITLE,
                        USERNAME = sIMREG_DELIVEREDBY.USERNAME,
                        IDATE = sIMREG_DELIVEREDBY.IDATE,
                        IUSER = sIMREG_DELIVEREDBY.IUSER,
                        EDATE = sIMREG_DELIVEREDBY.EDATE,
                        EUSER = sIMREG_DELIVEREDBY.EUSER
                    };

                    return PartialView("_Details", sIMREG_DELIVEREDBYViewModel);
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
        // GET: /DELIVEREDBY/Add

        public ActionResult Add()
        {
            try
            {
                var sIMREG_DELIVEREDBYViewModel = new SIMREG_DELIVEREDBYViewModel();

                return PartialView("_Add", sIMREG_DELIVEREDBYViewModel);

            }
            catch (Exception ex)
            {
                ExceptionHelper.ExceptionMessageFormat(ex);
                return PartialView("_Error", ex);
            }


        }

        //
        // POST: /DELIVEREDBY/Create

        [HttpPost]
        public ActionResult Add(SIMREG_DELIVEREDBYViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _boSIMREG_DELIVEREDBY = new BOSIMREG_DELIVEREDBY();

                    var beSIMREG_DELIVEREDBY = new BESIMREG_DELIVEREDBY
                    {
                        DELIVEREDBYID = model.DELIVEREDBYID,
                        TITLE = model.TITLE,
                        USERNAME = model.USERNAME,
                        IDATE = DateTime.Now,
                        IUSER = model.IUSER,
                        EDATE = DateTime.Now,
                        EUSER = model.EUSER,
                        IsNew = true
                    };

                    _boSIMREG_DELIVEREDBY.Save(beSIMREG_DELIVEREDBY);

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
        // GET: /DELIVEREDBY/Edit/by id

        public ActionResult Edit(int id)
        {
            try
            {
                _boSIMREG_DELIVEREDBY = new BOSIMREG_DELIVEREDBY();

                var sIMREG_DELIVEREDBY = _boSIMREG_DELIVEREDBY.GetSIMREG_DELIVEREDBY(id);
                if (sIMREG_DELIVEREDBY != null)
                {

                    var sIMREG_DELIVEREDBYViewModel = new SIMREG_DELIVEREDBYViewModel
                    {
                        DELIVEREDBYID = sIMREG_DELIVEREDBY.DELIVEREDBYID,
                        TITLE = sIMREG_DELIVEREDBY.TITLE,
                        USERNAME = sIMREG_DELIVEREDBY.USERNAME,
                        IDATE = sIMREG_DELIVEREDBY.IDATE,
                        IUSER = sIMREG_DELIVEREDBY.IUSER,
                        EDATE = sIMREG_DELIVEREDBY.EDATE,
                        EUSER = sIMREG_DELIVEREDBY.EUSER
                    };

                    return PartialView("_Edit", sIMREG_DELIVEREDBYViewModel);
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
        // POST: /DELIVEREDBY/Edit/by model

        [HttpPost]
        public ActionResult Edit(SIMREG_DELIVEREDBYViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _boSIMREG_DELIVEREDBY = new BOSIMREG_DELIVEREDBY();

                    var sIMREG_DELIVEREDBY = _boSIMREG_DELIVEREDBY.GetSIMREG_DELIVEREDBY(model.DELIVEREDBYID);

                    if (sIMREG_DELIVEREDBY != null)
                    {
                        sIMREG_DELIVEREDBY.DELIVEREDBYID = model.DELIVEREDBYID;
                        sIMREG_DELIVEREDBY.TITLE = model.TITLE;
                        sIMREG_DELIVEREDBY.USERNAME = model.USERNAME;
                        //sIMREG_DELIVEREDBY.IDATE = model.IDATE;
                        //sIMREG_DELIVEREDBY.IUSER = model.IUSER;
                        sIMREG_DELIVEREDBY.EDATE = DateTime.Now;
                        sIMREG_DELIVEREDBY.EUSER = model.EUSER;
                        sIMREG_DELIVEREDBY.IsNew = false;

                        _boSIMREG_DELIVEREDBY.Save(sIMREG_DELIVEREDBY);

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
        // GET: /DELIVEREDBY/Delete/by id

        public ActionResult Delete(int id)
        {
            try
            {
                _boSIMREG_DELIVEREDBY = new BOSIMREG_DELIVEREDBY();

                var sIMREG_DELIVEREDBY = _boSIMREG_DELIVEREDBY.GetSIMREG_DELIVEREDBY(id);
                if (sIMREG_DELIVEREDBY != null)
                {
                    var sIMREG_DELIVEREDBYViewModel = new SIMREG_DELIVEREDBYViewModel
                    {
                        DELIVEREDBYID = sIMREG_DELIVEREDBY.DELIVEREDBYID,
                        TITLE = sIMREG_DELIVEREDBY.TITLE,
                        USERNAME = sIMREG_DELIVEREDBY.USERNAME,
                        //IDATE = sIMREG_DELIVEREDBY.IDATE,
                        //IUSER = sIMREG_DELIVEREDBY.IUSER,
                        //EDATE = sIMREG_DELIVEREDBY.EDATE,
                        //EUSER = sIMREG_DELIVEREDBY.EUSER
                    };

                    return PartialView("_Delete", sIMREG_DELIVEREDBYViewModel);
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
        // POST: /DELIVEREDBY/Delete/by model

        [HttpPost]
        public ActionResult Delete(SIMREG_DELIVEREDBYViewModel model)
        {
            try
            {
                //if (ModelState.IsValid)
                //{
                _boSIMREG_DELIVEREDBY = new BOSIMREG_DELIVEREDBY();

                var sIMREG_DELIVEREDBY = _boSIMREG_DELIVEREDBY.GetSIMREG_DELIVEREDBY(model.DELIVEREDBYID);

                if (sIMREG_DELIVEREDBY != null)
                {
                    sIMREG_DELIVEREDBY.DELIVEREDBYID = model.DELIVEREDBYID;
                    sIMREG_DELIVEREDBY.TITLE = model.TITLE;
                    sIMREG_DELIVEREDBY.USERNAME = model.USERNAME;
                    sIMREG_DELIVEREDBY.IDATE = model.IDATE;
                    sIMREG_DELIVEREDBY.IUSER = model.IUSER;
                    sIMREG_DELIVEREDBY.EDATE = model.EDATE;
                    sIMREG_DELIVEREDBY.EUSER = model.EUSER;

                    _boSIMREG_DELIVEREDBY.Delete(sIMREG_DELIVEREDBY);

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
