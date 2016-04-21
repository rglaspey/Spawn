<?xml version="1.0" encoding="utf-16"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl">

  <xsl:output method="text" encoding="utf-8" indent="no"/>

  <xsl:include href="Shared/Usings.xslt"/>
  <xsl:include href="Shared/NamespaceStart.xslt"/>
  <xsl:include href="Shared/NamespaceEnd.xslt"/>
  <xsl:include href="Shared/FullComments.xslt"/>

  <xsl:template match="/">

    <xsl:call-template name="Usings" />

    <xsl:call-template name="NamespaceStart" />

    <xsl:call-template name="Delegate" />

    <xsl:call-template name="NamespaceEnd" />

  </xsl:template>

  <xsl:template name="Delegate">

    <xsl:for-each select="output/TypeDefinitions/TypeDefinitionsItem">

      <xsl:call-template name="FullComments" />

      <xsl:text>  public delegate </xsl:text>
      <xsl:value-of select="TranslatedType"/>
      <xsl:text> </xsl:text>
      <xsl:value-of select="TranslatedName"/>
      <xsl:text> (</xsl:text>
      
      <xsl:variable name="memberCount" select="count(Parameters/ParametersItem)" />

      <xsl:for-each select="Parameters/ParametersItem">
        <xsl:if test="Comment != ''">
          <xsl:text>    /// &lt;summary&gt; </xsl:text>
          <xsl:text>&#10;</xsl:text>
          <xsl:text>    /// </xsl:text>
          <xsl:value-of select="Comment"/>
          <xsl:text>&#10;</xsl:text>
          <xsl:text>    /// &lt;/summary&gt; </xsl:text>
          <xsl:text>&#10;</xsl:text>
        </xsl:if>
        <xsl:text>    </xsl:text>
        <xsl:text>public</xsl:text>
        <xsl:text> </xsl:text>
        <xsl:value-of select="TranslatedType"/>
        <xsl:text> </xsl:text>
        <xsl:value-of select="TranslatedName"/>
        <xsl:text> = </xsl:text>
        <xsl:value-of select="Value"/>
        <xsl:text>;</xsl:text>

      </xsl:for-each>

      <xsl:text>);</xsl:text>

    </xsl:for-each>

  </xsl:template>
</xsl:stylesheet>

