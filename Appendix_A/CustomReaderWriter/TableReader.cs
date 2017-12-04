using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Data;
using System.Data.OleDb;

namespace RelationalToXml
{

    public class TableReader:XmlReader
    {
        private OleDbConnection cnn;
        private OleDbCommand cmd;
        private OleDbDataReader reader;
        private int intColumnIndex = -1;
        private string strValue;

        public TableReader(string connectionString,string tableName)
        {
            cnn = new OleDbConnection(connectionString);
            cmd = new OleDbCommand();
            cmd.Connection = cnn;
            cmd.CommandText = tableName;
            cmd.CommandType = CommandType.TableDirect;
            cnn.Open();
            reader = cmd.ExecuteReader();
        }

        public override int AttributeCount
        {
            get 
            {
                return reader.FieldCount;
            }
        }

        public override void Close()
        {
            reader.Close();
            cnn.Close();
        }

        public override int Depth
        {
            get 
            {
                return reader.Depth;
            }
        }

        public override string GetAttribute(int i)
        {
            return reader.GetValue(i).ToString();
        }

        public override string GetAttribute(string name)
        {
            return reader.GetValue(reader.GetOrdinal(name)).ToString();
        }

        public override bool MoveToAttribute(string name)
        {
            intColumnIndex = reader.GetOrdinal(name);
            return true;
        }

        public override bool MoveToElement()
        {
            intColumnIndex = -1;
            return true;
        }

        public override bool MoveToFirstAttribute()
        {
            intColumnIndex = 0;
            return true;
        }

        public override bool MoveToNextAttribute()
        {
            intColumnIndex++;
            if (intColumnIndex > reader.FieldCount - 1)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public override bool Read()
        {
            intColumnIndex = -1;
            strValue = "";
            return reader.Read();
        }

        public override bool HasValue
        {
            get 
            {
                return reader.IsDBNull(intColumnIndex);
            }
        }

        public override bool ReadAttributeValue()
        {
            if (intColumnIndex < reader.FieldCount)
            {
                strValue = reader.GetValue(intColumnIndex).ToString();
                return true;
            }
            else
            {
                return false;
            }
        }

        public override string Name
        {
            get
            {
                if (intColumnIndex == -1)
                {
                    return cmd.CommandText;
                }
                else
                {
                    return reader.GetName(intColumnIndex);
                }
            }
        }

        public override string Value
        {
            get 
            {
                return strValue;
            }
        }

        #region Not Implemented Members
        public override bool EOF
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        public override string GetAttribute(string name, string namespaceURI)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public override bool MoveToAttribute(string name, string ns)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public override string BaseURI
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        public override bool IsEmptyElement
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        public override string LocalName
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        public override string LookupNamespace(string prefix)
        {
            throw new Exception("The method or operation is not implemented.");
        }


        public override XmlNameTable NameTable
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        public override string NamespaceURI
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        public override XmlNodeType NodeType
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        public override string Prefix
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }


        public override ReadState ReadState
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        public override void ResolveEntity()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion

    }
}
