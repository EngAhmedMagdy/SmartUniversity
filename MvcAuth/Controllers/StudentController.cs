using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MvcAuth.Models;
using Microsoft.AspNet.Identity;

namespace MvcAuth.Controllers
{
    public class StudentController : Controller
    {
        private SmartModel1 db = new SmartModel1();

        // GET: Student
        public ActionResult Index()
        {
            var studentTbls = db.StudentTbls.Include(s => s.DepartmentTbl);
            return View(studentTbls.ToList());
        }
        [HttpGet]
        // GET: Student/Details/5
        public ActionResult Details(int? id)
        {
            id = int.Parse(Session["UserId"].ToString());
            var myAcc = db.StudentTbls.Single(a => a.St_ID == id);
            return View(myAcc);
        }




        // POST: Student/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.

        public StudentTbl Create(RegisterViewModel studentTbl)
        {
            StudentTbl student = new StudentTbl()
            {
                St_Email = studentTbl.Email,
                St_Name = studentTbl.FullName,
                St_Password = studentTbl.Password,
                Dep_ID = studentTbl.SelectedDeparmentID

            };
            db.StudentTbls.Add(student);
            db.SaveChanges();
            return student;
        }

        // GET: Student/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentTbl studentTbl = db.StudentTbls.Find(id);
            if (studentTbl == null)
            {
                return HttpNotFound();
            }
            ViewBag.Dep_ID = new SelectList(db.DepartmentTbls, "Dep_ID", "Dep_Name", studentTbl.Dep_ID);
            return View(studentTbl);
        }

        // POST: Student/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "St_ID,St_Name,St_Password,Dep_ID")] StudentTbl studentTbl)
        {
            if (ModelState.IsValid)
            {
                db.Entry(studentTbl).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Details", new { id = studentTbl.St_ID});
            }
            ViewBag.Dep_ID = new SelectList(db.DepartmentTbls, "Dep_ID", "Dep_Name", studentTbl.Dep_ID);
            return View(studentTbl);
        }

        // GET: Student/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentTbl studentTbl = db.StudentTbls.Find(id);
            if (studentTbl == null)
            {
                return HttpNotFound();
            }
            return View(studentTbl);
        }

        // POST: Student/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
           
            StudentTbl studentTbl = db.StudentTbls.Find(id);
            db.StudentTbls.Remove(studentTbl);
            db.SaveChanges();
            Session.Abandon();
            Session.RemoveAll();
            return RedirectToAction("Index", "Home");
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
