using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.Runtime.Serialization;
using System.Data;

namespace EmployeeWCFService
{
    [DataContract]
    public class EmployeeDataContract
    {
        [DataMember]
        public int EmployeeID { get; set; }
        [DataMember]
        public string LastName { get; set; }
        [DataMember]
        public string FirstName { get; set; }
        [DataMember]
        public string HomePhone { get; set; }
        [DataMember]
        public string Notes { get; set; }
    }
}
