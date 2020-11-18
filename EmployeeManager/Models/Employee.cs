using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeManager.Models
{
    public class Employee
    {
        public int EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        public int Salary { get; set; }
        public int DepartmentID { get; set; }
        public virtual Department Department { get; set; }

    }
}