using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace WindowsApplication31
{
    class Employee
    {
        public string GetBirthDate(int employeeid)
        {
            SqlConnection cnn = new SqlConnection(@"data source=.;initial catalog=northwind;integrated security=true");
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cnn;
            cmd.CommandText = "select birthdate from employees where employeeid=@id";
            SqlParameter pDOB = new SqlParameter("@id", employeeid);
            cmd.Parameters.Add(pDOB);
            cnn.Open();
            object obj = cmd.ExecuteScalar();
            cnn.Close();
            DateTime dob = DateTime.Parse(obj.ToString());
            return dob.ToString("MM/dd/yyyy");
        }

    }
}
