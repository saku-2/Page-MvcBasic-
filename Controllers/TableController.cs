using MvcBasic.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace MvcBasic.Controllers
{
    public class TableController : Controller
    {
        public MvcBasicContext db = new MvcBasicContext();

        public IPagedList<Member> pagedList;

        // GET: Table
        //[Route("Table/Index/{id?}")]
        // 引数をidにしないといけない
        // ヒントはRouteConfig.csにある。ルーティング
        public ActionResult Index(int? id)
        {
            //var members = db.Database.SqlQuery<Member>("SELECT * FROM Members;");
            //var members = db.Members.Select(x => x);
            //return View(members);
            //

            // データベースから取得するためのIQueryable型を用意
            // OrderBy(b=>b.Id)はなぜか重要
            IQueryable<Member> members = db.Members.OrderBy(b=>b.Id);
                //.Where(b => b.)
                //.OrderBy(b => b.Title);

            int pageNumber = id?? 1; // ページ番号
            int pageSize = 2;  // ージに表示する件数

            //IPagedList<Member> memberPages = members.ToPagedList(pageNumber, pageSize); // Bookをページで取得

            // View(memberPages);
            pagedList = members.ToPagedList(pageNumber, pageSize);
            return View(pagedList);

            //return View(db.Members);

        }

        // GET: Members/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Members/Create
        // 過多ポスティング攻撃を防止するには、バインド先とする特定のプロパティを有効にしてください。
        // 詳細については、https://go.microsoft.com/fwlink/?LinkId=317598 をご覧ください。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Email,Birth,Married,Memo")] Member member)
        {
            if (ModelState.IsValid)
            {
                db.Members.Add(member);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(member);
        }

        /// <summary>
        /// BaseModelテーブルに追加できる
        /// </summary>
        private void BaseModelInsert()
        {
            /*
            db.BaseModel.Add(new BaseModel
            {
                
                Name = "追加",
                Email = "mail@mail",
                Birth = DateTime.Now,
                Married = true,
                Memo = "メモ",
                Status = 1,
            });
            db.SaveChanges();
            */
            /*
            (
                new BaseModel {
            
                }
            )
            .
            */
            (
                new List<BaseModel>()
                {
                    new BaseModel()
                    {
                        Name = "追加",
                        Email = "mail@mail",
                        Birth = DateTime.Now,
                        Married = true,
                        Memo = "メモ",
                        Status = 1,
                    },
                    new BaseModel()
                    {
                        Name = "追加2",
                        Email = "mail@mail",
                        Birth = DateTime.Now,
                        Married = false,
                        Memo = "メモ",
                        Status = 2,
                    },
                }
            )
            .Where(e => e.Status == 1)
            .Skip(2)
            .ToList()
            .ForEach(
                e =>
                {
                    db.BaseModel.Add(e);
                    db.SaveChanges();
                }
            );

        }

        // GET: Members/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Member member = db.Members.Find(id);
            if (member == null)
            {
                return HttpNotFound();
            }
            return View(member);
        }

        // GET: Members/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Member member = db.Members.Find(id);
            if (member == null)
            {
                return HttpNotFound();
            }
            return View(member);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Email,Birth,Married,Memo")] Member member)
        {
            if (ModelState.IsValid)
            {
                db.Entry(member).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(member);
        }

        // GET: Members/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Member member = db.Members.Find(id);
            if (member == null)
            {
                return HttpNotFound();
            }
            return View(member);
        }

        // POST: Members/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Member member = db.Members.Find(id);
            db.Members.Remove(member);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}