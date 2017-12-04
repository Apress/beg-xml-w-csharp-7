using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Schema;

namespace WindowsApplication27
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
                MessageBox.Show("Please enter file name");
                return;
            }

            if (!System.IO.Directory.Exists(System.IO.Path.GetDirectoryName(textBox1.Text)))
            {
                MessageBox.Show("Invalid destination directory");
                return;
            }
            
            XmlSchema schema = new XmlSchema();

            //define NameSimpleType

            XmlSchemaSimpleType nametype = new XmlSchemaSimpleType();
            XmlSchemaSimpleTypeRestriction nameRes = new XmlSchemaSimpleTypeRestriction();
            nameRes.BaseTypeName = new XmlQualifiedName("string", "http://www.w3.org/2001/XMLSchema");
            XmlSchemaMinLengthFacet nameFacet1 = new XmlSchemaMinLengthFacet();
            nameFacet1.Value = "3";
            XmlSchemaMaxLengthFacet nameFacet2 = new XmlSchemaMaxLengthFacet();
            nameFacet2.Value = "255";
            nameRes.Facets.Add(nameFacet1);
            nameRes.Facets.Add(nameFacet2);
            nametype.Content = nameRes;

            //define PhoneSimpleType

            XmlSchemaSimpleType phonetype = new XmlSchemaSimpleType();
            XmlSchemaSimpleTypeRestriction phoneRes = new XmlSchemaSimpleTypeRestriction();
            phoneRes.BaseTypeName = new XmlQualifiedName("string", "http://www.w3.org/2001/XMLSchema");
            XmlSchemaMaxLengthFacet phoneFacet1 = new XmlSchemaMaxLengthFacet();
            phoneFacet1.Value = "20";
            phoneRes.Facets.Add(phoneFacet1);
            phonetype.Content = phoneRes;

            //define NotesSimpleType

            XmlSchemaSimpleType notestype = new XmlSchemaSimpleType();
            XmlSchemaSimpleTypeRestriction notesRes = new XmlSchemaSimpleTypeRestriction();
            notesRes.BaseTypeName = new XmlQualifiedName("string", "http://www.w3.org/2001/XMLSchema");
            XmlSchemaMaxLengthFacet notesFacet1 = new XmlSchemaMaxLengthFacet();
            notesFacet1.Value = "500";
            notesRes.Facets.Add(notesFacet1);
            notestype.Content = notesRes;

            //define EmployeeType complex type

            XmlSchemaComplexType employeetype = new XmlSchemaComplexType();
            XmlSchemaSequence sequence = new XmlSchemaSequence();
            XmlSchemaElement firstname = new XmlSchemaElement();
            firstname.Name = "firstname";
            firstname.SchemaType = nametype;
            XmlSchemaElement lastname = new XmlSchemaElement();
            lastname.Name = "lastname";
            lastname.SchemaType = nametype;
            XmlSchemaElement homephone = new XmlSchemaElement();
            homephone.Name = "homephone";
            homephone.SchemaType = phonetype;
            XmlSchemaElement notes = new XmlSchemaElement();
            notes.Name = "notes";
            notes.SchemaType = notestype;

            sequence.Items.Add(firstname);
            sequence.Items.Add(lastname);
            sequence.Items.Add(homephone);
            sequence.Items.Add(notes);

            employeetype.Particle = sequence;

            //define employeeid attribute

            XmlSchemaAttribute employeeid = new XmlSchemaAttribute();
            employeeid.Name = "employeeid";
            employeeid.SchemaTypeName = new XmlQualifiedName("int", "http://www.w3.org/2001/XMLSchema");
            employeeid.Use = XmlSchemaUse.Required;

            employeetype.Attributes.Add(employeeid);

            //define top complex type

            XmlSchemaComplexType complextype = new XmlSchemaComplexType();
            XmlSchemaSequence sq = new XmlSchemaSequence();
            XmlSchemaElement employee = new XmlSchemaElement();
            employee.Name = "employee";
            employee.SchemaType = employeetype;
            employee.MinOccurs = 0;
            employee.MaxOccursString = "unbounded";
            sq.Items.Add(employee);
            complextype.Particle = sq;

            //define <employees> element

            XmlSchemaElement employees = new XmlSchemaElement();
            employees.Name = "employees";
            employees.SchemaType = complextype;

            schema.Items.Add(employees);

            //compile the schema
            try
            {
                XmlSchemaSet set = new XmlSchemaSet();
                set.Add(schema);
                set.Compile();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Schema compilation failed");
                return;
            }

            //save the schema
            XmlTextWriter writer=new XmlTextWriter(textBox1.Text,null);
            schema.Write(writer);
            writer.Close();
            MessageBox.Show("Schema Created Successfully!");

        }


    }
}