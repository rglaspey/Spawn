<?xml version="1.0" encoding="utf-16"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
  xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl">

  <xsl:output method="text" encoding="utf-8" indent="no"/>

  <xsl:template name="Usings">

    <xsl:for-each select="output/Usings/UsingsItem">

      <xsl:choose>
        <xsl:when test="IsStatic = 'true'">
          <xsl:text>using static</xsl:text>
          <xsl:value-of select="Name"/>
          <xsl:text>;</xsl:text>
        </xsl:when>
        <xsl:when test="UseAlias = 'true'">
          <xsl:text>using </xsl:text>
          <xsl:value-of select="Alias"/>
          <xsl:text> = </xsl:text>
          <xsl:value-of select="TranslatedName"/>
          <xsl:text>;</xsl:text>
        </xsl:when>
        <xsl:otherwise>
          <xsl:text>using </xsl:text>
          <xsl:value-of select="TranslatedName"/>
          <xsl:text>;</xsl:text>
        </xsl:otherwise>
      </xsl:choose>
      
      <xsl:text>&#10;</xsl:text>
      <xsl:text>&#10;</xsl:text>

    </xsl:for-each>

  </xsl:template>

</xsl:stylesheet>
