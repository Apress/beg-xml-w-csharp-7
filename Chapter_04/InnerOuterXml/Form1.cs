using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.XPath;

namespace WindowsApplication19
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            XPathDocument doc = new XPathDocument($"{Application.StartupPath}\\employees.xml");
            XPathNavigator navigator = doc.CreateNavigator();
            navigator.MoveToRoot();
            navigator.MoveToFirstChild();
            while (navigator.MoveToNext())
            {
                if (radioButton1.Checked)
                {
                    MessageBox.Show(navigator.InnerXml);
                }
                else
                {
                    MessageBox.Show(navigator.OuterXml);
                }
            }

        }
    }
}