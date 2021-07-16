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
    public class SamplesController : Controller
    {
        private IHEntities db = new IHEntities();

        // GET: Samples
        public ActionResult Index(int id)
        {
            var employee = db.Employees.Find(id);
            return View(employee.Samples.ToList());
        }

        // GET: Samples/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sample sample = db.Samples.Find(id);
            if (sample == null)
            {
                return HttpNotFound();
            }
            return View(sample);
        }

        // GET: Samples/Create
        public ActionResult Create()
        {
            ViewBag.EmployeeId = new SelectList(db.Employees, "EmployeeId", "employeeFullName");
            ViewBag.taskId = new SelectList(db.MineTasks, "taskId", "getTaskDescription");
            return View();
        }

        // POST: Samples/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SampleViewModel sample)
        {
            if (ModelState.IsValid)
            {
                var addSample = new Sample
                {
                    SampleId = sample.SampleId,
                    FieldSampleId = sample.FieldSampleId,
                    Date = sample.Date,
                    LPM = sample.LPM,
                    StartTime = sample.StartTime,
                    EndTime = sample.EndTime,
                    FieldNotes = sample.FieldNotes,
                    NotificationLetter = sample.NotificationLetter,
                    taskId = sample.taskId,
                    EmployeeId = sample.EmployeeId              

                };
                                
                db.Samples.Add(addSample);
                db.SaveChanges();
                return RedirectToAction("Index");
                ViewBag.EmployeeId = new SelectList(db.Employees, "EmployeeId", "employeeFullName", sample.EmployeeId);
                ViewBag.taskId = new SelectList(db.MineTasks, "taskId", "getTaskDescription", sample.taskId);

            }
            return View(sample);
        }

        // GET: Samples/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sample sample = db.Samples.Find(id);
            if (sample == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmployeeId = new SelectList(db.Employees, "EmployeeId", "employeeFullName", sample.EmployeeId);
            ViewBag.taskId = new SelectList(db.MineTasks, "taskId", "getTaskDescription", sample.taskId);
            return View(sample);
        }

        // POST: Samples/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SampleId,Date,LPM,StartTime,EndTime,FieldNotes,FieldSampleId,NotificationLetter,EmployeeId,taskId")] Sample sample)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sample).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EmployeeId = new SelectList(db.Employees, "EmployeeId", "employeeFullName", sample.EmployeeId);
            ViewBag.taskId = new SelectList(db.MineTasks, "taskId", "getTaskDescription", sample.taskId);
            return View(sample);
        }

        // GET: Samples/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sample sample = db.Samples.Find(id);
            if (sample == null)
            {
                return HttpNotFound();
            }
            return View(sample);
        }

        // POST: Samples/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Sample sample = db.Samples.Find(id);
            db.Samples.Remove(sample);
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
