using Hiring.Test.Model;
using Hiring.Test.Services.Interfaces;

namespace Hiring.Test.Data
{
    public class EmployeeRepository : IEmployeeRepository
    {

        private readonly IEmployeeService _employeeService;
        public EmployeeRepository(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        public static List<Employee> AllEmployees()
        {
            var loc1 = new List<Location> { new Location { City = "Charlotte", State = "NC", ZipCode = "28277" }, new Location { City = "Charlotte", State = "NC", ZipCode = "28012" } };
            var loc2 = new List<Location> { new Location { City = "Boston", State = "MA", ZipCode = "02333" }, new Location { City = "Waldham", State = "MA", ZipCode = "02323" } };
            var loc3 = new List<Location> { new Location { City = "Greenville", State = "NC", ZipCode = "29011" } };
            var loc4 = new List<Location> { new Location { City = "Greenville", State = "SC", ZipCode = "26000" }, new Location { City = "Charleston", State = "SC", ZipCode = "26011" } };
            var loc5 = new List<Location> { new Location { City = "Greenville", State = "SC", ZipCode = "26000" }, new Location { City = "Charleston", State = "SC", ZipCode = "26011" } };

            return new List<Employee>()
            {
                new Employee {Id = 1, FirstName ="John", LastName = "Doe", Salary = 100000, Department = new Department{Id = 1, Name = "Technology" },  HireDate = DateTime.Now.AddMonths(-5), Locations = loc1 },
                new Employee {Id = 2, FirstName ="Dean", LastName = "Smith", Salary = 120000, Department = new Department{Id = 1, Name = "Technology" } ,  HireDate = DateTime.Now.AddDays(-5), Locations = loc2},
                new Employee {Id = 3, FirstName ="Jeff", LastName = "Stricklin", Salary = 130000, Department = new Department{Id = 1, Name = "Technology" },  HireDate = DateTime.Now.AddMonths(-3), Locations = loc3 },
                new Employee {Id = 4, FirstName ="Brad", LastName = "Johnson", Salary = 50000, Department = new Department{Id = 2, Name = "HR" },  HireDate = DateTime.Now.AddMonths(-1), Locations = loc4 },
                new Employee {Id = 5, FirstName ="Manoj", LastName = "Tiwari", Salary = 200000, Department = new Department{Id = 2, Name = "HR" },  HireDate = DateTime.Now.AddDays(-12), Locations = loc5 },
                new Employee {Id = 6, FirstName ="Doug", LastName = "Johns", Salary = 125000, Department = new Department{Id = 3, Name = "Sales" },  HireDate = DateTime.Now.AddMonths(-7), Locations = loc3 },
                new Employee {Id = 7, FirstName ="Scott", LastName = "Clark", Salary = 100000, Department = new Department{Id = 3, Name = "Sales" },  HireDate = DateTime.Now.AddDays(-5), Locations = loc2},
                new Employee {Id = 9, FirstName ="Michael", LastName = "Clark", Salary = 100000, Department = new Department{Id = 4, Name = "Marketing" },  HireDate = DateTime.Now.AddMonths(-9), Locations = loc2 },
                new Employee {Id = 9, FirstName ="Johnson", LastName = "Doe", Salary = 100000, Department = new Department{Id = 4, Name = "Marketing" },  HireDate = DateTime.Now.AddDays(-15), Locations = loc1 },
            };
        }

        public object GetAvgDeptSalary(string departmentName)
        {
            return _employeeService.AvgDeptSalary(AllEmployees(), departmentName);
        }

        public object GetDepartmentwiseEmp()
        {
            return _employeeService.EmployeeCount(AllEmployees());
        }

        public List<Employee>? GetEmployeeAsync(string? firstName, string? lastName, string? salary, string? departmentName)
        {
            var emp = AllEmployees();

            if(!string.IsNullOrEmpty(firstName))
            {
                emp = emp.Where(e=> e.FirstName.ToLower() == firstName.ToLower()).ToList();
            }
            if(!string.IsNullOrEmpty(lastName))
            {
                emp = emp.Where(e=> e.LastName.ToLower() == lastName.ToLower()).ToList();
            }

            if(!string.IsNullOrEmpty(salary))
            {
                emp = emp.Where(e => e.Salary == Convert.ToDecimal(salary)).ToList();
            }
            if(!string.IsNullOrEmpty(departmentName))
            {
                emp = emp.Where(e => e.Department.Name.ToLower() == departmentName.ToLower()).ToList();
            }

            return emp;
        }

        public object GetHightestSalary()
        {
            var emp = AllEmployees();

            return _employeeService.HighestSalary(emp);

        }

        public async Task<string> GetProductAsync(string product)
        {
            return await _employeeService.GetProduct(product);

        }

        public object GetRecentHires()
        {
            var emp = AllEmployees();
            return _employeeService.RecentHires(emp);
        }

        public object UniqueLocations(string deptName)
        {
            var emp = AllEmployees();      

            return _employeeService.UniqueLocations(emp, deptName);

        }
    }
}
