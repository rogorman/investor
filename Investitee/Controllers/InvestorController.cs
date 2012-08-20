using PagedList;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Investitee.Models;
using Investitee.Dal;
using Investitee.ViewModels;

namespace Investitee.Controllers
{
    [Authorize]
    public class InvestorController : Controller
    {
        private InvestiteeContext db = new InvestiteeContext();

        //
        // GET: /Investor/
        [Authorize]
        public ViewResult Index(string sortOrder, string searchString, string currentFilter, int? page)
        {
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "Name" : sortOrder;

            if (Request.HttpMethod == "GET")
            {
                searchString = currentFilter;
            }
            else
            {
                page = 1;
            }

            ViewBag.CurrentFilter = searchString;
            var investors = from s in db.Investors
                           select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                investors = investors.Where(s => s.Name.ToUpper().Contains(searchString.ToUpper())
                                       || s.Description.ToUpper().Contains(searchString.ToUpper()));
            }

            switch (sortOrder)
            {
                case "Name":
                    investors = investors.OrderByDescending(s => s.Name);
                    break;
                case "Description":
                    investors = investors.OrderBy(s => s.Description);
                    break;
                case "Fund Size":
                    investors = investors.OrderByDescending(s => s.FundSize);
                    break;
                default:
                    investors = investors.OrderBy(s => s.Name);
                    break;
            }
            int pageSize = 3;
            int pageNumber = (page ?? 1);
            return View(investors.ToPagedList(pageNumber, pageSize));
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
            try
            {
                if (ModelState.IsValid)
                {
                    db.Investors.Add(investor);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Unable to save entity");
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

        public ActionResult Stats()
        {
            var count = db.Investors.Count();

            return View(new InvestorStats() { NumberOfInvestors = count });
        }


        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}