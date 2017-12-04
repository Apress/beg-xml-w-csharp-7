using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using EmployeeWebService.Models;
using System.Data.Entity;


namespace EmployeeWebService.Services
{
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    public class EmployeeManagerWithSOAPHeader : System.Web.Services.WebService
    {
        public EmployeeManagerHeader Header;

        [WebMethod]
        [SoapHeader("Header", Direction = SoapHeaderDirection.In)]
        public List<Employee> SelectAll()
        {
            if (Header==null)
            {
                throw new SoapHeaderException("SOAP header was not found!", SoapException.ClientFaultCode);
            }

            if(Header.ClientKey != "KEY001")
            {
                throw new SoapException("Invalid client key!", SoapException.ClientFaultCode);
            }

            using (Northwind db = new Northwind())
            {
                return db.Employees.OrderBy(e => e.EmployeeID).ToList();
            }
        }

        [WebMethod]
        [SoapHeader("Header", Direction = SoapHeaderDirection.In)]
        public Employee SelectByID(int id)
        {
            if (string.IsNullOrEmpty(Header.ClientKey))
            {
                throw new SoapHeaderException("SOAP header was not found!", SoapException.ClientFaultCode);
            }

            if (Header.ClientKey != "KEY001")
            {
                throw new SoapException("Invalid client key!", SoapException.ClientFaultCode);
            }

            using (Northwind db = new Northwind())
            {
                return db.Employees.Find(id);
            }
        }

        [WebMethod]
        [SoapHeader("Header", Direction = SoapHeaderDirection.In)]
        public string Update(Employee emp)
        {
            if (string.IsNullOrEmpty(Header.ClientKey))
            {
                throw new SoapHeaderException("SOAP header was not found!", SoapException.ClientFaultCode);
            }

            if (Header.ClientKey != "KEY001")
            {
                throw new SoapException("Invalid client key!", SoapException.ClientFaultCode);
            }

            using (Northwind db = new Northwind())
            {
                db.Entry(emp).State = EntityState.Modified;
                db.SaveChanges();
                return "Employee modified successfully!";
            }
        }

    }
}
