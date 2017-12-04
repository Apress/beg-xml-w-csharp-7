<?xml version="1.0" encoding="UTF-8" ?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
  <xsl:template match="/">
    <xsl:for-each select=".">
      <xsl:apply-templates/>
    </xsl:for-each>      
  </xsl:template>

  <xsl:template match="node">
    <xsl:element name="MenuItem">
      <xsl:attribute name="Title">
        <xsl:value-of select="@text"/>
      </xsl:attribute>
      <xsl:attribute name="URL">
        <xsl:value-of select="@url"/>
      </xsl:attribute>
      <xsl:apply-templates />
    </xsl:element>
  </xsl:template>

</xsl:stylesheet>