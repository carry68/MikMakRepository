using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MikMak2016.App_Data.DAL;

namespace MikMak2016.Controllers
{
    public class ArticleTypeController : Controller
    {
        private MikMak2016Entities db = new MikMak2016Entities();

        // GET: /ArticleType/
        public ActionResult Index()
        {
            return View(db.ArticleType.ToList());
        }

        // GET: /ArticleType/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ArticleType articletype = db.ArticleType.Find(id);
            if (articletype == null)
            {
                return HttpNotFound();
            }
            return View(articletype);
        }

        // GET: /ArticleType/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /ArticleType/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Code,Name,Id,InsertedBy,InsertedOn,UpdatedBy,UpdatedOn")] ArticleType articletype)
        {
            if (ModelState.IsValid)
            {
                db.ArticleType.Add(articletype);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(articletype);
        }

        // GET: /ArticleType/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ArticleType articletype = db.ArticleType.Find(id);
            if (articletype == null)
            {
                return HttpNotFound();
            }
            return View(articletype);
        }

        // POST: /ArticleType/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Code,Name,Id,InsertedBy,InsertedOn,UpdatedBy,UpdatedOn")] ArticleType articletype)
        {
            if (ModelState.IsValid)
            {
                db.Entry(articletype).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(articletype);
        }

        // GET: /ArticleType/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ArticleType articletype = db.ArticleType.Find(id);
            if (articletype == null)
            {
                return HttpNotFound();
            }
            return View(articletype);
        }

        // POST: /ArticleType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ArticleType articletype = db.ArticleType.Find(id);
            db.ArticleType.Remove(articletype);
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
