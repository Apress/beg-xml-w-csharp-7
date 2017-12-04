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

namespace WindowsApplication31
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!System.IO.File.Exists(textBox1.Text))
            {
                MessageBox.Show("Invalid source file name");
                return;
            }

            if (!System.IO.File.Exists(textBox2.Text))
            {
                MessageBox.Show("Invalid style sheet name");
                return;
            }

            if (!System.IO.Directory.Exists(System.IO.Path.GetDirectoryName(textBox3.Text)))
            {
                MessageBox.Show("Invalid destination directory");
                return;
            }

            if(Path.GetExtension(textBox3.Text)!=".htm" && Path.GetExtension(textBox3.Text)!=".html")
            {
                MessageBox.Show("File extention must be .htm or .html");
                return;
            }
            XslCompiledTransform xslt = new XslCompiledTransform();
            xslt.Load(textBox2.Text);
            xslt.Transform(textBox1.Text, textBox3.Text);
            if (checkBox1.Checked)
            {
                System.Diagnostics.Process.Start(textBox3.Text);
            }
        }
    }
}