using PagedList;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication;

namespace WebApplication.Controllers
{
    public class productListsController : Controller
    {
        private productEntities db = new productEntities();

        // GET: productLists
        public ActionResult Index(int? i)
        {
            return View(db.productLists.ToList().ToPagedList(i ?? 1, 3));
        }

        // GET: productLists/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            productList productList = db.productLists.Find(id);
            if (productList == null)
            {
                return HttpNotFound();
            }
            return View(productList);
        }

        // GET: productLists/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: productLists/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ProductId,ProductName,CategoryId,CategeoryName")] productList productList)
        {
            if (ModelState.IsValid)
            {
                db.productLists.Add(productList);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(productList);
        }

        // GET: productLists/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            productList productList = db.productLists.Find(id);
            if (productList == null)
            {
                return HttpNotFound();
            }
            return View(productList);
        }

        // POST: productLists/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ProductId,ProductName,CategoryId,CategeoryName")] productList productList)
        {
            if (ModelState.IsValid)
            {
                db.Entry(productList).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(productList);
        }

        // GET: productLists/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            productList productList = db.productLists.Find(id);
            if (productList == null)
            {
                return HttpNotFound();
            }
            return View(productList);
        }

        // POST: productLists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            productList productList = db.productLists.Find(id);
            db.productLists.Remove(productList);
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
