using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace LINQBasic
{
    public class Employee
    {
        public int EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Country { get; set; }




        public static List<Employee> GetEmployees()
        {
            SqlConnection cnn = new SqlConnection(@"data source=.;initial catalog=northwind;integrated security=true");
            cnn.Open();
            SqlCommand cmd = new SqlCommand("select employeeid,firstname,lastname,birthdate,country from employees");
            cmd.Connection = cnn;
            SqlDataReader reader = cmd.ExecuteReader();
            List<Employee> items = new List<Employee>();
            while (reader.Read())
            {
                Employee item = new Employee();
                item.EmployeeID = reader.GetInt32(0);
                item.FirstName = reader.GetString(1);
                item.LastName = reader.GetString(2);
                item.BirthDate = reader.GetDateTime(3);
                item.Country = reader.GetString(4);
                items.Add(item);
            }

            reader.Close();
            cnn.Close();
            return items;
        }

    }
}
