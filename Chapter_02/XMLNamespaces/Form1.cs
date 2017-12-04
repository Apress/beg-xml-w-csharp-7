using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace WindowsApplication9
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load($"{Application.StartupPath}\\employees.xml");
            label4.Text = doc.DocumentElement.NamespaceURI;
            label5.Text = doc.DocumentElement.Prefix;
            label6.Text = doc.DocumentElement.LocalName;
          
        }
    }
}