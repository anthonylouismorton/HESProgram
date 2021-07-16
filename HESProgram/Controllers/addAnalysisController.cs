using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HESProgram.Models;

namespace HESProgram.Controllers
{
    public class addAnalysisController : Controller
    {
        private IHEntities db = new IHEntities();

        // GET: addAnalysis
        public ActionResult Index(/*string id*/)
        {
            /*var sample = db.Samples.Find(id);
            ViewBag.SampleId = id;*/
            return PartialView(db.addAnalysis.ToList());
        }

        // GET: addAnalysis/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            addAnalysi addAnalysi = db.addAnalysis.Find(id);
            if (addAnalysi == null)
            {
                return HttpNotFound();
            }
            return View(addAnalysi);
        }

        // GET: addAnalysis/Create
        public ActionResult Create(int id)
        {
            var sample = db.Samples.Find(id);
            var addanalysis = new addAnalysi { SampleId = id, Sample = sample };
            ViewBag.AnalysisId = new SelectList(db.Analyses, "AnalysisId", "AirContaminant");
            ViewBag.SampleId = new SelectList(db.Samples, "SampleId", "SampleId");
            return View(addanalysis);
        }

        // POST: addAnalysis/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "addAnalysisId,SampleId,AnalysisId")] addAnalysi addAnalysi)
        {
            if (ModelState.IsValid)
            {
                db.addAnalysis.Add(addAnalysi);
                db.SaveChanges();
                return RedirectToAction("Edit","Samples", new {id = addAnalysi.SampleId });
            }

            ViewBag.AnalysisId = new SelectList(db.Analyses, "AnalysisId", "AirContaminant", addAnalysi.AnalysisId);
            ViewBag.SampleId = new SelectList(db.Samples, "SampleId", "SampleId", addAnalysi.SampleId);
            addAnalysi.Sample = db.Samples.Find(addAnalysi.SampleId);
            return View(addAnalysi);
        }

        // GET: addAnalysis/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            addAnalysi addAnalysi = db.addAnalysis.Find(id);
            if (addAnalysi == null)
            {
                return HttpNotFound();
            }
            ViewBag.AnalysisId = new SelectList(db.Analyses, "AnalysisId", "AirContaminant", addAnalysi.AnalysisId);
            ViewBag.SampleId = new SelectList(db.Samples, "SampleId", "FieldNotes", addAnalysi.SampleId);
            return View(addAnalysi);
        }

        // POST: addAnalysis/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "addAnalysisId,SampleId,AnalysisId")] addAnalysi addAnalysi)
        {
            if (ModelState.IsValid)
            {
                db.Entry(addAnalysi).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AnalysisId = new SelectList(db.Analyses, "AnalysisId", "AirContaminant", addAnalysi.AnalysisId);
            ViewBag.SampleId = new SelectList(db.Samples, "SampleId", "FieldNotes", addAnalysi.SampleId);
            return View(addAnalysi);
        }

        // GET: addAnalysis/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            addAnalysi addAnalysi = db.addAnalysis.Find(id);
            if (addAnalysi == null)
            {
                return HttpNotFound();
            }
            return View(addAnalysi);
        }

        // POST: addAnalysis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            addAnalysi addAnalysi = db.addAnalysis.Find(id);
            db.addAnalysis.Remove(addAnalysi);
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
