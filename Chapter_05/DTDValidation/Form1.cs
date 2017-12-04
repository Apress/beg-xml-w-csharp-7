using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Schema;
using System.Xml.XPath;

namespace WindowsApplication26
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            XmlReaderSettings settings = new XmlReaderSettings();
            settings.XmlResolver = new XmlUrlResolver();
            settings.ValidationFlags = XmlSchemaValidationFlags.ProcessSchemaLocation;
            settings.ValidationType = ValidationType.Schema;
            settings.ValidationEventHandler += new ValidationEventHandler(r_ValidationEventHandler);
            XmlReader reader = XmlReader.Create(@"C:\Test\EmployeesExtSchema.xml", settings);
            XPathDocument doc = new XPathDocument(reader);
            XPathNavigator navigator = doc.CreateNavigator();

        }

        void r_ValidationEventHandler(object sender, System.Xml.Schema.ValidationEventArgs e)
        {
            MessageBox.Show(e.Message);
        }
    }
}