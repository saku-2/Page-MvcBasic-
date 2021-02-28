using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcBasic.Extensions;
using MvcBasic.Models;

namespace MvcBasic.Controllers
{
    public class InputController : Controller
    {
        // GET: Input
        [HttpPost]
        [Button(ButtonName = "Search")]
        [ValidateAntiForgeryToken]
        public ActionResult Index()
        {
            Input hl = new Input();

            ViewBag.SelectList = new SelectListItem[] {
                new SelectListItem() { Value="001", Text="選択①" },
                new SelectListItem() { Value="002", Text="選択②" },
                new SelectListItem() { Value="003", Text="選択③" }
            };

            return View(hl);
            //return View();
        }

        //public ActionResult HelloView()
        //{
        //    Input hl = new Input();

        //    ViewBag.SelectList = new SelectListItem[] {
        //        new SelectListItem() { Value="001", Text="選択①" },
        //        new SelectListItem() { Value="002", Text="選択②" },
        //        new SelectListItem() { Value="003", Text="選択③" }
        //    };

        //    return View(hl);
        //}

        [HttpPost]
        public ActionResult HelloView(Input hl)
        {

            ViewBag.SelectList = new SelectListItem[] {
                new SelectListItem() { Value="001", Text="選択①" },
                new SelectListItem() { Value="002", Text="選択②" },
                new SelectListItem() { Value="003", Text="選択③" }
            };
            return View(hl);
        }
    }
}