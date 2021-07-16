using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HESProgram.Models;

namespace HESProgram.Controllers
{
    public class AnalysesController : Controller
    {
        private IHEntities db = new IHEntities();

        // GET: Analyses
        public ActionResult Index()
        {
            return View(db.Analyses.ToList());
        }

        // GET: Analyses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Analysis analysis = db.Analyses.Find(id);
            if (analysis == null)
            {
                return HttpNotFound();
            }
            return View(analysis);
        }

        // GET: Analyses/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Analyses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public ActionResult Create(AnalysesViewModel analysis, HttpPostedFileBase upload)
        {
            var isValid = ModelState.IsValid;
            if (isValid)
            {
                var addAnalysis = new Analysis
                {
                    AnalysisId = analysis.AnalysisId,
                    AirContaminant = analysis.AirContaminant,
                    Method = analysis.Method,
                    PEL = analysis.PEL,
                    STEL = analysis.STEL,
                    CeilingLimit = analysis.CeilingLimit,
                    ActionLevel = analysis.ActionLevel,
                    REL = analysis.REL,
                    TLV = analysis.TLV,
                    TLVC = analysis.TLVC,
                    TLVST = analysis.TLVST,
                    RELC = analysis.REL,
                    RELST = analysis.RELST,
                    
                };
                if (upload != null && upload.ContentLength > 0)
                {
                    var filename = DateTime.Now.ToString("yyyyMMdd-HHmmss-fffff") + "_" + upload.FileName;
                    var filepath = Server.MapPath("~/UserUploads");
                    var folderpath = Path.Combine(filepath, filename);
                    upload.SaveAs(folderpath);
                    addAnalysis.Attachment = filename;
                }
                db.Analyses.Add(addAnalysis);
                db.SaveChanges();
                return RedirectToAction("Index", new { id = addAnalysis.AnalysisId });

            }
            return View(analysis);
        }

        // GET: Analyses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Analysis analysis = db.Analyses.Find(id);
            if (analysis == null)
            {
                return HttpNotFound();
            }
            return View(analysis);
        }

        // POST: Analyses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AnalysisId,AirContaminant,Attachment,Method,PEL,STEL,CeilingLimit,ActionLevel,REL,TLV,TLVC,TLVST,RELC,RELST")] Analysis analysis)
        {
            if (ModelState.IsValid)
            {
                db.Entry(analysis).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(analysis);
        }

        // GET: Analyses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Analysis analysis = db.Analyses.Find(id);
            if (analysis == null)
            {
                return HttpNotFound();
            }
            return View(analysis);
        }

        // POST: Analyses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Analysis analysis = db.Analyses.Find(id);
            db.Analyses.Remove(analysis);
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
