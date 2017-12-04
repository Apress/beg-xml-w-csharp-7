using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.ServiceModel;
using EmployeeWCFServiceREST.Models;


namespace EmployeeWCFServiceREST
{
    public class EmployeeManager:IEmployeeManager
    {
        public List<EmployeeDataContract> SelectAll()
        {
            using (Northwind db = new Northwind())
            {
                var query = from e in db.Employees
                            orderby e.EmployeeID ascending
                            select new EmployeeDataContract()
                            {
                                EmployeeID = e.EmployeeID,
                                FirstName = e.FirstName,
                                LastName = e.LastName,
                                HomePhone = e.HomePhone,
                                Notes = e.Notes
                            };
                return query.ToList();
            }
        }

        public EmployeeDataContract SelectByID(string id)
        {
            using (Northwind db = new Northwind())
            {
                int empId = int.Parse(id);
                var query = from e in db.Employees
                            where e.EmployeeID == empId
                            select new EmployeeDataContract()
                            {
                                EmployeeID = e.EmployeeID,
                                FirstName = e.FirstName,
                                LastName = e.LastName,
                                HomePhone = e.HomePhone,
                                Notes = e.Notes
                            };
                return query.SingleOrDefault();
            }
        }


        public string Insert(EmployeeDataContract obj)
        {
            using (Northwind db = new Northwind())
            {
                Employee emp = new Employee();
                emp.EmployeeID = obj.EmployeeID;
                emp.FirstName = obj.FirstName;
                emp.LastName = obj.LastName;
                emp.HomePhone = obj.HomePhone;
                emp.Notes = obj.Notes;
                db.Employees.Add(emp);
                db.SaveChanges();
                return "Employee added successfully!";
            }
        }


        public string Update(string id,EmployeeDataContract obj)
        {
            using (Northwind db = new Northwind())
            {
                Employee emp = db.Employees.Find(int.Parse(id));
                emp.FirstName = obj.FirstName;
                emp.LastName = obj.LastName;
                emp.HomePhone = obj.HomePhone;
                emp.Notes = obj.Notes;
                db.SaveChanges();
                return "Employee modified successfully!";
            }
        }

        public string Delete(string id)
        {
            using (Northwind db = new Northwind())
            {
                Employee emp = db.Employees.Find(int.Parse(id));
                db.Employees.Remove(emp);
                db.SaveChanges();
                return "Employee deleted successfully!";
            }
        }
    }
}
