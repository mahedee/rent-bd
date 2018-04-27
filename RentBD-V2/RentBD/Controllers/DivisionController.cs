using RentBD.Models;
using RentBD.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RentBD.Controllers
{
    public class DivisionController : Controller
    {
        // GET: Division
        public ActionResult Index()
        {
            return View();
        }

        // GET: Division/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Division/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Division/Create
        [HttpPost]
        public ActionResult Create(Division division)
        {
            try
            {
                // TODO: Add insert logic here

                DivisionRepo divisionRepo = new DivisionRepo();
                string msg = divisionRepo.InsertDivision(division);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Division/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Division/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Division/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Division/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
