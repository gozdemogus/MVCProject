﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCProject.Controllers
{
    public class TestController : Controller
    {
        // GET: Test
        public ActionResult SweetAlert()
        {
            return View();
        }
    }
}