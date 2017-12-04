using System;
using System.Collections.Generic;
using System.Text;

namespace WindowsApplication45
{
    public class Employee
    {
        public int EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string HomePhone { get; set; }
        public string Notes { get; set; }
        public string[] Emails { get; set; }
        public EmployeeType Type { get; set; }
        public Address Address { get; set; } = new Address();
    }

}
