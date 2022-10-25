using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCProject.Controllers
{
    public class WriterPnlController : Controller
    {
        HeadingManager hm = new HeadingManager(new EFHeadingDal());
        CategoryManager cm = new CategoryManager(new EFCategoryDal());   
        WriterManager wm= new WriterManager(new EFWriterDal());

        // GET: WriterPnl
        [HttpGet]
        public ActionResult WriterProfile(int id=0)
        {
           string p = (string)Session["WriterMail"];
            //ViewBag.d = p;
            id = wm.GetList().FirstOrDefault(x => x.WriterMail == p).WriterId;
            var writervalue = wm.GetByID(id);
            return View(writervalue);
        }

        [HttpPost]
        public ActionResult WriterProfile(Writer p)
        {
            WriterValidator wv = new WriterValidator();
            ValidationResult results = wv.Validate(p);
            if (results.IsValid)
            {
                wm.WriterUpdate(p);
                return RedirectToAction("AllHeading", "WriterPnl");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }


        public ActionResult MyHeading(string p)
        {
            p = (string)Session["WriterMail"];
            var writerid = wm.GetList().FirstOrDefault(x => x.WriterMail == p).WriterId;
           
            var values = hm.GetListByWriter(writerid);
            return View(values);
        }

        [HttpGet]
        public ActionResult NewHeading()
        {
     
          
            List<SelectListItem> valuecategory = (from x in cm.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryId.ToString()
                                                  }).ToList();
            ViewBag.vlc=valuecategory;  
            return View();
        }

        [HttpPost]
        public ActionResult NewHeading(Heading p)
        {
            string writermailinfo = (string)Session["WriterMail"];
            var writerid = wm.GetList().FirstOrDefault(x => x.WriterMail == writermailinfo).WriterId;
           
            p.HeadingDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            p.WriterID = writerid;
            p.HeadingStatus = true;

            hm.Headingadd(p);
            return RedirectToAction("MyHeading");
        
        }
        [HttpGet]
        public ActionResult EditHeading(int id)
        {
            List<SelectListItem> valuecategory = (from x in cm.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryId.ToString()
                                                  }).ToList();
            ViewBag.vlc = valuecategory;
            var HeadingValue = hm.GetById(id);
            return View(HeadingValue);
        }
        [HttpPost]
        public ActionResult EditHeading(Heading p)
        {
            hm.Headingupdate(p);
            return RedirectToAction("MyHeading");

        }


        public ActionResult DeleteHeading(int id)
        {
            var HeadingValue = hm.GetById(id);
            HeadingValue.HeadingStatus = false;
            hm.HeadingDelete(HeadingValue);
            return RedirectToAction("MyHeading");
        }

        public ActionResult AllHeadings(int p=1)
        {
            var headings = hm.GetList().ToPagedList(p,4);
            return View(headings);
        }
    }
}