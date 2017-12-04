using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace WindowsApplication4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        XmlDocument doc = new XmlDocument();

        private void Form1_Load(object sender, EventArgs e)
        {
            doc.Load($"{Application.StartupPath}\\employees.xml");
            foreach (XmlNode node in doc.DocumentElement.ChildNodes)
            {
                string employeeid = node.Attributes["employeeid"].Value;
                comboBox1.Items.Add(employeeid);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            XmlElement ele= doc.GetElementById(comboBox1.SelectedItem.ToString());
            label6.Text = ele.ChildNodes[0].InnerText;
            label7.Text = ele.ChildNodes[1].InnerText;
            label8.Text = ele.ChildNodes[2].InnerText;
            label9.Text = ele.ChildNodes[3].InnerText;
        }
    }
}