using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;

namespace FindContent
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        XElement root = null;


        private void Form1_Load(object sender, EventArgs e)
        {
            root = XElement.Load($"{Application.StartupPath}\\employees.xml");
            var result = from item in root.Elements("employee")
                         where item.Attributes("employeeid").Count() > 0
                         select item.Attribute("employeeid").Value;
            foreach (var obj in result)
            {
                comboBox1.Items.Add(obj);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == null)
            {
                MessageBox.Show("Please select an Employee ID");
                return;
            }

            var result = from item in root.Elements("employee")
                         where item.Attribute("employeeid").Value == comboBox1.SelectedItem.ToString()
                         select item;
            foreach (var obj in result)
            {
                label6.Text = obj.Element("firstname").Value;
                label7.Text = obj.Element("lastname").Value;
                label8.Text = obj.Element("homephone").Value;
                label9.Text = obj.Element("notes").Value;
            }
        }
    }
}
