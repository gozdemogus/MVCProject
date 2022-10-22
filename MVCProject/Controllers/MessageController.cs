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
    public class MessageController : Controller
    {

        MessageManager mm = new MessageManager(new EFMessageDal());
        // GET: Message
        public ActionResult Inbox()
        {
            var messagelist = mm.GetListInbox();
            return View(messagelist);
        }

        public ActionResult Sentbox()
        {
            var messagelist = mm.GetListSentBox();
            return View(messagelist);
        }

        [HttpGet]
        public ActionResult NewMessage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewMessage(Message p)
        {

            return View();
        }

    }
}