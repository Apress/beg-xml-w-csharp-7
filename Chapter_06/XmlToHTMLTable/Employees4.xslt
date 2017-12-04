<?xml version="1.0" encoding="UTF-8" ?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
  <xsl:template match="/">
    <EMPLOYEES>
      <xsl:apply-templates/>
    </EMPLOYEES>
  </xsl:template>

  <xsl:template match="employee">
    <xsl:element name="E{@employeeid}">
      <xsl:attribute name="EMPCODE">
        <xsl:value-of select="@employeeid"/>
      </xsl:attribute>
      <xsl:apply-templates select="firstname"/>
      <xsl:apply-templates select="lastname"/>
      <xsl:apply-templates select="homephone"/>
      <xsl:apply-templates select="notes"/>
    </xsl:element>
  </xsl:template>

  <xsl:template match="firstname">
    <FNAME>
      <xsl:value-of select="."/>
    </FNAME>
  </xsl:template>

  <xsl:template match="lastname">
    <LNAME>
      <xsl:value-of select="."/>
    </LNAME>
  </xsl:template>

  <xsl:template match="homephone">
    <PHONE>
      <xsl:value-of select="."/>
    </PHONE>
  </xsl:template>

  <xsl:template match="notes">
    <REMARKS>
      <xsl:value-of select="."/>
    </REMARKS>
  </xsl:template>

</xsl:stylesheet>