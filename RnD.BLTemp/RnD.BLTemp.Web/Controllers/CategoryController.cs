using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RnD.BLTemp.BusinessEntity;
using RnD.BLTemp.BusinessObject;
using RnD.BLTemp.Web.Helpers;
using RnD.BLTemp.Web.Models;

namespace RnD.BLTemp.Web.Controllers
{
    public class CategoryController : BaseController
    {

        BOCategory _db = new BOCategory();
        //
        // GET: /Category/

        public ActionResult LogIn()
        {
            return View();
        }

        public ActionResult Index(int Index = 1, int Size = 10)
        {
            var modelList = GetCategories(Index, Size);

            Session["categories"] = modelList;

            return View(modelList.AsEnumerable());
        }

        public ActionResult GetIndex()
        {
            var modelList = GetCategories();
            return PartialView("_GetIndex", modelList.AsEnumerable());
        }

        // for display datatable
        public List<CategoryModel> GetCategories()
        {
            try
            {
                List<CategoryModel> categoryList = new List<CategoryModel>();

                var beCategoryList = _db.GetCategorys();

                if (beCategoryList.Any())
                {
                    categoryList = beCategoryList.Select(x => new CategoryModel { CategoryId = x.CategoryId, CategoryName = x.CategoryName }).ToList();
                }

                ViewBag.TotalRowCount = _db.DataCount();

                return categoryList;
            }
            catch (Exception)
            {
                throw;
            }

        }

        public List<CategoryModel> GetCategories(int Index, int Size)
        {
            try
            {
                List<CategoryModel> categoryList = new List<CategoryModel>();

                var beCategoryList = _db.GetCategorys(Index, Size);

                if (beCategoryList.Any())
                {
                    categoryList = beCategoryList.Select(x => new CategoryModel { CategoryId = x.CategoryId, CategoryName = x.CategoryName }).ToList();
                }

                #region Paging Code

                int totalRow = _db.DataCount();
                ViewBag.TotalRowCount = totalRow;
                SetPager(Index, Size, totalRow);

                #endregion



                return categoryList;
            }
            catch (Exception)
            {
                throw;
            }

        }

        //
        // GET: /Category/Get/By ID

        public ActionResult Get(int id)
        {
            try
            {
                var categories = Session["categories"];

                var beCategory = new BECategory();
                if (id != 0)
                    beCategory = _db.GetCategory(id);

                if (beCategory != null)
                {
                    var categoryModel = new CategoryModel { CategoryId = beCategory.CategoryId, CategoryName = beCategory.CategoryName };

                    //return PartialView("_Edit", categoryModel);
                    return PartialView("_Common", categoryModel);
                }
                else
                {
                    return RedirectToAction("Index", "Category");
                }

            }
            catch (Exception ex)
            {
                ExceptionHelper.ExceptionMessageFormat(ex);
                return RedirectToAction("Index", "Category");
            }
        }

        //
        // POST: /Category/Edit/By ID

        [HttpPost]
        public ActionResult Save(CategoryModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var beCategory = new BECategory { CategoryId = model.CategoryId, CategoryName = model.CategoryName, UpdatedBy = 2 }; //Temp UpdatedBy

                    beCategory.IsNew = model.CategoryId == 0;

                    //_db.Save(beCategory);

                    return Content(Boolean.TrueString);
                }

                return Content(ExceptionHelper.ModelStateErrorFormat(ModelState));
            }
            catch (Exception ex)
            {
                ExceptionHelper.ExceptionMessageFormat(ex);
                return Content("Sorry! Unable to edit this category.");
            }
        }

        //
        // GET: /Category/Delete/By ID

        public ActionResult Delete(int id)
        {
            try
            {
                var beCategory = _db.GetCategory(id);
                if (beCategory != null)
                {
                    var categoryModel = new CategoryModel { CategoryId = beCategory.CategoryId, CategoryName = beCategory.CategoryName };

                    //return PartialView("_Delete", categoryModel);
                    return PartialView("_Common", categoryModel);
                }
                else
                {
                    return RedirectToAction("Index", "Category");
                }

            }
            catch (Exception ex)
            {
                ExceptionHelper.ExceptionMessageFormat(ex);
                return RedirectToAction("Index", "Category");
            }
        }

        //
        // POST: /Category/Delete/By ID

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                var beCategory = _db.GetCategory(id);
                if (beCategory != null)
                {
                    //_db.Delete(beCategory);

                    return Content(Boolean.TrueString);
                }

                return Content(ExceptionHelper.ModelStateErrorFormat(ModelState));
            }
            catch (Exception ex)
            {
                ExceptionHelper.ExceptionMessageFormat(ex);
                return Content("Sorry! Unable to delete this category.");
            }
        }
    }
}
