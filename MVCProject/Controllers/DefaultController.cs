using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCProject.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        HeadingManager hm = new HeadingManager(new EFHeadingDal());
        ContentManager cm = new ContentManager(new EFContentDal()); 
        public ActionResult Headings()
        {
            var headinglist = hm.GetList();
            return View(headinglist);
        }

        // GET: Default
        public PartialViewResult Index(int id=0)
        {
            var contentlist = cm.GetListByHeadingId(id);
            return PartialView(contentlist);
        }

 
    }
}