using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace EmployeeWCFService
{
    [ServiceContract]
    public interface IEmployeeManager
    {
        [OperationContract]
        List<EmployeeDataContract> SelectAll();

        [OperationContract]
        EmployeeDataContract SelectByID(int id);

        [OperationContract]
        string Update(EmployeeDataContract emp);
    }

}
