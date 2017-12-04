<?xml version="1.0" encoding="UTF-8" ?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
  <xsl:template match="/">
    <html>
      <body>
        <h1>Employee Listing</h1>
        <xsl:apply-templates/>
      </body>
    </html>
  </xsl:template>

  <xsl:template match="employee">
    <div>
      <h3>Employee ID :
      <xsl:value-of select="@employeeid"/>
      </h3>
      <xsl:apply-templates select="firstname"/>
      <xsl:apply-templates select="lastname"/>
      <xsl:apply-templates select="homephone"/>
      <xsl:apply-templates select="notes"/>
    </div>
  </xsl:template>

  <xsl:template match="firstname">
    <b>First Name :</b><xsl:value-of select="."/>
    <br />
  </xsl:template>

  <xsl:template match="lastname">
    <b>Last Name :</b>
    <xsl:value-of select="."/>
    <br />
  </xsl:template>

  <xsl:template match="homephone">
    <b>Home Phone :</b>
    <xsl:value-of select="."/>
    <br />
  </xsl:template>

  <xsl:template match="notes">
    <b>Remarks :</b>
    <xsl:value-of select="."/>
    <br />
  </xsl:template>

</xsl:stylesheet>