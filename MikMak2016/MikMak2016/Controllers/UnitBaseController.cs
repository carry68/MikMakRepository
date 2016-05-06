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
    public class UnitBaseController : Controller
    {
        private MikMak2016Entities db = new MikMak2016Entities();

        // GET: /UnitBase/
        public ActionResult Index()
        {
            return View(db.UnitBase.ToList());
        }

        // GET: /UnitBase/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UnitBase unitbase = db.UnitBase.Find(id);
            if (unitbase == null)
            {
                return HttpNotFound();
            }
            return View(unitbase);
        }

        // GET: /UnitBase/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /UnitBase/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Code,Name,Id,InsertedBy,InsertedOn,UpdatedBy,UpdatedOn")] UnitBase unitbase)
        {
            if (ModelState.IsValid)
            {
                db.UnitBase.Add(unitbase);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(unitbase);
        }

        // GET: /UnitBase/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UnitBase unitbase = db.UnitBase.Find(id);
            if (unitbase == null)
            {
                return HttpNotFound();
            }
            return View(unitbase);
        }

        // POST: /UnitBase/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Code,Name,Id,InsertedBy,InsertedOn,UpdatedBy,UpdatedOn")] UnitBase unitbase)
        {
            if (ModelState.IsValid)
            {
                db.Entry(unitbase).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(unitbase);
        }

        // GET: /UnitBase/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UnitBase unitbase = db.UnitBase.Find(id);
            if (unitbase == null)
            {
                return HttpNotFound();
            }
            return View(unitbase);
        }

        // POST: /UnitBase/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UnitBase unitbase = db.UnitBase.Find(id);
            db.UnitBase.Remove(unitbase);
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
