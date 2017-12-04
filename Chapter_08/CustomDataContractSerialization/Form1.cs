using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.IO;
using System.Diagnostics;
using System.Runtime.Serialization;


namespace WindowsApplication45
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text=="")
            {
                MessageBox.Show("Please enter all the details about an employee");
                return;
            }

            int result;
            if (!int.TryParse(textBox1.Text, out result))
            {
                MessageBox.Show("Employee ID must be an integer");
                return;
            }

            
            Employee emp = new Employee();
            emp.EmployeeID = int.Parse(textBox1.Text);
            emp.FirstName = textBox2.Text;
            emp.LastName = textBox3.Text;
            emp.HomePhone = textBox4.Text;
            emp.Notes = textBox5.Text;
            FileStream stream = new FileStream($"{Application.StartupPath}\\employee.xml", FileMode.Create);

            DataContractSerializer serializer = new DataContractSerializer(typeof(Employee));
            serializer.WriteObject(stream, emp);

            stream.Close();
            if (checkBox1.Checked)
            {
                Process.Start($"{Application.StartupPath}\\employee.xml");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Employee emp;
            FileStream stream = new FileStream($"{Application.StartupPath}\\employee.xml", FileMode.Open);

            DataContractSerializer serializer = new DataContractSerializer(typeof(Employee));
            emp = (Employee)serializer.ReadObject(stream);

            stream.Close();
            textBox1.Text = emp.EmployeeID.ToString();
            textBox2.Text = emp.FirstName;
            textBox3.Text = emp.LastName;
            textBox4.Text = emp.HomePhone;
            textBox5.Text = emp.Notes;
        }
    }
}