using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace WindowsApplication13
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
                MessageBox.Show("Please specify database connection string");
                return;
            }

            if (textBox2.Text == "")
            {
                MessageBox.Show("Please specify table name to export");
                return;
            }

            if (textBox3.Text == "")
            {
                MessageBox.Show("Please specify destination file name");
                return;
            }

            if (!System.IO.Directory.Exists(System.IO.Path.GetDirectoryName(textBox3.Text)))
            {
                MessageBox.Show("Invalid destination directory");
                return;
            }


            if (textBox1.Text == "")
            {
                MessageBox.Show("Please specify database connection string");
                return;
            }

            try
            {
                SqlConnection cnn = new SqlConnection(textBox1.Text);
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cnn;
                cmd.CommandText = $"select * from {textBox2.Text}";
                cnn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                XmlTextWriter writer = new XmlTextWriter(textBox3.Text, null);
                if (checkBox1.Checked)
                {
                    writer.Formatting = Formatting.Indented;
                    writer.Indentation = int.Parse(textBox4.Text);
                    writer.IndentChar = (radioButton3.Checked ? ' ' : '\t');
                }
                writer.WriteStartDocument();
                writer.WriteComment($"File exported on {DateTime.Now}");
                writer.WriteStartElement("table");
                while (reader.Read())
                {
                    if (radioButton1.Checked)
                    {
                        writer.WriteStartElement("row");
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            writer.WriteStartElement(reader.GetName(i));
                            writer.WriteString(reader.GetValue(i).ToString());
                            writer.WriteEndElement();
                        }
                        writer.WriteEndElement();
                    }
                    else
                    {
                        writer.WriteStartElement("row");
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            writer.WriteAttributeString(reader.GetName(i), reader.GetValue(i).ToString());
                        }
                        writer.WriteEndElement();
                    }
                }
                writer.WriteEndElement();
                writer.Close();
                reader.Close();
                cnn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}