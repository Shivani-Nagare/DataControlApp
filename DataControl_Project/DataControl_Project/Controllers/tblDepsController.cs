using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DataControl_Project.Models;

namespace DataControl_Project.Controllers
{
    public class tblDepsController : Controller
    {
        private DataControlDBEntities1 db = new DataControlDBEntities1();

        // GET: tblDeps
        public ActionResult Index(string searchBy, string search, string[] ids)
        {

            int[] id = null;
            if (ids != null)
            {
                id = new int[ids.Length];
                int j = 0;
                foreach (string i in ids)
                {
                    int.TryParse(i, out id[j++]);
                }
            }

            
            if (id != null && id.Length > 0)
            {
                List<tblDep> allSelected = new List<tblDep>();
                using (DataControlDBEntities1 db = new DataControlDBEntities1())
                {
                    allSelected = db.tblDeps.Where(a => id.Contains(a.DeptId)).ToList();
                    foreach (var i in allSelected)
                    {
                        db.tblDeps.Remove(i);
                    }
                    db.SaveChanges();
                }
            }


            if (searchBy == "Name")
            {
                return View(db.tblDeps.Where(x => x.DeptName.StartsWith(search) || search == null).ToList());
            }
            else
            {
                return View(db.tblDeps.ToList());
            }
            //delete selected
            ViewBag.Location = this.db.tblLocations.ToList();
            return View();


            //var result = db.tblDeps.Select(db => new DataControlDBEntities1 { tblDeps = db..Count() }).ToString();


        }

        public ActionResult DeleteSelected(string[] empids)
        {
            int[] getid = null;
            if (empids != null)
            {
                getid = new int[empids.Length];
                int j = 0;
                foreach (string i in empids)
                {
                    int.TryParse(i, out getid[j++]);
                }

                List<tblDep> getempids = new List<tblDep>();
                DataControlDBEntities1 db = new DataControlDBEntities1();
                {
                    getempids = db.tblDeps.Where(a => getid.Contains(a.DeptId)).ToList();
                    foreach (var i in getempids)
                    {
                        db.tblDeps.Remove(i);
                    }
                    db.SaveChanges();
                }
            }

            return RedirectToAction("Index");
        }
            //// GET: tblDeps/Details/5

            public ActionResult Details(int? id)
            {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblDep tblDep = db.tblDeps.Find(id);
            if (tblDep == null)
            {
                return HttpNotFound();
            }
            return View(tblDep);
            }

        // GET: tblDeps/Create
            public ActionResult Create()
            {
                return View();
            }

            // POST: tblDeps/Create
            // To protect from overposting attacks, enable the specific properties you want to bind to, for 
            // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
            [HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult Create([Bind(Include = "DeptId,DeptName,DeptDescription,DeptLocation,IsActive")] tblDep tblDep)
            {
                if (ModelState.IsValid)
                {
                    db.tblDeps.Add(tblDep);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                return View(tblDep);
            }

        // GET: tblDeps/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblDep tblDep = db.tblDeps.Find(id);
            if (tblDep == null)
            {
                return HttpNotFound();
            }
            return View(tblDep);
        }

        // POST: tblDeps/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DeptId,DeptName,DeptDescription,DeptLocation,IsActive")] tblDep tblDep)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblDep).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblDep);
        }

        // GET: tblDeps/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblDep tblDep = db.tblDeps.Find(id);
            if (tblDep == null)
            {
                return HttpNotFound();
            }
            return View(tblDep);
        }

        // POST: tblDeps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblDep tblDep = db.tblDeps.Find(id);
            db.tblDeps.Remove(tblDep);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
