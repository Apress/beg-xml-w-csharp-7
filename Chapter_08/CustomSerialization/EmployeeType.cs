using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace WindowsApplication49
{
    public enum EmployeeType
    {
        [XmlEnum(Name="Permanent Employee")]
        Permanent,
        [XmlEnum(Name = "Employee on contract")]
        Contract
    }

}
