<?xml version="1.0" encoding="utf-16"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
  xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl">

  <xsl:output method="text" encoding="utf-8" indent="no"/>

  <xsl:include href="Attributes.xslt"/>

  <xsl:template name="Methods">

    <xsl:variable name="smallcase" select="'abcdefghijklmnopqrstuvwxyz'" />
    <xsl:variable name="uppercase" select="'ABCDEFGHIJKLMNOPQRSTUVWXYZ'" />

    <xsl:variable name="memberCount" select="count(Fields/FieldsItem)" />

    <xsl:for-each select="Methods/MethodsItem">
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

      <xsl:call-template name="Attributes" />

      <xsl:for-each select="Modifiers/ModifiersItem">
        <xsl:value-of select="translate(Modifier, $uppercase, $smallcase)"/>
        <xsl:text> </xsl:text>
      </xsl:for-each>

      <xsl:value-of select="TranslatedType"/>
      <xsl:text> </xsl:text>
      <xsl:value-of select="TranslatedName"/>

      <xsl:if test="TranslatedValue != ''">
        <xsl:text> = </xsl:text>
        <xsl:value-of select="TranslatedValue"/>
      </xsl:if>
      <xsl:text>;</xsl:text>

      <xsl:choose>
        <xsl:when test="position() != $memberCount">
          <xsl:text>&#10;</xsl:text>
          <xsl:text>&#10;</xsl:text>
        </xsl:when>
        <xsl:otherwise>
          <xsl:text>&#10;</xsl:text>
        </xsl:otherwise>
      </xsl:choose>

    </xsl:for-each>
  </xsl:template>

</xsl:stylesheet>
