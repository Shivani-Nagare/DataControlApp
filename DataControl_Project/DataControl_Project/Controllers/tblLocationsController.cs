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
    public class tblLocationsController : Controller
    {
        private DataControlDBEntities1 db = new DataControlDBEntities1();

        // GET: tblLocations
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
                List<tblLocation> allSelected = new List<tblLocation>();
                using (DataControlDBEntities1 db = new DataControlDBEntities1())
                {
                    allSelected = db.tblLocations.Where(a => id.Contains(a.LocationId)).ToList();
                    foreach (var i in allSelected)
                    {
                        db.tblLocations.Remove(i);
                    }
                    db.SaveChanges();
                }
            }

            
            if (searchBy == "Name")
            {
                return View(db.tblLocations.Where(x => x.LocationName.StartsWith(search) || search == null).ToList());
            }
            else
            {
                return View(db.tblLocations.ToList());
            }


            ViewBag.Location = this.db.tblLocations.ToList();
            return View();



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

                List<tblLocation> getempids = new List<tblLocation>();
                DataControlDBEntities1 db = new DataControlDBEntities1();
                {
                    getempids = db.tblLocations.Where(a => getid.Contains(a.LocationId)).ToList();
                    foreach (var i in getempids)
                    {
                        db.tblLocations.Remove(i);
                    }
                    db.SaveChanges();
                }
            }
            return RedirectToAction("Index");
        }

        // GET: tblLocations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblLocation tblLocation = db.tblLocations.Find(id);
            if (tblLocation == null)
            {
                return HttpNotFound();
            }
            return View(tblLocation);
        }

        // GET: tblLocations/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tblLocations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LocationId,LocationName,IsActive")] tblLocation tblLocation)
        {
            if (ModelState.IsValid)
            {
                db.tblLocations.Add(tblLocation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblLocation);
        }

        // GET: tblLocations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblLocation tblLocation = db.tblLocations.Find(id);
            if (tblLocation == null)
            {
                return HttpNotFound();
            }
            return View(tblLocation);
        }

        // POST: tblLocations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LocationId,LocationName,IsActive")] tblLocation tblLocation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblLocation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblLocation);
        }

        

        // GET: tblLocations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblLocation tblLocation = db.tblLocations.Find(id);
            if (tblLocation == null)
            {
                return HttpNotFound();
            }
            return View(tblLocation);
        }

        // POST: tblLocations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblLocation tblLocation = db.tblLocations.Find(id);
            db.tblLocations.Remove(tblLocation);
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
