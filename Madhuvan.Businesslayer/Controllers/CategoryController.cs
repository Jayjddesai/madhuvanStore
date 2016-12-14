using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Madhuvan.Datalayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Madhuvan.Businesslayer
{
    public class CategoryController : BaseController
    {
        readonly GenericRepository<CategoryMaster> _repository = new GenericRepository<CategoryMaster>();


        public ActionResult Index()
        {

            return View();
        }

        public ActionResult Create()
        {
            return View("~/Views/Category/Create"); 
        }

        public ActionResult KendoRead(DataSourceRequest request)
        {
            return Json(_repository.GetEntities().OrderBy(x => x.CategoryName).ToList().ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        public ActionResult KendoSave(DataSourceRequest request, CategoryMaster model)
        {
            if (model == null || !ModelState.IsValid)
            {
                return Json(new[] { model }.ToDataSourceResult(request, ModelState));
            }

            if (model.CategoryId > 0)
            {
                
                _repository.Update(model);
            }
            else
            {
               
                _repository.Insert(model);
            }

            return Json(new[] { model }.ToDataSourceResult(request, ModelState), JsonRequestBehavior.AllowGet);
        }

        public ActionResult KendoDestroy(DataSourceRequest request, CategoryMaster model)
        {
            string deleteMessage = _repository.Delete(model.CategoryId);
            ModelState.Clear();
            if (!string.IsNullOrEmpty(deleteMessage))
            {
                ModelState.AddModelError(deleteMessage, deleteMessage);
            }

            return Json(new[] { model }.ToDataSourceResult(request, ModelState), JsonRequestBehavior.AllowGet);
        }
    }
}
