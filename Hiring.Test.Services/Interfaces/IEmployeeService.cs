using Hiring.Test.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hiring.Test.Services.Interfaces
{
    public interface IEmployeeService
    {
        Task<string> GetProduct(string product);

        object AvgDeptSalary(List<Employee> lstEmp, string departmentName);

        object EmployeeCount(List<Employee> lstEmp);
        object HighestSalary(List<Employee> lstEmp);

        object RecentHires(List<Employee> lstEmp);

        object UniqueLocations(List<Employee> lstEmp, string deptName);
    }
}
