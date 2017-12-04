using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.XPath;

namespace WindowsApplication21
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Please enter Employee ID");
                return;
            }

            if (textBox2.Text == "")
            {
                MessageBox.Show("Please enter file to write");
                return;
            }
            
            if (!System.IO.Directory.Exists(System.IO.Path.GetDirectoryName(textBox2.Text)))
            {
                MessageBox.Show("Invalid destination directory");
                return;
            }
            
            XPathDocument doc = new XPathDocument($"{Application.StartupPath}\\employees.xml");
            XPathNavigator navigator = doc.CreateNavigator();
            navigator.MoveToRoot();
            navigator.MoveToFirstChild();
            while (navigator.MoveToNext())
            {
                navigator.MoveToFirstChild();
                do
                {
                    string id = navigator.GetAttribute("employeeid", "");
                    if (id == textBox1.Text)
                    {
                        XmlTextWriter writer = new XmlTextWriter(textBox2.Text, null);
                        navigator.WriteSubtree(writer);
                        writer.Close();
                        if (MessageBox.Show("Do you want to see the file?", "Question", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            System.Diagnostics.Process.Start(textBox2.Text);
                        }
                    }
                }
                while (navigator.MoveToNext());
            }

        }
    }
}