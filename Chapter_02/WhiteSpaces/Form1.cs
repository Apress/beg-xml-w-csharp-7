using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace WindowsApplication8
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
            doc.PreserveWhitespace = checkBox1.Checked;
            doc.Load($"{Application.StartupPath}\\employees.xml");
            MessageBox.Show(doc.InnerXml);
            MessageBox.Show($"Employee node contains {doc.DocumentElement.ChildNodes.Count} child nodes");
        }
    }
}