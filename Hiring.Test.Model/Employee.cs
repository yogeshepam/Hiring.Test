using System;
using System.Collections.Generic;
using System.Text;

namespace Hiring.Test.Model
{
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime HireDate { get; set; }
        public Department Department { get; set; }
        public List<Location> Locations { get; set; }

        public decimal Salary { get; set; }
    }

    public class Location
    {
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }

    }
}
