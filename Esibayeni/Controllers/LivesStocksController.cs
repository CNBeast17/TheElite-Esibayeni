using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Esibayeni.Models;

namespace Esibayeni.Controllers
{
    public class LivesStocksController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: LivesStocks
        public ActionResult Index()
        {
            var livesStocks = db.LivesStocks.Include(l => l.Batch).Include(l => l.Category);
            return View(livesStocks.ToList());
        }

        // GET: LivesStocks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LivesStock livesStock = db.LivesStocks.Find(id);
            if (livesStock == null)
            {
                return HttpNotFound();
            }
            return View(livesStock);
        }

        // GET: LivesStocks/Create
        public ActionResult Create(Batch batch)
        {

            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "CategoryType");
            LivesStock livestock = new LivesStock();
            livestock.BatchID = batch.ID;
            if(batch == null)
            {
                livestock.BatchID = null;
            }
            return View(livestock);
        }

        // POST: LivesStocks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,CategoryId,BatchID,Weight,Age,Gender,Image,CostPrice")] LivesStock livesStock)
        {
            if (ModelState.IsValid)
            {
                db.LivesStocks.Add(livesStock);
                if(livesStock.BatchID != null)
                {
                    db.Batches.Find(livesStock.BatchID).Quantity--;
                }
                db.SaveChanges();
                if (livesStock.BatchID != null)
                    if (db.Batches.Find(livesStock.BatchID).Quantity > 0)
                {
                    return RedirectToAction("Create",db.Batches.Find(livesStock.BatchID));
                }
                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "CategoryType", livesStock.CategoryId);
            return View(livesStock);
        }

        // GET: LivesStocks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LivesStock livesStock = db.LivesStocks.Find(id);
            if (livesStock == null)
            {
                return HttpNotFound();
            }
            ViewBag.BatchID = new SelectList(db.Batches, "ID", "ID", livesStock.BatchID);

            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "CategoryType", livesStock.CategoryId);
            return View(livesStock);
        }

        // POST: LivesStocks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,CategoryId,BatchID,Weight,Age,Gender,Image,CostPrice")] LivesStock livesStock)
        {
            if (ModelState.IsValid)
            {
                db.Entry(livesStock).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BatchID = new SelectList(db.Batches, "ID", "ID", livesStock.BatchID);
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "CategoryType", livesStock.CategoryId);
            return View(livesStock);
        }

        // GET: LivesStocks/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    LivesStock livesStock = db.LivesStocks.Find(id);
        //    if (livesStock == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(livesStock);
        //}

        //// POST: LivesStocks/Delete/5
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            LivesStock livesStock = db.LivesStocks.Find(id);
            db.LivesStocks.Remove(livesStock);
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
