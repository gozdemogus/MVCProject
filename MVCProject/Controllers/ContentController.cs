﻿using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCProject.Controllers
{
    public class ContentController : Controller
    {
        // GET: Content
        ContentManager cm = new ContentManager(new EFContentDal());
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ContentByHeading(int id)
        {
            var contentvalues = cm.GetListByHeadingId(id);
            return View(contentvalues);
        }
    }
}