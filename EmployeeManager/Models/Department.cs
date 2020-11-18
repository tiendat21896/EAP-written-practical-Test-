using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeManager.Models
{
    public class Department
    {
        public int DepartmentID { get; set; }
        public string DepartmentName { get; set; }

        public ICollection<Employee> Employee { get; set; }

    }
}