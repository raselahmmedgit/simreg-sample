//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Web.Mvc;
//using RnD.BLTemp.BusinessEntity;
//using RnD.BLTemp.BusinessObject;
//using RnD.BLTemp.Web.Helpers;
//using RnD.BLTemp.Web.Models;

//namespace RnD.BLTemp.Web.Controllers
//{
//    public class CategoryController : Controller
//    {

//        BOCategory _db = new BOCategory();
//        //
//        // GET: /Category/

//        public ActionResult Index()
//        {
//            var modelList = GetCategories();
//            return View(modelList.AsEnumerable());
//        }

//        // for display datatable
//        public List<CategoryModel> GetCategories()
//        {
//            try
//            {
//                List<CategoryModel> categoryList = new List<CategoryModel>();

//                var beCategoryList = _db.GetCategorys();

//                if (beCategoryList.Any())
//                {
//                    categoryList = beCategoryList.Select(x => new CategoryModel { CategoryId = x.CategoryId, CategoryName = x.CategoryName }).ToList();
//                }

//                return categoryList;
//            }
//            catch (Exception)
//            {
//                throw;
//            }

//        }

//        //
//        // GET: /Category/Details/By ID

//        public ActionResult Details(int id)
//        {
//            try
//            {
//                var beCategory = _db.GetCategory(id);
//                if (beCategory != null)
//                {
//                    var categoryModel = new CategoryModel { CategoryId = beCategory.CategoryId, CategoryName = beCategory.CategoryName };

//                    //return PartialView("_Details", categoryModel);
//                    return PartialView("_Common", categoryModel);
//                }
//                else
//                {
//                    return RedirectToAction("Index", "Category");
//                }

//            }
//            catch (Exception ex)
//            {
//                ExceptionHelper.ExceptionMessageFormat(ex);
//                return RedirectToAction("Index", "Category");
//            }
//        }

//        //
//        // GET: /Category/Add

//        public ActionResult Add()
//        {
//            try
//            {
//                var categoryModel = new CategoryModel();
//                categoryModel.CategoryId = 1;
//                //return PartialView("_Add");
//                return PartialView("_Common", categoryModel);
//            }
//            catch (Exception ex)
//            {
//                ExceptionHelper.ExceptionMessageFormat(ex);
//                return RedirectToAction("Index", "Category");
//            }
//        }

//        //
//        // POST: /Category/Add

//        [HttpPost]
//        public ActionResult Add(CategoryModel model)
//        {
//            try
//            {
//                if (ModelState.IsValid)
//                {
//                    var beCategory = new BECategory { CategoryId = model.CategoryId, CategoryName = model.CategoryName, IsNew = true, CreatedBy = 1 };//Temp CreatedBy

//                    //_db.Save(beCategory);

//                    return Content(Boolean.TrueString);
//                }

//                return Content(ExceptionHelper.ModelStateErrorFormat(ModelState));
//            }
//            catch (Exception ex)
//            {
//                ExceptionHelper.ExceptionMessageFormat(ex);
//                return Content("Sorry! Unable to add this category.");
//            }

//        }

//        //
//        // GET: /Category/Edit/By ID

//        public ActionResult Edit(int id)
//        {
//            try
//            {
//                var beCategory = _db.GetCategory(id);
//                if (beCategory != null)
//                {
//                    var categoryModel = new CategoryModel { CategoryId = beCategory.CategoryId, CategoryName = beCategory.CategoryName };

//                    //return PartialView("_Edit", categoryModel);
//                    return PartialView("_Common", categoryModel);
//                }
//                else
//                {
//                    return RedirectToAction("Index", "Category");
//                }

//            }
//            catch (Exception ex)
//            {
//                ExceptionHelper.ExceptionMessageFormat(ex);
//                return RedirectToAction("Index", "Category");
//            }
//        }

//        //
//        // POST: /Category/Edit/By ID

//        [HttpPost]
//        public ActionResult Edit(CategoryModel model)
//        {
//            try
//            {
//                if (ModelState.IsValid)
//                {
//                    var beCategory = new BECategory { CategoryId = model.CategoryId, CategoryName = model.CategoryName, IsNew = false, UpdatedBy = 2 }; //Temp UpdatedBy

//                    //_db.Save(beCategory);

//                    return Content(Boolean.TrueString);
//                }

//                return Content(ExceptionHelper.ModelStateErrorFormat(ModelState));
//            }
//            catch (Exception ex)
//            {
//                ExceptionHelper.ExceptionMessageFormat(ex);
//                return Content("Sorry! Unable to edit this category.");
//            }
//        }

//        //
//        // GET: /Category/Delete/By ID

//        public ActionResult Delete(int id)
//        {
//            try
//            {
//                var beCategory = _db.GetCategory(id);
//                if (beCategory != null)
//                {
//                    var categoryModel = new CategoryModel { CategoryId = beCategory.CategoryId, CategoryName = beCategory.CategoryName };

//                    //return PartialView("_Delete", categoryModel);
//                    return PartialView("_Common", categoryModel);
//                }
//                else
//                {
//                    return RedirectToAction("Index", "Category");
//                }

//            }
//            catch (Exception ex)
//            {
//                ExceptionHelper.ExceptionMessageFormat(ex);
//                return RedirectToAction("Index", "Category");
//            }
//        }

//        //
//        // POST: /Category/Delete/By ID

//        [HttpPost, ActionName("Delete")]
//        public ActionResult DeleteConfirmed(int id)
//        {
//            try
//            {
//                var beCategory = _db.GetCategory(id);
//                if (beCategory != null)
//                {
//                    //_db.Delete(beCategory);

//                    return Content(Boolean.TrueString);
//                }

//                return Content(ExceptionHelper.ModelStateErrorFormat(ModelState));
//            }
//            catch (Exception ex)
//            {
//                ExceptionHelper.ExceptionMessageFormat(ex);
//                return Content("Sorry! Unable to delete this category.");
//            }
//        }
//    }
//}
