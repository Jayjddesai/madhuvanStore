﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Madhuvan.Businesslayer
{
    public class HomeController : BaseController
    {

        public ActionResult Index()
        {
            return View();
        }
           
    }
}