using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.IO;

namespace RSS
{
    public class RssWriter:XmlWriter
    {
        private XmlWriter writer;
        private Stream objStream;

        #region Constructor

        public RssWriter(Stream stream)
        {
            objStream = stream;
            writer=XmlWriter.Create(objStream);
        }

        #endregion

        #region Stream Related Operations

        public override void Close()
        {
            objStream.Close();
            writer.Close();
        }

        public override void Flush()
        {
            writer.Flush();
        }

        #endregion

        #region Writing Elements

        public void WriteStartElement(RssElements element)
        {
            string elementName = "";

            switch (element)
            {
                case RssElements.Channel:
                    elementName = "channel";
                    break;
                case RssElements.Copyright:
                    elementName = "copyright";
                    break;
                case RssElements.Description:
                    elementName = "description";
                    break;
                case RssElements.Generator:
                    elementName = "generator";
                    break;
                case RssElements.Item:
                    elementName = "item";
                    break;
                case RssElements.Link:
                    elementName = "link";
                    break;
                case RssElements.PubDate:
                    elementName = "pubDate";
                    break;
                case RssElements.Rss:
                    elementName = "rss";
                    break;
                case RssElements.Title:
                    elementName = "title";
                    break;
            }
            writer.WriteStartElement(elementName);
        }

        public void WriteElementString(RssElements element, string value)
        {
            string elementName = "";

            switch (element)
            {
                case RssElements.Channel:
                    elementName = "channel";
                    break;
                case RssElements.Copyright:
                    elementName = "copyright";
                    break;
                case RssElements.Description:
                    elementName = "description";
                    break;
                case RssElements.Generator:
                    elementName = "generator";
                    break;
                case RssElements.Item:
                    elementName = "item";
                    break;
                case RssElements.Link:
                    elementName = "link";
                    break;
                case RssElements.PubDate:
                    elementName = "pubDate";
                    break;
                case RssElements.Rss:
                    elementName = "rss";
                    break;
                case RssElements.Title:
                    elementName = "title";
                    break;
            }
            writer.WriteElementString(elementName, value);
        }

        public override void WriteEndElement()
        {
            writer.WriteEndElement();
        }

        #endregion

        #region Writing Attributes

        public void WriteStartAttribute(RssAttributes attb)
        {
            if (attb == RssAttributes.Version)
            {
                writer.WriteStartAttribute("version");
            }
        }

        public void WriteAttributeString(RssAttributes attb, string value)
        {
            if (attb == RssAttributes.Version)
            {
                writer.WriteAttributeString("version",value);
            }
        }
        
        public override void WriteEndAttribute()
        {
            writer.WriteEndAttribute();
        }

        #endregion

        #region Writing Data
        public override void WriteCData(string text)
        {
            writer.WriteCData(text);
        }

        public override void WriteChars(char[] buffer, int index, int count)
        {
            writer.WriteChars(buffer, index, count);
        }

        public override void WriteComment(string text)
        {
            writer.WriteComment(text);
        }
        public override void WriteWhitespace(string ws)
        {
            writer.WriteWhitespace(ws);
        }

        public override void WriteString(string text)
        {
            writer.WriteString(text);
        }


        #endregion

        #region Document

        public override void WriteStartDocument()
        {
            writer.WriteStartDocument();
        }
        public override void WriteStartDocument(bool standalone)
        {
            writer.WriteStartDocument(standalone);
        }
        public override void WriteEndDocument()
        {
            writer.WriteEndDocument();
        }

        #endregion

        #region Not Implemented Methods
        public override string LookupPrefix(string ns)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public override void WriteBase64(byte[] buffer, int index, int count)
        {
            throw new Exception("The method or operation is not implemented.");
        }
        public override void WriteCharEntity(char ch)
        {
            throw new Exception("The method or operation is not implemented.");
        }
        public override void WriteStartElement(string prefix, string localName, string ns)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public override WriteState WriteState
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        public override void WriteSurrogateCharEntity(char lowChar, char highChar)
        {
            throw new Exception("The method or operation is not implemented.");
        }
        public override void WriteEntityRef(string name)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public override void WriteFullEndElement()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public override void WriteProcessingInstruction(string name, string text)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public override void WriteRaw(string data)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public override void WriteRaw(char[] buffer, int index, int count)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public override void WriteStartAttribute(string prefix, string localName, string ns)
        {
            throw new Exception("The method or operation is not implemented.");
        }
        public override void WriteDocType(string name, string pubid, string sysid, string subset)
        {
            throw new Exception("The method or operation is not implemented.");
        }


        #endregion
    }


    public enum RssElements
    {
        Rss,Channel,Title,Description,Link,Copyright,Generator,Item,PubDate
    }


    public enum RssAttributes
    {
        Version
    }

}
