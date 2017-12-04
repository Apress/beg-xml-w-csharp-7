using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WindowsApplication36
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private string strConn = @"data source=.;initial catalog=northwind;integrated security=true";
        EmployeesDataSet ds = new EmployeesDataSet();
        SqlDataAdapter da = new SqlDataAdapter();
        SqlConnection cnn;

        private void Form1_Load(object sender, EventArgs e)
        {
            cnn = new SqlConnection(strConn);
            SqlCommand cmdEmployees = new SqlCommand();
            cmdEmployees.CommandText = "select * from employees";
            cmdEmployees.Connection = cnn;
            da.SelectCommand = cmdEmployees;
            da.Fill(ds, "Employees");
            FillEmployees();
        }

        private void FillEmployees()
        {
            comboBox1.Items.Clear();
            foreach (EmployeesDataSet.EmployeesRow row in ds.Employees.Rows)
            {
                if (row.RowState != DataRowState.Deleted)
                {
                    comboBox1.Items.Add(row.EmployeeID.ToString());
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = comboBox1.SelectedItem.ToString();
            EmployeesDataSet.EmployeesRow[] rows = (EmployeesDataSet.EmployeesRow[])ds.Employees.Select($"EmployeeID={id}");
            textBox1.Text = rows[0].FirstName;
            textBox2.Text = rows[0].LastName;
            textBox3.Text = rows[0].HomePhone;
            textBox4.Text = rows[0].Notes;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "" || textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "")
            {
                MessageBox.Show("Please enter all the details about an employee");
                return;
            }
            
            EmployeesDataSet.EmployeesRow row = ds.Employees.NewEmployeesRow();
            row.EmployeeID = int.Parse(comboBox1.Text);
            row.FirstName = textBox1.Text;
            row.LastName = textBox2.Text;
            row.HomePhone = textBox3.Text;
            row.Notes = textBox4.Text;
            ds.Employees.AddEmployeesRow(row);
            FillEmployees();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == null)
            {
                MessageBox.Show("Please select Employee ID!");
                return;
            }
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "")
            {
                MessageBox.Show("Please enter all the details about an employee");
                return;
            }
            
            string id = comboBox1.SelectedItem.ToString();
            EmployeesDataSet.EmployeesRow[] rows= (EmployeesDataSet.EmployeesRow[])ds.Employees.Select("EmployeeID=" + id);
            rows[0].BeginEdit();
            rows[0].FirstName = textBox1.Text;
            rows[0].LastName = textBox2.Text;
            rows[0].HomePhone = textBox3.Text;
            rows[0].Notes = textBox4.Text;
            rows[0].EndEdit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == null)
            {
                MessageBox.Show("Please select Employee ID!");
                return;
            }

            string id = comboBox1.SelectedItem.ToString();
            EmployeesDataSet.EmployeesRow[] rows = (EmployeesDataSet.EmployeesRow[])ds.Employees.Select($"EmployeeID={id}");
            rows[0].Delete();
            FillEmployees();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlCommand cmdInsert = new SqlCommand();
            SqlCommand cmdUpdate = new SqlCommand();
            SqlCommand cmdDelete = new SqlCommand();
            cmdInsert.Connection = cnn;
            cmdUpdate.Connection = cnn;
            cmdDelete.Connection = cnn;
            cmdInsert.CommandText = "insert into employees(firstname,lastname,homephone,notes) values(@fname,@lname,@phone,@notes)";
            cmdUpdate.CommandText = "update employees set firstname=@fname,lastname=@lname,homephone=@phone where employeeid=@empid";
            cmdDelete.CommandText = "delete from employees where employeeid=@empid";

            SqlParameter[] pInsert = new SqlParameter[4];
            pInsert[0] = new SqlParameter("@fname", SqlDbType.VarChar);
            pInsert[0].SourceColumn = "firstname";
            pInsert[1] = new SqlParameter("@lname", SqlDbType.VarChar);
            pInsert[1].SourceColumn = "lastname";
            pInsert[2] = new SqlParameter("@phone", SqlDbType.VarChar);
            pInsert[2].SourceColumn = "homephone";
            pInsert[3] = new SqlParameter("@notes", SqlDbType.VarChar);
            pInsert[3].SourceColumn = "notes";
            foreach (SqlParameter p in pInsert)
            {
                cmdInsert.Parameters.Add(p);
            }

            SqlParameter[] pUpdate = new SqlParameter[5];
            pUpdate[0] = new SqlParameter("@fname", SqlDbType.VarChar);
            pUpdate[0].SourceColumn = "firstname";
            pUpdate[1] = new SqlParameter("@lname", SqlDbType.VarChar);
            pUpdate[1].SourceColumn = "lastname";
            pUpdate[2] = new SqlParameter("@phone", SqlDbType.VarChar);
            pUpdate[2].SourceColumn = "homephone";
            pUpdate[3] = new SqlParameter("@notes", SqlDbType.VarChar);
            pUpdate[3].SourceColumn = "notes";
            pUpdate[4] = new SqlParameter("@empid", SqlDbType.VarChar);
            pUpdate[4].SourceColumn = "employeeid";
            foreach (SqlParameter p in pUpdate)
            {
                cmdUpdate.Parameters.Add(p);
            }

            SqlParameter[] pDelete = new SqlParameter[1];
            pDelete[0] = new SqlParameter("@empid", SqlDbType.VarChar);
            pDelete[0].SourceColumn = "employeeid";
            foreach (SqlParameter p in pDelete)
            {
                cmdDelete.Parameters.Add(p);
            }

            da.InsertCommand = cmdInsert;
            da.UpdateCommand = cmdUpdate;
            da.DeleteCommand = cmdDelete;
            da.Update(ds,"Employees");
            ds.AcceptChanges();
        }
    }
}