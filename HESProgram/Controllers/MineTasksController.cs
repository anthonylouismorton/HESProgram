using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using HESProgram.Models;

namespace HESProgram.Controllers
{
    public class MineTasksController : Controller
    {
        private IHEntities db = new IHEntities();

        // GET: MineTasks
        public ActionResult Index()
        {
            return View(db.MineTasks.ToList());
        }

        // GET: MineTasks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MineTask mineTask = db.MineTasks.Find(id);
            if (mineTask == null)
            {
                return HttpNotFound();
            }
            return View(mineTask);
        }

        // GET: MineTasks/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MineTasks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(MineTaskViewModel mineTask)
        {
            if (ModelState.IsValid)
            {
                var addMineTask = new MineTask
                {
                    taskId = mineTask.taskId,
                    taskDescription = mineTask.taskDescription,
                    Respirator = mineTask.Respirator,
                    MedicalMonitoring = mineTask.MedicalMonitoring
                };
                db.MineTasks.Add(addMineTask);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mineTask);
        }

        // GET: MineTasks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MineTask mineTask = db.MineTasks.Find(id);
            if (mineTask == null)
            {
                return HttpNotFound();
            }
            return View(mineTask);
        }

        // POST: MineTasks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "taskId,taskDescription,Respirator,MedicalMonitoring")] MineTask mineTask)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mineTask).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mineTask);
        }

        // GET: MineTasks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MineTask mineTask = db.MineTasks.Find(id);
            if (mineTask == null)
            {
                return HttpNotFound();
            }
            return View(mineTask);
        }

        // POST: MineTasks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MineTask mineTask = db.MineTasks.Find(id);
            db.MineTasks.Remove(mineTask);
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
