<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl">

  <xsl:output method="text" encoding="utf-8" indent="no"/>

  <xsl:template match="SpawnEnum">
    
    <xsl:call-template name="HasFlags" />
    
    <xsl:text>&#10;</xsl:text>
    <xsl:text>namespace </xsl:text>
    <xsl:value-of select="Namespace"/>
    <xsl:text>&#10;</xsl:text>
    <xsl:text>{</xsl:text>
    <xsl:text>&#10;</xsl:text>
 
    <xsl:call-template name="Comments" />
    <xsl:call-template name="Enum" />
    
    <xsl:text>&#10;</xsl:text>
    <xsl:text>}</xsl:text>

  </xsl:template>

  <xsl:template name="HasFlags">
  
    <xsl:if test="HasFlags = 'true'">
      <xsl:text>using System;</xsl:text>
      <xsl:text>&#10;</xsl:text>
    </xsl:if>

  </xsl:template>
  
  <xsl:template name="Comments">
  
    <xsl:variable name="commentCount" select="count(Comments/Comment)" />
    
    <xsl:if test="$commentCount > 0">
    <xsl:text>  /// &lt;summary&gt;</xsl:text>
    <xsl:text>&#10;</xsl:text>
    <xsl:for-each select="Comments/Comment">
      <xsl:text>  /// </xsl:text>
      <xsl:value-of select="current()"/>
      <xsl:text>&#10;</xsl:text>
    </xsl:for-each>
    <xsl:text>  /// &lt;&#x2f;summary&gt;</xsl:text>
  </xsl:if>
  
  </xsl:template>
  
  <xsl:template name="Enum">
  
    <xsl:if test="HasFlags = 'true'">
      <xsl:text>&#10;</xsl:text>
      <xsl:text>  [Flags]</xsl:text>
    </xsl:if>
    <xsl:text>&#10;</xsl:text>
    <xsl:text>  public enum </xsl:text>
    <xsl:value-of select="Name"/><xsl:if test="EnumType != ''"> : <xsl:value-of select="EnumType"/></xsl:if>
    <xsl:text>&#10;</xsl:text>
    <xsl:text>  {</xsl:text>
    <xsl:text>&#10;</xsl:text>
    <xsl:call-template name="EnumValues" />
    <xsl:text>  }</xsl:text>
  
  </xsl:template>
  
  <xsl:template name="EnumValues">
    
    <xsl:for-each select="Members/Member">
      <xsl:if test="Comment != ''">
        <xsl:text>    // </xsl:text>
        <xsl:value-of select="Comment"/>
        <xsl:text>&#10;</xsl:text>
      </xsl:if>
      <xsl:text>    </xsl:text>
      <xsl:value-of select="Name"/>
      <xsl:text> = </xsl:text>
      <xsl:value-of select="Value"/>
      <xsl:text>;</xsl:text>
      <xsl:text>&#10;</xsl:text>
    </xsl:for-each>
  
  </xsl:template>

</xsl:stylesheet>
