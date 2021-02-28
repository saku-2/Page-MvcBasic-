using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcBasic.Extensions;
using MvcBasic.Models;

namespace MvcBasic.Controllers
{
    public class InputListController : Controller
    {
        public MvcBasicContext db = new MvcBasicContext();


        // GET: InputList
        [HttpPost]
        [Button(ButtonName = "ListBox")]
        [ValidateAntiForgeryToken]
        public ActionResult Index()
        {
            BaseModel member = new BaseModel();
            // これもOKだった
            //member.SelectedMember = new List<SelectListItem>()
            //{
            //    new SelectListItem() {Value = "1", Text = "日曜日" },
            //    new SelectListItem() {Value = "2", Text = "月曜日" },
            //    new SelectListItem() {Value = "3", Text = "火曜日" , Selected = true},
            //    new SelectListItem() {Value = "4", Text = "水曜日" },
            //    new SelectListItem() {Value = "5", Text = "木曜日" },
            //    new SelectListItem() {Value = "6", Text = "金曜日" },
            //    new SelectListItem() {Value = "7", Text = "土曜日" },
            //};

            // これはダメだったパターン
            // aには、Listははいった。
            //var selectMember = db.Members.OrderBy(b => b.Id);
            //var a = selectMember.ToList();

            // OK♪
            // DBから値を取得した。
            member.SelectedMember = db.Members.Select(s=> new SelectListItem
            { 
                Value = s.Id.ToString(),
                Text = s.Name,
            });

            return View(member);
        }
    }
}