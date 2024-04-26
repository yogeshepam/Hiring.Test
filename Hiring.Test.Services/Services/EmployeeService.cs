using Hiring.Test.Model;
using Hiring.Test.Services.Interfaces;
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

        public object AvgDeptSalary(List<Employee> lstEmp)
        {
            var result = lstEmp.GroupBy(x => x.Department.Name)
                                  .Select(d => new { Input = d.Key, AvgSalary = d.Average(x => x.Salary).ToString() })
                                  .FirstOrDefault();
            return result;
        }

        public object EmployeeCount(List<Employee> lstEmp)
        {
            var result = lstEmp.GroupBy(x => x.Department.Name)
                                    .Select(d => new { Department = d.Key, EmployeeCount = d.Count() }).ToList();

            return result;
        }

        public object HighestSalary(List<Employee> lstEmp)
        {
            var result = lstEmp.GroupBy(x=> x.Department.Name)
                .Select(d=> new { DepartmentName = d.Key, HighestSalary = d.Max(x => x.Salary)}).ToList();

            return result;
        }

        public async Task<string> GetProduct(string product)
        {
            var httpClient = _httpClientFactory.CreateClient("Employee");

            using HttpResponseMessage response = await httpClient.GetAsync(product);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();

            return JsonObject.Parse(responseBody).ToString();

        }


        public object RecentHires(List<Employee> lstEmp)
        {
            var result = lstEmp.OrderByDescending(x => x.HireDate)
                .Select(e => new
            {
                firstName = e.FirstName,
                lastname = e.LastName,
                hireDate = e.HireDate
            }).Take(5).ToList();

            return result;
        }

        public object UniqueLocations(List<Employee> lstEmp)
        {
            var result = lstEmp.Select(x => 
                        new { 
                            City = x.Locations.Select(l => l.City),
                            State = x.Locations.Select(l => l.State),
                            ZipCode = x.Locations.Select(l => l.ZipCode)
                        }).Distinct();

            return result;
        }
    }
}
