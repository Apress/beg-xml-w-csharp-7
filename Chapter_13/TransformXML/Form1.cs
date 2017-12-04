using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Diagnostics;

namespace TransformXML
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            XElement root = XElement.Load($"{Application.StartupPath}\\employees.xml");
            XElement html = new XElement("html",
                            new XElement("body",
                                new XElement("table",
                                    new XAttribute("border",1),
                                    new XElement("th", "Employee ID"),
                                    new XElement("th", "First Name"),
                                    new XElement("th", "LastName"),
                                    new XElement("th", "Home Phone"),
                                    new XElement("th", "Notes"),
                                    from item in root.Descendants("employee")
                                    select new XElement("tr",
                                        new XElement("td", item.Attribute("employeeid").Value),
                                        new XElement("td", item.Element("firstname").Value),
                                        new XElement("td", item.Element("lastname").Value),
                                        new XElement("td", item.Element("homephone").Value),
                                        new XElement("td", item.Element("notes").Value)))));
            html.Save($"{Application.StartupPath}\\employees.htm");
            if (checkBox1.Checked)
            {
                Process.Start($"{Application.StartupPath}\\employees.htm");
            }
            else
            {
                MessageBox.Show($"Output saved as {Application.StartupPath}\\employees.htm");
            }

        }
    }
}
