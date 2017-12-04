using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using System.Linq;

namespace EventsOfXElement
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        XElement doc = null;

        private void Form1_Load(object sender, EventArgs e)
        {
            doc = XElement.Load($"{Application.StartupPath}\\employees.xml");

            doc.Changing += new EventHandler<XObjectChangeEventArgs>(doc_Changing);
            doc.Changed += new EventHandler<XObjectChangeEventArgs>(doc_Changed);

            var result=from item in doc.Descendants("employee")
                       select item.Attribute("employeeid").Value;
            foreach (var obj in result)
            {
                comboBox1.Items.Add(obj);
            }
            FillControls();
        }

        void doc_Changed(object sender, XObjectChangeEventArgs e)
        {
            string msg = "";
            switch (e.ObjectChange)
            {
                case XObjectChange.Add:
                    msg = "A new element has been added";
                    break;
                case XObjectChange.Remove:
                    msg = "An element has been removed";
                    break;
                case XObjectChange.Name:
                    msg = "An element has been renamed";
                    break;
                case XObjectChange.Value:
                    msg = "Value has been changed";
                    break;
            }
            MessageBox.Show(msg);
        }

        void doc_Changing(object sender, XObjectChangeEventArgs e)
        {
            
        }

        private void FillControls()
        {
            if (comboBox1.SelectedIndex == -1)
            {
                comboBox1.SelectedIndex = 0;
            }
            string employeeid = comboBox1.SelectedItem.ToString();
            var employees = from item in doc.Elements()
                                where item.Attribute("employeeid").Value == employeeid
                                select item;
            foreach (var employee in employees)
            {
                textBox1.Text = employee.Element("firstname").Value;
                textBox2.Text = employee.Element("lastname").Value;
                textBox3.Text = employee.Element("homephone").Value;
                textBox4.Text = employee.Element("notes").Value;
            }
            label6.Text = $"Employee {(comboBox1.SelectedIndex + 1)} of {comboBox1.Items.Count}";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
            FillControls();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex > 0)
            {
                comboBox1.SelectedIndex = comboBox1.SelectedIndex - 1;
            }
            FillControls();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex < comboBox1.Items.Count - 1)
            {
                comboBox1.SelectedIndex = comboBox1.SelectedIndex + 1;
            }
            FillControls();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = comboBox1.Items.Count - 1;
            FillControls();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text=="" || textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "")
            {
                MessageBox.Show("Please enter all the details about an employee");
                return;
            }

            
            
            XElement employee = new XElement("employee",
                                    new XElement("firstname", textBox1.Text),
                                    new XElement("lastname", textBox2.Text),
                                    new XElement("homephone", textBox3.Text),
                                    new XElement("notes", new XCData(textBox4.Text)));
            employee.SetAttributeValue("employeeid", comboBox1.Text);

            doc.Add(employee);
            comboBox1.Items.Add(comboBox1.Text);
            FillControls();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "")
            {
                MessageBox.Show("Please enter all the details about an employee");
                return;
            }
            
            string employeeid = comboBox1.SelectedItem.ToString();
            var employees = from item in doc.Descendants("employee")
                            where item.Attribute("employeeid").Value == employeeid
                            select item;
            foreach (var employee in employees)
            {
                employee.SetElementValue("firstname", textBox1.Text);
                employee.SetElementValue("lastname", textBox2.Text);
                employee.SetElementValue("homephone", textBox3.Text);
                employee.SetElementValue("notes", textBox4.Text);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string employeeid = comboBox1.SelectedItem.ToString();
            var employees = from item in doc.Descendants("employee")
                            where item.Attribute("employeeid").Value == employeeid
                            select item;
            foreach (var employee in employees)
            {
                employee.Remove();
                break;
            }
            comboBox1.Items.Remove(employeeid);
            FillControls();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            doc.Save($"{Application.StartupPath}\\employees.xml");
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillControls();
        }
    }
}