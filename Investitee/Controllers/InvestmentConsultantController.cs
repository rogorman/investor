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
    public class InvestmentConsultantController : Controller
    {
        private InvestiteeContext db = new InvestiteeContext();

        //
        // GET: /InvestmentConsultant/

        public ActionResult Index()
        {
            return View(db.InvestmentConsultants.ToList());
        }

        //
        // GET: /InvestmentConsultant/Details/5

        public ActionResult Details(int id = 0)
        {
            InvestmentConsultant investmentconsultant = db.InvestmentConsultants.Find(id);
            if (investmentconsultant == null)
            {
                return HttpNotFound();
            }
            return View(investmentconsultant);
        }

        //
        // GET: /InvestmentConsultant/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /InvestmentConsultant/Create

        [HttpPost]
        public ActionResult Create(InvestmentConsultant investmentconsultant)
        {
            if (ModelState.IsValid)
            {
                db.InvestmentConsultants.Add(investmentconsultant);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(investmentconsultant);
        }

        //
        // GET: /InvestmentConsultant/Edit/5

        public ActionResult Edit(int id = 0)
        {
            InvestmentConsultant investmentconsultant = db.InvestmentConsultants.Find(id);
            if (investmentconsultant == null)
            {
                return HttpNotFound();
            }
            return View(investmentconsultant);
        }

        //
        // POST: /InvestmentConsultant/Edit/5

        [HttpPost]
        public ActionResult Edit(InvestmentConsultant investmentconsultant)
        {
            if (ModelState.IsValid)
            {
                db.Entry(investmentconsultant).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(investmentconsultant);
        }

        //
        // GET: /InvestmentConsultant/Delete/5

        public ActionResult Delete(int id = 0)
        {
            InvestmentConsultant investmentconsultant = db.InvestmentConsultants.Find(id);
            if (investmentconsultant == null)
            {
                return HttpNotFound();
            }
            return View(investmentconsultant);
        }

        //
        // POST: /InvestmentConsultant/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            InvestmentConsultant investmentconsultant = db.InvestmentConsultants.Find(id);
            db.InvestmentConsultants.Remove(investmentconsultant);
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