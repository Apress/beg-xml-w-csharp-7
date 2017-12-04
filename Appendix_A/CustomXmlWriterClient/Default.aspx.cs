using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using RSS;

public partial class _Default : System.Web.UI.Page 
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.ContentEncoding = System.Text.Encoding.UTF8;
        Response.ContentType = "text/xml";
        RssWriter writer = new RssWriter(Response.OutputStream);
        writer.WriteStartElement(RssElements.Rss);
        writer.WriteAttributeString(RssAttributes.Version, "2.0");
        writer.WriteStartElement(RssElements.Channel);
        writer.WriteElementString(RssElements.Title, "My Web Site");
        writer.WriteElementString(RssElements.Link, "http://localhost/mywebsite");
        writer.WriteElementString(RssElements.Description, "Latest Articles from My Web Site");
        writer.WriteElementString(RssElements.Copyright, "Copyright (C) My Web Site. All rights reserved.");
        writer.WriteElementString(RssElements.Generator, "My XML RSS Generator");
        writer.WriteStartElement(RssElements.Item);
        writer.WriteElementString(RssElements.Title, "Create and consume RSS Feeds");
        writer.WriteElementString(RssElements.Link, "http://localhost/mywebsite/Articles/displayarticle.aspx?id=242");
        writer.WriteElementString(RssElements.Description, "This article explains how to create and consume RSS feeds.");
        writer.WriteElementString(RssElements.PubDate, "Mon, 04 Sep 2017 12:00:00 AM GMT");
        writer.WriteEndElement();
        writer.WriteEndElement();
        writer.WriteEndElement();
        writer.Close();
        Response.End();
    }
}
