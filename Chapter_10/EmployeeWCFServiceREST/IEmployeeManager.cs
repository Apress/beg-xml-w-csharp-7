using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace EmployeeWCFServiceREST
{
    [ServiceContract]
    public interface IEmployeeManager
    {
        [OperationContract]
        [WebGet(UriTemplate = "/employees",ResponseFormat =WebMessageFormat.Xml)]
        List<EmployeeDataContract> SelectAll();

        [OperationContract]
        [WebGet(UriTemplate = "/employees/{id}", ResponseFormat = WebMessageFormat.Xml)]
        EmployeeDataContract SelectByID(string id);

        [OperationContract]
        [WebInvoke(Method = "POST",UriTemplate = "/employees", RequestFormat =WebMessageFormat.Xml , ResponseFormat = WebMessageFormat.Xml,BodyStyle =WebMessageBodyStyle.Bare)]
        string Insert(EmployeeDataContract emp);

        [OperationContract]
        [WebInvoke(Method = "PUT",UriTemplate = "/employees/{id}", ResponseFormat = WebMessageFormat.Xml)]
        string Update(string id,EmployeeDataContract emp);

        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "/employees/{id}", ResponseFormat = WebMessageFormat.Xml)]
        string Delete(string id);


    }

}
