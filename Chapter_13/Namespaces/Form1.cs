using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Namespaces
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            XElement root = XElement.Load($"{Application.StartupPath}\\employees.xml");
            label4.Text = root.Name.NamespaceName;
            label5.Text = root.Name.LocalName;
            label6.Text = root.Name.ToString();
        }

    }
}
