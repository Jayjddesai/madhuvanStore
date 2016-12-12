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
        public ActionResult Index()
        {

            return View();
        }

        public ActionResult Create()
        {
            return View(); 
        }
    }
}
