using Hiring.Test.Model;

namespace Hiring.Test.Data
{
    public interface IEmployeeRepository
    {
       Task<string> GetProductAsync(string product);

        List<Employee>? GetEmployeeAsync(string? firstName, string? lastName, string? salary, string? departmentName);

        object GetAvgDeptSalary(string departmentName);

        object GetDepartmentwiseEmp();

        object GetHightestSalary();

        object GetRecentHires();

        object UniqueLocations(string deptName);

    }
}
