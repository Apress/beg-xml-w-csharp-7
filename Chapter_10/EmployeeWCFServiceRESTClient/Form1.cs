using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting; //Microsoft.AspNet.WebApi.Client NuGet Pkg
using System.Net.Http.Headers;
using System.Xml;




namespace EmployeeWCFServiceRESTClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }



        private HttpClient client;


        private void Form1_Load(object sender, EventArgs e)
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:49833");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml"));

            HttpResponseMessage response = client.GetAsync("/EmployeeManager.svc/employees").Result;
            string xmlData = response.Content.ReadAsStringAsync().Result;

            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xmlData);

            XmlNodeList list = doc.GetElementsByTagName("EmployeeID");
            foreach(XmlNode item in list)
            {
                comboBox1.Items.Add(item.InnerText);
            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            HttpResponseMessage response = client.GetAsync("/EmployeeManager.svc/employees/" + comboBox1.SelectedItem).Result;
            string xmlData = response.Content.ReadAsStringAsync().Result;

            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xmlData);

            textBox1.Text = doc.GetElementsByTagName("FirstName")[0].InnerText;
            textBox2.Text = doc.GetElementsByTagName("LastName")[0].InnerText;
            textBox3.Text = doc.GetElementsByTagName("HomePhone")[0].InnerText;
            textBox4.Text = doc.GetElementsByTagName("Notes")[0].InnerText;

            label6.Text = "";
        }


        private void button1_Click(object sender, EventArgs e)
        {
            string xmlEmp = $"<EmployeeDataContract xmlns='http://schemas.datacontract.org/2004/07/EmployeeWCFServiceREST' xmlns:i='http://www.w3.org/2001/XMLSchema-instance'><FirstName>{textBox1.Text}</FirstName><HomePhone>{textBox3.Text}</HomePhone><LastName>{textBox2.Text}</LastName><Notes>{textBox4.Text}</Notes></EmployeeDataContract>";

            HttpContent content = new StringContent(xmlEmp, Encoding.UTF8, "application/xml");

            HttpResponseMessage response = client.PostAsync("/EmployeeManager.svc/employees", content).Result;

            string xmlMsg = response.Content.ReadAsStringAsync().Result;

            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xmlMsg);
            label6.Text = doc.DocumentElement.InnerText;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string xmlEmp = $"<EmployeeDataContract xmlns='http://schemas.datacontract.org/2004/07/EmployeeWCFServiceREST' xmlns:i='http://www.w3.org/2001/XMLSchema-instance'><EmployeeID>{comboBox1.SelectedItem}</EmployeeID><FirstName>{textBox1.Text}</FirstName><HomePhone>{textBox3.Text}</HomePhone><LastName>{textBox2.Text}</LastName><Notes>{textBox4.Text}</Notes></EmployeeDataContract>";

            HttpContent content = new StringContent(xmlEmp, Encoding.UTF8, "application/xml");

            HttpResponseMessage response = client.PutAsync("/EmployeeManager.svc/employees/" + comboBox1.SelectedItem, content).Result;

            string xmlMsg = response.Content.ReadAsStringAsync().Result;

            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xmlMsg);
            label6.Text = doc.DocumentElement.InnerText;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            HttpResponseMessage response = client.DeleteAsync("/EmployeeManager.svc/employees/" + comboBox1.SelectedItem).Result;

            string xmlMsg = response.Content.ReadAsStringAsync().Result;

            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xmlMsg);
            label6.Text = doc.DocumentElement.InnerText;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            client.Dispose();
        }
    }
}
