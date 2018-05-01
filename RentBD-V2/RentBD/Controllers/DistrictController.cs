using RentBD.Models;
using RentBD.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RentBD.Controllers
{
    public class DistrictController : Controller
    {
        // GET: District
        public ActionResult Index()
        {

            DistrictRepo districtRepro = new DistrictRepo();
            List<District> districtList = new List<District>();
            districtList = districtRepro.GetAllDistrictInfo();
            return View(districtList);

           
        }

        // GET: District/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: District/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: District/Create
        [HttpPost]
        public ActionResult Create(District district)
        {
            try
            {
                DistrictRepo districtrepo = new DistrictRepo();
               string msg= districtrepo.insertDistrict(district);





                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: District/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: District/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, District district)
        {
            try
            {
                // TODO: Add update logic here

                DistrictRepo districtRepro = new DistrictRepo();
                districtRepro.updateDistrictinfo(district);



                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: District/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: District/Delete/5
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
