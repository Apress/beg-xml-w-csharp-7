using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;
using System.Xml.Serialization;

namespace EmployeeWebService.Models
{
    //[XmlRoot(ElementName ="EmployeeRoot")]
    public partial class Employee
    {
        //[XmlElement(ElementName ="EmpCode")]
        public int EmployeeID { get; set; }

        //[XmlElement(ElementName = "LName")]
        public string LastName { get; set; }

        //[XmlElement(ElementName = "FName")]
        public string FirstName { get; set; }

        //[XmlIgnore]
        public string HomePhone { get; set; }

        //[XmlElement(ElementName = "Remarks")]
        public string Notes { get; set; }
    }
}
