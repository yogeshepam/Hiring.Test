##Hiring.Test

Create an interface named: IEmployeeService


Create a class named EmployeeService that implement the interface above.


Inject the EmployeeService service in the Controller as Singleton


Use HttpClientFactory to call the endpoint provided below in the employee service. Input will be GetProducts(jewelery). Parse the response and return it to the UI.


Endpoint: https://fakestoreapi.com/products/category/jewelery
5.	Given an array of binary digits, 0 and 1, sort the array so that all zeros are at one end and all ones are at the other. Which end does not matter. Determine the minimum number of swaps to sort the array.
Example:
arr=[0,1,0,1,0]
With 1 move, switching elements 1 and 4, yields [0,0,0,1,1], a sorted array.
6.	Write an endpoint that filters employees based on firstName, lastName, Salary, and departmentName. All criteria should be optional.
7.	Create a method within the EmployeeService service named AvgDeptSalary that takes any department name as a string input and returns the average salary of that department.
8.	Expected Output:
Input	Avg. Salary
HR	125000

Create a method within the EmployeeService service named EmployeeCount that returns a count of employees by department.
Create a method within the EmployeeService service named RecentHires that returns the 5 most recent hires.
Create a method within the EmployeeService service named UniqueLocations that returns all and only unique locations of a department given as input.
