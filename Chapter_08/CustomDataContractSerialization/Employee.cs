using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;


namespace WindowsApplication45
{
    [DataContract(Name ="MyEmployee")]
    public class Employee
    {
        [DataMember(Name ="EmployeeCode")]
        public int EmployeeID { get; set; }
        [DataMember(Name = "FName")]
        public string FirstName { get; set; }
        [DataMember(Name = "LName")]
        public string LastName { get; set; }
        [IgnoreDataMember]
        public string HomePhone { get; set; }
        [DataMember(Name = "Remarks")]
        public string Notes { get; set; }
    }
}
