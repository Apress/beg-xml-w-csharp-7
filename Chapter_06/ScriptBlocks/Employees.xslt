<?xml version="1.0" encoding="UTF-8" ?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:msxsl="urn:schemas-microsoft-com:xslt" xmlns:myscripts="urn:myscripts">

<msxsl:script language="C#" implements-prefix="myscripts">
  <msxsl:assembly name="System.Data" />
  <msxsl:using namespace="System.Data" />
  <msxsl:using namespace="System.Data.SqlClient" />
  <![CDATA[
  public string GetBirthDate(int employeeid)
  {
    SqlConnection cnn=new SqlConnection(@"data source=.;initial catalog=northwind;integrated security=true");
    SqlCommand cmd=new SqlCommand();
    cmd.Connection=cnn;
    cmd.CommandText="select birthdate from employees where employeeid=@id";
    SqlParameter pDOB=new SqlParameter("@id",employeeid);
    cmd.Parameters.Add(pDOB);
    cnn.Open();
    object obj=cmd.ExecuteScalar();
    cnn.Close();
    DateTime dob=DateTime.Parse(obj.ToString());
    return dob.ToString("MM/dd/yyyy");
  }
  ]]>
</msxsl:script>

<xsl:template match="/">
    <html>
      <body>
        <h1>Employee Listing</h1>
        <table border="1">
          <tr>
            <th>Employee ID</th>
            <th>First Name</th>
            <th>Last Name</th>
            <th>Home Phone</th>
            <th>Birth Date</th>
            <th>Notes</th>
          </tr>
          <xsl:for-each select="employees/employee">
            <tr>
              <td>
                <xsl:value-of select="@employeeid"/>
              </td>
              <td>
                <xsl:value-of select="firstname"/>
              </td>
              <td>
                <xsl:value-of select="lastname"/>
              </td>
              <td>
                <xsl:value-of select="homephone"/>
              </td>
              <td>
                <xsl:value-of select="myscripts:GetBirthDate(@employeeid)"/>
              </td>
              <td>
                <xsl:value-of select="notes"/>
              </td>
            </tr>
          </xsl:for-each>
        </table>
      </body>
    </html>
  </xsl:template>
</xsl:stylesheet>