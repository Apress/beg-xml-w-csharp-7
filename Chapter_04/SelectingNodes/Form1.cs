using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.XPath;

namespace WindowsApplication23
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Please enter XPath Expression");
                return;
            }

            XPathDocument doc = new XPathDocument($"{Application.StartupPath}\\employees.xml");
            XPathNavigator navigator = doc.CreateNavigator();
            XPathNodeIterator iterator=navigator.Select(textBox1.Text);
            try
            {
                label3.Text = $"The expressions returned {iterator.Count} nodes";
                if (iterator.Count > 0)
                {
                    while (iterator.MoveNext())
                    {
                        textBox2.Text = iterator.Current.OuterXml;
                    }
                }
                else
                {
                    textBox2.Text = "No results";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}