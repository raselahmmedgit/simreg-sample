using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SIMREG.Data.Repositories;
using SIMREG.ViewModels;
using SIMREG.Helpers;

namespace SIMREG.Controllers
{
    public class MSISDNController : Controller
    {
        #region Global Variable

        ISIMREG_MSISDNRepository _iSIMREG_MSISDNRepository;

        public MSISDNController(ISIMREG_MSISDNRepository iSIMREG_MSISDNRepository)
        {
            _iSIMREG_MSISDNRepository = iSIMREG_MSISDNRepository;
        }

        #endregion

        #region Action
        //
        // GET: /MSISDN/

        public ActionResult Index()
        {
            return View();
        }

        // for display jqGrid
        public ActionResult GetMSISDNList()
        {
            var sIMREG_MSISDNList = _iSIMREG_MSISDNRepository.GetAll().ToList();

            var viewModels = sIMREG_MSISDNList.Select(data => new SIMREG_MSISDNGridViewModel() { MSISDNID = Convert.ToString(data.MSISDNID), TITLE = data.TITLE, ActionLink = JQGridHelper.GenerateActionLink(data.MSISDNID.ToString(), "MSISDN") });

            //No of total records
            int totalRecords = (int)sIMREG_MSISDNList.Count;
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
							jq.MSISDNID,
							jq.TITLE,
							jq.ActionLink }
                    }).ToArray()
            };
            return Json(getdata);
        }

        //
        // GET: /MSISDN/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /MSISDN/Add

        public ActionResult Add()
        {
            return View();
        }

        //
        // POST: /MSISDN/Add

        [HttpPost]
        public ActionResult Add(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /MSISDN/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /MSISDN/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /MSISDN/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /MSISDN/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        #endregion

        #region Method

        #endregion

    }
}
