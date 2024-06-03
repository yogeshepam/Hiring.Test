using Hiring.Test.Model;
using Hiring.Test.Services.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace Hiring.Test.Services.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public EmployeeService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public object AvgDeptSalary(List<Employee> lstEmp, string departmentName)
        {
            var result = lstEmp.Where(x => x.Department.Name.ToLower() == departmentName.ToLower())
                        .GroupBy(x => x.Department.Name)
                        .Select(d => new { Input = d.Key, AvgSalary = d.Average(x => x.Salary)})
                        .FirstOrDefault();
            return result;
        }

        public object EmployeeCount(List<Employee> lstEmp)
        {
            var result = lstEmp.GroupBy(x => x.Department.Name)
                         .Select(d => new 
                                { 
                                    Department = d.Key, 
                                    EmployeeCount = d.Count() 
                                });
            return result;
        }

        public object HighestSalary(List<Employee> lstEmp)
        {
            var result = lstEmp.GroupBy(x => x.Department.Name)
                .Select(d => new { DepartmentName = d.Key, HighestSalary = d.Max(x => x.Salary) });

            return result;
        }

        public class Product
        {
            public int Id { get; set; }
            public string Title { get; set; }
            public decimal Price { get; set; }
        }

        public async Task<string> GetProduct(string product)
        {
            var httpClient = _httpClientFactory.CreateClient("Employee");
            var result = string.Empty;
            using HttpResponseMessage response = await httpClient.GetAsync(product);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            List<Product> products = JsonConvert.DeserializeObject<List<Product>>(responseBody);

            foreach (var item in products)
            {
                result += result + $"Id: {item.Id}, Title: {item.Title}, Price: {item.Price} ";
            }
            return result;

        }

        public object RecentHires(List<Employee> lstEmp)
        {
            var result = lstEmp.OrderByDescending(x => x.HireDate)
                .Select(e => new
                {
                    firstName = e.FirstName,
                    lastname = e.LastName,
                    hireDate = e.HireDate
                }).Take(5);

            return result;
        }

        public object UniqueLocations(List<Employee> lstEmp, string deptName)
        {
            var emp = lstEmp.Where(x => x.Department.Name == deptName).ToList();

            var result = emp.SelectMany(x => x.Locations)
                .GroupBy(l => new { l.City, l.State, l.ZipCode })
                .Select(g =>
                        new
                        {
                            City = g.Key.City,
                            State = g.Key.State,
                            ZipCode = g.Key.ZipCode
                        }).ToList();

            return result;
        }
    }
}
