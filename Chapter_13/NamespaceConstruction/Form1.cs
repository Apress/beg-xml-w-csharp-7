using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;

namespace NamespaceConstruction
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "")
            {
                MessageBox.Show("Please enter all the details");
                return;
            }
            
            XNamespace ns = textBox1.Text;
            XElement root = new XElement(ns + "employee",
                                new XElement(ns + "firstname",textBox3.Text),
                                new XElement(ns + "lastname",textBox4.Text)
                                );
            if (textBox2.Text == "")
            {
                root.SetAttributeValue("xmlns", ns);
            }
            else
            {
                root.SetAttributeValue(XNamespace.Xmlns + textBox2.Text, ns);
            }
            MessageBox.Show(root.ToString());
        }
    }
}
