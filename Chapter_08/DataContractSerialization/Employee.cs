using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;


namespace WindowsApplication45
{
    [DataContract]
    public class Employee
    {
        [DataMember]
        public int EmployeeID { get; set; }
        [DataMember]
        public string FirstName { get; set; }
        [DataMember]
        public string LastName { get; set; }
        [DataMember]
        public string HomePhone { get; set; }
        [DataMember]
        public string Notes { get; set; }
    }
}
