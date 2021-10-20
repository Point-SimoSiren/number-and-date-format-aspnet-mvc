using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ShopMVC.Models;

namespace ShopMVC.Controllers
{
    public class OstoksetController : Controller
    {
        private shoppingdbEntities db = new shoppingdbEntities();

        // GET: Ostokset
        public ActionResult Index()
        {
            return View(db.Ostokset.ToList());
        }

        // GET: Ostokset/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ostokset ostokset = db.Ostokset.Find(id);
            if (ostokset == null)
            {
                return HttpNotFound();
            }
            return View(ostokset);
        }

        // GET: Ostokset/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Ostokset/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,kuvaus,summa,päivä")] Ostokset ostokset)
        {
            if (ModelState.IsValid)
            {
                db.Ostokset.Add(ostokset);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ostokset);
        }

        // GET: Ostokset/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ostokset ostokset = db.Ostokset.Find(id);
            if (ostokset == null)
            {
                return HttpNotFound();
            }
            return View(ostokset);
        }

        // POST: Ostokset/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,kuvaus,summa,päivä")] Ostokset ostokset)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ostokset).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ostokset);
        }

        // GET: Ostokset/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ostokset ostokset = db.Ostokset.Find(id);
            if (ostokset == null)
            {
                return HttpNotFound();
            }
            return View(ostokset);
        }

        // POST: Ostokset/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ostokset ostokset = db.Ostokset.Find(id);
            db.Ostokset.Remove(ostokset);
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
