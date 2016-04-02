<?xml version="1.0" encoding="utf-16"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
  xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl">

  <xsl:output method="text" encoding="utf-8" indent="no"/>

  <xsl:template name="FullComments">

    <xsl:variable name="commentCount" select="count(../../CommentLines/CommentLinesItem)" />

    <xsl:if test="$commentCount > 0">
      <xsl:text>  /// &lt;summary&gt;</xsl:text>
      <xsl:text>&#10;</xsl:text>
      <xsl:for-each select="../../CommentLines/CommentLinesItem">
        <xsl:text>  /// </xsl:text>
        <xsl:value-of select="current()"/>
        <xsl:text>&#10;</xsl:text>
      </xsl:for-each>
      <xsl:text>  /// &lt;&#x2f;summary&gt;</xsl:text>
      <xsl:text>&#10;</xsl:text>
    </xsl:if>

  </xsl:template>

</xsl:stylesheet>
