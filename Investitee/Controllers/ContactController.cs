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
    public class ContactController : Controller
    {
        private InvestiteeContext db = new InvestiteeContext();

        //
        // GET: /Contact/

        public ActionResult Index()
        {
            return View(db.InvestorContacts.ToList());
        }

        //
        // GET: /Contact/Details/5

        public ActionResult Details(int id = 0)
        {
            InvestorContact investorcontact = db.InvestorContacts.Find(id);
            if (investorcontact == null)
            {
                return HttpNotFound();
            }
            return View(investorcontact);
        }

        //
        // GET: /Contact/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Contact/Create

        [HttpPost]
        public ActionResult Create(InvestorContact investorcontact)
        {
            if (ModelState.IsValid)
            {
                db.InvestorContacts.Add(investorcontact);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(investorcontact);
        }

        //
        // GET: /Contact/Edit/5

        public ActionResult Edit(int id = 0)
        {
            InvestorContact investorcontact = db.InvestorContacts.Find(id);
            if (investorcontact == null)
            {
                return HttpNotFound();
            }
            return View(investorcontact);
        }

        //
        // POST: /Contact/Edit/5

        [HttpPost]
        public ActionResult Edit(InvestorContact investorcontact)
        {
            if (ModelState.IsValid)
            {
                db.Entry(investorcontact).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(investorcontact);
        }

        //
        // GET: /Contact/Delete/5

        public ActionResult Delete(int id = 0)
        {
            InvestorContact investorcontact = db.InvestorContacts.Find(id);
            if (investorcontact == null)
            {
                return HttpNotFound();
            }
            return View(investorcontact);
        }

        //
        // POST: /Contact/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            InvestorContact investorcontact = db.InvestorContacts.Find(id);
            db.InvestorContacts.Remove(investorcontact);
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