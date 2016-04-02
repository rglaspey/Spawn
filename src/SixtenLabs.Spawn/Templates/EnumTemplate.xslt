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

    <xsl:call-template name="Enum" />

    <xsl:call-template name="NamespaceEnd" />

  </xsl:template>

  <xsl:template name="Enum">

    <xsl:for-each select="output/TypeDefinitions/TypeDefinitionsItem">

      <xsl:call-template name="FullComments" />
      
      <xsl:if test="HasFlags = 'true'">
        <xsl:text>  [Flags]</xsl:text>
        <xsl:text>&#10;</xsl:text>
      </xsl:if>
      <xsl:text>  public enum </xsl:text>
      <xsl:value-of select="Name"/>
      <xsl:if test="EnumType != ''">
        <xsl:text> : </xsl:text>
        <xsl:value-of select="EnumType"/>
      </xsl:if>
      <xsl:text>&#10;</xsl:text>
      <xsl:text>  {</xsl:text>
      <xsl:text>&#10;</xsl:text>

      <xsl:variable name="memberCount" select="count(Members/MembersItem)" />
      
      <xsl:for-each select="Members/MembersItem">
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
        <xsl:value-of select="Name"/>
        <xsl:text> = </xsl:text>
        <xsl:value-of select="Value"/>

        <xsl:choose>
          <xsl:when test="position() != $memberCount">
            <xsl:text>,</xsl:text>
            <xsl:text>&#10;</xsl:text>
            <xsl:text>&#10;</xsl:text>
          </xsl:when>
          <xsl:otherwise>
            <xsl:text>&#10;</xsl:text>
          </xsl:otherwise>
        </xsl:choose>
        
      </xsl:for-each>

      <xsl:text>  }</xsl:text>

    </xsl:for-each>

  </xsl:template>
</xsl:stylesheet>
