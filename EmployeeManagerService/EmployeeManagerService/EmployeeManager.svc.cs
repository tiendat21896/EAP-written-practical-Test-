using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace EmployeeManagerService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "EmployeeManager" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select EmployeeManager.svc or EmployeeManager.svc.cs at the Solution Explorer and start debugging.
    public class EmployeeManager : IEmployeeManager
    {
        EmployeeManagerDataContext data = new EmployeeManagerDataContext();

        public bool AddEmployee(Employee employee)
        {
            try
            {
                data.Employees.InsertOnSubmit(employee);
                data.SubmitChanges();
                return true;
            }
            catch { return false; }

        }

        public bool AddDepartment(Department department)
        {
            try
            {
                data.Departments.InsertOnSubmit(department);
                data.SubmitChanges();
                return true;
            }
            catch { return false; }
        }

        public bool DeleteEmployee(string id)
        {
            try
            {
                var Employee = data.Employees.Where(ca => ca.EmployeeID == int.Parse(id)).FirstOrDefault();
                data.Employees.DeleteOnSubmit(Employee);
                data.SubmitChanges();
                return true;
            }
            catch { return false; }
        }

        public bool DeleteDepartment(string id)
        {
            try
            {
                var Department = data.Departments.Where(ca => ca.DepartmentID == int.Parse(id)).FirstOrDefault();
                data.Departments.DeleteOnSubmit(Department);
                data.SubmitChanges();
                return true;
            }
            catch { return false; }
        }

        public bool EditEmployee(string id, Employee newEmployee)
        {
            try
            {
                var Employee = data.Employees.Where(ca => ca.EmployeeID == int.Parse(id)).FirstOrDefault();
                data.Employees.DeleteOnSubmit(Employee);
                data.Employees.InsertOnSubmit(newEmployee);
                data.SubmitChanges();
                return true;
            }
            catch { return false; }
        }

        public bool EditDepartment(string id, Department newDepartment)
        {
            try
            {
                var Department = data.Departments.Where(ca => ca.DepartmentID == int.Parse(id)).FirstOrDefault();
                data.Departments.DeleteOnSubmit(Department);
                data.Departments.InsertOnSubmit(newDepartment);
                data.SubmitChanges();
                return true;
            }
            catch { return false; }
        }

        public List<Employee> GetEmployees()
        {
            try
            {
                var Employees = (from Employee in data.Employees select Employee).ToList();
                return Employees;
            }
            catch { return null; }
        }

        public List<Department> GetDepartment()
        {
            try
            {
                var Departments = (from Department in data.Departments select Department).ToList();
                return Departments;
            }
            catch { return null; }
        }

        public List<Department> GetDepartments()
        {
            throw new NotImplementedException();
        }

        
    }
}
