using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.XPath;

namespace WindowsApplication17
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            XPathNavigator navigator = null;
            if (radioButton1.Checked)
            {
                XmlDocument doc = new XmlDocument();
                doc.Load($"{Application.StartupPath}\\employees.xml");
                navigator = doc.CreateNavigator();
            }
            else
            {
                XPathDocument doc = new XPathDocument($"{Application.StartupPath}\\employees.xml");
                navigator = doc.CreateNavigator();
            }
            MessageBox.Show("Navigator created successfully!");
        }
    }
}