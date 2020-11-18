using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace EmployeeManagerService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IEmployeeManager" in both code and config file together.
    [ServiceContract]
    public interface IEmployeeManager
    {

        //Employee

        //Hien thi 
        [OperationContract]
        [WebInvoke(Method = "GET",
           ResponseFormat = WebMessageFormat.Json,
           RequestFormat = WebMessageFormat.Json,
           BodyStyle = WebMessageBodyStyle.Bare,
           UriTemplate = "api/v1/Employee/GetList"
         )]
        List<Employee> GetEmployees();

        // Them
        [OperationContract]
        [WebInvoke(Method = "POST",
           ResponseFormat = WebMessageFormat.Json,
           RequestFormat = WebMessageFormat.Json,
           BodyStyle = WebMessageBodyStyle.Bare,
           UriTemplate = "api/v1/Category/Create"
         )]
        bool AddEmployee(Employee employee);


        //Sua
        [OperationContract]
        [WebInvoke(Method = "PUT",
          ResponseFormat = WebMessageFormat.Json,
          RequestFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.Bare,
          UriTemplate = "api/v1/Employee/Edit/{id}"
        )]
        bool EditEmployee(string id, Employee employee);

        //xoa
        [OperationContract]
        [WebInvoke(Method = "POST",
          ResponseFormat = WebMessageFormat.Json,
          RequestFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.Bare,
          UriTemplate = "api/v1/Employee/Delete/{id}"
        )]
        bool DeleteEmployee(string id);

        //Derpatment

        //Hien thi 
        [OperationContract]
        [WebInvoke(Method = "GET",
           ResponseFormat = WebMessageFormat.Json,
           RequestFormat = WebMessageFormat.Json,
           BodyStyle = WebMessageBodyStyle.Bare,
           UriTemplate = "api/v1/Department/GetList"
         )]
        List<Department> GetDepartments();

        // Them
        [OperationContract]
        [WebInvoke(Method = "POST",
           ResponseFormat = WebMessageFormat.Json,
           RequestFormat = WebMessageFormat.Json,
           BodyStyle = WebMessageBodyStyle.Bare,
           UriTemplate = "api/v1/Department/Create"
         )]
        bool AddDepartment(Department department);


        //Sua
        [OperationContract]
        [WebInvoke(Method = "PUT",
          ResponseFormat = WebMessageFormat.Json,
          RequestFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.Bare,
          UriTemplate = "api/v1/Department/Edit/{id}"
        )]
        bool EditDepartment(string id, Department department);

        //xoa
        [OperationContract]
        [WebInvoke(Method = "POST",
          ResponseFormat = WebMessageFormat.Json,
          RequestFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.Bare,
          UriTemplate = "api/v1/Department/Delete/{id}"
        )]
        bool DeleteDepartment(string id);
    }
}
