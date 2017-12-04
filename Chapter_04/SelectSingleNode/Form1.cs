using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.XPath;

namespace WindowsApplication20
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
                MessageBox.Show("Please enter Employee ID");
                return;
            }

            XPathDocument doc = new XPathDocument($"{Application.StartupPath}\\employees.xml");
            XPathNavigator navigator = doc.CreateNavigator();
            XPathNavigator result = navigator.SelectSingleNode($"employees/employee[@employeeid={textBox1.Text}]");
            result.MoveToFirstChild();
            do
            {
                switch (result.Name)
                {
                    case "firstname":
                        label6.Text=result.Value;
                        break;
                    case "lastname":
                        label7.Text=result.Value;
                        break;
                    case "homephone":
                        label8.Text=result.Value;
                        break;
                    case "notes":
                        label9.Text=result.Value;
                        break;
                }
                
            }
            while (result.MoveToNext());

        }


    }
}