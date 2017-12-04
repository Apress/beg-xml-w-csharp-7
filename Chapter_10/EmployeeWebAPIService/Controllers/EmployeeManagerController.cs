using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EmployeeWebAPIService.Models;




namespace EmployeeWebAPIService.Controllers
{
    public class EmployeeManagerController : ApiController
    {
        [HttpGet]
        public List<Employee> SelectAll()
        {
            using (Northwind db = new Northwind())
            {
                var query = from e in db.Employees
                            orderby e.EmployeeID ascending
                            select e;
                return query.ToList();
            }
        }


        [HttpGet]
        public Employee SelectByID(int id)
        {
            using (Northwind db = new Northwind())
            {
                return db.Employees.Find(id);
            }
        }


        [HttpPost]
        public string Insert(Employee obj)
        {
            using (Northwind db = new Northwind())
            {
                Employee emp = new Employee();
                emp.FirstName = obj.FirstName;
                emp.LastName = obj.LastName;
                emp.HomePhone = obj.HomePhone;
                emp.Notes = obj.Notes;
                db.Employees.Add(emp);
                db.SaveChanges();
                return "Employee added successfully!";
            }
        }


        [HttpPut]
        public string Update(int id, Employee obj)
        {
            using (Northwind db = new Northwind())
            {
                Employee emp = db.Employees.Find(id);
                emp.FirstName = obj.FirstName;
                emp.LastName = obj.LastName;
                emp.HomePhone = obj.HomePhone;
                emp.Notes = obj.Notes;
                db.SaveChanges();
                return "Employee modified successfully!";
            }
        }


        [HttpDelete]
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
