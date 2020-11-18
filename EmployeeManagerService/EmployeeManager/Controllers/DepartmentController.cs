using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EmployeeConsumer.Models;

namespace EmployeeConsumer.Controllers
{

    public class DepartmentController : Controller
    {
        ServiceClient servicesClient = new ServicesClient();
        // GET: Department
        public ViewResult Index(string sortOrder, string search, string currentFilter, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            /*            ViewBag.listLocation = servicesClient.getAllLocations();
            */
            if (search != null)
            {
                page = 1; // nếu search có giá trị trả về page = 1
            }
            else
            {
                search = currentFilter; //  nếu có thì render phần dữ liệu search ra
            }
            ViewBag.CurrentFilter = search;
            var departments = from s in servicesClient.getAllDepartment() select s;
            if (!String.IsNullOrEmpty(search)) // check nếu search string có thì in ra hoặc không thì không in ra
            {
                departments = departments.Where(s => s.DepartmentName.Contains(search) || s.DepartmentName.Contains(search)); // contains là để check xem lastname hoặc firstName có chứa search string ở trên 
            }
            switch (sortOrder)
            {
                case "name desc":
                    departments = departments.OrderByDescending(s => s.DepartmentName); // các case tương đương với các cột muốn sort
                    break;

                default:
                    departments = departments.OrderBy(s => s.DepartmentName);
                    break;
            }

            return View(departments.ToList());

        }

        // GET: Department/Details/5
        public ActionResult Details(int id)
        {
            var department = servicesClient.getAllDepartment().Where(b => b.DepartmentID == id).FirstOrDefault();
            return View(department);

        }

        // GET: Department/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Department/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Department newDepartment)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    servicesClient.AddDepartment(newDepartment);
                    return RedirectToAction("Index", "Department");
                }

                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Department/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Department/Edit/5
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

        // GET: Department/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Department/Delete/5
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