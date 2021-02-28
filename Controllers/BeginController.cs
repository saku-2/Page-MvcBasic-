using MvcBasic.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcBasic.Controllers
{
    public class BeginController : Controller
    {
        private MvcBasicContext db = new MvcBasicContext();
        public BeginController()
        {
            db.Database.Log = sql =>
            {
                Debug.Write(sql);
            };
        }

        // GET: Begin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Show()
        {
            ViewBag.Message = "こんにちは、世界！";
            return View();
        }

        public ActionResult list()
        {
            return View(db.Members);
        }
    }
}