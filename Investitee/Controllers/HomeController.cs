using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Investitee.Dal;
using Investitee.Models;

namespace Investitee.Controllers
{
    public class HomeController : Controller
    {
        private InvestiteeContext db = new InvestiteeContext();

        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Home/Details/5

        public ActionResult Details(int id = 0)
        {
            Investor investor = db.Investors.Find(id);
            if (investor == null)
            {
                return HttpNotFound();
            }
            return View(investor);
        }

        //
        // GET: /Home/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Home/Create

        [HttpPost]
        public ActionResult Create(Investor investor)
        {
            if (ModelState.IsValid)
            {
                db.Investors.Add(investor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(investor);
        }

        //
        // GET: /Home/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Investor investor = db.Investors.Find(id);
            if (investor == null)
            {
                return HttpNotFound();
            }
            return View(investor);
        }

        //
        // POST: /Home/Edit/5

        [HttpPost]
        public ActionResult Edit(Investor investor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(investor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(investor);
        }

        //
        // GET: /Home/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Investor investor = db.Investors.Find(id);
            if (investor == null)
            {
                return HttpNotFound();
            }
            return View(investor);
        }

        //
        // POST: /Home/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Investor investor = db.Investors.Find(id);
            db.Investors.Remove(investor);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}