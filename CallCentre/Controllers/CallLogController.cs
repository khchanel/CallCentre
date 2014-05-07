using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CallCentre.Models;

namespace CallCentre.Controllers
{
    public class CallLogController : Controller
    {
        private CallCentreContext db = new CallCentreContext();

        // GET: /CallLog/
        public ActionResult Index()
        {
            var calllogs = db.CallLogs.Include(c => c.Contact);
            return View(calllogs.ToList());
        }

        // GET: /CallLog/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CallLog calllog = db.CallLogs.Find(id);
            if (calllog == null)
            {
                return HttpNotFound();
            }
            return View(calllog);
        }

        // GET: /CallLog/Create
        public ActionResult Create()
        {
            ViewBag.ContactId = new SelectList(db.Contacts, "Id", "Name");
            return View();
        }

        // POST: /CallLog/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,ContactId,Message,CallDate")] CallLog calllog)
        {
            if (ModelState.IsValid)
            {
                db.CallLogs.Add(calllog);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ContactId = new SelectList(db.Contacts, "Id", "Name", calllog.ContactId);
            return View(calllog);
        }

        // GET: /CallLog/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CallLog calllog = db.CallLogs.Find(id);
            if (calllog == null)
            {
                return HttpNotFound();
            }
            ViewBag.ContactId = new SelectList(db.Contacts, "Id", "Name", calllog.ContactId);
            return View(calllog);
        }

        // POST: /CallLog/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,ContactId,Message,CallDate")] CallLog calllog)
        {
            if (ModelState.IsValid)
            {
                db.Entry(calllog).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ContactId = new SelectList(db.Contacts, "Id", "Name", calllog.ContactId);
            return View(calllog);
        }

        // GET: /CallLog/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CallLog calllog = db.CallLogs.Find(id);
            if (calllog == null)
            {
                return HttpNotFound();
            }
            return View(calllog);
        }

        // POST: /CallLog/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CallLog calllog = db.CallLogs.Find(id);
            db.CallLogs.Remove(calllog);
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
