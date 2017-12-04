using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;

namespace FindElements
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        IEnumerable<XElement> subset = null;
        XElement ele = null;
        XElement[] datasource = null;

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Please enter tag name to search");
                return;
            }
            
            textBox2.Text = "";
            subset = from item in ele.Descendants(textBox1.Text)
                     select item;

            if (!checkBox1.Checked)
            {
                datasource = subset.ToArray();
            }
            else
            {
                if (subset.Count() > 0)
                {
                    datasource = new XElement[1];
                    datasource[0] = subset.First();
                }
            }
            listBox1.DataSource = datasource;
            listBox1.DisplayMember = "Name";

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox2.Text= datasource[listBox1.SelectedIndex].Value;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ele = XElement.Load($"{Application.StartupPath}\\employees.xml");
        }
    }
}
