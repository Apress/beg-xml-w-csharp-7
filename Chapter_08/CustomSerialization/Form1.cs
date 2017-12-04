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

namespace WindowsApplication49
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
            foreach (Control c in this.Controls)
            {
                if (c is TextBox)
                {
                    if (((TextBox)c).Text == "")
                    {
                        MessageBox.Show("Please enter all the details about an employee");
                        return;
                    }
                }
            }

            int result;
            if (!int.TryParse(textBox1.Text,out result))
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
            emp.Type = (comboBox1.SelectedIndex == 0 ? EmployeeType.Permanent : EmployeeType.Contract);
            emp.Address.Street = textBox6.Text;
            emp.Address.City = textBox7.Text;
            emp.Address.State = textBox8.Text;
            emp.Address.Country = textBox9.Text;
            emp.Address.PostalCode = textBox10.Text;
            emp.Emails = textBox11.Text.Split(',');
            FileStream stream = new FileStream(Application.StartupPath + @"\employee.xml", FileMode.Create);
            XmlSerializer serializer = new XmlSerializer(typeof(Employee));
            serializer.Serialize(stream, emp);
            stream.Close();
            if (checkBox1.Checked)
            {
                Process.Start(Application.StartupPath + @"\employee.xml");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Employee emp;
            FileStream stream = new FileStream(Application.StartupPath + @"\employee.xml", FileMode.Open);
            XmlSerializer serializer = new XmlSerializer(typeof(Employee));
            emp=(Employee)serializer.Deserialize(stream);
            stream.Close();
            textBox1.Text = emp.EmployeeID.ToString();
            textBox2.Text = emp.FirstName;
            textBox3.Text = emp.LastName;
            textBox4.Text = emp.HomePhone;
            textBox5.Text = emp.Notes;
            comboBox1.SelectedIndex = (emp.Type == EmployeeType.Permanent?0:1);
            textBox6.Text=emp.Address.Street;
            textBox7.Text=emp.Address.City;
            textBox8.Text=emp.Address.State;
            textBox9.Text=emp.Address.Country;
            textBox10.Text=emp.Address.PostalCode;
            textBox11.Text = string.Join(",", emp.Emails);
            stream.Close();
        }

        void serializer_UnknownNode(object sender, XmlNodeEventArgs e)
        {
            MessageBox.Show("Unknown Node " + e.Name + " found at Line " + e.LineNumber);
        }

        void serializer_UnknownElement(object sender, XmlElementEventArgs e)
        {
            MessageBox.Show("Unknown Element " + e.Element.Name + " found at Line " + e.LineNumber);
        }

        void serializer_UnknownAttribute(object sender, XmlAttributeEventArgs e)
        {
            MessageBox.Show("Unknown Attribute " + e.Attr.Name + " found at Line " + e.LineNumber);
        }
    }
}