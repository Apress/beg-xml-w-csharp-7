using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Xsl;
using System.IO;

namespace WindowsApplication32
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
                MessageBox.Show("Please enter first name");
                return;
            }
            
            string sourcefile= $"{Application.StartupPath}\\employees.xml";
            string xsltfile = $"{Application.StartupPath}\\employees.xslt";
            string destinationfile = $"{Application.StartupPath}\\employees.html";

            FileStream stream = new FileStream(destinationfile, FileMode.Create);

            XslCompiledTransform xslt = new XslCompiledTransform();
            xslt.Load(xsltfile);
            XsltArgumentList arguments = new XsltArgumentList();
            arguments.AddParam("firstname", "", textBox1.Text);
            xslt.Transform(sourcefile, arguments, stream);
            stream.Close();
            if (checkBox1.Checked)
            {
                System.Diagnostics.Process.Start(destinationfile);
            }
        }
    }
}