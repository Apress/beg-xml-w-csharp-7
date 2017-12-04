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
            <th>Home Phone</th>
            <th>Notes</th>
            <th>Qualification</th>
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
                <xsl:value-of select="notes"/>
              </td>
              <td>
              <xsl:choose>
                <xsl:when test="notes[contains(.,'BA')]">
                  BA (Arts)
                </xsl:when>
                <xsl:when test="notes[contains(.,'BS')]">
                  BS (Science)
                </xsl:when>
                <xsl:when test="notes[contains(.,'BTS')]">
                  BTS (Other)
                </xsl:when>
                <xsl:otherwise>
                  Unknown
                </xsl:otherwise>
              </xsl:choose>
              </td>
            </tr>
          </xsl:for-each>
        </table>
      </body>
    </html>
  </xsl:template>
</xsl:stylesheet>