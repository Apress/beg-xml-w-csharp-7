using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.ServiceModel;
using EmployeeWCFService.Models;


namespace EmployeeWCFService
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

        public EmployeeDataContract SelectByID(int id)
        {
            using (Northwind db = new Northwind())
            {
                var query = from e in db.Employees
                            where e.EmployeeID == id
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

        public string Update(EmployeeDataContract emp)
        {
            using (Northwind db = new Northwind())
            {
                Employee existing = db.Employees.Find(emp.EmployeeID);
                existing.FirstName = emp.FirstName;
                existing.LastName = emp.LastName;
                existing.HomePhone = emp.HomePhone;
                existing.Notes = emp.Notes;
                db.SaveChanges();
                return "Employee modified successfully!";
            }
        }
    }
}
