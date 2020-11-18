using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeManager.Models
{
    public class ServicesClient
    {
        EmployeeServiceClient client = new EmployeeServiceClient();
        public List<Department> getAllDeparment()
        {
            var list = client.GetDepartments().ToList();
            var rt = new List<Department>();
            list.ForEach(dp => rt.Add(new Department()
            {
                DepartmentID = dp.DepartmentID,
                DepartmentName = dp.DepartmentName,
            }
            ));
            return rt;
        }
        public bool AddDepartment(Department newDepartment)
        {
            var department = new EmployeeServiceReference.Department()
            {
                DepartmentID = newDepartment.DepartmentID,
                DepartmentName = newDepartment.DepartmentName,
            };
            return client.AddDepartment(department);
        }


        public List<Employee> getAllEmployee()
        {
            var list = client.GetEmployees().ToList();
            var rt = new List<Employee>();
            list.ForEach(emp => rt.Add(new Employee()
            {
                EmployeeID = emp.EmployeeID,
                EmployeeName = emp.EmployeeName,
                Salary = (int)emp.Salary,
                DepartmentID = emp.Department.DepartmentID

            }
            ));
            return rt;
        }
        public bool AddEmployee(Employee newEmployee)
        {
            var employee = new EmployeeServiceReference.Employee()
            {
                EmployeeID = newEmployee.EmployeeID,
                EmployeeName = newEmployee.EmployeeName,
                Salary = newEmployee.Salary,
                DepartmentID = newEmployee.Department.DepartmentID
            };
            return client.AddEmployee(employee);
        }

    }
}