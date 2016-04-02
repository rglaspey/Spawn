<?xml version="1.0" encoding="utf-16"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
  xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl">

  <xsl:output method="text" encoding="utf-8" indent="no"/>

  <xsl:template name="NamespaceStart">

    <xsl:text>namespace </xsl:text>
    <xsl:value-of select="output/Namespace/Name"/>
    <xsl:text>&#10;</xsl:text>
    <xsl:text>{</xsl:text>

    <xsl:text>&#10;</xsl:text>

  </xsl:template>

</xsl:stylesheet>
