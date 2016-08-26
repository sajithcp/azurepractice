using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DealersPortal.Models;

namespace DealersPortal.Controllers
{
    [Authorize]
    public class AssistancesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Assistances
        public async Task<ActionResult> Index()
        {
            return View(await db.Assistances.ToListAsync());
        }

        // GET: Assistances/Details/5
        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Assistance assistance = await db.Assistances.FindAsync(id);
            if (assistance == null)
            {
                return HttpNotFound();
            }
            return View(assistance);
        }

        // GET: Assistances/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Assistances/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Name,Description,Provider,Status,Date,Synced")] Assistance assistance)
        {
            if (ModelState.IsValid)
            {
                db.Assistances.Add(assistance);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(assistance);
        }

        // GET: Assistances/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Assistance assistance = await db.Assistances.FindAsync(id);
            if (assistance == null)
            {
                return HttpNotFound();
            }
            return View(assistance);
        }

        // POST: Assistances/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name,Description,Provider,Status,Date,Synced")] Assistance assistance)
        {
            if (ModelState.IsValid)
            {
                db.Entry(assistance).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(assistance);
        }

        // GET: Assistances/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Assistance assistance = await db.Assistances.FindAsync(id);
            if (assistance == null)
            {
                return HttpNotFound();
            }
            return View(assistance);
        }

        // POST: Assistances/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            Assistance assistance = await db.Assistances.FindAsync(id);
            db.Assistances.Remove(assistance);
            await db.SaveChangesAsync();
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
