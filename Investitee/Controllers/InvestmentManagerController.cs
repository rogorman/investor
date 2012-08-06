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
    public class InvestmentManagerController : Controller
    {
        private InvestiteeContext db = new InvestiteeContext();

        //
        // GET: /InvestmentManager/

        public ActionResult Index()
        {
            return View(db.InvestmentManagers.ToList());
        }

        //
        // GET: /InvestmentManager/Details/5

        public ActionResult Details(int id = 0)
        {
            InvestmentManager investmentmanager = db.InvestmentManagers.Find(id);
            if (investmentmanager == null)
            {
                return HttpNotFound();
            }
            return View(investmentmanager);
        }

        //
        // GET: /InvestmentManager/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /InvestmentManager/Create

        [HttpPost]
        public ActionResult Create(InvestmentManager investmentmanager)
        {
            if (ModelState.IsValid)
            {
                db.InvestmentManagers.Add(investmentmanager);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(investmentmanager);
        }

        //
        // GET: /InvestmentManager/Edit/5

        public ActionResult Edit(int id = 0)
        {
            InvestmentManager investmentmanager = db.InvestmentManagers.Find(id);
            if (investmentmanager == null)
            {
                return HttpNotFound();
            }
            return View(investmentmanager);
        }

        //
        // POST: /InvestmentManager/Edit/5

        [HttpPost]
        public ActionResult Edit(InvestmentManager investmentmanager)
        {
            if (ModelState.IsValid)
            {
                db.Entry(investmentmanager).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(investmentmanager);
        }

        //
        // GET: /InvestmentManager/Delete/5

        public ActionResult Delete(int id = 0)
        {
            InvestmentManager investmentmanager = db.InvestmentManagers.Find(id);
            if (investmentmanager == null)
            {
                return HttpNotFound();
            }
            return View(investmentmanager);
        }

        //
        // POST: /InvestmentManager/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            InvestmentManager investmentmanager = db.InvestmentManagers.Find(id);
            db.InvestmentManagers.Remove(investmentmanager);
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