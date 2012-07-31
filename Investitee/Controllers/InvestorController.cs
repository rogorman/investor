using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Investitee.Models;
using Investitee.Dal;

namespace Investitee.Controllers
{
    public class InvestorController : Controller
    {
        private InvestiteeContext db = new InvestiteeContext();

        //
        // GET: /Investor/

        public ActionResult Index()
        {
            return View(db.Investors.ToList());
        }

        //
        // GET: /Investor/Details/5

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
        // GET: /Investor/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Investor/Create

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
        // GET: /Investor/Edit/5

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
        // POST: /Investor/Edit/5

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
        // GET: /Investor/Delete/5

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
        // POST: /Investor/Delete/5

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