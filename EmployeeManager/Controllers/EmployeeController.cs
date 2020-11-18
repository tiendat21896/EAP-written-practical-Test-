using System;
using System.Linq;
using System.Web.Mvc;

namespace EmployeeConsumer.Controllers
{
    public class EmployeeController : Controller
    {
        ServicesClient servicesClient = new ServicesClient();

        // GET: Employee
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
            var employees = from s in servicesClient.GetEmployees() select s;
            if (!String.IsNullOrEmpty(search)) // check nếu search string có thì in ra hoặc không thì không in ra
            {
                employees = employees.Where(s => s.Department.DepartmentName.Contains(search) || s.Department.DepartmentName.Contains(search)); // contains là để check xem lastname hoặc firstName có chứa search string ở trên 
            }
            switch (sortOrder)
            {
                case "name desc":
                    employees = employees.OrderByDescending(s => s.Department.DepartmentName); // các case tương đương với các cột muốn sort
                    break;

                default:
                    employees = employees.OrderBy(s => s.Department.DepartmentName);
                    break;
            }

            return View(employees.ToList());
            /*return View();*/
        }


        // GET: Employee/Details/5
        public ActionResult Details(int id)
        {
            var employee = servicesClient.GetEmployees().Where(b => b.EmployeeID == id).FirstOrDefault();
            return View(employee);
        }

        // GET: Employee/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employee/Create
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Create(Employee newEmp)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    servicesClient.AddEmployee(newEmp);
                    return RedirectToAction("Index", "Employee");
                }

                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Employee/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Employee/Edit/5
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

        // GET: Employee/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Employee/Delete/5
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