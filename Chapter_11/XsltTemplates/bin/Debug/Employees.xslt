<?xml version="1.0" encoding="UTF-8" ?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
  <xsl:template match="/">
    <html>
      <body>
        <h1>Employee Listing</h1>
        <table border="1">
          <tr>
            <th>Employee ID</th>
            <th>First Name</th>
            <th>Last Name</th>
          </tr>
          <xsl:for-each select="root/employees">
            <tr>
              <td>
                <xsl:value-of select="@EmployeeID"/>
              </td>
              <td>
                <xsl:value-of select="@FirstName"/>
              </td>
              <td>
                <xsl:value-of select="@LastName"/>
              </td>
            </tr>
          </xsl:for-each>
        </table>
      </body>
    </html>
  </xsl:template>
</xsl:stylesheet>