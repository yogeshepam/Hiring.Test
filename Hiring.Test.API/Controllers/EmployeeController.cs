using Hiring.Test.Data;
using Hiring.Test.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hiring.Test.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly ILogger<EmployeeController> _logger;
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeController(ILogger<EmployeeController> logger, IEmployeeRepository employeeRepository)
        {
            _logger = logger;
            _employeeRepository = employeeRepository;
        }

        [HttpGet]
        public Employee Get()
        {
            return new Employee { FirstName = "John" };
        }

        /// <summary>
        /// Use HttpClientFactory to call the endpoint provided below in the employee service. 
        /// Input will be GetProducts(jewelery). Parse the response and return it to the UI.
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        [HttpGet("GetProduct")]
        public async Task<string> GetProdcut(string product)
        {
            try
            {
                var result = await _employeeRepository.GetProductAsync(product);

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
            }
            return null;

        }

        /// <summary>
        /// Given an array of binary digits, 0 and 1, sort the array so that all zeros are at one end and all ones are at the other. 
        /// Which end does not matter. Determine the minimum number of swaps to sort the array.
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetSortedArray")]
        public int[] GetSortedArray()
        {
            try
            {
                var input = new int[] { 0, 1, 0, 1, 0 };

                int swapIndex1 = -1;

                int swapIndex2 = -1;

                // Find the indices to swap
                for (int i = 0; i < input.Length; i++)
                {
                    if (input[i] == 1 && swapIndex1 == -1)
                    {
                        swapIndex1 = i;
                    }
                    else if (input[i] == 0 && swapIndex1 != -1)
                    {
                        swapIndex2 = i;
                    }
                }

                // Perform the swap
                if (swapIndex1 != -1 && swapIndex2 != -1)
                {
                    int temp = input[swapIndex1];
                    input[swapIndex1] = input[swapIndex2];
                    input[swapIndex2] = temp;
                }

                return input;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
            }
            return null;
        }

        /// <summary>
        /// Write an endpoint that filters employees based on firstName, lastName, Salary, and departmentName. All criteria should be optional.
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="salary"></param>
        /// <param name="departmentName"></param>
        /// <returns></returns>
        [HttpGet("FilterEmployee")]
        public List<Employee> GetEmploeeSearch(string? firstName, string? lastName, string? salary, string? departmentName)
        {
            try
            {
                var result = _employeeRepository.GetEmployeeAsync(firstName, lastName, salary, departmentName);
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
            }
            return null;
        }

        /// <summary>
        /// Create a method within the EmployeeService service named 
        /// AvgDeptSalary that takes any department name as a string input and returns the average salary of that department.
        /// </summary>
        /// <param name="departmentName"></param>
        /// <returns></returns>
        [HttpGet("GetAvgDeptSalary")]
        public JsonResult GetAvgDeptSalary(string departmentName)
        {
            try
            {
                var avgSalary = _employeeRepository.GetAvgDeptSalary(departmentName);

                return ReturnResult(avgSalary);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
            }
            return null;
        }


        /// <summary>
        /// Create a method within the EmployeeService service named EmployeeCount that returns a count of employees by department.
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetDeptEmployeeCount")]
        public JsonResult GetEmployeeCount()
        {
            try
            {
                var empCount = _employeeRepository.GetDepartmentwiseEmp();

                return ReturnResult(empCount);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
            }
            return null;
        }


        /// <summary>
        /// Create a method within the EmployeeService service named HighestSalary that returns the highest salary by department for all departments.
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetHightSalaryInDepartment")]
        public JsonResult GetHightSalaryInDepartment()
        {
            try
            {
                var highestSalary = _employeeRepository.GetHightestSalary();
                return ReturnResult(highestSalary);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
            }
            return null;
        }


        /// <summary>
        /// Create a method within the EmployeeService service named RecentHires that returns the 5 most recent hires.
        /// </summary>
        /// <returns></returns>
        [HttpGet("RecentHires")]
        public JsonResult GetRecentHires()
        {
            try
            {
                var recentHires = _employeeRepository.GetRecentHires();
                return ReturnResult(recentHires);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
            }
            return null;

        }

        [HttpGet("UniqueLocations")]
        public JsonResult GetUniqueLocations(string deptName)
        {
            try
            {
                var uniquelocations = _employeeRepository.UniqueLocations(deptName);

                return ReturnResult(uniquelocations);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
            }
            return null;
        }

        private JsonResult ReturnResult(object result)
        {
            return new JsonResult(result);
        }

    }
}
