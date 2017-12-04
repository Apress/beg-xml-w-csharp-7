using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace WindowsApplication49
{
    [XmlRoot(ElementName="MyEmployee")]
    public class Employee
    {
        [XmlAttribute(AttributeName = "EmployeeCode")]
        public int EmployeeID { get; set; }

        [XmlElement(ElementName = "FName")]
        public string FirstName { get; set; }

        [XmlElement(ElementName = "LName")]
        public string LastName { get; set; }

        [XmlIgnore]
        public string HomePhone { get; set; }

        [XmlElement(ElementName = "Remarks")]
        public string Notes { get; set; }

        [XmlArray(ElementName = "EmailAddresses")]
        [XmlArrayItem(ElementName = "Email")]
        public string[] Emails { get; set; }

        [XmlElement(ElementName = "EmployeeType")]
        public EmployeeType Type { get; set; }

        [XmlElement(IsNullable = true)]
        public Address Address { get; set; } = new Address();

    }

}
