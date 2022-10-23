using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCProject.Controllers
{
    public class LoginController : Controller
    {
        AdminManager adminManager = new AdminManager(new EFAdminDal());
        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Admin p)
        {
            var adminUser = adminManager.GetList().FirstOrDefault(x => x.AdminUserName == p.AdminUserName && x.AdminPassword == p.AdminPassword);
            if (adminUser != null)
            {
                return RedirectToAction("Index", "AdminCategory");
            }
            else
            {
                Response.Write("<script language='javascript'>alert(\"Hatalı Kullanıcı Adı veya Şifre Girdiniz\")</script>");
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
