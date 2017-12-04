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
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class EmployeeManager : System.Web.Services.WebService
    {

        [WebMethod]
        public List<Employee> SelectAll()
        {
            using (Northwind db = new Northwind())
            {
                return db.Employees.OrderBy(e => e.EmployeeID).ToList();
            }
        }

        [WebMethod]
        public Employee SelectByID(int id)
        {
            using (Northwind db = new Northwind())
            {
                return db.Employees.Find(id);
            }
        }

        [WebMethod]
        public string Insert(Employee obj)
        {
            using (Northwind db = new Northwind())
            {
                db.Employees.Add(obj);
                db.SaveChanges();
                return "Employee added successfully!";
            }
        }

        [WebMethod]
        public string Update(Employee emp)
        {
            using (Northwind db = new Northwind())
            {
                db.Entry(emp).State = EntityState.Modified;
                db.SaveChanges();
                return "Employee modified successfully!";
            }
        }

        [WebMethod]
        public string Delete(int id)
        {
            using (Northwind db = new Northwind())
            {
                Employee emp = db.Employees.Find(id);
                db.Employees.Remove(emp);
                db.SaveChanges();
                return "Employee deleted successfully!";
            }
        }

    }
}
